using B1Site.Connection;
using B1Site.Models.ARAgedOutstanding;
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
    public class ARAgedOutstandingController : Controller
    {
        #region Declare local Varaible
        private readonly IARAgedOutstandingService aRAgedOutstandingService;
        #endregion
        #region Construtor
        public ARAgedOutstandingController(IARAgedOutstandingService aRAgedOutstandingService)
        {
            this.aRAgedOutstandingService = aRAgedOutstandingService;
        }
        #endregion
        #region Return View
        public async Task<IActionResult> Index()
        {
            return View( new MasterVeiwARAgedOutstanding
                {
                    customerClassMasters = await aRAgedOutstandingService.GetCustomerClassMastersAsync(),
                    customerNameMasters = await aRAgedOutstandingService.GetCustomerNameMastersAsync(), 
                    creditControlMasters = await aRAgedOutstandingService.GetCreditControlMastersAsync(),
                    regionMasters = await aRAgedOutstandingService.GetRegionMastersAsync(),
                    saleEmployeeMasters = await aRAgedOutstandingService.GetSaleEmployeeMastersAsync()
            }
        );
        }
        #endregion
        #region Method Get Data From Ajax
        [HttpGet]
        public async Task<string> GetARAgedoutstandingsAsync(DateTime agingdate, string customerclass,
                                                       string creditcontrol, string customername,
                                                       string saleemployee, string region)
        {
            return await aRAgedOutstandingService.GetARAgedOutstandingsAsync(agingdate,creditcontrol,
                                                                             customerclass, customername,
                                                                             region, saleemployee);                                                  
        }
        #endregion
        #region Method Post Data From Ajax
        #endregion
    }
}
