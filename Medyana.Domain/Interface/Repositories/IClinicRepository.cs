using Medyana.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medyana.Domain.Interface
{
  public interface IClinicRepository : IRepository<Clinic>
  {
    Task<bool> Any(int id);
    IQueryable<Clinic> GetIncludeAll(int id);
  }
}
