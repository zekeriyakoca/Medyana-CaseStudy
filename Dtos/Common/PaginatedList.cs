using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos.Common
{
  public class Paginatedlist<T>
  {
    public Paginatedlist()
    {

    }
    public Paginatedlist(List<T> items, int page, int totalItemCount, int pageSize)
    {
      Items = items;
      Page = page;
      TotalItemCount = totalItemCount;
      PageSize = pageSize;
    }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public List<T> Items { get; set; }
    public int TotalItemCount { get; set; }
    public int TotalPage
    {
      get
      {
        if (Items?.Count > 0) {
          var temp = Math.Ceiling(new decimal(TotalItemCount) / new decimal(PageSize));
          return (int)temp;
        }
        return 0;
      
      }
    }
    public bool HasNext
    {
      get
      {
        return TotalPage > Page+1;
      }
    }
    public bool HasPrev
    {
      get
      {
        return Page > 0;
      }
    }
  }
}
