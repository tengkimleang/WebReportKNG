using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Models.PSIReport
{
    public class MasterViewPSIReport
    {
        public List<CategoryMaster> CategoryMasters { get; set; }
        public List<ItemGroupMaster> ItemGroupMasters { get; set; }
        public List<SourceMaster> SourceMasters { get; set; }
        public List<UnitOfMeasureMaster> UnitOfMeasureMasters { get; set; }
    }
}
