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
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT '' AS Categoryall UNION ALL SELECT Distinct ItmsGrpNam AS Categoryall FROM OITB WHERE ItmsGrpNam IS NOT NULL ORDER BY Categoryall");
            List<CategoryMaster> categoryMasters = new List<CategoryMaster>();
            foreach (DataRow a in dt.Rows)
            {
                try
                {
                    categoryMasters.Add(new CategoryMaster
                    {
                        Category = a[0].ToString()
                    });
                }catch(Exception ex)
                {
                    var a1 = ex.Message;
                }
            }
            return Task.FromResult(categoryMasters);
        }

        public Task<List<ItemsNameMaster>> GetItemsNameMasterAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT Distinct Isnull(ItemName,'') AS ItemName1 from OITM Where SellItem<>'N' and InvntItem<>'N'");
            List<ItemsNameMaster> itemsNameMasters = new List<ItemsNameMaster>();
            foreach (DataRow a in dt.Rows)
            {
                try
                {
                    itemsNameMasters.Add(new ItemsNameMaster
                    {
                        ItemsName = a[0].ToString()
                    });
                }
                catch(Exception ex)
                {
                    var a1 = ex.Message;
                }
                
            }
            return Task.FromResult(itemsNameMasters);
        }

        public Task<List<ReceipNumberMaster>> GetReceiptNumberMasterAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("Select DocNum As Receipt From OPOR Order By DocNum");
            List<ReceipNumberMaster> receipNumberMasters = new List<ReceipNumberMaster>();
            foreach (DataRow a in dt.Rows)
            {
                try
                {
                    receipNumberMasters.Add(new ReceipNumberMaster
                    {
                        ReceipNumber = a[0].ToString()
                    });
                }
                catch (Exception ex)
                {
                    var a1 = ex.Message;
                }
                
            }
            return Task.FromResult(receipNumberMasters);
        }

        public Task<List<SubCategoryMaster>> GetSubCategoryMasterAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT '' AS SubAll UNION ALL SELECT  Distinct ISNULL(U_Category,'Item No SubCategory') FROM OITM ORDER BY SubAll");
            List<SubCategoryMaster> subCategoryMasters = new List<SubCategoryMaster>();
            foreach (DataRow a in dt.Rows)
            {
                try
                {
                    subCategoryMasters.Add(new SubCategoryMaster
                    {
                        SubCategory = a[0].ToString()
                    });
                }
                catch (Exception ex)
                {
                    var a1 = ex.Message;
                }
               
            }
            return Task.FromResult(subCategoryMasters);
        }

        public Task<List<VenderNameMaster>> GetVenderNameMasterAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT CardCode,CardCode + ' : ' + CardName AS Vendor FROM OCRD ORDER BY CardCode");
            List<VenderNameMaster> venderNameMasters = new List<VenderNameMaster>();
            foreach (DataRow a in dt.Rows)
            {
                try
                {
                    venderNameMasters.Add(new VenderNameMaster
                    {
                        Vendercode = a[0].ToString(),
                        Vendername = a[1].ToString()

                    });
                }
                catch (Exception ex)
                {
                    var a1 = ex.Message;
                }
               
            }
            return Task.FromResult(venderNameMasters);
        }

        public Task<List<WarehouseMaster>> GetWarehouseMasterAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT Whscode,Whscode+' : '+ WhsName As Whs FROM OWHS");
            List<WarehouseMaster> warehouseMasters = new List<WarehouseMaster>();
            foreach (DataRow a in dt.Rows)
            {
                try
                {
                    warehouseMasters.Add(new WarehouseMaster
                    {
                        WarehouseCode = a[0].ToString(),
                        WarehouseName = a[1].ToString()

                    });
                }
                catch (Exception ex)
                {
                    var a1 = ex.Message;
                }
                
            }
            return Task.FromResult(warehouseMasters);
        }
        #endregion
    }
}
