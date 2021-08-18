using B1Site.Models.Apcashoutreport;
using B1Site.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace B1Site.Controllers
{
    public class ApcashoutreportController : Controller
    {
        private readonly IApcashoutService apcashoutService;

        #region Constucter
        public ApcashoutreportController(IApcashoutService apcashoutService)
        {
            this.apcashoutService = apcashoutService;
        }
        #endregion
        #region Viwe
        public async Task<IActionResult> Index()
        {
            return View();
        }
        #endregion
        #region Bind data to report
        [HttpGet]
        public async Task<string> GetApcatoutreport(DateTime datefrom, DateTime dateto)
        {
            return await apcashoutService.GetApcastoutAsync(datefrom, dateto);
        }
        #endregion
    }
}
