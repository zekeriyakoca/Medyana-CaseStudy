using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Medyana.Test.Common
{
  [CollectionDefinition(nameof(DatabaseFixtureCollection))]
  public class DatabaseFixtureCollection : ICollectionFixture<DatabaseFixture> {}
}
