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
            var dt = clsCRUD.Getdata("select distinct U_CreditControl AS CreditControl from OCRD where U_CreditControl IS NOT NULL");
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
            var dt = clsCRUD.Getdata("SELECT Name,CAST(Code AS NVARCHAR) +' : '+Name AS 'Region'FROM OCST WHERE Country='KH'");
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
            var dt = clsCRUD.Getdata("EXEC [Customer_Aging_V2_WebReport]  '" + agingdate.ToString("yyyy-MM-dd") +
                                        "','" + customerclass + "','" + customername + "','" +
                                        creditcontrol + "','" + salemployee + "','" + region + "'");
            List<ARAgedOutstanding> aRAgedOutstandings = new List<ARAgedOutstanding>();
            foreach (DataRow a in dt.Rows)
            {
                try
                {
                    aRAgedOutstandings.Add(new ARAgedOutstanding
                    {
                        CardCode = a[0].ToString(),
                        CardName = a[1].ToString(),
                        GroupName = a[2].ToString(),
                        Region = a[3].ToString(),
                        Doc = a[4].ToString(),
                        SalePerson = a[5].ToString(),
                        SysInvoice = a[6].ToString(),
                        DO = a[7].ToString(),
                        Invoice = a[8].ToString(),
                        INVDATE = Convert.ToDateTime(a[9].ToString()).ToString("yyyy-MM-dd"),
                        Term = a[10].ToString(),
                        Aged = a[11].ToString(),
                        Balance = a[12].ToString(),
                        Current = a[13].ToString(),
                        ThirtyFirst_To_Sixty = a[14].ToString(),
                        SixtyFirst_To_Ninety = a[15].ToString(),
                        NinetyFirst_To_OneHundredTwenty = a[16].ToString(),
                        OneHundred_TwentyFirst_Till = a[17].ToString(),
                        ItemGroup = a[18].ToString(),
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