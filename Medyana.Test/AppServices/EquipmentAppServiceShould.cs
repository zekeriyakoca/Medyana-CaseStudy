using Castle.Core.Configuration;
using Dtos.Common;
using Dtos.Equipment;
using Medyana.Domain.Entities;
using Medyana.Dtos.Equipment;
using Medyana.Infrastructure.Repositories;
using Medyana.Service.AppServices;
using Medyana.Test.Common;
using Medyana.Test.DataSources;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Utils.Infrastructure;
using Xunit;

namespace Medyana.Test.AppServices
{
  /// <summary>
  /// Tests Depends on Database Seed.
  /// Delete Operations should depends on instantly created data
  /// </summary>

  [Collection(nameof(DatabaseFixtureCollection))]
  public class EquipmentAppServiceShould : DataOperationBaseShould
  {
    public EquipmentAppService equipmentAppService { get; set; }
    public EquipmentRepository equipmentRepository { get; set; }
    public ClinicRepository clinicRepository { get; set; }


    public EquipmentAppServiceShould(DatabaseFixture dbFixture) : base(dbFixture)
    {
      var configuration = new Mock<IConfiguration>();
      var serviceProvider = new Mock<IServiceProvider>();

      equipmentRepository = new EquipmentRepository(base.Context);
      clinicRepository = new ClinicRepository(base.Context);
      equipmentAppService = new EquipmentAppService(equipmentRepository, clinicRepository);
    }

    [Fact]
    public async Task GetEquipmentIsSuccess()
    {
      try
      {
        var equipmentId = Context.Equipments.First()?.Id;

        var equipment = await equipmentAppService.GetEquipment(equipmentId.Value);
        Assert.NotNull(equipment);

      }
      catch
      {
        Assert.True(false);
      }
    }

    [Theory]
    [MemberData(nameof(EquipmentInternalTestData.GetPaginatedEquipmentsReqeusts),
      MemberType = typeof(EquipmentInternalTestData))]
    public async Task GetAllEquipmentsIsSuccess(EquipmentPaginationRequestDto dto, bool expectation)
    {
      try
      {
        var equipment = await equipmentAppService.GetAllEquipments(dto);

        Assert.Equal(equipment.Items.Any(), expectation);
      }
      catch
      {
        Assert.True(false);
      }
    }

    [Theory]
    [MemberData(nameof(EquipmentInternalTestData.EquipmentsToInsert),
        MemberType = typeof(EquipmentInternalTestData))]
    public async Task InsertEquipment_IsSuccess_or_IsFail(EquipmentInsertDto dto, bool expectation, bool expectHandledException)
    {
      try
      {
        var equipment = await equipmentAppService.InsertEquipment(dto);

        if (expectation)
          Assert.NotNull(equipment);
        else
          Assert.Null(equipment);
      }
      catch (Exception ex)
      {
        if(expectHandledException)
          Assert.IsType<BusinessException>(ex);
        else
          Assert.True(false);
      }
    }

    [Theory]
    [MemberData(nameof(EquipmentInternalTestData.EquipmentsToUpdate),
        MemberType = typeof(EquipmentInternalTestData))]
    public async Task UpdateEquipmentIsSuccess(EquipmentUpdateDto dto, bool expectation)
    {
      try
      {
        var equipmentId = Context.Equipments.First()?.Id;

        var equipment = await equipmentAppService.UpdateEquipment(new Dtos.Equipment.EquipmentUpdateDto { Name = dto.Name, ClinicId = dto.ClinicId, Quantity = dto.Quantity, UsageRate = dto.UsageRate, Price = dto.Price, Id = equipmentId.Value });

        if (expectation)
        {
          Assert.NotNull(equipment);
          Assert.Equal(equipment.Id, equipmentId);
        }
        else
          Assert.Null(equipment);
      }
      catch
      {
        Assert.True(false);
      }
    }

    [Fact]
    public async Task DeleteEquipmentIsSuccess()
    {
      try
      {
        var equipmentToDelete = Context.Equipments.Add(new Equipment { Name = "Equipment to be deleted" });
        Context.SaveChanges();

        var equipmentId = equipmentToDelete.Entity.Id;

        var equipment = await equipmentAppService.DeleteEquipment(equipmentId);

        Assert.True(equipment);
      }
      catch
      {
        Assert.True(false);
      }
    }

  }
}
