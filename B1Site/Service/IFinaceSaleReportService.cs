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
        Task<List<ItemsGropMaster>> ItemsGropMaster();
        Task<List<CategoryMaster>> categoryMasters();
        Task<List<SaleemployeeMaster>> SaleemployeeMasters();
        Task<List<MeasureMaster>> measureMasters();
        Task<List<ItemsCodeMaster>> ItemsCodeMasters();
        Task<List<CustomerIDMaster>> customerIDMasters();
        Task<List<SourceMaster>> SourceMasters();
    }
}
