using Dtos.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos.Common
{
  public class PaginationRequestDto
  {
    public int Page { get; set; } = 0;
    public int PageItemCount { get; set; } = 10;
    public string SearchText { get; set; }
    public bool IsAscending { get; set; } = true;
    public string Column { get; set; }

    public PaginationType Type
    {
      get
      {
        if (String.IsNullOrWhiteSpace(SearchText) == false)
          return PaginationType.Searching;
        else if (String.IsNullOrWhiteSpace(Column) == false)
          return PaginationType.Sorting;
        else
          return PaginationType.Paging;

      }
    }
  }
}
