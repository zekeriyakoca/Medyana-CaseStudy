using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Medyana.Domain.Entities
{
  public class Equipment : BaseEntity
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime SupplyDate { get; set; }
    public int Quantity { get; set; }
    public decimal UsageRate { get; set; }
    public decimal Price { get; set; }

    [ForeignKey(nameof(Clinic))]
    public int ClinicId { get; set; }
    public virtual Clinic Clinic { get; set; }
  }
}
