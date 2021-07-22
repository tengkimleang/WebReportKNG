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

        #region Bindeing data 
        public Task<string> GetSaleserialreport(DateTime datefrom, DateTime dateto, string byItemgroup)
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            byItemgroup = ((string.IsNullOrEmpty(byItemgroup) || byItemgroup == "0") ? "" : byItemgroup);
            var dt = clsCRUD.Getdata("EXEC [USP_SALES_DIALY_REPORT_SERIAL_01_Webreport_With_Serail] '"+datefrom.ToString("yyyy-MM-dd")+"','"+dateto.ToString("yyyy-MM-dd")+"','','"+byItemgroup+"','','','','','','',''");
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
        #endregion


    }
}
