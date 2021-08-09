using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using B1Site.Service;
using B1Site.Models.FinalSaleReport;

namespace B1Site.Controllers
{
    public class FinaceSaelReportController : Controller
    {
        #region Declare local Varaible
        private readonly IFinaceSaleReportService finaceSaleReportService;
        #endregion
        #region Constatur
        public FinaceSaelReportController(IFinaceSaleReportService finaceSaleReportService)
        {
            this.finaceSaleReportService = finaceSaleReportService;
        }
        #endregion
        #region ReturnViwe
        public async Task<IActionResult> Index()
        {
            return View( //new MasterViweFanceSaleReport { 

            //itemsGropMasters = await finaceSaleReportService.GetItemsGropMasterAsync(),
            //categoryMasters = await finaceSaleReportService.GetcategoryMastersAsync(),
            //saleemployeeMasters = await finaceSaleReportService.GetSaleemployeeMastersAync(),
            //measureMasters = await finaceSaleReportService.GetmeasureMastersAync(),
            //itemsCodeMasters = await finaceSaleReportService.GetItemsCodeMastersAync(),
            //customerIDMasters = await finaceSaleReportService.GetcustomerIDMastersAync(),
            //sourceMasters = await finaceSaleReportService.GetSourceMastersAync()
           //}
                                        
             );
        }
        #endregion
        #region Method Get Data From Ajax
        [HttpGet]
        public async Task<string> GetFinaceReportsAsync(DateTime datefrom, DateTime dateto,string itemgroup,string categroy,string saleemployee,string Measure,string itemcode,string customerid,string source)
        {
            return await finaceSaleReportService.GetFinalceSaleReportAsync(datefrom, dateto,itemgroup,categroy,saleemployee,Measure,itemcode,customerid,source);
        }
        #endregion
    }
}
