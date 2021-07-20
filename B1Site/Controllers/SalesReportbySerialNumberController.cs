using B1Site.Models.SalesReportbySerialNumber;
using B1Site.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Controllers
{
    public class SalesReportbySerialNumberController : Controller
    {
        private readonly ISalesReportbySerialNumberService salesReportbySerialNumberService;

        public SalesReportbySerialNumberController(ISalesReportbySerialNumberService salesReportbySerialNumberService)
        {
            this.salesReportbySerialNumberService = salesReportbySerialNumberService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            return View(new MasterViewSaleReportbySerialNumber
            {
                ItemGroupMastersSerailNumber =await salesReportbySerialNumberService.GetItemGroupMasterSerialNumbers(),
                SaleemployeeMasterSerialNumber=await salesReportbySerialNumberService.GetSaleemployeeMasterSerialNumbers()
            });
        }
    }
}
