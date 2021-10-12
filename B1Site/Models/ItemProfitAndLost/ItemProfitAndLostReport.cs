using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Models.ItemProfitAndLost
{
    public class ItemProfitAndLostReport
    {
        public int No { get; set; }
        public  string  CarCode { get; set; }
        public string  CardName { get; set; }
        public string  CustomerGroup { get; set; }
        public string CustomerGrade { get; set; }
        public string  State { get; set; }
        public string  Saler { get; set; }
        public string SONo { get; set; }
        public string DONo { get; set; }
        public string InvNo { get; set; }
        public string InvDate { get; set; }
        public string Status { get; set; }
        public string Group { get; set; }
        public string Product { get; set; }
        public string InventeryID { get; set; }
        public string VendorCode { get; set; }
        public string  ItemsName { get; set; }
        public string U_Source { get; set; }
        public string SubCategory { get; set; }
        public string U_SubCategory { get; set; }
        public string  U_Movement { get; set; }
        public string U_Condition { get; set; }
        public string U_Model { get; set; }
        public string U_Year { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public string  Promotion { get; set; }
        public string  Warranty { get; set; }
        public string Whs { get; set; }
        public Double  Price { get; set; }
        public double DisAmount { get; set; }
        public int Quality { get; set; }
        public double TotalAmount { get; set;}
        public double TotalDiscountAmount { get; set; }
        public double NetAmount { get; set; }
        public double COGSAmount { get; set; }
        public double GrossProfit { get; set; }
        public double Margin { get; set; }
        public string InvntryUom { get; set; }
        public string ItemsGroupforSV { get; set; }
        public string Name { get; set; }
        public string BPCategory { get; set; }
    }
}
