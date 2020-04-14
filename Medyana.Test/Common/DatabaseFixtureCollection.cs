using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Medyana.IntegrationTest.Common
{
  [CollectionDefinition(nameof(DatabaseFixtureCollection))]
  public class DatabaseFixtureCollection : ICollectionFixture<DatabaseFixture> {}
}
