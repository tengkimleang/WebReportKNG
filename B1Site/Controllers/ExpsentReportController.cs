using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B1Site.Service;

namespace B1Site.Controllers
{
    public class ExpsentReportController : Controller
    {
        #region Variabel local
        private readonly IExspenReportService exspenReportService;
        #endregion
        #region Contrutor
        public ExpsentReportController(IExspenReportService exspenReportService)
        {
            this.exspenReportService = exspenReportService;
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        #region Binding Data to Report
        public async Task<string> GetExspentReprotController(DateTime datefrom, DateTime dateto)
        {
            return await exspenReportService.GetExspenReportAsync(datefrom, dateto);
        }
        #endregion
    }
}
