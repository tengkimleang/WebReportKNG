using B1Site.Models.SaleDailyReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Service
{
    public interface ISaleDailyReportService
    {
        Task<string> GetSaleDailyReportAsync(DateTime datefrom, DateTime dateto,string byItemGroup,string bySaleEmployee,string byCategory,string byCustomerClass,string byLocation,string byInventoryID,string byCustomerID,string bySource,string byWarehouse);
        Task<List<ItemGroupMaster>> GetItemGroupMasterAsync();
        Task<List<SaleEmployeeMaster>> GetSaleEmployeeMastersAsync();
        Task<List<CategoryMaster>> GetCategoryMastersAsync();
        Task<List<CustomerClassMaster>> GetCustomerClassMastersAsync();
        Task<List<LocationMaster>> GetLocationMastersAsync();
        Task<List<InventoryIDMaster>> GetInventoryIDMastersAsync();
        Task<List<CusomterIDMaster>> GetCusomterIDMastersAsync();
        Task<List<SourceMaster>> GetSourceMastersAsync();
        Task<List<WarehouseMaster>> GetWarehouseMastersAsync();
    }
}
