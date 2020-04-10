using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.Infrastructure
{
  public class BusinessException : Exception
  {
    public BusinessException(string message)
        : base(message)
    {
    }
  }
}
