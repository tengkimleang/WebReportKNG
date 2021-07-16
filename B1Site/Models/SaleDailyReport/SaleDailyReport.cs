using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Models.SaleDailyReport
{
    public class SaleDailyReport
    {
        public string InvoiceDate { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string GroupName { get; set; }
        public string CustomerCategory { get; set; }
        public string Region { get; set; }
        public string ItemGroup { get; set; }
        public string VendorCode { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public double TotalDiscount { get; set; }
        public double TotalNetPrice { get; set; }
        public string SaleEmployee { get; set; }
    }
}
