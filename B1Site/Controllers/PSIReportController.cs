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
        #region Method Get Data From Ajax
        [HttpGet]
        public async Task<string> GetPSIReportAsync(DateTime datefrom, DateTime dateto,
                                                            string byItemGroup, string byCategory,
                                                            string byUnit, string bySource)
        {
            return await pSIReportService.GetPSIReportAsync(datefrom, dateto,byItemGroup,byCategory, byUnit, bySource);
        }
        #endregion
    }
}
