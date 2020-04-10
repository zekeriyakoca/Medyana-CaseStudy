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
  public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
  {
    public EquipmentRepository(DataContext context) : base(context)
    {

    }

    public async Task<bool> Any(int id) {
      return await Context.Set<Equipment>().AnyAsync(e => e.Id == id);
    }

    public IQueryable<Equipment> GetAllLazy()
    {
      return Context.Set<Equipment>().AsNoTracking().AsQueryable<Equipment>();
    }
  }
}
