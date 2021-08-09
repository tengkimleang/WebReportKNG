using B1Site.Models.InventoryReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Service
{
  public  interface IInventoryReportService
    {
        //Task<List<CustomerIDMaster>> GetCustomerIDMastersAsync();
        //Task<string> GetDailyCashCollectionsAsync(DateTime datefrom, DateTime dateto, string CustomerID);
        Task<List<CategoryMaster>> GetCategoryMastersAsync();
        Task<List<ItemCodeMaster>> GetItemCodeMastersAsyc();
        Task<List<MainGroupMaster>> GetMainGroupMastersAsyc();
        Task<List<MeasureMaster>> GetMeasureMastersAsyc();
        Task<List<SourceMaster>> GetSourceMastersAsyc();
        Task<List<SubCategoryMaster>> GetSubCategoryMastersAsysc();
        Task<List<WarehouseMaster>> GetWarehouseMastersAsysc();
        Task<string> GetInventoryReporAsync(DateTime datefrominv, DateTime datetoinv, string itemcode, string mainGroups, string categorys, string subcategorys, string sources, string measures, string warehouses);

    }
}
