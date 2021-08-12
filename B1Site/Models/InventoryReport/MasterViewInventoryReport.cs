using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Models.InventoryReport
{
    public class MasterViewInventoryReport
    {
        public List<ItemCodeMaster> ItemCodeMasters { get; set; }
        public List<CategoryMaster> CategoryMasters { get; set; }
        public List<MeasureMaster> MeasureMasters { get; set; } 
        public List<SourceMaster> SourceMasters { get; set; }
        public List<SubCategoryMaster> SubCategoryMasters { get; set; }
        public List<WarehouseMaster> WarehouseMasters { get; set; }
        public List<MainGroupMaster> MainGroupMasters { get; set; }
    }
}
