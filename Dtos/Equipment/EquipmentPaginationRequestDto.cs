using Dtos.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos.Equipment
{
  public class EquipmentPaginationRequestDto : PaginationRequestDto
  {
    public int ClinicId { get; set; }
  }
}
