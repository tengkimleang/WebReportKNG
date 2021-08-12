using B1Site.Connection;
using B1Site.Models.Home;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Service
{
    public class HomeService : IHomeService
    {
        public Task<List<CompanyDatabase>> GetCompanyDatabasesAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.GetdataWebDb("SELECT dbName AS DatabaseName,cmpName As CompanyName from SRGC", "DB");
            List<CompanyDatabase> companyDatabases = new List<CompanyDatabase>();
            foreach (DataRow a in dt.Rows)
            {
                companyDatabases.Add(new CompanyDatabase
                {
                    DataBaseName = a[0].ToString(),
                    CompanyName = a[1].ToString()
                });
            }
            return Task.FromResult(companyDatabases);
        }

        public Task<List<LanguageTypeDatabase>> GetLanguageTypeDatabasesAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.GetdataWebDb("SELECT * FROM Tb_LanguageType WHERE active=1", "WebDb");
            List<LanguageTypeDatabase> languageTypeDatabases = new List<LanguageTypeDatabase>();
            foreach (DataRow a in dt.Rows)
            {
                languageTypeDatabases.Add(new LanguageTypeDatabase
                {
                    ID=a[0].ToString(),
                    Name=a[1].ToString(),
                    Active=true,
                });
            }
            return Task.FromResult(languageTypeDatabases);
        }

        public Task<Login> GetLoginsAsync(string user, string password)
        {
            if (user == "admin" && password == "admin")
            {
                return Task.FromResult(new Login
                {
                    ID = 1,
                    Name = user.ToString(),
                    Password = password.ToString(),
                });
            }
            else
            {
                return Task.FromResult(new Login
                {
                    ID = 0,
                    Name = "",
                    Password = "",
                });
            }
        }

        public Task<List<ReportDatabase>> GetReportDatabasesAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.GetdataWebDb("SELECT * FROM Tb_Report WHERE Active=1", "WebDb");
            List<ReportDatabase> reportDatabases = new List<ReportDatabase>();
            foreach (DataRow a in dt.Rows)
            {
                try
                {
                    reportDatabases.Add(new ReportDatabase
                    {
                        ID = Convert.ToInt32(a[0].ToString()),
                        Action = a[1].ToString(),
                        Controller = a[2].ToString(),
                        Language = a[3].ToString(),
                        LanguageType = a[4].ToString(),
                        ByOrder = Convert.ToInt32(a[5].ToString()),
                    });
                }
                catch(Exception ex)
                {
                    var e1 = ex.Message;
                }
            }
            return Task.FromResult(reportDatabases);
        }
    }
}
