using B1Site.Models.InventoryReportBySerial;
using B1Site.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Controllers
{
    public class InventoryReportBySerialController : Controller
    {
        #region Local Varaible
        private readonly IInventoryReportBySerialService inventoryReportBySerialService;
        #endregion
        #region Contructor
        public InventoryReportBySerialController(IInventoryReportBySerialService inventoryReportBySerialService)
        {
            this.inventoryReportBySerialService = inventoryReportBySerialService;
        }
        #endregion
        #region Return View
        public async Task<IActionResult> IndexAsync()
        {
            return View(new MasterViewInventoryReportBySerial { 
                MainGroupMasters=await inventoryReportBySerialService.GetMainGroupsAsync(),
                ModelMasters=await inventoryReportBySerialService.GetModelMastersAsync(),
                RegionMasters=await inventoryReportBySerialService.GetRegionMastersAsync(),
                VendorCodeMasters=await inventoryReportBySerialService.GetVendorCodeMastersAsync(),
                WarehouseIDMasters=await inventoryReportBySerialService.GetWarehouseIDMastersAsync(),
            });
        }
        #endregion
        #region Get From Ajax
        [HttpGet]
        public async Task<string> GetInventoryReportBySerialsAsync(DateTime datefrom, DateTime dateto, string itemgroup, string model, string vendorcode, string warehouse)
        {
            return await inventoryReportBySerialService.GetInventoryReportBySerialsAsync(datefrom, dateto,
                                                                       itemgroup, model, vendorcode,warehouse);
        }
        #endregion
    }
}
