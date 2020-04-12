using Dtos.Common;
using Dtos.Enums;
using Dtos.Equipment;
using Medyana.Domain.Entities;
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
    public IEquipmentRepository equipmentRepository { get; }
    public IClinicRepository clinicRepository { get; }

    public EquipmentAppService(IEquipmentRepository equipmentRepository, IClinicRepository clinicRepository)
    {
      this.equipmentRepository = equipmentRepository;
      this.clinicRepository = clinicRepository;
    }

    public async Task<EquipmentDetailDto> GetEquipment(int equipmentId)
    {
      var equipment = await equipmentRepository.Get(equipmentId);
      return equipment?.ToEquipmentDetailDto();
    }

    public async Task<Paginatedlist<EquipmentItemDto>> GetAllEquipments(EquipmentPaginationRequestDto dto)
    {
      var result = new Paginatedlist<EquipmentItemDto>();

      var query = await equipmentRepository.GetAllIncludeAll();

      if (dto.ClinicId > 0)
        query = query.Where(c => c.ClinicId == dto.ClinicId);

      var totalItem = query.Count();

      query = SortAndFilterEquipments(dto, query);

      query = query.Skip(dto.Page * dto.PageItemCount)
                   .Take(dto.PageItemCount);

      var equipments = query?.ToEquipmentItemDtoList();

      return new Paginatedlist<EquipmentItemDto>(equipments, dto.Page, totalItem, dto.PageItemCount);
    }

    public async Task<EquipmentDetailDto> InsertEquipment(EquipmentInsertDto equipmentToInsert)
    {
      if (!await clinicRepository.Any(equipmentToInsert.ClinicId))
      {
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

    public async Task<bool> DeleteEquipment(int equipmentId)
    {
      var equipmentToDelete = await equipmentRepository.Get(equipmentId);
      if (equipmentToDelete == null)
        return false;
      equipmentRepository.Remove(equipmentToDelete);
      await equipmentRepository.SaveChangesAsync();
      return true;
    }

    #region Private Methods 

    private static IEnumerable<Equipment> SortAndFilterEquipments(EquipmentPaginationRequestDto dto, IEnumerable<Equipment> query)
    {
      var property = typeof(Equipment).GetProperties()
                        .Where(p => p.CanWrite && p.Name.ToLower() == dto.Column?.ToLower())
                        .SingleOrDefault();

      switch (dto.Type)
      {
        case PaginationType.Sorting:
          query = dto.IsAscending
                      ? query.OrderBy(c => property.GetValue(c))
                      : query.OrderByDescending(c => property.GetValue(c));
          break;
        case PaginationType.Searching:
          query = query.Where(c => c.Name.ToLower().Contains(dto.SearchText.ToLower()));
          break;
        default:
          break;
      }

      return query;
    }

    #endregion
  }
}
