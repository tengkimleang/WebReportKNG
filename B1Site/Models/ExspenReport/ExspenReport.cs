using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Models.ExspenReport
{
    public class ExspenReport
    {
        public int TranID { get; set; }
        public string RefDate { get; set; }
        public string SerialName { get; set; }
        public string  Docnum { get; set; }
        public int  Number { get; set; }
        public string Origion { get; set; }
        public string ControlAcount { get; set; }
        public string  ControlAcountName { get; set; }
        public string Description { get; set; }
        public string  ExternalDocument { get; set; }
        public string  InternalDocument { get; set; }
        public string CheckNumber { get; set; }
        public string  CardCode { get; set; }
        public string GLAocuntABPCode { get; set; }
        public string CardName { get; set; }
        public string Itemsgroup { get; set; }
        public string Location { get; set; }
        public string  Department { get; set; }
        public string Promotion { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
    }
}
