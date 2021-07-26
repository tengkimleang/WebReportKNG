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
                itemGroupMasters = await saleReportbySerialService.GetItemGroupMastersAsyc(),
                saleemployeeMasters = await saleReportbySerialService.GetSaleemployeeMastersAsyc(),
                categoryMasters = await saleReportbySerialService.GetCategoryMastersAsyc(),
                customeridMasters = await saleReportbySerialService.GetCustomeridMastersAsyc(),
                customerclassMasters = await saleReportbySerialService.GetCustomerclassMastersAsyc(),
                inventeryidMasters = await saleReportbySerialService.GetInventeryidMastersAsyc(),
                sourceMasters = await saleReportbySerialService.GetSourceMastersAsyc(),
                bywarehouseMasters = await saleReportbySerialService.GetBywarehousesAsyc(),
                locationMasters = await saleReportbySerialService.GetLocationMastersAsyc()



            }); ;
        }
        #endregion
        #region Method Get Data From Ajax
        [HttpGet]
        public async Task<string> GetSaleSerialReportAsync(DateTime datefrom, DateTime dateto,
                                                            string byItemGroup, string saleemployee
                                                            , string category, string location, string customerclass
                                                            , string customerid, string warhoue,string source
                                                            , string Inveteryid
                                                )
        {
            return await saleReportbySerialService.GetSaleserialreport(datefrom, dateto,
                                                                        byItemGroup,saleemployee,category,location
                                                                        ,customerclass,customerid,warhoue,source,Inveteryid);
        }
        #endregion


    }
}
