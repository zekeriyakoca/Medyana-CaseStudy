using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dtos.Common;
using Dtos.Equipment;
using Medyana.Dtos.Clinic;
using Medyana.Dtos.Equipment;
using Medyana.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Utils.Infrastructure;

namespace Medyana.Web.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EquipmentController : BaseController
  {
    public EquipmentController(IEquipmentAppService equipmentAppService, ILogger<EquipmentController> logger) : base(logger)
    {
      this.equipmentAppService = equipmentAppService;
      this.logger = logger;
    }

    public readonly ILogger<EquipmentController> logger;
    public IEquipmentAppService equipmentAppService { get; }

    #region CRUD Operations

    [HttpGet("{EquipmentId}")]
    public async Task<IActionResult> GetEquipment(int EquipmentId)
    {
      return await ActionHandle(async () =>
      {
        var Equipment = await equipmentAppService.GetEquipment(EquipmentId);
        return Ok(Equipment);
      });
    }

    [HttpPost("")]
    public async Task<IActionResult> GetEquipments([FromBody] EquipmentPaginationRequestDto dto)
    {
      return await ActionHandle(async () =>
      {
        var Equipments = await equipmentAppService.GetAllEquipments(dto);
        return Ok(Equipments);
      });
    }


    [HttpPut("")]
    public async Task<IActionResult> AddEquipment([FromBody]EquipmentInsertDto Equipment)
    {
      return await ActionHandle(async () =>
      {
        var createdEquipment = await equipmentAppService.InsertEquipment(Equipment);
        if (createdEquipment == null)
          return BadRequest("Unable to insert Equipment.");
        return Created($"api/Equipment/{createdEquipment.Id}", createdEquipment);
      });
    }
    [HttpPatch("")]
    public async Task<IActionResult> UpdateEquipment([FromBody]EquipmentUpdateDto Equipment)
    {
      return await ActionHandle(async () =>
      {
        var createdEquipment = await equipmentAppService.UpdateEquipment(Equipment);
        if (createdEquipment == null)
          return BadRequest("Unable to update Equipment.");
        return Created($"api/Equipment/{createdEquipment.Id}", createdEquipment);
      });
    }
    [HttpDelete("{equipmentId}")]
    public async Task<IActionResult> DeleteEquipment(int equipmentId)
    {
      return await ActionHandle(async () =>
      {
        var createdEquipment = await equipmentAppService.DeleteEquipment(equipmentId);
        if (!createdEquipment)
          return BadRequest("Unable to delete equipment.");
        return Ok(createdEquipment);
      });
    }

    #endregion
  }
}