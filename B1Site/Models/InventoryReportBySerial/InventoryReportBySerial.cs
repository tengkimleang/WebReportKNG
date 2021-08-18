using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Models.InventoryReportBySerial
{
    public class InventoryReportBySerial
    {
        public string ItemCode { get; set; }
        public string VenderCode { get; set; }
        public string ItemGroup { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Description { get; set; }
        public string Year { get; set; }
        public string Model { get; set; }
        public string SerailNumber { get; set; }
        public string Warehouse { get; set; }
        public string Shelf { get; set; }
        public string BinLocation { get; set; }
        public int Qty { get; set; }
    }
}
