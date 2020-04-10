using Medyana.Dtos.Clinic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Medyana.Service.Interfaces
{
  public interface IClinicAppService
  {
    Task<List<ClinicItemDto>> GetAllClinics();
    Task<ClinicDetailDto> GetClinic(int clinicId);
    Task<ClinicDetailDto> InsertClinic(ClinicInsertDto clinicToInsert);
    Task<ClinicDetailDto> UpdateClinic(ClinicUpdateDto clinicToUpdate);
    Task<bool> DeleteClinic( int clinicId);
  }
}
