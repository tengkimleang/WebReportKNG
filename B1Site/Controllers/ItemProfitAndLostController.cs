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
            return View() ;
        }
        #endregion
        #region Get Data From ajax

        public async Task<string> GetItemProfitAndLostAsync(DateTime datefrom,DateTime dateto)
        {
            return await itemProfitAndLostService.GetItemProfitAndLostAsync(datefrom, dateto);
        }
        #endregion 
    }
}
