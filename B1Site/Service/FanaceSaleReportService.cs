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
        public Task<List<CategoryMaster>> categoryMasters()
        {
            throw new NotImplementedException();
        }

        public Task<List<CustomerIDMaster>> customerIDMasters()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetFinalceSaleReportAsync(DateTime datefrom, DateTime dateto, string byitemsgroup, string bycategory, string bysaleempoyee, string byMeasure, string itemscode, string customerid, string source)
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("EXEC dbo.[USP_Item_Profit_And_Lost_NEW_V1_WebReport] '"+datefrom.ToString("yyyy-MM-dd")+"','"+dateto.ToString("yyyy-MM-dd")+"','','','','','','','','customers'");
            List<FinaceSaleReport> FinaceSaleReportList = new List<FinaceSaleReport>();
            foreach (DataRow a in dt.Rows)
            {
                try
                {
                    FinaceSaleReportList.Add(new FinaceSaleReport
                    {
                        //InvoiceDate = Convert.ToDateTime(a[0].ToString()).ToString("MMM"),
                        //CardCode = a[1].ToString(),
                        //CardName = a[2].ToString(),
                        //GroupName = a[3].ToString(),
                        //CustomerCategory = a[4].ToString(),
                        //Region = a[5].ToString(),
                        //ItemGroup = a[6].ToString(),
                        //VendorCode = a[7].ToString(),
                        //Description = a[8].ToString(),
                        //Qty = Convert.ToInt32(a[9]),
                        //Price = Convert.ToDouble(a[10].ToString()),
                        //TotalDiscount = Convert.ToDouble(a[11].ToString()),
                        //TotalNetPrice = Convert.ToDouble(a[12].ToString()),
                        //SaleEmployee = a[13].ToString(),
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

        public Task<List<ItemsCodeMaster>> ItemsCodeMasters()
        {
            throw new NotImplementedException();
        }

        public Task<List<ItemsGropMaster>> ItemsGropMaster()
        {
            throw new NotImplementedException();
        }

        public Task<List<MeasureMaster>> measureMasters()
        {
            throw new NotImplementedException();
        }

        public Task<List<SaleemployeeMaster>> SaleemployeeMasters()
        {
            throw new NotImplementedException();
        }

        public Task<List<SourceMaster>> SourceMasters()
        {
            throw new NotImplementedException();
        }
    }
}
