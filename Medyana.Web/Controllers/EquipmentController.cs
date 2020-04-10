using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public readonly ILogger<EquipmentController> logger;
    public EquipmentController(IEquipmentAppService equipmentAppService, ILogger<EquipmentController> logger) : base(logger)
    {
      this.equipmentAppService = equipmentAppService;
      this.logger = logger;
    }

    public IEquipmentAppService equipmentAppService { get; }

    [HttpGet("")]
    public async Task<IActionResult> GetEquipments(int clinicId)
    {
      return await ActionHandle(async () =>
      {
        throw new Exception("----------------test---------------------------------");
        var Equipments = await equipmentAppService.GetAllEquipmentsByClinicId(clinicId);
        return Ok(Equipments);
      });
    }

    [HttpGet("{EquipmentId}")]
    public async Task<IActionResult> GetEquipment(int EquipmentId)
    {
      return await ActionHandle(async () =>
      {
        var Equipment = await equipmentAppService.GetEquipment(EquipmentId);
        return Ok(Equipment);
      });
    }

    [HttpPost("insert")]
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
    [HttpPost("update")]
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
  }
}