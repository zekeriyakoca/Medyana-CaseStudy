using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medyana.Dtos.Clinic
{
  public class ClinicInsertDto
  {
    [Required]
    [MinLength(2)]
    public string Name { get; set; }
  }
}
