using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B1Site.Models.ItemProfitAndLost;

namespace B1Site.Service
{
    public interface IItemProfitAndLostService
    {
        Task<string> GetItemProfitAndLostAsync(DateTime datefrom,DateTime dateto);
    }
}
