using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyana.Dtos.Clinic
{
  public class EquipmentDetailDto
  {
  
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime SupplyDate { get; set; }
    public int Quantity { get; set; }
    public decimal UsageRate { get; set; }
    public decimal Price { get; set; }

    public int ClinicId { get; set; }
    public virtual ClinicItemDto Clinic { get; set; }
  }
}
