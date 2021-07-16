using B1Site.Connection;
using B1Site.Models.SaleDailyReport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Service
{
    public class SaleDailyReportService : ISaleDailyReportService
    {
        #region Bind Master Data Report
        public Task<List<CategoryMaster>> GetCategoryMastersAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT DISTINCT U_Category FROM OITM WHERE ISNULL(U_Category,'')<>'' ORDER BY U_Category");
            List<CategoryMaster> categoryMasters = new List<CategoryMaster>();
            foreach (DataRow a in dt.Rows)
            {
                categoryMasters.Add(new CategoryMaster
                {
                    Category = a[0].ToString()
                });
            }
            return Task.FromResult(categoryMasters);
        }

        public Task<List<CusomterIDMaster>> GetCusomterIDMastersAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT CardCode AS Code,CardName AS Name FROM OCRD Order By CardName");
            List<CusomterIDMaster> cusomterIDMasters = new List<CusomterIDMaster>();
            foreach (DataRow a in dt.Rows)
            {
                cusomterIDMasters.Add(new CusomterIDMaster
                {
                    Code = a[0].ToString(),
                    Name = a[1].ToString(),
                });
            }
            return Task.FromResult(cusomterIDMasters);
        }

        public Task<List<CustomerClassMaster>> GetCustomerClassMastersAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT GroupCode AS Code,GroupName AS Name FROM OCRG ORDER By GroupCode");
            List<CustomerClassMaster> customerClassMasters = new List<CustomerClassMaster>();
            foreach (DataRow a in dt.Rows)
            {
                customerClassMasters.Add(new CustomerClassMaster
                {
                    Code = Convert.ToInt32(a[0].ToString()),
                    Name = a[1].ToString(),
                });
            }
            return Task.FromResult(customerClassMasters);
        }

        public Task<List<InventoryIDMaster>> GetInventoryIDMastersAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT ItemCode AS Code,ItemName AS Name FROM OITM WHERE ItemType='I' ORDER BY ItemCode");
            List<InventoryIDMaster> inventoryIDMasters = new List<InventoryIDMaster>();
            foreach (DataRow a in dt.Rows)
            {
                inventoryIDMasters.Add(new InventoryIDMaster
                {
                    Code = a[0].ToString(),
                    Name = a[1].ToString(),
                });
            }
            return Task.FromResult(inventoryIDMasters);
        }

        public Task<List<ItemGroupMaster>> GetItemGroupMasterAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT ItmsGrpNam AS ItemGroup FROM OITB");
            List<ItemGroupMaster> itemGroups = new List<ItemGroupMaster>();
            foreach (DataRow a in dt.Rows)
            {
                itemGroups.Add(new ItemGroupMaster
                {
                    ItemGroup = a[0].ToString()
                });
            }
            return Task.FromResult(itemGroups);
        }

        public Task<List<LocationMaster>> GetLocationMastersAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT OcrCode AS Code,OcrCode+' : '+OcrName AS Name FROM OOCR WHERE DimCode=1");
            List<LocationMaster> locationMasters = new List<LocationMaster>();
            foreach (DataRow a in dt.Rows)
            {
                locationMasters.Add(new LocationMaster
                {
                    Code = a[0].ToString(),
                    Name = a[1].ToString(),
                });
            }
            return Task.FromResult(locationMasters);
        }

        public Task<List<SaleEmployeeMaster>> GetSaleEmployeeMastersAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT SlpCode AS Code,SlpName As SaleEmployee FROM OSLP ORDER BY SlpCode");
            List<SaleEmployeeMaster> saleEmployeeMasters = new List<SaleEmployeeMaster>();
            foreach (DataRow a in dt.Rows)
            {
                saleEmployeeMasters.Add(new SaleEmployeeMaster
                {
                    Code = Convert.ToInt32(a[0].ToString()),
                    SaleEmployee = a[1].ToString(),
                });
            }
            return Task.FromResult(saleEmployeeMasters);
        }

        public Task<List<SourceMaster>> GetSourceMastersAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT DISTINCT ISNULL(U_Source,'')AS Source FROM OITM WHERE ISNULL(U_Source,'')<>''  ORDER BY ISNULL(U_Source,'')");
            List<SourceMaster> sourceMasters = new List<SourceMaster>();
            foreach (DataRow a in dt.Rows)
            {
                sourceMasters.Add(new SourceMaster
                {
                    Source = a[0].ToString(),
                });
            }
            return Task.FromResult(sourceMasters);
        }

        public Task<List<WarehouseMaster>> GetWarehouseMastersAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT Whscode AS Code,WhsName AS Name FROM OWHS ORDER BY WhsCode");
            List<WarehouseMaster> warehouseMasters = new List<WarehouseMaster>();
            foreach (DataRow a in dt.Rows)
            {
                warehouseMasters.Add(new WarehouseMaster
                {
                    Code = a[0].ToString(),
                    Name = a[1].ToString(),
                });
            }
            return Task.FromResult(warehouseMasters);
        }
        #endregion
        #region Bind Data to Report
        public Task<string> GetSaleDailyReportAsync(DateTime datefrom, DateTime dateto, string byItemGroup, string bySaleEmployee, string byCategory, string byCustomerClass, string byLocation, string byInventoryID, string byCustomerID, string bySource, string byWarehouse)
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("EXEC [USP_SALES_DIALY_REPORT_SERIAL_01_WebReport] '" 
                    + datefrom.ToString("yyyy-MM-dd") + "','" + dateto.ToString("yyyy-MM-dd") 
                    + "','"+byInventoryID+"','"+byItemGroup+"','"+byCustomerClass+"','"
                    +bySaleEmployee+"','"+bySource+"','"+byCategory+"','"
                    +byWarehouse+"','"+byLocation+"','"+byCustomerID+"'");
            List<SaleDailyReport> saleDailyReportList = new List<SaleDailyReport>();
            foreach (DataRow a in dt.Rows)
            {
                try
                {
                    saleDailyReportList.Add(new SaleDailyReport
                    {
                        InvoiceDate = Convert.ToDateTime(a[0].ToString()).ToString("MMM"),
                        CardCode = a[1].ToString(),
                        CardName = a[2].ToString(),
                        GroupName = a[3].ToString(),
                        CustomerCategory = a[4].ToString(),
                        Region = a[5].ToString(),
                        ItemGroup = a[6].ToString(),
                        VendorCode = a[7].ToString(),
                        Description = a[8].ToString(),
                        Qty = Convert.ToInt32(a[9]),
                        Price=Convert.ToDouble(a[10].ToString()),
                        TotalDiscount = Convert.ToDouble(a[11].ToString()),
                        TotalNetPrice = Convert.ToDouble(a[12].ToString()),
                        SaleEmployee = a[13].ToString(),
                    });
                }
                catch(Exception ex)
                {
                    var a1= ex.Message;
                }
            }
            return Task.FromResult(Utf8Json.JsonSerializer.ToJsonString(saleDailyReportList));
        }
        #endregion
    }
}
