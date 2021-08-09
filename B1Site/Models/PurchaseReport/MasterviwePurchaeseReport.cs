using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Models.PurchaseReport
{
    public class MasterviwePurchaeseReport
    {
        public List<SubCategoryMaster> subCategoryMasters { get; set; }
        public List<CategoryMaster> categoryMasters { get; set; }
        public List<VenderNameMaster>venderNameMasters { get; set; }
        public List<ItemsNameMaster> itemsNameMasters { get; set; }
        public List<ReceipNumberMaster> receipNumberMasters { get; set; }
        public  List<WarehouseMaster> warehouseMasters { get; set; }

    }
}
