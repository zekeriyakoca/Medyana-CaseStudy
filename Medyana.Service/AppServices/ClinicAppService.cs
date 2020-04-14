using Dtos.Common;
using Dtos.Enums;
using Medyana.Domain.Entities;
using Medyana.Domain.Interface;
using Medyana.Dtos.Clinic;
using Medyana.Service.Interfaces;
using Medyana.Service.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medyana.Service.AppServices
{
  public class ClinicAppService : IClinicAppService
  {
    public ClinicAppService(IClinicRepository clinicRepository)
    {
      this.clinicRepository = clinicRepository;
    }

    public IClinicRepository clinicRepository { get; }

    public async Task<bool> DeleteClinic(int clinicId)
    {
      var clinicToDelete = await clinicRepository.Get(clinicId);
      if (clinicToDelete == null)
        return false;
      clinicRepository.Remove(clinicToDelete);
      var result = await clinicRepository.SaveChangesAsync();
      if (result < 1)
        return false;
      return true;
    }

    public async Task<Paginatedlist<ClinicItemDto>> GetAllClinics(PaginationRequestDto dto)
    {
      var result = new Paginatedlist<ClinicItemDto>();

      var query = await clinicRepository.GetAll();
      var totalItem = query.Count();
      var property = typeof(Clinic).GetProperties().Where(p => p.CanWrite && p.Name.ToLower() == dto.Column?.ToLower()).SingleOrDefault();

      switch (dto.Type)
      {
        case PaginationType.Sorting:
          query = dto.IsAscending ? query.OrderBy(c => property.GetValue(c)) : query.OrderByDescending(c => property.GetValue(c));
          break;
        case PaginationType.Searching:
          query = query.Where(c => c.Name != null && c.Name.ToLower().Contains(dto.SearchText?.ToLower()));
          break;
        default:
          break;
      }
      query = query.Skip(dto.Page * dto.PageItemCount).Take(dto.PageItemCount);

      var clinics = query?.ToClinicItemDtoList();

      return new Paginatedlist<ClinicItemDto>(clinics, dto.Page, totalItem, dto.PageItemCount);
    }

    public async Task<ClinicDetailDto> GetClinic(int clinicId)
    {
      var clinic = await clinicRepository.Get(clinicId);
      return clinic?.ToClinicDetailDto();
    }

    public async Task<ClinicDetailDto> InsertClinic(ClinicInsertDto clinicToInsert)
    {
      var clinic = clinicToInsert.ToClinic();
      clinicRepository.Add(clinic);

      await clinicRepository.SaveChangesAsync();

      return clinic.ToClinicDetailDto();

    }

    public async Task<ClinicDetailDto> UpdateClinic(ClinicUpdateDto dto)
    {
      var clinic = await clinicRepository.Get(dto.Id);
      if (clinic == null)
        throw new Exception("Unable to find clinic to update");

      clinic.Parse(dto);
      await clinicRepository.SaveChangesAsync();

      return clinic.ToClinicDetailDto();
    }
  }
}
