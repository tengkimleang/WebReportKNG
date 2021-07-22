using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B1Site.Models.SaleReportBySerialNumber;
namespace B1Site.Service
{
   public interface ISaleReportbySerialService
    {
        Task<string> GetSaleserialreport(DateTime datefrom,DateTime dateto,string byItemgroup);
        Task<List<ItemGroupMaster>> GetItemGroupMastersAsyc();

    }
}
