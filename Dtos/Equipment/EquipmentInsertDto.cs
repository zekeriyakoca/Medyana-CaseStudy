using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Utils.Infrastructure;

namespace Medyana.Dtos.Equipment
{
  public class EquipmentInsertDto
  {
    [Required]
    public string Name { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
    [Range(0, 100)]
    public decimal UsageRate { get; set; }
    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    [MinValue(1)]
    public int ClinicId { get; set; }
  }
}
