using Medyana.Domain.Interface;
using Medyana.Infrastructure.EntityFramework.Context;
using Medyana.Infrastructure.Repositories;
using Medyana.Service.AppServices;
using Medyana.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medyana.Service.Injection
{
  public class IocInfrastructure
  {
    public static void Set(IServiceCollection services, IConfiguration configuration) {


      services.AddSingleton<IConfiguration>(configuration);
      services.AddSingleton<IServiceCollection>(services);

      services.AddTransient<Seeder>();

      services.AddScoped<IClinicRepository, ClinicRepository>();
      services.AddScoped<IEquipmentRepository, EquipmentRepository>();

      services.AddScoped<IClinicAppService, ClinicAppService>();
      services.AddScoped<IEquipmentAppService, EquipmentAppService>();

    }
  }
}
