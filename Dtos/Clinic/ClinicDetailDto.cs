using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyana.Dtos.Clinic
{
  public class ClinicDetailDto
  {
    public ClinicDetailDto()
    {
      Equipments = new List<EquipmentItemDto>();
    }

    public int Id { get; set; }
    public string Name { get; set; }

    public virtual IEnumerable<EquipmentItemDto> Equipments { get; set; }
  }
}
