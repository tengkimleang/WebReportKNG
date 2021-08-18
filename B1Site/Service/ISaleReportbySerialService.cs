using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B1Site.Models.SaleReportBySerialNumber;
namespace B1Site.Service
{
   public interface ISaleReportbySerialService
    {
        Task<string> GetSaleserialreport(DateTime datefrom,DateTime dateto,string byItemgroup,string bysalemmployee,string bycategory,string bycustomerclass,string byinventerid,string bylocation,string bysoucre,string bycustomerid,string bywarhouse);
        Task<List<ItemGroupMaster>> GetItemGroupMastersAsyc();
        Task<List<SaleemployeeMaster>> GetSaleemployeeMastersAsyc();
        Task<List<CategoryMaster>> GetCategoryMastersAsyc();
        Task<List<CustomerclassMaster>> GetCustomerclassMastersAsyc();
        Task<List<InventeryidMaster>> GetInventeryidMastersAsyc();
        Task<List<LocationMaster>> GetLocationMastersAsyc();
        Task<List<SourceMaster>> GetSourceMastersAsyc();
        Task<List<CustomeridMaster>> GetCustomeridMastersAsyc();
        Task<List<BywarehouseMaster>> GetBywarehousesAsyc();
       

    }
}
