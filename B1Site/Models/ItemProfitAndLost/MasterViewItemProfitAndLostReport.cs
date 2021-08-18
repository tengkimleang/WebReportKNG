using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B1Site.Models.ItemProfitAndLost;

namespace B1Site.Models.ItemProfitAndLost
{
    public class MasterViewItemProfitAndLostReport
    {
        public List<ItemGroupMaster> itemGroupMasters { get; set; }
        public List<SalePerson> salePerson { get; set; }
        public List<ItemCategory> itemCategories { get; set; }
        public List<InventoryUOM> inventoryUOMs { get; set; }
        public List<ItemCodeMaster> itemCodeMasters { get; set; }
        public List<BPCodeMaster> bPCodeMasters { get; set; }
        public List<ItemSource> itemSources { get; set; }
    }
}
