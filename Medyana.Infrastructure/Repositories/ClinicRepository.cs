using Medyana.Domain.Entities;
using Medyana.Domain.Interface;
using Medyana.Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medyana.Infrastructure.Repositories
{
  public class ClinicRepository : Repository<Clinic>, IClinicRepository
  {
    public ClinicRepository(DataContext context) : base(context)
    {
      this.context = context;
    }

    public DataContext context { get; }

    public async Task<bool> Any(int id)
    {
      return await Context.Set<Clinic>().AnyAsync(e => e.Id == id);
    }

    public IQueryable<Clinic> GetIncludeAll(int id)
    {
      return context.Clinics.Include(c => c.Equipments).AsNoTracking();
    }

  }
}
