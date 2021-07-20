using B1Site.Connection;
using B1Site.Models.SalesReportbySerialNumber;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Service
{
    public class SalesReportbySerialNumberService : ISalesReportbySerialNumberService
    {
        public Task<List<ItemGroupMasterSerialNumber>> GetItemGroupMasterSerialNumbers()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT ItmsGrpNam AS ItemGroup FROM OITB");
            List<ItemGroupMasterSerialNumber> itemGroupMasterSerialNumbers = new List<ItemGroupMasterSerialNumber>();
            foreach (DataRow a in dt.Rows)
            {
                itemGroupMasterSerialNumbers.Add(new ItemGroupMasterSerialNumber
                {
                    ItemGroup = a[0].ToString()
                });
            }
            return Task.FromResult(itemGroupMasterSerialNumbers);
        }

        public Task<List<SaleemployeeMasterSerialNumber>> GetSaleemployeeMasterSerialNumbers()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT Cast(SlpCode As varchar(100))+' : '+SlpName AS Saleman FROM OSLP WHERE SlpCode > 0 ORDER BY SlpName");
            List<SaleemployeeMasterSerialNumber> saleemployeeMasterSerialNumber = new List<SaleemployeeMasterSerialNumber>();
            foreach (DataRow a in dt.Rows)
            {
                saleemployeeMasterSerialNumber.Add(new SaleemployeeMasterSerialNumber
                {
                    Saleemployee = a[0].ToString()
                });
            }
            return Task.FromResult(saleemployeeMasterSerialNumber);
        }
    }
}
