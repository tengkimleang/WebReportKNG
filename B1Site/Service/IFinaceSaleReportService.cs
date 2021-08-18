using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B1Site.Models.FinalSaleReport;
namespace B1Site.Service
{
   public  interface IFinaceSaleReportService
    {
        Task<string> GetFinalceSaleReportAsync(DateTime datefrom,DateTime dateto,string byitemsgroup,string bycategory,string bysaleempoyee,string byMeasure,string itemscode,string customerid,string source);
        Task<List<ItemsGropMaster>> GetItemsGropMasterAsync();
        Task<List<CategoryMaster>> GetcategoryMastersAsync();
        Task<List<SaleemployeeMaster>> GetSaleemployeeMastersAync();
        Task<List<MeasureMaster>> GetmeasureMastersAync();
        Task<List<ItemsCodeMaster>> GetItemsCodeMastersAync();
        Task<List<CustomerIDMaster>> GetcustomerIDMastersAync();
        Task<List<SourceMaster>> GetSourceMastersAync();
    }
}
