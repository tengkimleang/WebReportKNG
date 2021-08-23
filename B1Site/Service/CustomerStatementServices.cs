using B1Site.Connection;
using B1Site.Models.CustomerStatement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Service
{
    public class CustomerStatementServices : ICustomerStatementService
    {
        #region Bind master data
        public Task<List<CustomerMaster>> GetCustomerstatementsAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT CardCode,CardCode+' : '+ CardName AS Customer FROM OCRD Order By Customer");
            List<CustomerMaster> customer = new List<CustomerMaster>();
            foreach (DataRow a in dt.Rows)
            {
                customer.Add(new CustomerMaster
                {
                    CardCode = a[0].ToString(),
                    Customer = a[1].ToString()
                });
            }
            return Task.FromResult(customer);
        }
        #endregion
        #region Bind Data to report
        public Task<string> GetCustomerstatementsAsync(DateTime agingdate, string customer)
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            if (customer == "0")
            {
                customer = "";
            }
            var dt = clsCRUD.Getdata("EXEC [CUSTOMER_AGING_DETIAL_PAYMENT_CUSTOMERSTATEMENT] '" + agingdate.ToString("yyyy-MM-dd") + "','" + customer + "'");
            List<CustomerStatement> customerStatementsList = new List<CustomerStatement>();
            foreach (DataRow a in dt.Rows)
            {
                customerStatementsList.Add(new CustomerStatement
                {
                    CardCode = a[0].ToString(),
                    CardName = a[1].ToString(),
                    Region = a[2].ToString(),
                    DocType = a[3].ToString(),
                    GroupName = a[4].ToString(),
                    SLPName = a[5].ToString(),
                    SysInvoice = a[6].ToString(),
                    DO = a[7].ToString(),
                    Invoice = a[8].ToString(),
                    InvDate = Convert.ToDateTime(a[9].ToString()).ToString("yyyy-MM-dd"),
                    Term = a[10].ToString(),
                    Age = a[11].ToString(),
                    Total = a[12].ToString(),
                    Current = a[13].ToString(),
                    ThirtyFirst_To_Sixty_Days = a[14].ToString(),
                    SixtyFirst_To_Ninety_Days = a[15].ToString(),
                    NinetyFirst_To_OneHundredTwenty_Days = a[16].ToString(),
                    OneHundredTwentyOne_Untill_Days = a[17].ToString(),
                    ItemGroup = a[18].ToString(),
                    Model = a[19].ToString(),
                    DocNum = a[19].ToString(),
                    Type = a[20].ToString()
                });
            }
            return Task.FromResult(Utf8Json.JsonSerializer.ToJsonString(customer));
        }
        #endregion
    }
}
