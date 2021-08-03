using B1Site.Models.SaleReportBySerialNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B1Site.Connection;
using System.Data;

namespace B1Site.Service
{
    public class SaleReportBySerailService : ISaleReportbySerialService
    {

        #region Binding data
        public Task<string> GetSaleserialreport(DateTime datefrom, DateTime dateto, string byItemgroup, string bysalemmployee, string bycategory, string bycustomerclass, string bylocation, string byinventerid, string bycustomerid, string bysoucre, string bywarhouse)
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            byItemgroup = ((string.IsNullOrEmpty(byItemgroup) || byItemgroup == "0") ? "" : byItemgroup);
            bysalemmployee = ((string.IsNullOrEmpty(bysalemmployee) || bysalemmployee == "0") ? "" : bysalemmployee);
            bycategory = ((string.IsNullOrEmpty(bycategory) || bycategory == "0") ? "" : bycategory);
            bycustomerclass = ((string.IsNullOrEmpty(bycustomerclass) || bycustomerclass == "0") ? "" : bycustomerclass);
            bylocation = ((string.IsNullOrEmpty(bylocation) || bylocation == "0") ? "" : bylocation);
            byinventerid = ((string.IsNullOrEmpty(byinventerid) || byinventerid == "0") ? "" : byinventerid);
            bycustomerid = ((string.IsNullOrEmpty(bycustomerid) || bycustomerid == "0") ? "" : bycustomerid);
            bysoucre = ((string.IsNullOrEmpty(bysoucre) || bysoucre == "0") ? "" : bysoucre);
            bywarhouse = ((string.IsNullOrEmpty(bywarhouse) || bywarhouse == "0") ? "" : bywarhouse);
            var dt = clsCRUD.Getdata("EXEC [USP_SALES_DIALY_REPORT_SERIAL_01_Webreport_With_Serail] '" + datefrom.ToString("yyyy-MM-dd") + "','" + dateto.ToString("yyyy-MM-dd") + "','"+byinventerid+"','" + byItemgroup + "','"+bycustomerclass+"','"+bysalemmployee+"','"+bysoucre+"','"+bycategory+"','"+bywarhouse+"','"+bylocation+"','"+bycustomerid+"'");
            List<SaleReportbySerial> salereportbyserialList = new List<SaleReportbySerial>();
            foreach (DataRow a in dt.Rows)
            {
                try
                {
                    salereportbyserialList.Add(new SaleReportbySerial
                    {
                        InvoiceDate = Convert.ToDateTime(a[0].ToString()).ToString("yyyy-MM-dd"),
                        SysiNvoice = a[1].ToString(),
                        Invoice = a[2].ToString(),
                        Cardcode = a[3].ToString(),
                        CardName = a[4].ToString(),
                        GroupName = a[5].ToString(),
                        ItmsGroup = a[6].ToString(),
                        Vendorcode = a[7].ToString(),
                        Decritions = a[8].ToString(),
                        OrcName = a[9].ToString(),
                        U_Color = a[10].ToString(),
                        Qulity = a[11].ToString(),
                        Intrserail = a[12].ToString(),
                        Price = a[13].ToString(),
                        Saleemployee = a[14].ToString(),
                    });
                }
                catch (Exception ex)
                {
                    var a1 = ex.Message;
                }
            }
            return Task.FromResult(Utf8Json.JsonSerializer.ToJsonString(salereportbyserialList));
        }
        #endregion
        #region Binding Master Veiw
        public Task<List<ItemGroupMaster>> GetItemGroupMastersAsyc()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT ItmsGrpNam AS ItemGroup FROM OITB");
            List<ItemGroupMaster> itemGroups = new List<ItemGroupMaster>();
            foreach (DataRow a in dt.Rows)
            {
                itemGroups.Add(new ItemGroupMaster
                {
                    ItemGroupName = a[0].ToString()
                });
            }
            return Task.FromResult(itemGroups);
        }



        public Task<List<SaleemployeeMaster>> GetSaleemployeeMastersAsyc()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT SlpCode AS Code,SlpName As SaleEmployee FROM OSLP ORDER BY SlpCode");
            List<SaleemployeeMaster> saleEmployeeMasters = new List<SaleemployeeMaster>();
            foreach (DataRow a in dt.Rows)
            {
                saleEmployeeMasters.Add(new SaleemployeeMaster
                {
                    saleemployeecode = Convert.ToInt32(a[0].ToString()),
                    saleemployeeName = a[1].ToString(),
                });
            }
            return Task.FromResult(saleEmployeeMasters);
        }

        public Task<List<CategoryMaster>> GetCategoryMastersAsyc()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT DISTINCT U_Category FROM OITM WHERE ISNULL(U_Category,'')<>'' ORDER BY U_Category");
            List<CategoryMaster> categoryMasters = new List<CategoryMaster>();
            foreach (DataRow a in dt.Rows)
            {
                categoryMasters.Add(new CategoryMaster
                {
                    CategoryName = a[0].ToString()
                });
            }
            return Task.FromResult(categoryMasters);
        }

        public Task<List<CustomerclassMaster>> GetCustomerclassMastersAsyc()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT GroupCode AS Code,GroupName AS Name FROM OCRG ORDER By GroupCode");
            List<CustomerclassMaster> customerClassMasters = new List<CustomerclassMaster>();
            foreach (DataRow a in dt.Rows)
            {
                customerClassMasters.Add(new CustomerclassMaster
                {
                    Customerclasscode = a[0].ToString(),
                    Customerclassname = a[1].ToString(),
                });
            }
            return Task.FromResult(customerClassMasters);
        }

        public Task<List<InventeryidMaster>> GetInventeryidMastersAsyc()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT ItemCode AS Code,ItemName AS Name FROM OITM WHERE ItemType='I' ORDER BY ItemCode");
            List<InventeryidMaster> inventoryIDMasters = new List<InventeryidMaster>();
            foreach (DataRow a in dt.Rows)
            {
                inventoryIDMasters.Add(new InventeryidMaster
                {
                    Inventeryidcode = a[0].ToString(),
                    Inventeryidname = a[1].ToString(),
                });
            }
            return Task.FromResult(inventoryIDMasters);
        }

        public Task<List<LocationMaster>> GetLocationMastersAsyc()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT OcrCode AS Code,OcrCode+' : '+OcrName AS Name FROM OOCR WHERE DimCode=1");
            List<LocationMaster> locationMasters = new List<LocationMaster>();
            foreach (DataRow a in dt.Rows)
            {
                locationMasters.Add(new LocationMaster
                {
                    Locationcode = a[0].ToString(),
                    LocationName = a[1].ToString(),
                });
            }
            return Task.FromResult(locationMasters);
        }

        public Task<List<SourceMaster>> GetSourceMastersAsyc()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT DISTINCT ISNULL(U_Source,'')AS Source FROM OITM WHERE ISNULL(U_Source,'')<>''  ORDER BY ISNULL(U_Source,'')");
            List<SourceMaster> sourceMasters = new List<SourceMaster>();
            foreach (DataRow a in dt.Rows)
            {
                sourceMasters.Add(new SourceMaster
                {
                    sourcename = a[0].ToString(),
                });
            }
            return Task.FromResult(sourceMasters);
        }

        public Task<List<CustomeridMaster>> GetCustomeridMastersAsyc()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT CardCode AS Code,CardName AS Name FROM OCRD Order By CardName");
            List<CustomeridMaster> cusomterIDMasters = new List<CustomeridMaster>();
            foreach (DataRow a in dt.Rows)
            {
                cusomterIDMasters.Add(new CustomeridMaster
                {
                    customeridcode = a[0].ToString(),
                    customername = a[1].ToString(),
                });
            }
            return Task.FromResult(cusomterIDMasters);
        }

        public Task<List<BywarehouseMaster>> GetBywarehousesAsyc()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT Whscode AS Code,WhsName AS Name FROM OWHS ORDER BY WhsCode");
            List<BywarehouseMaster> warehouseMasters = new List<BywarehouseMaster>();
            foreach (DataRow a in dt.Rows)
            {
                warehouseMasters.Add(new BywarehouseMaster
                {
                    warehousecode = a[0].ToString(),
                    warehousename = a[1].ToString(),
                });
            }
            return Task.FromResult(warehouseMasters);
        }
        #endregion


    }
}
