using Medyana.Domain.Entities;
using Medyana.Infrastructure.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medyana.Infrastructure.EntityFramework.Context
{
  public class Seeder
  {
    public Seeder(DataContext context)
    {
      this.context = context;
    }

    public DataContext context { get; }

    public bool Seed()
    {
      try
      {
        context.Database.EnsureCreated();
        if (!context.Clinics.Any())
        {
          AddClinics(context);
          AddEquipments(context);
        }
      }
      catch
      {
        return false;
      }
      return true;
    }

    private void AddClinics(DataContext context)
    {
      var clinic = new Clinic { Name = "MedIstanbul" };
      context.Clinics.Add(clinic);
      context.SaveChanges();

    }

    private void AddEquipments(DataContext context)
    {
      var firstClinic = context.Clinics.FirstOrDefault();
      if (firstClinic != null)
      {
        var equipments = new List<Equipment> {
          new Equipment { Name = "Sterilizier", ClinicId = firstClinic.Id, Quantity = 2, Price = 1000, UsageRate = 82, SupplyDate = DateTime.UtcNow.AddDays(30) },
          new Equipment { Name = "Stethoscope", ClinicId = firstClinic.Id, Quantity = 2, Price = 1000, UsageRate = 82, SupplyDate = DateTime.UtcNow.AddDays(20) }
        };
        context.Equipments.AddRange(equipments);
        context.SaveChanges();
      }

    }
  }
}
