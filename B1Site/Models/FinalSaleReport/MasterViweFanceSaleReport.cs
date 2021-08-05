using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Models.FinalSaleReport
{
    public class MasterViweFanceSaleReport
    {
        public  List<ItemsGropMaster> itemsGropMasters { get; set; }
        public List<CategoryMaster> categoryMasters { get; set; }
        public List<SaleemployeeMaster> saleemployeeMasters { get; set; }
        public List<MeasureMaster> measureMasters { get; set; }
        public List<ItemsCodeMaster> itemsCodeMasters { get; set; }
        public List<CustomerIDMaster> customerIDMasters { get; set; }
        public List<SourceMaster> sourceMasters { get; set; }

    }
}
