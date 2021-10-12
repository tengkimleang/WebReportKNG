using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B1Site.Models.FinanceInventoryReport;
using System.Data;
using B1Site.Connection;

namespace B1Site.Service
{
    public class FinanceInventoryReportService : IFinanceInventoryReportService
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

        public Task<string> GetInventoryReporAsync(DateTime datefrominv, DateTime datetoinv, string itemGroups, string mainGroups, string categorys, string subcategorys, string sources, string measures, string warehouses)
        {
            {
                itemGroups = ((string.IsNullOrEmpty(itemGroups) || itemGroups == "0") ? "" : itemGroups);
                mainGroups = ((string.IsNullOrEmpty(mainGroups) || mainGroups == "0") ? "" : mainGroups);
                categorys = ((string.IsNullOrEmpty(categorys) || categorys == "0") ? "" : categorys);
                subcategorys = ((string.IsNullOrEmpty(subcategorys) || subcategorys == "0") ? "" : subcategorys);
                sources = ((string.IsNullOrEmpty(sources) || sources == "0") ? "" : sources);
                measures = ((string.IsNullOrEmpty(measures) || measures == "0") ? "" : measures);
                warehouses = ((string.IsNullOrEmpty(warehouses) || warehouses == "0") ? "" : warehouses);
                ClsCRUD clsCRUD = new ClsCRUD();
                var dt = clsCRUD.Getdata("EXEC [USP_InventoryCost_Report_WebReport] '" + datefrominv.ToString("yyyy-MM-dd") + "','" + datetoinv.ToString("yyyy-MM-dd") + "','" + subcategorys + "','" + itemGroups + "','','" + mainGroups + "','" + categorys + "','" + sources + "','" + measures + "','" + warehouses + "'");
                List<FinanceInventoryReport> InventoryReportlist = new List<FinanceInventoryReport>();
                foreach (DataRow a in dt.Rows)
                {
                    InventoryReportlist.Add(new FinanceInventoryReport
                    {
                        Row = a[0].ToString(),
                        ItemCode = a[1].ToString(),
                        description = a[2].ToString(),                        
                        vendorCode1 = a[3].ToString(),
                        Group = a[4].ToString(),
                        ItemGroup =a[5].ToString(),
                        Source = a[6].ToString(),
                        Category = a[7].ToString(),
                        SubCategory = a[8].ToString(),
                        Movement = a[9].ToString(),
                        Condition = a[10].ToString(),
                        Model = a[11].ToString(),
                        Year = a[12].ToString(),
                        QTY = a[13].ToString(),
                        Cost = a[15].ToString(),
                        PostingDate = a[16].ToString(),
                        Age = a[17].ToString(),
                        WhareHouse =a[18].ToString()                                        
                    });
                }
                return Task.FromResult(Utf8Json.JsonSerializer.ToJsonString(InventoryReportlist));
            }
        }

        public Task<List<ItemGroupMaster>> GetItemCodeMastersAsyc()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT ItemCode AS ItemCode FROM OITM");
            List<ItemGroupMaster> itemCodes = new List<ItemGroupMaster>();
            foreach (DataRow a in dt.Rows)
            {
                itemCodes.Add(new ItemGroupMaster
                {
                    ItemGroup = a[0].ToString(),
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
