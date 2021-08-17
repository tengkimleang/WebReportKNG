using B1Site.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using B1Site.Models.ExspenReport;

namespace B1Site.Service
{
    public class ExspenReprotService : IExspenReportService
    {
        public Task<string> GetExspenReportAsync(DateTime datefrom, DateTime dateto)
        {
            #region Binding data to reprot
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("EXEC [USP_KNG_YAMAHA_APREPORT_R1_Web_Report] '" + datefrom.ToString("yyyy-MM-dd") + "','" + dateto.ToString("yyyy-MM-dd") + "'");
            List<ExspenReport> ExspentReprotList = new List<ExspenReport>();
            foreach (DataRow a in dt.Rows)
            {
                ExspentReprotList.Add(new ExspenReport
                {

                    TranID = Convert.ToInt32(a[0].ToString()),
                    RefDate  = Convert.ToDateTime(a[1].ToString()).ToString("dd/MM/yyyy"),
                    SerialName = a[2].ToString(),
                    Docnum = a[3].ToString(),
                    Number =Convert.ToInt32(a[4].ToString()),
                    Origion = a[5].ToString(),
                    ControlAcount = a[6].ToString(),
                    ControlAcountName = a[7].ToString(),
                    Description = a[8].ToString(),
                    ExternalDocument = a[9].ToString(),
                    InternalDocument =a[10].ToString(),
                    CheckNumber = a[11].ToString(),
                    CardCode = a[12].ToString(),
                    GLAocuntABPCode = a[13].ToString(),
                    CardName = a[14].ToString(),
                    Itemsgroup = a[15].ToString(),
                    Location = a[16].ToString(),
                    Department = a[17].ToString(),
                    Promotion = a[18].ToString (),
                    Debit = Convert.ToDouble(a[19].ToString()),
                    Credit = Convert.ToDouble(a[20].ToString())
                });
            }
            return Task.FromResult(Utf8Json.JsonSerializer.ToJsonString(ExspentReprotList));

            #endregion
        }
    }
}
