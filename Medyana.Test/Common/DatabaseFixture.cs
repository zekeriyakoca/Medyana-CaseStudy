using Medyana.Infrastructure.EntityFramework.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medyana.Test.Common
{
  public class DatabaseFixture 
  {
    public IHostingEnvironment HostingEnvironment { get; set; }
    public DataContext Context { get; set; }

    public DatabaseFixture()
    {

      var mockEnvironment = new Mock<IHostingEnvironment>();
      mockEnvironment
                .Setup(m => m.ContentRootPath)
                .Returns("C:/Users/zeker/source/repos/Medyana/Medyana.Test");
      this.HostingEnvironment = mockEnvironment.Object;

      var options = new DbContextOptionsBuilder<DataContext>()
                    .UseInMemoryDatabase(databaseName: "MedyanaTestDBContext")
                    .Options;
      Context = new DataContext(options);

      SeedDatabase();

    }

    protected void SeedDatabase()
    {
      var seeder = new Seeder(Context);
      seeder.Seed();
    }
  }
}
