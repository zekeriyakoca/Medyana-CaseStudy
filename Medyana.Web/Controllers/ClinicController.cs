using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dtos.Common;
using Medyana.Dtos.Clinic;
using Medyana.Service.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Medyana.Web.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ClinicController : BaseController
  {
    public readonly ILogger<ClinicController> logger;
    public ClinicController(IClinicAppService clinicAppService, ILogger<ClinicController> logger) : base(logger)
    {
      ClinicAppService = clinicAppService;
      this.logger = logger;
    }

    public IClinicAppService ClinicAppService { get; }

    [HttpPost("")]
    public async Task<IActionResult> GetClinics([FromBody] PaginationRequestDto dto)
    {
      return await ActionHandle(async () =>
      {
        var clinics = await ClinicAppService.GetAllClinics(dto);
        return Ok(clinics);
      });
      
    }

    [HttpGet("{clinicId}")]
    public async Task<IActionResult> GetClinic(int clinicId)
    {
      return await ActionHandle(async () =>
      {
        var clinic = await ClinicAppService.GetClinic(clinicId);
        return Ok(clinic);
      });

    }

    [HttpPut("")]
    public async Task<IActionResult> AddClinic([FromBody]ClinicInsertDto clinic)
    {
      return await ActionHandle(async () =>
      {
        var createdClinic = await ClinicAppService.InsertClinic(clinic);
        if (createdClinic == null)
          return BadRequest("Unable to insert clinic.");
        return Created($"api/clinic/{createdClinic.Id}",createdClinic);
      });
    }
    [HttpPatch("")]
    public async Task<IActionResult> UpdateClinic([FromBody]ClinicUpdateDto clinic)
    {
      return await ActionHandle(async () =>
      {
        var createdClinic = await ClinicAppService.UpdateClinic(clinic);
        if (createdClinic == null)
          return BadRequest("Unable to update clinic.");
        return Ok(createdClinic);
      });
    }
    [HttpDelete("{clinicId}")]
    public async Task<IActionResult> DeleteClinic(int clinicId)
    {
      return await ActionHandle(async () =>
      {
        var createdClinic = await ClinicAppService.DeleteClinic(clinicId);
        if (!createdClinic)
          return BadRequest("Unable to delete clinic.");
        return Ok(createdClinic);
      });
    }
  }
}