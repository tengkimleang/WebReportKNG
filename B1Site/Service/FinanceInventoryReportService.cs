using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B1Site.Models.FinanceInventoryReport;
using System.Data;


namespace B1Site.Service
{
    public class FinanceInventoryReportService : IFinanceInventoryReportService
    {
        public Task<List<CategoryMaster>> GetCategoryMastersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetInventoryReporAsync(DateTime datefrominv, DateTime datetoinv, string itemGroups, string mainGroups, string categorys, string subcategorys, string sources, string measures, string warehouses)
        {
            throw new NotImplementedException();
        }

        public Task<List<ItemGroupMaster>> GetItemCodeMastersAsyc()
        {
            throw new NotImplementedException();
        }

        public Task<List<MainGroupMaster>> GetMainGroupMastersAsyc()
        {
            throw new NotImplementedException();
        }

        public Task<List<MeasureMaster>> GetMeasureMastersAsyc()
        {
            throw new NotImplementedException();
        }

        public Task<List<SourceMaster>> GetSourceMastersAsyc()
        {
            throw new NotImplementedException();
        }

        public Task<List<SubCategoryMaster>> GetSubCategoryMastersAsysc()
        {
            throw new NotImplementedException();
        }

        public Task<List<WarehouseMaster>> GetWarehouseMastersAsysc()
        {
            throw new NotImplementedException();
        }
    }
}
