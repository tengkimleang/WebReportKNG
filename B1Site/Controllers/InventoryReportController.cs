using Microsoft.AspNetCore.Mvc;
using System;
using B1Site.Service;
using B1Site.Models.InventoryReport;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using B1Site.Connection;

namespace B1Site.Controllers
{
    public class InventoryReportController : Controller
    {
        private readonly IInventoryReportService inventoryReportService;

        
        public InventoryReportController(IInventoryReportService inventoryReportService)
        {
            this.inventoryReportService = inventoryReportService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            return View(new MasterViewFinanceInventoryReport {
                MainGroupMasters=await inventoryReportService.GetMainGroupMastersAsyc(),
                CategoryMasters=await inventoryReportService.GetCategoryMastersAsync(),
                ItemCodeMasters=await inventoryReportService.GetItemCodeMastersAsyc(),
                MeasureMasters=await inventoryReportService.GetMeasureMastersAsyc(),
                SourceMasters=await inventoryReportService.GetSourceMastersAsyc(),
                SubCategoryMasters=await inventoryReportService.GetSubCategoryMastersAsysc(),
                WarehouseMasters=await inventoryReportService.GetWarehouseMastersAsysc(),

            });
        }
        [HttpGet]
        public async Task<string> GetInventoryReport(DateTime datefrom, DateTime dateto, string itemcode, string mainGroups, string categorys, string subcategorys, string sources, string measures, string warehouses)
        {
            return await inventoryReportService.GetInventoryReporAsync(datefrom, dateto,itemcode,mainGroups,categorys,subcategorys,sources,measures,warehouses);
        }
    }
}
