using B1Site.Connection;
using B1Site.Models.DailyCashCollection;
using B1Site.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Controllers
{
    public class DailyCashCollectioncontroller : Controller
    {
        private readonly IDailyCashCollectionService dailyCashCollectionService;
        #region Constructor
        public DailyCashCollectioncontroller(IDailyCashCollectionService dailyCashCollectionService)
        {
            this.dailyCashCollectionService = dailyCashCollectionService;
        }
        #endregion
        #region Veiw
        public async Task<IActionResult> IndexAsync()
        {
            return View(new MasterVeiwDailyCashCollection
            {
                customerIDMasters =await dailyCashCollectionService.GetCustomerIDMastersAsync()
            }); ;
        }
        #endregion
        #region Bind data to report
        [HttpGet]
        public async Task<string> GetDailyCashCollection(DateTime datefrom, DateTime dateto, string customerID)
        {
            return await dailyCashCollectionService.GetDailyCashCollectionsAsync(datefrom, dateto,customerID);
        }
        #endregion
    }
}
