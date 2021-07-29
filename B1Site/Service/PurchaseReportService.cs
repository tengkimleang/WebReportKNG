using B1Site.Models.PurchaseReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B1Site.Connection;
using System.Data;

namespace B1Site.Service
{
    public class PurchaseReportService : IPurchaseReportService
    {

        #region Binding data to report
        public Task<string> GetPurchaeReportAsync(DateTime datefrom, DateTime dateto, string bysubcategory, string bycategory, string byvendername, string byitemsname, string byreceiptnumber, string byWarehouse)
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("EXEC [USP_Purchase_Report] '"+datefrom.ToString("yyyy-MM-dd")+"','"+dateto.ToString("yyyy-MM-dd")+"','','','','','',''");
            List<PurchaseReport> PurchaseReportList = new List<PurchaseReport>();
            foreach (DataRow a in dt.Rows)
            {
                try
                {
                    PurchaseReportList.Add(new PurchaseReport
                    {
                        //InvoiceDate = Convert.ToDateTime(a[0].ToString()).ToString("MMM"),
                        PoNum = a[0].ToString().ToString(),
                        DocNum = a[1].ToString(),
                        GoodsReceiptDate = Convert.ToDateTime(a[2].ToString()).ToString("MMM"),
                        ItemGroup = a[3].ToString(),
                        ItemCode = a[4].ToString(),
                        U_vendercode1 = a[5].ToString(),
                        ItemsName = a[6].ToString(),
                        CustomerRefNo = a[7].ToString(),
                        Quality = a[8].ToString(),
                        TotalItemsWidthCost = a[9].ToString(),
                        FreightInsurance = a[10].ToString(),
                        Custom = a[11].ToString(),
                        ClearanceTransportaion = a[12].ToString(),
                        other = a[13].ToString(),
                        TotalCost = a[14].ToString(),
                        UnitCost = a[15].ToString(),
                        WSprice = a[16].ToString()

                    });
                }
                catch (Exception ex)
                {
                    var a1 = ex.Message;
                }
            }
            return Task.FromResult(Utf8Json.JsonSerializer.ToJsonString(PurchaseReportList));
        }
        #endregion
        #region Binding data MasterViwe
        public Task<List<CategoryMaster>> GetCategeroyMastersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ItemsNameMaster>> GetItemsNameMasterAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ReceipNumberMaster>> GetReceiptNumberMasterAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<SubCategoryMaster>> GetSubCategoryMasterAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<VenderNameMaster>> GetVenderNameMasterAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<WarehouseMaster>> GetWarehouseMasterAsync()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
