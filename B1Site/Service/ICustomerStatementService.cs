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
         Task<string> GetCustomerstatementsAsync(DateTime agingdate, string customer);
    }
}
