using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Models.SaleDailyReport
{
    public class MasterViewSaleDailyReport
    {
        public List<ItemGroupMaster> ItemGroupMasters { get; set; }
        public List<SaleEmployeeMaster> SaleEmployeeMasters { get; set; }
        public List<CategoryMaster> CategoryMasters { get; set; }
        public List<CustomerClassMaster> CustomerClassMasters { get; set; }
        public List<LocationMaster> LocationMasters { get; set; }
        public List<InventoryIDMaster> InventoryIDMasters { get; set; }
        public List<CusomterIDMaster> CusomterIDMasters { get; set; }
        public List<SourceMaster> SourceMasters { get; set; }
        public List<WarehouseMaster> WarehouseMasters { get; set; }

    }
}
