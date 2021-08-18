using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B1Site.Models.ItemProfitAndLost;

namespace B1Site.Service
{
    public interface IItemProfitAndLostService
    {
        Task<string> GetItemProfitAndLostAsync(DateTime datefrom,DateTime dateto,string byitemgroup,string bysaleperson,string bycategory,string byUom,string byitemcode,string bycardcode,string bysource);
        Task<List<ItemGroupMaster>> GetItemGroupMasterAsync();
        Task<List<SalePerson>> GetSalePersonAsync();
        Task<List<ItemCategory>> GetItemCategoryAsync();        
        Task<List<InventoryUOM>> GetInventoryUOMAsync();
        Task<List<ItemCodeMaster>> GetItemCodeMasterAsync();
        Task<List<BPCodeMaster>> GetBPCodeMasterAsync();
        Task<List<ItemSource>> GetItemSourceAsync();
    }
}
