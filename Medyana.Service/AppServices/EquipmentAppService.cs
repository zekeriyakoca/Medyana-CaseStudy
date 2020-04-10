using Medyana.Domain.Interface;
using Medyana.Dtos.Clinic;
using Medyana.Dtos.Equipment;
using Medyana.Service.Interfaces;
using Medyana.Service.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Infrastructure;

namespace Medyana.Service.AppServices
{
  public class EquipmentAppService : IEquipmentAppService
  {
    public EquipmentAppService(IEquipmentRepository equipmentRepository, IClinicRepository clinicRepository)
    {
      this.equipmentRepository = equipmentRepository;
      this.clinicRepository = clinicRepository;
    }

    public IEquipmentRepository equipmentRepository { get; }
    public IClinicRepository clinicRepository { get; }

    public async Task<bool> DeleteEquipment(int equipmentId)
    {
      var equipmentToDelete = await equipmentRepository.Get(equipmentId);
      if (equipmentToDelete == null)
        return false;
      equipmentRepository.Remove(equipmentToDelete);
      return true;
    }

    public async Task<List<EquipmentItemDto>> GetAllEquipmentsByClinicId(int clinicId)
    {
      var equipments = equipmentRepository.GetAllLazy().Where(e=>e.ClinicId == clinicId).ToList();
      return equipments?.ToEquipmentItemDtoList();
    }

    public async Task<EquipmentDetailDto> GetEquipment(int equipmentId)
    {
      var equipment = await equipmentRepository.Get(equipmentId);
      return equipment?.ToEquipmentDetailDto();
    }

    public async Task<EquipmentDetailDto> InsertEquipment(EquipmentInsertDto equipmentToInsert)
    {
      if (!await clinicRepository.Any(equipmentToInsert.ClinicId)) {
        throw new BusinessException($"There is no clinic with id : {equipmentToInsert.ClinicId}");
      }
      var equipment = equipmentToInsert.ToEquipment();
      equipmentRepository.Add(equipment);

      await equipmentRepository.SaveChangesAsync();

      return equipment.ToEquipmentDetailDto();
    }

    public async Task<EquipmentDetailDto> UpdateEquipment(EquipmentUpdateDto dto)
    {
      if (!await clinicRepository.Any(dto.ClinicId))
      {
        throw new BusinessException($"There is no clinic with id : {dto.ClinicId}");
      }

      var equipment = await equipmentRepository.Get(dto.Id);
      if (equipment == null)
        throw new Exception("Unable to find equipment to update");

      equipment.Parse(dto);
      await equipmentRepository.SaveChangesAsync();

      return equipment.ToEquipmentDetailDto();
    }
  }
}
