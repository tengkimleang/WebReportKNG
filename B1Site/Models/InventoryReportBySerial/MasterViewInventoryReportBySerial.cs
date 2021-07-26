using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Models.InventoryReportBySerial
{
    public class MasterViewInventoryReportBySerial
    {
        public List<MainGroupMaster> MainGroupMasters { get; set; }
        public List<ModelMaster> ModelMasters { get; set; }
        public List<RegionMaster> RegionMasters { get; set; }
        public List<VendorCodeMaster> VendorCodeMasters { get; set; }
        public List<WarehouseIDMaster> WarehouseIDMasters { get; set; }
    }
}
