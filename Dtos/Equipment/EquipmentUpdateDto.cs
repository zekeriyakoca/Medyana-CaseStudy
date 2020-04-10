using System;
using System.ComponentModel.DataAnnotations;
using Utils.Infrastructure;

namespace Medyana.Dtos.Equipment
{
  public class EquipmentUpdateDto
  {
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
    [Range(0, 100)]
    public decimal UsageRate { get; set; }

    public DateTime SupplyDate { get; set; }
    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    [MinValue(1)]
    public int ClinicId { get; set; }
  }
}
