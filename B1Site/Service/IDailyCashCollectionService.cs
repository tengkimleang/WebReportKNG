using B1Site.Models.DailyCashCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Service
{
    public interface IDailyCashCollection
    {
        Task<List<CustomerIDMaster>> GetCustomerIDMastersAsync();
        Task<string> GetDailyCashCollectionsAsync(DateTime datefrom,DateTime dateto,string CustomerID);

    }
}
