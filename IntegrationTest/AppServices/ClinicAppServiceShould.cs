using Dtos.Common;
using Medyana.Domain.Entities;
using Medyana.Domain.Interface;
using Medyana.Dtos.Clinic;
using Medyana.Service.AppServices;
using Medyana.Service.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Medyana.Test.AppServices
{
  public class ClinicAppServiceShould
  {
    public ClinicAppServiceShould()
    {

    }

    [Fact]
    public async Task DeleteClinic_ReturnsNull_AbsentId()
    {
      //Arrange
      var clinicId = 10;
      var clinicRepository = new Mock<IClinicRepository>();
      clinicRepository.Setup(c => c.Get(clinicId)).ReturnsAsync((Clinic)null);
      var clinicAppService = new Mock<ClinicAppService>(clinicRepository.Object).Object;

      //Act
      var isClinicDeleted = await clinicAppService.DeleteClinic(clinicId);

      //Assert
      Assert.False(isClinicDeleted);
      clinicRepository.Verify(c => c.Remove(It.IsAny<Clinic>()), Times.Never);
    }

    [Fact]
    public async Task DeleteClinic_IsSuccess_ExistId()
    {
      //Arrange
      var clinicId = 1;
      var clinicRepository = new Mock<IClinicRepository>();
      clinicRepository.Setup(c => c.Get(clinicId)).ReturnsAsync((Clinic)new Clinic { Id = clinicId });
      clinicRepository.Setup(c => c.SaveChangesAsync()).ReturnsAsync(1).Verifiable();
      var clinicAppService = new Mock<ClinicAppService>(clinicRepository.Object).Object;

      //Act
      var isClinicDeleted = await clinicAppService.DeleteClinic(clinicId);

      //Assert
      Assert.True(isClinicDeleted);
      clinicRepository.Verify();
    }

    [Theory]
    [MemberData(nameof(GetPaginationRequestDto_ForPaging))]
    public async Task GetAllClinics_IsSuccess_WhenPaging(PaginationRequestDto pagingRequest, int firstItemIndex_Should)
    {

      //Arrange
      var clinicRepository = new Mock<IClinicRepository>();
      clinicRepository.Setup(c => c.GetAll()).ReturnsAsync(ClinicList);
      var clinicAppService = new Mock<ClinicAppService>(clinicRepository.Object).Object;

      //Act
      var paginatedlist = await clinicAppService.GetAllClinics(pagingRequest);

      //Assert
      Assert.IsType<Paginatedlist<ClinicItemDto>>(paginatedlist);
      Assert.Equal(paginatedlist.Items.Count, pagingRequest.PageItemCount);
      Assert.Equal(paginatedlist.Page, pagingRequest.Page);
      Assert.Equal(paginatedlist.Items[0].Id, ClinicList.ToList().ElementAt(firstItemIndex_Should).Id);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task GetAllClinics_IsSuccess_WhenSorting(bool IsAscending)
    {

      //Arrange
      PaginationRequestDto pagingRequest = new PaginationRequestDto { Column = "Name", IsAscending = IsAscending };
      var clinicRepository = new Mock<IClinicRepository>();
      clinicRepository.Setup(c => c.GetAll()).ReturnsAsync(ClinicList);
      var clinicAppService = new Mock<ClinicAppService>(clinicRepository.Object).Object;

      //Act
      var paginatedlist = await clinicAppService.GetAllClinics(pagingRequest);

      //Assert
      if (IsAscending)
        Assert.Equal(paginatedlist.Items.ToList().First().Name, paginatedlist.Items.OrderBy(s => s.Name).First().Name);
      else
        Assert.Equal(paginatedlist.Items.ToList().First().Name, paginatedlist.Items.OrderByDescending(s => s.Name).First().Name);

      Assert.IsType<Paginatedlist<ClinicItemDto>>(paginatedlist);
    }

    [Fact]
    public async Task GetAllClinics_IsSuccess_WhenSearching()
    {
      //Arrange
      PaginationRequestDto pagingRequest = new PaginationRequestDto { Column = "Name", SearchText = "Clinic2" };
      var clinicRepository = new Mock<IClinicRepository>();
      clinicRepository.Setup(c => c.GetAll()).ReturnsAsync(ClinicList);
      var clinicAppService = new Mock<ClinicAppService>(clinicRepository.Object).Object;

      var result_Should = ClinicList.Where(s => s.Name.Contains(pagingRequest.SearchText)).ToList();

      //Act
      var paginatedlist = await clinicAppService.GetAllClinics(pagingRequest);

      //Assert
      Assert.Equal(result_Should.Count, paginatedlist.Items.Count);
      Assert.True(paginatedlist.Items.Where(s=> !s.Name.Contains(pagingRequest.SearchText)).Count() == 0);
      Assert.IsType<Paginatedlist<ClinicItemDto>>(paginatedlist);
    }


    #region Private Methods

    public static IEnumerable<object[]> GetPaginationRequestDto_ForPaging
    {
      get
      {
        yield return new object[] { new PaginationRequestDto { Page = 1, PageItemCount = 2 }, 2 };
      }
    }

    /// <summary>
    /// Should be disordered List
    /// </summary>
    public static IEnumerable<Clinic> ClinicList
    {
      get
      {
        yield return new Clinic { Id = 1, Name = "Clinic2" };
        yield return new Clinic { Id = 2, Name = "Clinic1" };
        yield return new Clinic { Id = 3, Name = "Clinic3" };
        yield return new Clinic { Id = 4, Name = "Clinic5" };
        yield return new Clinic { Id = 5, Name = "Clinic4" };
      }
    }
    #endregion
  }
}
