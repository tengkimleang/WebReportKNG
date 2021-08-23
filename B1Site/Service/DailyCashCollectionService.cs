using B1Site.Connection;
using B1Site.Models.DailyCashCollection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Service
{
    public class DailyCashCollectionService : IDailyCashCollectionService
    {
        #region Bind master data
        public Task<List<CustomerIDMaster>> GetCustomerIDMastersAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT CardCode,CardCode+' : '+ CardName AS CUSTOMER_ID FROM OCRD Order By CUSTOMER_ID");
            List<CustomerIDMaster> customerID = new List<CustomerIDMaster>();
            foreach (DataRow a in dt.Rows)
            {
                customerID.Add(new CustomerIDMaster
                {
                    CardCode = a[0].ToString(),
                    CustomerID = a[1].ToString()
                });
            }
            return Task.FromResult(customerID);
        }
        #endregion
        #region Bind Data to report
        public Task<string> GetDailyCashCollectionsAsync(DateTime datefrom, DateTime dateto,string CustomerID)
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            if (CustomerID == "0")
            {
                CustomerID = "";
            }
            var dt = clsCRUD.Getdata("EXEC [USP_Daily_Cash_Collection_WebReport] '" + datefrom.ToString("yyyy-MM-dd") + "','" + dateto.ToString("yyyy-MM-dd") + "','"+CustomerID+"'");
            List<DailyCashCollection> dailyCashCollectionList = new List<DailyCashCollection>();
            foreach (DataRow a in dt.Rows)
            {
                dailyCashCollectionList.Add(new DailyCashCollection
                {
                    Row = a[0].ToString(),
                    Receipt = a[1].ToString(),
                    ReceivedDate = Convert.ToDateTime(a[2].ToString()).ToString("yyyy-MM-dd"),
                    CustomerReceived = a[3].ToString(),
                    SysInvoice = a[4].ToString(),
                    Type = a[5].ToString(),
                    Status = a[6].ToString(),
                    CustomerName = a[7].ToString(),
                    Location = a[8].ToString(),
                    CustomerClass = a[9].ToString(),
                    Region = a[10].ToString(),
                    PaymentMethod = a[11].ToString(),
                    Remark = a[12].ToString(),
                    Manufacture = a[13].ToString(),
                    ItemGroup = a[14].ToString(),
                    Source = a[15].ToString(),
                    Category = a[16].ToString(),
                    Movement = a[17].ToString(),
                    Model = a[18].ToString(),
                    Year = a[19].ToString(),
                    VenderCode = a[20].ToString(),
                    ItemCode = a[21].ToString(),
                    Description = a[22].ToString(),
                    CollectedAmount = a[23].ToString(),
                    ServiceCharge = a[24].ToString(),
                    TotalAmount = a[25].ToString(),



                }); ;
            }
            return Task.FromResult(Utf8Json.JsonSerializer.ToJsonString(dailyCashCollectionList));
        }
        #endregion
    }
}
