using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B1Site.Models.PurchaseReport;

namespace B1Site.Service
{
    public   interface IPurchaseReportService
    {
        Task<string> GetPurchaeReportAsync(DateTime datefrom, DateTime dateto, string bysubcategory, string bycategory, string byvendername, string byitemsname, string byreceiptnumber, string byWarehouse);
        Task<List<SubCategoryMaster>> GetSubCategoryMasterAsync();
        Task<List<CategoryMaster>> GetCategeroyMastersAsync();
        Task<List<VenderNameMaster>> GetVenderNameMasterAsync();
        Task<List<ItemsNameMaster>> GetItemsNameMasterAsync();
        Task<List<ReceipNumberMaster>> GetReceiptNumberMasterAsync();
        Task<List<WarehouseMaster>> GetWarehouseMasterAsync();
    }
}
