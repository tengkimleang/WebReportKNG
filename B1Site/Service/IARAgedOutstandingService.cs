using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B1Site.Models.ARAgedOutstanding;

namespace B1Site.Service
{
    public interface IARAgedOutstandingService
    {
        //Task<string> GetArAgedOutstandingsAsync(DateTime agingdate, string customerclass, string creditcontrol,
        //                                        string customername, string salemployee, string region);
        Task<List<CustomerNameMaster>> GetCustomerNameMastersAsync();
        Task<List<SaleEmployeeMaster>> GetSaleEmployeeMastersAsync();
        Task<List<CustomerClassMaster>> GetCustomerClassMastersAsync();
        Task<List<CreditControlMaster>> GetCreditControlMastersAsync();
        Task<List<RegionMaster>> GetRegionMastersAsync();
    }
}
