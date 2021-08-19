using B1Site.Connection;
using B1Site.Models.SaleDailyReport;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;
using B1Site.Service;

namespace B1Site.Controllers
{
    public class SaleDialyReportController : Controller
    {
        #region Declare local Varaible
        private readonly ISaleDailyReportService saleDailyReportService;
        #endregion
        #region Construtor
        public SaleDialyReportController(ISaleDailyReportService saleDailyReportService)
        {
            this.saleDailyReportService = saleDailyReportService;
        }
        #endregion
        #region Return View
        public async Task<IActionResult> Index()
        {
            ViewBag.DisA = "active";
            return View(new MasterViewSaleDailyReport
            {
                ItemGroupMasters= await saleDailyReportService.GetItemGroupMasterAsync(),
                SaleEmployeeMasters= await saleDailyReportService.GetSaleEmployeeMastersAsync(),
                CategoryMasters = await saleDailyReportService.GetCategoryMastersAsync(),
                CustomerClassMasters = await saleDailyReportService.GetCustomerClassMastersAsync(),
                LocationMasters = await saleDailyReportService.GetLocationMastersAsync(),
                InventoryIDMasters = await saleDailyReportService.GetInventoryIDMastersAsync(),
                CusomterIDMasters = await saleDailyReportService.GetCusomterIDMastersAsync(),
                SourceMasters = await saleDailyReportService.GetSourceMastersAsync(),
                WarehouseMasters = await saleDailyReportService.GetWarehouseMastersAsync(),
            });
        }
        #endregion
        #region Method Get Data From Ajax
        [HttpGet]
        public async Task<string> GetSaleDailyReportAsync(DateTime datefrom,DateTime dateto, 
                                                            string byItemGroup, string bySaleEmployee, 
                                                            string byCategory, string byCustomerClass, 
                                                            string byLocation, string byInventoryID, 
                                                            string byCustomerID, string bySource, 
                                                            string byWarehouse)
        {
            return await saleDailyReportService.GetSaleDailyReportAsync(datefrom, dateto,
                                                                        byItemGroup,bySaleEmployee,byCategory,
                                                                        byCustomerClass,byLocation,byInventoryID,
                                                                        byCustomerID,bySource,byWarehouse);
        }
        #endregion
        #region Method Post Data From Ajax
        #endregion
    }
}
