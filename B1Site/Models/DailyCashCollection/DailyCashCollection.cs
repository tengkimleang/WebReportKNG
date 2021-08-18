using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Models.DailyCashCollection
{
    public class DailyCashCollection
    {
        internal string CollectedAmount;

        public string Receipt { get; set; }
        public string ReceivedDate { get; set; }
        public string CustomerReceived { get; set; }
        public string SysInvoice { get; set; }
        public string CustomerRef { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Location { get; set; }
        public string CustomerClass { get; set; }
        public string Region { get; set; }
        public string PaymentMethod { get; set; }
        public string CashAccountDescription { get; set; }
        public string CollectionAmount { get; set; }
        public string ServiceCharge { get; set; }
        public string TotalAmount { get; set; }
        public string Product { get; set; }

    }
}
