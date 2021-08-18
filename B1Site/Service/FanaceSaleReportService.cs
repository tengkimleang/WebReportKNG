using B1Site.Models.FinalSaleReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B1Site.Connection;
using System.Data;

namespace B1Site.Service
{
    public class FanaceSaleReportService : IFinaceSaleReportService
    {
        public Task<List<CategoryMaster>> GetcategoryMastersAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT DISTINCT ISNULL(OITB.ItmsGrpNam,'') AS Category FROM OITM LEFT JOIN OITB ON OITM.ItmsGrpCod=OITB.ItmsGrpCod ORDER BY ISNULL(OITB.ItmsGrpNam,'')");
            List<CategoryMaster> CategoryMasterlist = new List<CategoryMaster>();
            foreach (DataRow a in dt.Rows)
            {
                try
                {
                    CategoryMasterlist.Add(new CategoryMaster
                    {
                        Category = a[0].ToString(),
                    });
                }catch(Exception ex)
                {
                    var ex1 = ex.Message;
                }
               
            }
            return Task.FromResult(CategoryMasterlist);
        }

        public Task<List<CustomerIDMaster>> GetcustomerIDMastersAync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT CardCode,CardCode+' : '+ CardName AS CustomerID FROM OCRD");
            List<CustomerIDMaster> CustomerIDMasterlist = new List<CustomerIDMaster>();
            foreach (DataRow a in dt.Rows)
            {
                try
                {
                    CustomerIDMasterlist.Add(new CustomerIDMaster
                    {
                        CustomerCode = a[0].ToString(),
                        CustomerName = a[1].ToString()

                    });
                }catch(Exception ex)
                {
                    var ex1 = ex.Message;
                }
                
            }
            return Task.FromResult(CustomerIDMasterlist);
        }
        public Task<string> GetFinalceSaleReportAsync(DateTime datefrom, DateTime dateto, string byitemsgroup, string bycategory, string bysaleempoyee, string byMeasure, string itemscode, string customerid, string source)
        {
            byitemsgroup = ((string.IsNullOrEmpty(byitemsgroup) || byitemsgroup == "0") ? "" : byitemsgroup);
            bycategory = ((string.IsNullOrEmpty(bycategory) || bycategory == "0") ? "" : bycategory);
            bysaleempoyee = ((string.IsNullOrEmpty(bysaleempoyee) || bysaleempoyee == "0") ? "" : bysaleempoyee);
            byMeasure = ((string.IsNullOrEmpty(byMeasure) || byMeasure == "0") ? "" : byMeasure);
            itemscode = ((string.IsNullOrEmpty(itemscode) || itemscode == "0") ? "" : itemscode);
            customerid = ((string.IsNullOrEmpty(customerid) || customerid == "0") ? "" : customerid);
            source = ((string.IsNullOrEmpty(source) || source == "0") ? "" : source);
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("EXEC dbo.[USP_Item_Profit_And_Lost_NEW_V1_WebReport] '"+datefrom.ToString("yyyy-MM-dd")+"','"+dateto.ToString("yyyy-MM-dd")+"','"+byitemsgroup+"','"+ bysaleempoyee +"','"+bycategory+"','"+byMeasure+"','"+itemscode+"','"+customerid+"','"+source+"','customers'");
            List<FinaceSaleReport> FinaceSaleReportList = new List<FinaceSaleReport>();
            foreach (DataRow a in dt.Rows)
            {
                try
                {
                    FinaceSaleReportList.Add(new FinaceSaleReport
                    {
                        Cardcode = a[0].ToString(),
                        CarName = a[1].ToString(),
                        CustomerGroup = a[2].ToString(),
                        CustomerGrade = a[3].ToString(),
                        Stae = a[4].ToString(),
                        Saler = a[5].ToString(),
                        SONo = a[6].ToString(),
                        DONo = a[7].ToString(),
                        InvNo = a[8].ToString(),
                        InvDate = a[9].ToString(),
                        Status = a[10].ToString(),
                        Group = a[11].ToString(),
                        Product = a[12].ToString(),
                        InventeryId = a[13].ToString(),
                        VenderCode = a[14].ToString(),
                        ItemsName = a[15].ToString(),
                        U_Source = a[16].ToString(),
                        SubCategory = a[17].ToString(),
                        U_SubCategory = a[18].ToString(),
                        U_Movement = a[19].ToString(),
                        U_Condition = a[20].ToString(),
                        U_Model = a[21].ToString(),
                        U_Year = a[22].ToString(),
                        Location = a[23].ToString(),
                        Deparment = a[24].ToString(),
                        Promotion =a[25].ToString(),
                        Warranly = a[26].ToString(),
                        whs = a[27].ToString(),
                        Price = a[28].ToString(),
                        DisAmount = a[29].ToString(),
                        Quanlity = a[30].ToString(),
                        TotalAmount = a[31].ToString(),
                        TotalDiscountAmount = a[32].ToString(),
                        NetAmount = a[33].ToString(),
                        COGSAmount = a[34].ToString(),
                        GrossProfit = a[35].ToString(),
                        Margin = a[36].ToString(),
                        InvntryUom = a[37].ToString(),
                        ItemsGroupforSV = a[38].ToString()                    
                    });
                }
                catch (Exception ex)
                {
                    var a1 = ex.Message;
                }
            }
            return Task.FromResult(Utf8Json.JsonSerializer.ToJsonString(FinaceSaleReportList));
        }

        public Task<List<ItemsCodeMaster>> GetItemsCodeMastersAync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT ItemCode,ItemCode + ' : ' + ItemName AS InventoryID FROM OITM WHERE ItemType='I' ORDER BY ItemCode");
            List<ItemsCodeMaster> ItemsCodeMasterlist = new List<ItemsCodeMaster>();
            foreach (DataRow a in dt.Rows)
            {
                try
                {
                    ItemsCodeMasterlist.Add(new ItemsCodeMaster
                    {
                        Itemscode = a[0].ToString(),
                        ItemsName = a[1].ToString()

                    });
                }catch(Exception ex)
                {
                    var a1 = ex.Message;
                }
            }
            return Task.FromResult(ItemsCodeMasterlist);
        }

        public Task<List<ItemsGropMaster>> GetItemsGropMasterAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT ItmsGrpCod,RTRIM(CONVERT(NVARCHAR(100),ItmsGrpCod) + ' - '+ ItmsGrpNam) AS 'ItemGroup' FROM OITB ORDER BY ItmsGrpCod");
            List<ItemsGropMaster> itemsGropMasterslist = new List<ItemsGropMaster>();
            foreach (DataRow a in dt.Rows)
            {
                try
                {
                    itemsGropMasterslist.Add(new ItemsGropMaster
                    {
                        ItemsGroupCode = a[0].ToString(),
                        ItemsGoupName = a[1].ToString()

                    });
                }
                catch(Exception ex)
                {
                    var a1 = ex.Message;
                }
                
            }
            return Task.FromResult(itemsGropMasterslist);
        }

        public Task<List<MeasureMaster>> GetmeasureMastersAync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("Select Distinct InvntryUOM As Unit From OITM Where InvntryUom Is Not Null order by InvntryUom ASC");
            List<MeasureMaster> MeasureMasterlist = new List<MeasureMaster>();
            foreach (DataRow a in dt.Rows)
            {
                try
                {
                    MeasureMasterlist.Add(new MeasureMaster
                    {
                        MeasureName = a[0].ToString()
                    });
                }catch(Exception ex)
                {
                    var a1 = ex.Message;
                }
            }
            return Task.FromResult(MeasureMasterlist);
        }

        public Task<List<SaleemployeeMaster>> GetSaleemployeeMastersAync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT SlpCode,Cast(SlpCode As varchar(100))+' : '+SlpName AS SaleMan FROM OSLP WHERE SlpCode > 0");
            List<SaleemployeeMaster> SaleeemployeeMasterlist = new List<SaleemployeeMaster>();
            foreach (DataRow a in dt.Rows)
            {
                try
                {
                    SaleeemployeeMasterlist.Add(new SaleemployeeMaster
                    {
                        SaleEmployeeCode = Convert.ToInt32(a[0].ToString()),
                        SaleeEmployeeName = a[1].ToString()
                    });
                }catch(Exception ex)
                {
                    var a1 = ex.Message;
                }
                
            }
            return Task.FromResult(SaleeemployeeMasterlist);
        }

        public Task<List<SourceMaster>> GetSourceMastersAync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT DISTINCT ISNULL(U_Source,'') AS Source  FROM OITM Where U_Source<>'-'and U_Source<>'' ORDER BY ISNULL(U_Source,'')");
            List<SourceMaster> SourceMasterlist = new List<SourceMaster>();
            foreach (DataRow a in dt.Rows)
            {
                try
                {
                    SourceMasterlist.Add(new SourceMaster
                    {
                        SourceName = a[0].ToString()
                    });
                }catch(Exception ex)
                {
                    var a1 = ex.Message;
                }
                
            }
            return Task.FromResult(SourceMasterlist);
        }
    }
}
