using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Utils.Infrastructure;

namespace Medyana.Web.Controllers
{
  public class BaseController : ControllerBase
  {
    ILogger logger;

    public BaseController(ILogger logger)
    {
      this.logger = logger;
    }

    [NonAction]
    public async Task<ActionResult> ActionHandle(Func<Task<ActionResult>> action)
    {
      try
      {
        return await action.Invoke();
      }
      catch (AggregateException ae)
      {
        try
        {
          ae.Handle(ex => { throw ex; });
        }
        catch (Exception ex)
        {
          Log(ex);
          return BadRequest(ex.Message);
        }

        return BadRequest(ae.Message);
      }
      catch (Exception ex)
      {
        Log(ex);
        return BadRequest(ex.Message);
      }
    }

    void Log(Exception ex)
    {
      if (ex is BusinessException business)
      {
        logger.LogWarning(ex, $"Business exception - {business.Message}");
      }
      else
      {
        logger.LogError(ex, "Unhandled exception");
      }
    }
  }
}