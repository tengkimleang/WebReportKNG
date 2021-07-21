using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Models.Apcashoutreport
{
    public class Apcastoutreport
    {
        public string Apdocnum { get; set; }
        public string DocumentDate { get; set; }

        public string PaymentDoc { get; set; }
        public string PaidDate { get; set; }
        public string VendorName { get; set; }
        public string NameVendorissueCheck { get; set; }
        public string InternalDocument { get; set; }
        public string ExternalDocument { get; set; }
        public string Glaccount { get; set; }
        public string GlaccountName { get; set; }
        public string Decription { get; set; }
        public string Department { get; set; }
        public string Branch { get; set; }
        public string ProductName { get; set; }
        public string PaymentMethod { get; set; }
        public string CheckNo { get; set; }
        public string BankName { get; set; }
        public string Cash { get; set; }
        public string Debit { get; set; }
        public string Credit { get; set; }
    }
}
