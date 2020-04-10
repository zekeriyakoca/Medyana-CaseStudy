using Medyana.Domain.Interface;
using Medyana.Dtos.Clinic;
using Medyana.Service.Interfaces;
using Medyana.Service.Mappers;
using System;
using System.Collections.Generic;
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
      return true;
    }

    public async Task<List<ClinicItemDto>> GetAllClinics()
    {
      var clinics = await clinicRepository.GetAll();
      return clinics?.ToClinicItemDtoList();
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
