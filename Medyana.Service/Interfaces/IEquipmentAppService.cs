using Medyana.Dtos.Clinic;
using Medyana.Dtos.Equipment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Medyana.Service.Interfaces
{
  public interface IEquipmentAppService
  {
    Task<List<EquipmentItemDto>> GetAllEquipmentsByClinicId(int clinicId);
    Task<EquipmentDetailDto> GetEquipment(int equipmentId);
    Task<EquipmentDetailDto> InsertEquipment(EquipmentInsertDto equipmentToInsert);
    Task<EquipmentDetailDto> UpdateEquipment(EquipmentUpdateDto equipmentToUpdate);
    Task<bool> DeleteEquipment( int equipmentId);
  }
}
