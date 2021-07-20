using B1Site.Models.SalesReportbySerialNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Service
{
    public interface ISalesReportbySerialNumberService
    {
        Task<List<ItemGroupMasterSerialNumber>> GetItemGroupMasterSerialNumbers();
        Task<List<SaleemployeeMasterSerialNumber>> GetSaleemployeeMasterSerialNumbers();
    }
}
