using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B1Site.Service;
using B1Site.Models.PurchaseReport;
namespace B1Site.Controllers
{
    public class PurchaseReportController : Controller
    {
        #region Declare Variable
        private readonly IPurchaseReportService purchaseReportService;

        #endregion
        #region Construtor
        public PurchaseReportController(IPurchaseReportService purchaseReportService)
        {
            this.purchaseReportService = purchaseReportService;
        }
        #endregion
        #region return viwe master
        public async Task<IActionResult> Index()
        {
            return View(
                new MasterviwePurchaeseReport
                {
                    subCategoryMasters = await purchaseReportService.GetSubCategoryMasterAsync(),
                    categoryMasters = await purchaseReportService.GetCategeroyMastersAsync(),
                    venderNameMasters = await purchaseReportService.GetVenderNameMasterAsync(),
                    itemsNameMasters = await purchaseReportService.GetItemsNameMasterAsync(),
                    receipNumberMasters = await purchaseReportService.GetReceiptNumberMasterAsync(),
                    warehouseMasters = await purchaseReportService.GetWarehouseMasterAsync()

                }
           ); ;
        }
        #endregion
        #region Mothor get data form ajax
        [HttpGet]
        public async Task<string> GetPruchaseReportsAsync(DateTime datefrom, DateTime dateto,
                                                            string bysubcategory, string byCategory,
                                                            string byVendername, string byItemsName,
                                                            string byReceiptnumber, string bywarehouse
                                                            )
        {
            return await purchaseReportService.GetPurchaeReportAsync(datefrom, dateto,
                                                                        bysubcategory, byCategory, byVendername,
                                                                        byItemsName, byReceiptnumber, bywarehouse
                                                                        );
        }

        #endregion

    }
}
