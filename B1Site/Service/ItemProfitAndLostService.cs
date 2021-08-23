using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B1Site.Models.ItemProfitAndLost;
using B1Site.Service;
using System.Data;
using B1Site.Connection;


namespace B1Site.Service
{
    public class ItemProfitAndLostService : IItemProfitAndLostService
    {
        #region Bind Master Data for Filter Report
        
        public Task<List<BPCodeMaster>> GetBPCodeMasterAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT CardCode,CardName FROM OCRD WHERE CardType='C'");
            List<BPCodeMaster> bPCodeMasters = new List<BPCodeMaster>();
            foreach (DataRow row in dt.Rows)
            {
                bPCodeMasters.Add(new BPCodeMaster { 
                    BPCode=row[0].ToString(),
                    BPName=row[1].ToString()
                });
            }
            return Task.FromResult(bPCodeMasters);
        }       
 
        public Task<List<InventoryUOM>> GetInventoryUOMAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT DISTINCT InvntryUOM FROM OITM WHERE InvntryUOM IS NOT NULL ORDER BY InvntryUOM ");
            List<InventoryUOM> inventoryUOMs = new List<InventoryUOM>();
            foreach (DataRow row in dt.Rows)
            {
                inventoryUOMs.Add(new InventoryUOM
                {
                    UoM = row[0].ToString()
                }); ;
            }
            return Task.FromResult(inventoryUOMs);
        }

        public Task<List<ItemCategory>> GetItemCategoryAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT ItmsGrpNam As Category  FROM OITB");
            List<ItemCategory> itemCategories = new List<ItemCategory>();
            foreach (DataRow row in dt.Rows)
            {
                itemCategories.Add(new ItemCategory
                {
                    Category = row[0].ToString()
                }); ;
            }
            return Task.FromResult(itemCategories);
        }

        public Task<List<ItemCodeMaster>> GetItemCodeMasterAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT ItemCode,ItemName FROM OITM ");
            List<ItemCodeMaster> itemCodeMasters = new List<ItemCodeMaster>();
            foreach (DataRow row in dt.Rows) {
                itemCodeMasters.Add(new ItemCodeMaster
                {
                    ItemCode = row[0].ToString(),
                    ItemName=row[1].ToString()
                });                
            }
            return Task.FromResult(itemCodeMasters);
        }

        public Task<List<ItemGroupMaster>> GetItemGroupMasterAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT ItmsGrpNam As Category  FROM OITB");
            List<ItemGroupMaster> itemGroupMasters = new List<ItemGroupMaster>();
            foreach (DataRow row in dt.Rows)
            {
                itemGroupMasters.Add(new ItemGroupMaster
                {
                    ItemGroup = row[0].ToString()
                }); ;
            }
            return Task.FromResult(itemGroupMasters);
        }

        public Task<List<ItemSource>> GetItemSourceAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT U_Source FROM OITM");
            List<ItemSource> itemSources = new List<ItemSource>();
            foreach (DataRow row in dt.Rows)
            {
                itemSources.Add(new ItemSource
                {
                    Source = row[0].ToString()
                }); 
            }
            return Task.FromResult(itemSources);
        }

        public Task<List<SalePerson>> GetSalePersonAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT SlpCode,SlpName FROM OSLP ORDER BY SlpCode");
            List<SalePerson> salePeople = new List<SalePerson>();
            foreach (DataRow row in dt.Rows)
            {
                salePeople.Add(new SalePerson
                {
                    SlpCode = row[0].ToString(),
                    SlpName=row[1].ToString()
                });
            }
            return Task.FromResult(salePeople);
        }
        #endregion
        #region Display Data Report

        //public Task<string> GetItemProfitAndLostAsync(DateTime datefrom, DateTime dateto, string byitemgroup, string bysaleperson, string bycategory, string byUom, string byitemcode, string bycardcode, string bysource)
        //{
        //    ClsCRUD clsCRUD = new ClsCRUD();
        //    byitemgroup = ((string.IsNullOrEmpty(byitemgroup) || byitemgroup == "0") ? "" : byitemgroup);
        //    bysaleperson = ((string.IsNullOrEmpty(bysaleperson) || bysaleperson == "0") ? "" : bysaleperson);
        //    bycategory = ((string.IsNullOrEmpty(bycategory) || bycategory == "0") ? "" : bycategory);
        //    byUom = ((string.IsNullOrEmpty(byUom) || byUom == "") ? "" : byUom);
        //    byitemcode = ((string.IsNullOrEmpty(byitemcode) || byitemcode == "") ? "" : byitemcode);
        //    bycardcode = ((string.IsNullOrEmpty(bycardcode) || bycardcode == "") ? "" : bycardcode);
        //    bycardcode = ((string.IsNullOrEmpty(bycardcode) || bycardcode == "") ? "" : bycardcode);
        //    var dt = clsCRUD.Getdata("EXEC [dbo].[USP_Item_Profit_And_Lost_NEW_V1_Web] '"+datefrom.ToString("yyyy-MM-dd")+"','"+dateto.ToString("yyyy-MM-dd")+"','','','','','','','','customers'");
        //    List<ItemProfitAndLostReport> ItemProfitAndLostReports = new List<ItemProfitAndLostReport>();
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        ItemProfitAndLostReports.Add(new ItemProfitAndLostReport
        //        {
        //            No = row[0].ToString(),
        //            CardCode = row[1].ToString(),
        //            CardName = row[2].ToString(),
        //            BPGroup = row[3].ToString(),
        //            BPCategory = row[4].ToString(),
        //            Grade = row[5].ToString(),
        //            Region = row[6].ToString(),
        //            SalePerson = row[7].ToString(),
        //            InvDate = Convert.ToDateTime(row[8].ToString()).ToString("MMM"),
        //            Group = row[9].ToString(),
        //            ItemGroup = row[10].ToString(),
        //            ItemCode = row[10].ToString(),
        //            Description = row[11].ToString(),
        //            Source = row[12].ToString(),
        //            Category = row[13].ToString(),
        //            SubCategory = row[14].ToString(),
        //            Movement = row[14].ToString(),
        //            Codition = row[15].ToString(),
        //            Year = row[16].ToString(),
        //            Promotion = row[17].ToString(),
        //            Warranty = row[18].ToString(),
        //            Quantity = Convert.ToInt32(row[19].ToString()),
        //            Price = Convert.ToDouble(row[20].ToString()),
        //            Discount = Convert.ToDouble(row[21].ToString()),
        //            NetAmount = Convert.ToDouble(row[22].ToString()),
        //            TotalAmount = Convert.ToDouble(row[23].ToString()),
        //            TotalDiscount = Convert.ToDouble(row[24].ToString()),
        //            TotalNetAmount = Convert.ToDouble(row[25].ToString()),
        //            COGS = row[26].ToString(),
        //            GrossProfit = Convert.ToDouble(row[27].ToString()),
        //            Margin = row[28].ToString(),
        //            SONum = row[29].ToString(),
        //            Shipment = row[30].ToString(),
        //            InvoiceNo = row[31].ToString(),
        //            Status = row[32].ToString(),
        //            UoM = row[33].ToString(),
        //            Location = row[34].ToString(),
        //            Warehouse = row[35].ToString(),
        //            Department = row[36].ToString()

        //        });
        //    }

        //    return Task.FromResult(Utf8Json.JsonSerializer.ToJsonString(ItemProfitAndLostReports));
        //}

        public Task<string> GetItemProfitAndLostAsync(DateTime datefrom, DateTime dateto)
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            //byitemgroup = ((string.IsNullOrEmpty(byitemgroup) || byitemgroup == "0") ? "" : byitemgroup);
            //bysaleperson = ((string.IsNullOrEmpty(bysaleperson) || bysaleperson == "0") ? "" : bysaleperson);
            //bycategory = ((string.IsNullOrEmpty(bycategory) || bycategory == "0") ? "" : bycategory);
            //byUom = ((string.IsNullOrEmpty(byUom) || byUom == "") ? "" : byUom);
            //byitemcode = ((string.IsNullOrEmpty(byitemcode) || byitemcode == "") ? "" : byitemcode);
            //bycardcode = ((string.IsNullOrEmpty(bycardcode) || bycardcode == "") ? "" : bycardcode);
            //bycardcode = ((string.IsNullOrEmpty(bycardcode) || bycardcode == "") ? "" : bycardcode);
            var dt = clsCRUD.Getdata("EXEC [dbo].[USP_Item_Profit_And_Lost_NEW_V1_Web] '" + datefrom.ToString("yyyy-MM-dd") + "','" + dateto.ToString("yyyy-MM-dd") + "','','','','','','','','customers'");
            List<ItemProfitAndLostReport> ItemProfitAndLostReports = new List<ItemProfitAndLostReport>();
            foreach (DataRow row in dt.Rows)
            {
                ItemProfitAndLostReports.Add(new ItemProfitAndLostReport
                {
                    No = row[0].ToString(),
                    CardCode = row[1].ToString(),
                    CardName = row[2].ToString(),
                    BPGroup = row[3].ToString(),
                    BPCategory = row[4].ToString(),
                    Grade = row[5].ToString(),
                    Region = row[6].ToString(),
                    SalePerson = row[7].ToString(),
                    InvDate = Convert.ToDateTime(row[8].ToString()).ToString("MMM"),
                    Group = row[9].ToString(),
                    ItemGroup = row[10].ToString(),
                    ItemCode = row[10].ToString(),
                    Description = row[11].ToString(),
                    Source = row[12].ToString(),
                    Category = row[13].ToString(),
                    SubCategory = row[14].ToString(),
                    Movement = row[14].ToString(),
                    Codition = row[15].ToString(),
                    Year = row[16].ToString(),
                    Promotion = row[17].ToString(),
                    Warranty = row[18].ToString(),
                    Quantity = Convert.ToInt32(row[19].ToString()),
                    Price = Convert.ToDouble(row[20].ToString()),
                    Discount = Convert.ToDouble(row[21].ToString()),
                    NetAmount = Convert.ToDouble(row[22].ToString()),
                    TotalAmount = Convert.ToDouble(row[23].ToString()),
                    TotalDiscount = Convert.ToDouble(row[24].ToString()),
                    TotalNetAmount = Convert.ToDouble(row[25].ToString()),
                    COGS = row[26].ToString(),
                    GrossProfit = Convert.ToDouble(row[27].ToString()),
                    Margin = row[28].ToString(),
                    SONum = row[29].ToString(),
                    Shipment = row[30].ToString(),
                    InvoiceNo = row[31].ToString(),
                    Status = row[32].ToString(),
                    UoM = row[33].ToString(),
                    Location = row[34].ToString(),
                    Warehouse = row[35].ToString(),
                    Department = row[36].ToString()

                });
            }

            return Task.FromResult(Utf8Json.JsonSerializer.ToJsonString(ItemProfitAndLostReports));
        }
        #endregion
    }
}
