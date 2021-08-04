using B1Site.Connection;
using B1Site.Models.ARAgedOutstanding;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Service
{
    public class ARAgedOutstandingService : IARAgedOutstandingService
    {
        #region Bind Master Data Report 
        public Task<List<CustomerClassMaster>> GetCustomerClassMastersAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT GroupCode,CAST(GroupCode AS NVARCHAR) +' : '+GroupName AS'Customer_Class' FROM OCRG");
            List<CustomerClassMaster> customerClassMasters = new List<CustomerClassMaster>();
            foreach(DataRow a in dt.Rows)
            {
                customerClassMasters.Add(new CustomerClassMaster
                {
                    CustomerClassCode = a[0].ToString(),
                    CustomerClassName = a[1].ToString()

                });
            }
            return Task.FromResult(customerClassMasters);
        }
        public Task<List<CreditControlMaster>> GetCreditControlMastersAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("select U_CreditControl AS CreditControl from OCRD");
            List<CreditControlMaster> creditControlMasters = new List<CreditControlMaster>();
            foreach(DataRow a in dt.Rows)
            {
                creditControlMasters.Add(new CreditControlMaster
                {
                    CreditControl =a[0].ToString()

                });
            }
            return Task.FromResult(creditControlMasters);
        }
        public Task<List<CustomerNameMaster>> GetCustomerNameMastersAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT CardCode,CAST(CardCode AS NVARCHAR) +' : '+CardName AS CustomerName FROM OCRD WHERE CardType='C'");
            List<CustomerNameMaster> customerNameMasters = new List<CustomerNameMaster>();
            foreach(DataRow a in dt.Rows)
            {
                customerNameMasters.Add(new CustomerNameMaster
                { 
                    CustomerNameCode = a[0].ToString(),
                    CustomerNameName = a[1].ToString()
                });
            }
            return Task.FromResult(customerNameMasters);
        }
        public Task<List<RegionMaster>> GetRegionMastersAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT Code,CAST(Code AS NVARCHAR) +' : '+Name AS 'Region' FROM OCST");
            List<RegionMaster> regionMasters = new List<RegionMaster>();
            foreach(DataRow a in dt.Rows)
            {
                regionMasters.Add(new RegionMaster
                { 
                    RegionCode = a[0].ToString(),
                    RegionName = a[1].ToString()
                });
            }
            return Task.FromResult(regionMasters);
        }
        public Task<List<SaleEmployeeMaster>> GetSaleEmployeeMastersAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT SlpCode,CAST(SlpCode as nvarchar)+' : '+SlpName AS Sale_Employee FROM OSLP Order By SlpCode");
            List<SaleEmployeeMaster> saleEmployeeMasters = new List<SaleEmployeeMaster>();
            foreach(DataRow a in dt.Rows)
            {
                saleEmployeeMasters.Add(new SaleEmployeeMaster
                { 
                    SaleEmployeeCode = a[0].ToString(),
                    SaleEmployeeName = a[1].ToString()
                });
            }
            return Task.FromResult(saleEmployeeMasters);
        }
        #endregion
        #region Bind Data to Report

        public Task<string> GetARAgedOutstandingsAsync(DateTime agingdate, string customerclass, string creditcontrol, string customername, string salemployee, string region)
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("EXEC [Customer_Aging_V2]  '" + agingdate.ToString("yyyy-MM-dd") +
                                        "','" + customerclass + "','" + customername + "','" +
                                        creditcontrol + "','" + salemployee + "','" + region + "'");
            List<ARAgedOutstanding> aRAgedOutstandings = new List<ARAgedOutstanding>();
            foreach (DataRow a in dt.Rows)
            {
                try
                {
                    aRAgedOutstandings.Add(new ARAgedOutstanding
                    {
                        Row = a[0].ToString(),
                        CardCode = a[1].ToString(),
                        CardName = a[2].ToString(),
                        Region = a[3].ToString(),
                        GroupName = a[4].ToString(),
                        Doc = a[5].ToString(),
                        SalePerson = a[6].ToString(),
                        SysInvoice = a[7].ToString(),
                        DO = a[8].ToString(),
                        Invoice = a[9].ToString(),
                        INVDATE = Convert.ToDateTime(a[1].ToString()).ToString("yyyy-MM-dd"),
                        Term = a[11].ToString(),
                        Aged = a[12].ToString(),
                        Balance = a[13].ToString(),
                        Current = a[14].ToString(),
                        ThirtyFirst_To_Sixty = a[15].ToString(),
                        SixtyFirst_To_Ninety = a[16].ToString(),
                        NinetyFirst_To_OneHundredTwenty = a[17].ToString(),
                        OneHundred_TwentyFirst_Till = a[17].ToString(),
                        ItemGroup = a[17].ToString(),
                        Model = a[17].ToString(),
                        DocTotal = a[17].ToString(),
                        GroupCode = a[17].ToString(),
                        SlpCode = a[17].ToString(),
                        Reconsum = a[17].ToString(),
                    });
                }
                catch (Exception ex)
                {
                    var a1 = ex.Message;
                }
            }
            return Task.FromResult(Utf8Json.JsonSerializer.ToJsonString(aRAgedOutstandings));
        }


        #endregion
    }
}