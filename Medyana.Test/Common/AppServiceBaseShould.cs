using Medyana.Infrastructure.EntityFramework.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Medyana.Test.Common
{
  public class DataOperationBaseShould :IClassFixture<DatabaseFixture>
  {
    public IHostingEnvironment HostingEnvironment { get; set; }

    public DataContext Context { get; set; }

    public DataOperationBaseShould(DatabaseFixture dbFixture)
    {
      this.HostingEnvironment = dbFixture.HostingEnvironment;
      this.Context = dbFixture.Context;
    }

  }
}
