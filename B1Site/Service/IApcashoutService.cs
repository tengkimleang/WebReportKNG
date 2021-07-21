using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Service
{
  public  interface IApcashoutService
    {
        //Task<List<CustomerIDMaster>> GetCustomerIDMastersAsync();
        Task<string> GetApcastoutAsync(DateTime datefrom, DateTime dateto);
    }
}
