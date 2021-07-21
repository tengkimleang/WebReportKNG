using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using B1Site.Connection;
using B1Site.Models.Apcashoutreport;

namespace B1Site.Service
{
    public class ApcasoutreportService : IApcashoutService
    {
        #region Binding data to report
        public Task<string> GetApcastoutAsync(DateTime datefrom, DateTime dateto)
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("EXEC [AP_Report_Actual_Cash_Out_MC_V3_Webreport] '" + datefrom.ToString("yyyy-MM-dd") + "','" + dateto.ToString("yyyy-MM-dd") + "'");
            List<Apcastoutreport> ApcastoutrepotList = new List<Apcastoutreport>();
            foreach (DataRow a in dt.Rows)
            {
                ApcastoutrepotList.Add(new Apcastoutreport
                {

                    //InvoiceDate = Convert.ToDateTime(a[0].ToString()).ToString("yyyy-MM-dd"),
                    Apdocnum = a[0].ToString(),
                    DocumentDate = a[1].ToString(),
                    PaymentDoc = a[2].ToString(),
                    PaidDate = a[3].ToString(),
                    VendorName = a[4].ToString(),
                    NameVendorissueCheck = a[5].ToString(),
                    InternalDocument = a[6].ToString(),
                    ExternalDocument = a[7].ToString(),
                    Glaccount = a[8].ToString(),
                    GlaccountName = a[9].ToString(),
                    Decription = a[10].ToString(),
                    Department = a[11].ToString(),
                    Branch = a[12].ToString(),
                    ProductName = a[13].ToString(),
                    PaymentMethod = a[14].ToString(),
                    CheckNo = a[15].ToString(),
                    BankName = a[16].ToString(),
                    Cash = a[17].ToString(),
                    Debit = a[18].ToString(),
                    Credit = a[19].ToString()

                });
            }
            return Task.FromResult(Utf8Json.JsonSerializer.ToJsonString(ApcastoutrepotList));
        }
        #endregion


    }
}
