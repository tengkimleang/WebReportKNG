using B1Site.Models.InventoryReport;
using B1Site.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using B1Site.Service;

namespace B1Site.Service
{
    public class InventoryReportService : IInventoryReportService
    {
        public Task<List<CategoryMaster>> GetCategoryMastersAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT ItmsGrpNam FROM OITB");
            List<CategoryMaster> Categorys = new List<CategoryMaster>();
            foreach (DataRow a in dt.Rows)
            {
                Categorys.Add(new CategoryMaster
                {
                    Category = a[0].ToString(),
                });
            }
            return Task.FromResult(Categorys);
        }

        public Task<string> GetInventoryReporAsync(DateTime datefrominv, DateTime datetoinv, string itemcode, string mainGroups, string categorys, string subcategorys, string sources, string measures, string warehouses)
        {
            itemcode = ((string.IsNullOrEmpty(itemcode) || itemcode == "0") ? "" : itemcode);
            mainGroups = ((string.IsNullOrEmpty(mainGroups) || mainGroups == "0") ? "" : mainGroups);
            categorys = ((string.IsNullOrEmpty(categorys) || categorys == "0") ? "" : categorys);
            subcategorys = ((string.IsNullOrEmpty(subcategorys) || subcategorys == "0") ? "" : subcategorys);
            sources = ((string.IsNullOrEmpty(sources) || sources == "0") ? "" : sources);
            measures = ((string.IsNullOrEmpty(measures) || measures == "0") ? "" : measures);
            warehouses = ((string.IsNullOrEmpty(warehouses) || warehouses == "0") ? "" : warehouses);
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("EXEC [USP_Inventory_PriceList] '" + datefrominv.ToString("yyyy-MM-dd") + "','" + datetoinv.ToString("yyyy-MM-dd") + "','" + itemcode + "','" + mainGroups + "','" + categorys + "','" + sources + "','" + measures + "','" + warehouses + "','" + subcategorys + "',''");
            List<InventoryReport> InventoryReportlist = new List<InventoryReport>();
            foreach (DataRow a in dt.Rows)
            {
                InventoryReportlist.Add(new InventoryReport
                {
                    Row = a[0].ToString(),
                    Group = a[1].ToString(),
                    ItemCode = a[2].ToString(),
                    vendorCode1 = a[3].ToString(),
                    description = a[4].ToString(),
                    Category = a[5].ToString(),
                    SubCategory = a[6].ToString(),
                    Movement = a[7].ToString(),
                    RetailPrice = a[8].ToString(),
                    WholeSale = a[9].ToString(),
                    QTY = a[10].ToString(),
                    Kng13 = a[11].ToString(),
                    Kng14 = a[12].ToString(),
                    Kng15 = a[13].ToString(),
                    Kng2 = a[14].ToString(),
                    Kng5 = a[15].ToString(),
                    Kngw3 = a[16].ToString(),
                    Kng8 = a[17].ToString(),
                    Kng9 = a[18].ToString(),
                    Kngfz1 = a[19].ToString(),
                    Kngfz2 = a[20].ToString(),
                    Kngfz3 = a[21].ToString(),
                    Kngfz4 = a[22].ToString(),
                    Kngfz5 = a[23].ToString(),
                    Kngfz6 = a[24].ToString(),
                    Kngfz7 = a[25].ToString(),
                    Kngfz8 = a[26].ToString(),
                    Kngfz9 = a[27].ToString(),
                    Kngw1 = a[28].ToString(),
                    Kngw4 = a[29].ToString(),
                    Kngw5 = a[30].ToString(),
                    Kngw6 = a[31].ToString()
                });
            }
            return Task.FromResult(Utf8Json.JsonSerializer.ToJsonString(InventoryReportlist));
        }

        public Task<List<ItemCodeMaster>> GetItemCodeMastersAsyc()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT ItemCode AS ItemCode FROM OITM");
            List<ItemCodeMaster> itemCodes = new List<ItemCodeMaster>();
            foreach (DataRow a in dt.Rows)
            {
                itemCodes.Add(new ItemCodeMaster
                {
                    ItemCode = a[0].ToString(),
                });
            }
            return Task.FromResult(itemCodes);
        }

        public Task<List<MainGroupMaster>> GetMainGroupMastersAsyc()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT FirmName FROM OMRC");
            List<MainGroupMaster> mainGroups = new List<MainGroupMaster>();
            foreach (DataRow a in dt.Rows)
            {
                mainGroups.Add(new MainGroupMaster
                {
                    MainGroup = a[0].ToString(),
                });
            }
            return Task.FromResult(mainGroups);
        }

        public Task<List<MeasureMaster>> GetMeasureMastersAsyc()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT distinct BuyUnitMsr FROM OITM");
            List<MeasureMaster> measures = new List<MeasureMaster>();
            foreach (DataRow a in dt.Rows)
            {
                measures.Add(new MeasureMaster
                {
                    Measure = a[0].ToString(),
                });
            }
            return Task.FromResult(measures);
        }

        public Task<List<SourceMaster>> GetSourceMastersAsyc()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT distinct U_Source FROM OITM");
            List<SourceMaster> sources = new List<SourceMaster>();
            foreach (DataRow a in dt.Rows)
            {
                sources.Add(new SourceMaster
                {
                    Source = a[0].ToString(),
                });
            }
            return Task.FromResult(sources);
        }

        public Task<List<SubCategoryMaster>> GetSubCategoryMastersAsysc()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT distinct U_Category FROM OITM");
            List<SubCategoryMaster> subCategorys = new List<SubCategoryMaster>();
            foreach (DataRow a in dt.Rows)
            {
                subCategorys.Add(new SubCategoryMaster
                {
                    SubCategory = a[0].ToString(),
                });
            }
            return Task.FromResult(subCategorys);
        }

        public Task<List<WarehouseMaster>> GetWarehouseMastersAsysc()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT distinct WhsCode FROM OITW");
            List<WarehouseMaster> warehouses = new List<WarehouseMaster>();
            foreach (DataRow a in dt.Rows)
            {
                warehouses.Add(new WarehouseMaster
                {
                    Warehouse = a[0].ToString(),
                });
            }
            return Task.FromResult(warehouses);
        }
    }
}
