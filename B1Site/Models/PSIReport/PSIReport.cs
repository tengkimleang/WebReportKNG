using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Models.PSIReport
{
    public class PSIReport
    {
        public string ItemCode { get; set; }
        public string Source { get; set; }
        public string Category { get; set; }
        public string ItemName { get; set; }
        public int OpenningStock { get; set; }
        public int InQty { get; set; }
        public int OutQty { get; set; }
        public int QtyAdjustment { get; set; }
        public int EndingStock { get; set; }
    }
}
