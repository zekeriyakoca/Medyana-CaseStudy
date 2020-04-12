using Dtos.Common;
using Dtos.Enums;
using Dtos.Equipment;
using Medyana.Dtos.Equipment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medyana.Test.DataSources
{
  public class EquipmentInternalTestData
  {
    public static IEnumerable<object[]> EquipmentsToInsert
    {
      get
      {
        yield return new object[] { new EquipmentInsertDto { Name = "Test Equipment 1", ClinicId = 1, Price = 10, Quantity = 20, UsageRate = new decimal(1.2) }, true, false };
        yield return new object[] { new EquipmentInsertDto { Name = "Test Equipment 1", ClinicId = 1, Price = 10, Quantity = 20, UsageRate = new decimal(1.2) }, true, false };
        yield return new object[] { new EquipmentInsertDto { Name = "Test Equipment 1", ClinicId = 1, Price = new decimal(10000.324), Quantity = 120, UsageRate = new decimal(1.2) }, true, false };

        yield return new object[] { new EquipmentInsertDto { Name = "Test Equipment 1", ClinicId = 12637, Price = 10, Quantity = 20, UsageRate = new decimal(1.2) }, true, true };
        yield return new object[] { new EquipmentInsertDto { Name = "Test Equipment 1", ClinicId = 1, Price = 10, Quantity = 0, UsageRate = new decimal(1.2) }, true, true };
        yield return new object[] { new EquipmentInsertDto { Name = "Test Equipment 1", ClinicId = 1, Price = 10, Quantity = 20, UsageRate = new decimal(1000) }, true, true };

        //Todo : implement...
      }
    }

    public static IEnumerable<object[]> EquipmentsToUpdate
    {
      get
      {
        yield return new object[] { new EquipmentUpdateDto { Name = "Test Equipment 1", ClinicId = 1, Price = 10, Quantity = 0, SupplyDate = DateTime.UtcNow, UsageRate = new decimal(1.2) }, true };

        //Todo : implement...
      }
    }

    public static IEnumerable<object[]> GetPaginatedEquipmentsReqeusts
    {
      get
      {
        yield return new object[] { new EquipmentPaginationRequestDto { ClinicId = 1, Column = "name", IsAscending = true, Page = 0, PageItemCount = 5, SearchText = "" }, true };
        yield return new object[] { new EquipmentPaginationRequestDto { ClinicId = 1, Column = "name", IsAscending = false, Page = 0, PageItemCount = 5, SearchText = "" }, true };
        yield return new object[] { new EquipmentPaginationRequestDto { ClinicId = 1, Column = "name", IsAscending = true, Page = 0, PageItemCount = 5, SearchText = "random name ksadfjksd" }, false };
        yield return new object[] { new EquipmentPaginationRequestDto { ClinicId = 1, Column = "", IsAscending = true, Page = 0, PageItemCount = 5, SearchText = "" }, true };

        //Todo : implement...

      }
    }



  }
}
