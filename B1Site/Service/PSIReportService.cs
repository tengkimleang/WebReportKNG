using B1Site.Connection;
using B1Site.Models.PSIReport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Service
{
    public class PSIReportService : IPSIReportService
    {
        #region Bind Master
        public Task<List<CategoryMaster>> GetCategoryMastersAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT DISTINCT U_Category FROM OITM WHERE ISNULL(U_Category,'')<>'' ORDER BY U_Category");
            List<CategoryMaster> categoryMasters = new List<CategoryMaster>();
            foreach (DataRow a in dt.Rows)
            {
                categoryMasters.Add(new CategoryMaster
                {
                    Name = a[0].ToString()
                });
            }
            return Task.FromResult(categoryMasters);
        }

        public Task<List<ItemGroupMaster>> GetItemGroupMastersAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("Select ItmsGrpCod,ItmsGrpNam As ItemGroup from OITB A Where ItmsGrpCod<>117");
            List<ItemGroupMaster> itemGroupMasters = new List<ItemGroupMaster>();
            foreach (DataRow a in dt.Rows)
            {
                itemGroupMasters.Add(new ItemGroupMaster
                {
                    Code=Convert.ToInt32(a[0].ToString()),
                    Name = a[1].ToString()
                });
            }
            return Task.FromResult(itemGroupMasters);
        }
        public Task<List<SourceMaster>> GetSourceMastersAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT DISTINCT ISNULL(U_Source,'') AS Source  FROM OITM WHERE ISNULL(U_Source,'')<>''");
            List<SourceMaster> sourceMasters = new List<SourceMaster>();
            foreach (DataRow a in dt.Rows)
            {
                sourceMasters.Add(new SourceMaster
                {
                    Name = a[0].ToString()
                });
            }
            return Task.FromResult(sourceMasters);
        }

        public Task<List<UnitOfMeasureMaster>> GetUnitOfMeasureMastersAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("Select Distinct InvntryUOM As UOM From OITM   Where InvntryUom<>''");
            List<UnitOfMeasureMaster> unitOfMeasureMasters = new List<UnitOfMeasureMaster>();
            foreach (DataRow a in dt.Rows)
            {
                unitOfMeasureMasters.Add(new UnitOfMeasureMaster
                {
                    Name = a[0].ToString()
                });
            }
            return Task.FromResult(unitOfMeasureMasters);
        }
        #endregion
        #region Get Bind Data Report
        public Task<string> GetPSIReportAsync(DateTime datefrom, DateTime dateto, string itemgroup, string category, string unit, string source)
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("EXEC [dbo].[USP_KNG_PSI_Report_V2_WebReport]'" + datefrom.ToString("yyyy-MM-dd") + "','" + dateto.ToString("yyyy-MM-dd") + "','" + itemgroup + "','" + category + "','" + unit + "','" + source + "'");
            List<PSIReport> pSIReports = new List<PSIReport>();
            foreach (DataRow a in dt.Rows)
            {
                try
                {
                    pSIReports.Add(new PSIReport
                    {
                        ItemCode = a[0].ToString(),
                        Source = a[1].ToString(),
                        Category = a[2].ToString(),
                        ItemName = a[3].ToString(),
                        OpenningStock = Convert.ToInt32(a[4].ToString()),
                        InQty = Convert.ToInt32(a[5].ToString()),
                        OutQty = Convert.ToInt32(a[6].ToString()),
                        QtyAdjustment = Convert.ToInt32(a[7].ToString()),
                        EndingStock = Convert.ToInt32(a[8].ToString()),
                    });
                }catch (Exception ex)
                {
                    var a1 = ex.Message;
                }
            }
           // return Task.FromResult(pSIReports);
            return Task.FromResult(Utf8Json.JsonSerializer.ToJsonString(pSIReports));
        }
        #endregion
    }
}
