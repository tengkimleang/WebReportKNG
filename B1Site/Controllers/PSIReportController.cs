using B1Site.Models.PSIReport;
using B1Site.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Controllers
{
    public class PSIReportController : Controller
    {
        private readonly IPSIReportService pSIReportService;

        public PSIReportController(IPSIReportService pSIReportService)
        {
            this.pSIReportService = pSIReportService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            return View(new MasterViewPSIReport
            {
                CategoryMasters = await pSIReportService.GetCategoryMastersAsync(),
                ItemGroupMasters = await pSIReportService.GetItemGroupMastersAsync(),
                SourceMasters=await pSIReportService.GetSourceMastersAsync(),
                UnitOfMeasureMasters=await pSIReportService.GetUnitOfMeasureMastersAsync(),
            });
        }
    }
}
