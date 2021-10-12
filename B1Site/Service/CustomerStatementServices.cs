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
        public Task<List<CustomerStatement>> GetCustomerstatementsAsync(DateTime agingdate, string customer)
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            int row;
            if (customer == "0")
            {
                customer = "";
            }
            var dt = clsCRUD.Getdata("EXEC [USP_KNG_CUSTOMERSTATEMENT_Crystal_R1_WebReport] '" + customer + "','" + agingdate.ToString("yyyy-MM-dd") + "'");
            List<CustomerStatement> customerStatementsList = new List<CustomerStatement>();

            foreach (DataRow a in dt.Rows)
            {
                customerStatementsList.Add(new CustomerStatement
                {
                    CardCode = a[0].ToString(),
                    CardName = a[1].ToString(),
                    CardFName = a[2].ToString(),
                    BPAddress = a[3].ToString(),
                    BPPhone = a[4].ToString(),
                    INVDATE = a[5].ToString(),
                    SysInvoice = a[6].ToString(),
                    Doc = a[7].ToString(),
                    ItemGroup = a[8].ToString(),
                    Aged = a[9].ToString(),
                    Balance = a[10].ToString(),
                    KEY1 = a[11].ToString(),
                    System1Invoice = a[12].ToString(),
                    TT2 = a[13].ToString(),
                    TT4 = a[14].ToString(),
                });
            }
            
            row = customerStatementsList.Count();
            if (row == 0)
            {
                customerStatementsList.Add(new CustomerStatement
                {
                    CardCode = "",
                    CardName = "",
                    CardFName = "",
                    BPAddress = "",
                    BPPhone = "",
                    INVDATE = "",
                    SysInvoice = "",
                    Doc = "",
                    ItemGroup = "",
                    Aged = "",
                    Balance = "",
                    KEY1 = "",
                    System1Invoice = "",
                    TT2 = "",
                    TT4 = ""
                });
            }
            return Task.FromResult(customerStatementsList);
        }
        #endregion
        Task<List<TestViewModel>> ICustomerStatementService.GetTestViewModelAsync(DateTime agingdate, string customer)
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            if (customer == "0")
            {
                customer = "";
            }
            var dt = clsCRUD.Getdata("EXEC [USP_KNG_CUSTOMERSTATEMENT_Crystal_R1_WebReport] '" + customer + "','" + agingdate.ToString("yyyy-MM-dd") + "'");
            List<TestViewModel> testViewModelsList = new List<TestViewModel>();

            foreach (DataRow a in dt.Rows)
            {
                testViewModelsList.Add(new TestViewModel
                {
                    CardCode = a[0].ToString(),
                    CardName = a[1].ToString(),
                    CardFName = a[2].ToString(),
                    BPAddress = a[3].ToString(),
                    BPPhone = a[4].ToString(),
                    INVDATE = a[5].ToString(),
                    SysInvoice = a[6].ToString(),
                    Doc = a[7].ToString(),
                    ItemGroup = a[8].ToString(),
                    Aged = a[9].ToString(),
                    Balance = a[10].ToString(),
                    KEY1 = a[11].ToString(),
                    System1Invoice = a[12].ToString(),
                    TT2 = a[13].ToString(),
                    TT4 = a[14].ToString(),
                });
            }
            return Task.FromResult(testViewModelsList);
        }
    }
}

