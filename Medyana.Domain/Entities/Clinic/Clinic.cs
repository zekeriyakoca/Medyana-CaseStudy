using System;
using System.Collections.Generic;
using System.Text;

namespace Medyana.Domain.Entities
{
  public class Clinic : BaseEntity
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual IEnumerable<Equipment> Equipments { get; set; }
  }
}
