using Dtos.Common;
using Dtos.Equipment;
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
    Task<Paginatedlist<EquipmentItemDto>> GetAllEquipments(EquipmentPaginationRequestDto dto);
    Task<EquipmentDetailDto> GetEquipment(int equipmentId);
    Task<EquipmentDetailDto> InsertEquipment(EquipmentInsertDto equipmentToInsert);
    Task<EquipmentDetailDto> UpdateEquipment(EquipmentUpdateDto equipmentToUpdate);
    Task<bool> DeleteEquipment( int equipmentId);
  }
}
