using Medyana.Domain.Entities;
using Medyana.Dtos.Clinic;
using System.Collections.Generic;
using System.Linq;
using Utils.Infrastructure;

namespace Medyana.Service.Mappers
{
  public static class ClinicMapperExtensionStack
  {
    public static Clinic ToClinic(this ClinicInsertDto dto)
    {
      return new Clinic()
      {
        Name = dto.Name
      };
    }

    public static Clinic ToClinic(this ClinicUpdateDto dto, Clinic clinic)
    {
      return new Clinic()
      {
        Id = dto.Id,
        Name = dto.Name
      };
    }

    public static ClinicItemDto ToClinicItemDto(this Clinic model)
    {
      return new ClinicItemDto()
      {
        Id = model.Id,
        Name = model.Name
      };
    }
    public static List<ClinicItemDto> ToClinicItemDtoList(this IEnumerable<Clinic> modelList)
    {
      return modelList.Select(m => m.ToClinicItemDto()).ToList();
    }

    public static ClinicDetailDto ToClinicDetailDto(this Clinic model)
    {
      return new ClinicDetailDto()
      {
        Id = model.Id,
        Name = model.Name,
        Equipments = model.Equipments?.ToEquipmentItemDtoList()
      };
    }

    public static void Parse(this Clinic clinic, ClinicUpdateDto dto)
    {
      if (clinic.Id != dto.Id)
        throw new BusinessException("ClinicUpdateDto parse - Model and dto should have the same id");
      clinic.Name = dto.Name;
    }
  }
}
