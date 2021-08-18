using B1Site.Connection;
using B1Site.Models.CustomerStatement;
using B1Site.Models.DailyCashCollection;
using B1Site.Service;
using Microsoft.AspNetCore.Mvc;
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
        #endregion
        #region Bind data to report
        [HttpGet]
        public async Task<string> GetDailyCashCollection(DateTime agingdate, string customer)
        {
            return await customerStatementServices.GetCustomerstatementsAsync(agingdate, customer);
        }
        #endregion
    }
}
