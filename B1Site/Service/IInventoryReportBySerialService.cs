using B1Site.Models.InventoryReportBySerial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Service
{
    public interface IInventoryReportBySerialService
    {
        #region Bind Master Data View
        Task<List<MainGroupMaster>> GetMainGroupsAsync();
        Task<List<ModelMaster>> GetModelMastersAsync();
        Task<List<VendorCodeMaster>> GetVendorCodeMastersAsync();
        Task<List<RegionMaster>> GetRegionMastersAsync();
        Task<List<WarehouseIDMaster>> GetWarehouseIDMastersAsync();
        #endregion
        #region Bind Report Data
        Task<string> GetInventoryReportBySerialsAsync(DateTime datefrom,DateTime dateto,string itemgroup,string model,string vendorcode,string warehouse);
        #endregion
    }
}
