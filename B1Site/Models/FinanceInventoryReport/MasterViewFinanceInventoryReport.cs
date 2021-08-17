using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Models.FinanceInventoryReport
{
    public class MasterViewFinanceInventoryReport
    {
        public List<ItemGroupMaster> ItemCodeMasters { get; set; }
        public List<CategoryMaster> CategoryMasters { get; set; }
        public List<MeasureMaster> MeasureMasters { get; set; } 
        public List<SourceMaster> SourceMasters { get; set; }
        public List<SubCategoryMaster> SubCategoryMasters { get; set; }
        public List<WarehouseMaster> WarehouseMasters { get; set; }
        public List<MainGroupMaster> MainGroupMasters { get; set; }
        
    }
}
