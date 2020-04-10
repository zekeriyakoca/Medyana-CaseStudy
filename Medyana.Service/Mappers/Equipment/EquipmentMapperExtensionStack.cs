using Medyana.Domain.Entities;
using Medyana.Dtos.Clinic;
using Medyana.Dtos.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using Utils.Infrastructure;

namespace Medyana.Service.Mappers
{
  public static class EquipmentMapperExtensionStack
  {
    public static Equipment ToEquipment(this EquipmentInsertDto dto)
    {
      return new Equipment() { 
        Name = dto.Name,
        ClinicId = dto.ClinicId,
        Price = dto.Price,
        Quantity = dto.Quantity,
        SupplyDate = DateTime.UtcNow,
        UsageRate = dto.UsageRate
      };
    }

    public static Equipment ToEquipment(this EquipmentUpdateDto dto)
    {
      return new Equipment()
      {
        Id = dto.Id,
        Name = dto.Name,
        ClinicId = dto.ClinicId,
        Price = dto.Price,
        Quantity = dto.Quantity,
        SupplyDate = dto.SupplyDate,
        UsageRate = dto.UsageRate
      };
    }

    public static EquipmentItemDto ToEquipmentItemDto(this Equipment model)
    {
      return new EquipmentItemDto()
      {
        Id = model.Id,
        Name = model.Name,
        ClinicId = model.ClinicId,
        Price = model.Price,
        Quantity = model.Quantity,
        SupplyDate = model.SupplyDate,
        UsageRate = model.UsageRate
      };
    }

    public static List<EquipmentItemDto> ToEquipmentItemDtoList(this IEnumerable<Equipment> modelList)
    {
      return modelList.Select(m => m.ToEquipmentItemDto()).ToList();
    }


    public static EquipmentDetailDto ToEquipmentDetailDto(this Equipment model)
    {
      return new EquipmentDetailDto()
      {
        Id = model.Id,
        Name = model.Name,
        ClinicId = model.ClinicId,
        Price = model.Price,
        Quantity = model.Quantity,
        SupplyDate = model.SupplyDate,
        UsageRate = model.UsageRate,
        Clinic = model.Clinic?.ToClinicItemDto()
      };
    }

    public static void Parse(this Equipment equipment, EquipmentUpdateDto dto)
    {
      if (equipment.Id != dto.Id)
        throw new BusinessException("EquipmentUpdateDto parse - Model and dto should have the same id");
      equipment.Name = dto.Name;
      equipment.ClinicId = dto.ClinicId;
      equipment.Price = dto.Price;
      equipment.Quantity = dto.Quantity;
      equipment.UsageRate = dto.UsageRate;

    }
  }
}
