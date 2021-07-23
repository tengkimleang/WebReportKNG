using B1Site.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B1Site.Models.SaleReportBySerialNumber;

namespace B1Site.Controllers
{
    public class SaleReportBySerialController : Controller
    {

        #region Declare local Varaible
        private readonly ISaleReportbySerialService saleReportbySerialService;
        #endregion
        #region Construtor
        public SaleReportBySerialController(ISaleReportbySerialService saleReportbySerialService)
        {
            this.saleReportbySerialService = saleReportbySerialService;
        }
        #endregion
        #region return View
        public async Task<IActionResult> Index()
        {
            return View(new SaleSerailReportMaster
            {
                itemGroupMasters = await saleReportbySerialService.GetItemGroupMastersAsyc()

            }) ;
        }
        #endregion
        #region Method Get Data From Ajax
        [HttpGet]
        public async Task<string> GetSaleSerialReportAsync(DateTime datefrom, DateTime dateto,
                                                            string byItemGroup
                                                )
        {
            return await saleReportbySerialService.GetSaleserialreport(datefrom, dateto,
                                                                        byItemGroup);
        }
        #endregion


    }
}
