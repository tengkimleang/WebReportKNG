using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Models.SaleReportBySerialNumber
{
    public class SaleSerailReportMaster
    {
        public List<ItemGroupMaster> itemGroupMasters { get; set; }
        public List<SaleemployeeMaster> saleemployeeMasters { get; set; }
        public List<CategoryMaster> categoryMasters { get; set; }
        public List<CustomerclassMaster> customerclassMasters { get; set; }
        public List<LocationMaster> locationMasters { get; set; }
        public List<InventeryidMaster> inventeryidMasters { get; set; }
        public List<CustomeridMaster>  customeridMasters { get; set; }
        public List<SourceMaster> sourceMasters { get; set; }
        public List<BywarehouseMaster> bywarehouseMasters { get; set; }
    }
}
