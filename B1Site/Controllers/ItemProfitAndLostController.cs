using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B1Site.Service;
using B1Site.Models.ItemProfitAndLost;
namespace B1Site.Controllers
{
    public class ItemProfitAndLostController : Controller
    {
        #region Declare Local Variable
        private readonly IItemProfitAndLostService itemProfitAndLostService;
        #endregion
        #region Constructor
        public ItemProfitAndLostController(IItemProfitAndLostService itemProfitAndLostService)
        {
            this.itemProfitAndLostService = itemProfitAndLostService;
        }
        #endregion
        #region Return View
        public async Task<IActionResult> Index()
        {
            return View(new MasterViewItemProfitAndLostReport
            {
                itemGroupMasters =await itemProfitAndLostService.GetItemGroupMasterAsync(),
                salePerson=await itemProfitAndLostService.GetSalePersonAsync(),
                itemCategories=await itemProfitAndLostService.GetItemCategoryAsync(),
                inventoryUOMs=await itemProfitAndLostService.GetInventoryUOMAsync(),
                itemCodeMasters=await itemProfitAndLostService.GetItemCodeMasterAsync(),
                bPCodeMasters=await itemProfitAndLostService.GetBPCodeMasterAsync(),
                itemSources=await itemProfitAndLostService.GetItemSourceAsync()
            }
            ) ;
        }
        #endregion
        #region Get Data From ajax

        public async Task<string> GetItemProfitAndLostAsync(DateTime datefrom,DateTime dateto
                                                               ,string byItemGroup
                                                               , string bySaleEmployee
                                                               , string byCategory
                                                               , string byInventoryUoM
                                                               , string byItemCode
                                                               , string byCardCode
                                                               , string bySource)
        {
            return await itemProfitAndLostService.GetItemProfitAndLostAsync(datefrom, dateto, byItemGroup, bySaleEmployee, byCategory, byInventoryUoM, byItemCode, byCardCode, bySource);
        }
        #endregion 
    }
}
