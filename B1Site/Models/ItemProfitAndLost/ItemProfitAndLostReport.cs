using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Models.ItemProfitAndLost
{
    public class ItemProfitAndLostReport
    {
        public string No { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string BPGroup { get; set; }
        public string BPCategory { get; set; }
        public string Grade { get; set; }
        public string Region { get; set; }
        public string SalePerson { get; set; }
        public string InvDate { get; set; }
        public string Group { get; set; }
        public string ItemGroup { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Movement { get; set; }
        public string Codition { get; set; }
        public  string Year { get; set; }
        public string Promotion { get; set; }
        public string Warranty { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public double NetAmount { get; set; }
        public double TotalAmount { get; set; }
        public double TotalDiscount { get; set; }
        public double TotalNetAmount { get; set; }
        public string COGS { get; set; }
        public double GrossProfit { get; set; }
        public string Margin { get; set; }
        public string SONum { get; set; }
        public string Shipment { get; set; }
        public string InvoiceNo { get; set; }
        public string Status { get; set; }
        public string UoM { get; set; }
        public string Location { get; set; }
        public string Warehouse { get; set; }
        public string Department { get; set; }
    }
}
