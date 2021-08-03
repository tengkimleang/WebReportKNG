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
            var dt = clsCRUD.Getdata("SELECT GroupCode,GroupName FROM OCRG");
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
            var dt = clsCRUD.Getdata("select U_CreditControl from OCRD");
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
            var dt = clsCRUD.Getdata("SELECT CardCode,CardName FROM OCRD where CardType='C'");
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
            var dt = clsCRUD.Getdata("SELECT Name From OCST");
            List<RegionMaster> regionMasters = new List<RegionMaster>();
            foreach(DataRow a in dt.Rows)
            {
                regionMasters.Add(new RegionMaster
                { 
                    Region = a[0].ToString()
                });
            }
            return Task.FromResult(regionMasters);
        }

        public Task<List<SaleEmployeeMaster>> GetSaleEmployeeMastersAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT SlpCode,SlpName FROM OSLP");
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
        public Task<string> GetArAgedOutstandingsAsync(DateTime agingdate, string customerclass,
                                                       string creditcontrol, string customername,
                                                       string salemployee, string region)
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("EXEC[Customer_Aging_V2] '" + agingdate.ToString("yyyy-MM-dd") + "','" + customerclass +"','"
        }
        #endregion
    }
}