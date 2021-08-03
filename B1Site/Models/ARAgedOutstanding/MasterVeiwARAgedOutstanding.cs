using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Models.ARAgedOutstanding
{
    public class MasterVeiwARAgedOutstanding
    {
        public List<CustomerClassMaster> customerClassMasters { get; set; }
        public List <CustomerNameMaster> customerNameMasters{ get; set; }
        public List <CreditControlMaster>creditControlMasters { get; set; }
        public List <RegionMaster>regionMasters { get; set; }
        public List <SaleEmployeeMaster>saleEmployeeMasters { get; set; }
    }
}
