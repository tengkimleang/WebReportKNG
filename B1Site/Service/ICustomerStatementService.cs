using B1Site.Models.CustomerStatement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Service
{
    public interface ICustomerStatementService
    {
         Task<List<CustomerMaster>> GetCustomerstatementsAsync();
         Task<List<CustomerStatement>> GetCustomerstatementsAsync(DateTime agingdate, string customer);
         Task<List<TestViewModel>> GetTestViewModelAsync(DateTime agingdate, string customer);
    }
}
