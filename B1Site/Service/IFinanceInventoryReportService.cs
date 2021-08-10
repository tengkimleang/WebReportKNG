using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B1Site.Models.FinanceInventoryReport;

namespace B1Site.Service
{
    interface IFinanceInventoryReportService
    {
        Task<List<CategoryMaster>> GetCategoryMastersAsync();
        Task<List<ItemGroupMaster>> GetItemCodeMastersAsyc();
        Task<List<MainGroupMaster>> GetMainGroupMastersAsyc();
        Task<List<MeasureMaster>> GetMeasureMastersAsyc();
        Task<List<SourceMaster>> GetSourceMastersAsyc();
        Task<List<SubCategoryMaster>> GetSubCategoryMastersAsysc();
        Task<List<WarehouseMaster>> GetWarehouseMastersAsysc();
        Task<string> GetInventoryReporAsync(DateTime datefrominv, DateTime datetoinv, string itemGroups, string mainGroups, string categorys, string subcategorys, string sources, string measures, string warehouses);

    }
}
