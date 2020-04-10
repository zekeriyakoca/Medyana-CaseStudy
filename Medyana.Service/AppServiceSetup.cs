using Medyana.Infrastructure.EntityFramework.Context;
using Medyana.Service.Injection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medyana.Service
{
  public static class AppServiceSetup
  {
    public static void AddAppServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContextPool<DataContext>(options =>
                options.UseSqlServer(configuration["DefaultConnection"]));

      IocInfrastructure.Set(services, configuration);

    }
  }
}
