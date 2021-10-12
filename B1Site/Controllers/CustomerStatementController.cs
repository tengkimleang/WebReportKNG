using B1Site.Connection;
using B1Site.Models;
using B1Site.Models.CustomerStatement;
using B1Site.Service;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Controllers
{
    public class CustomerStatementcontroller : Controller
    {
        private readonly ICustomerStatementService customerStatementServices;
        #region Constructor
        public CustomerStatementcontroller(ICustomerStatementService CustomerStatementServices)
        {
            this.customerStatementServices = CustomerStatementServices;
        }
        #endregion
        #region Veiw
        public async Task<IActionResult> IndexAsync()
        {
            return View(new MasterViewCustomerStatement
            {
                CustomerMasters = await customerStatementServices.GetCustomerstatementsAsync(),
            });
        }
        public async Task<IActionResult> CustomerStatementAsync(string customer, DateTime agingdate)
        {
            return View(await customerStatementServices.GetCustomerstatementsAsync(agingdate, customer));
        }
        public ActionResult TestViewWithModel(string customer, DateTime agingdate
            //,string id, string CardName, string CardFName, string BPAddress
            //                                  , string BPPhone, DateTime INVDate, string SysInvoice
            //                                  , string DOC, string ItemGroup, string Aged, string Balance
            //                                  , string KEY1, string System1Invoice, string TT2, string TT4
            )
        {
            var model = new TestViewModel
            {
                customer = customer,
                agingdate = agingdate
                //DocTitle = id,
                //DocContent = "sdfsfgaff",
                //CardName = CardName,
                //CardFName = CardFName,
                //BPAddress = BPAddress,
                //BPPhone = BPPhone,
                //INVDATE = INVDate,
                //SysInvoice = SysInvoice,
                //Doc = DOC,
                //ItemGroup = ItemGroup,
                //Aged = Aged,
                //Balance = Balance,
                //KEY1 = KEY1,
                //System1Invoice = System1Invoice,
                //TT2 = TT2,
                //TT4 = TT4

            };
            return new ViewAsPdf(model);
        }
        //public ActionResult TestViewWithModel(string id)
        //{
        //    var model = new TestViewModel() { DocTitle = id,DocContent = "This is a test" };
        //    return new ViewAsPdf(model);
        //}

        #endregion
        #region Bind data to report
        //[HttpGet]
        //public async Task<string> GetCustomerstatement(DateTime agingdate, string customer)
        //{
        //    return await customerStatementServices.GetCustomerstatementsAsync(agingdate, customer);
        //}
        #endregion

      
    }
}
