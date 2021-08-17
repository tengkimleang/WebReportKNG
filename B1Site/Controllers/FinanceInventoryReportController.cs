using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B1Site.Models.FinanceInventoryReport;
using B1Site.Service;

namespace B1Site.Controllers
{
    public class FinanceInventoryReportController : Controller
    {

        private readonly IFinanceInventoryReportService financeInventoryReportService;

        
        public FinanceInventoryReportController(IFinanceInventoryReportService financeInventoryReportService)
        {
            this.financeInventoryReportService = financeInventoryReportService;
        }

        public async Task<IActionResult> Index()
        {
            return View(
                    new MasterViewFinanceInventoryReport
                    {
                        MainGroupMasters = await financeInventoryReportService.GetMainGroupMastersAsyc(),
                        CategoryMasters = await financeInventoryReportService.GetCategoryMastersAsync(),
                        ItemCodeMasters = await financeInventoryReportService.GetItemCodeMastersAsyc(),
                        MeasureMasters = await financeInventoryReportService.GetMeasureMastersAsyc(),
                        SourceMasters = await financeInventoryReportService.GetSourceMastersAsyc(),
                        SubCategoryMasters = await financeInventoryReportService.GetSubCategoryMastersAsysc(),
                        WarehouseMasters = await financeInventoryReportService.GetWarehouseMastersAsysc()
                    }
                  );
                
        }
        [HttpGet]
        public async Task<string> GetFinanceInventoryReport(DateTime datefrom, DateTime dateto, string itemcode, string mainGroups, string categorys, string subcategorys, string sources, string measures, string warehouses)
        {
            return await financeInventoryReportService.GetInventoryReporAsync(datefrom, dateto,itemcode,mainGroups,categorys,subcategorys,sources,measures,warehouses);
        }
    }

     
}
