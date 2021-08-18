using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Models.PurchaseReport
{
    public class PurchaseReport
    {
        public string PoNum { get; set; }
        public string DocNum { get; set; }
        public string GoodsReceiptDate { get; set; }
        public string ItemGroup { get; set; }
        public string ItemCode { get; set; }
        public string U_vendercode1 { get; set; }
        public string ItemsName { get; set; }
        public string CustomerRefNo { get; set; }
        public string Quality { get; set; }
        public string TotalItemsWidthCost { get; set; }
        public string FreightInsurance { get; set; }
        public string Custom { get; set; }
        public string ClearanceTransportaion { get; set; }
        public string other { get; set; }
        public string TotalExspenseCost { get; set; }
        public string TotalCost { get; set; }
        public string UnitCost { get; set; }
        public string WSprice { get; set; }
    }
}
