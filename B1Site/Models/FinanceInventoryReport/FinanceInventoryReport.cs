using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Models.FinanceInventoryReport
{
    public class FinanceInventoryReport
    {
        public string Row { get; set; }
        public string ItemCode { get; set; }
        public string description { get; set; }
        public string vendorCode1 { get; set; }
        public string Group { get; set; } 
        public string ItemGroup { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Source { get; set; }
        public string Movement { get; set; }        
        public string Condition { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string QTY { get; set; }        
        public string Cost { get; set; }
        public string PostingDate { get; set; }
        public string Age { get; set; }
        public string WhareHouse { get; set; }
        

    }
}
