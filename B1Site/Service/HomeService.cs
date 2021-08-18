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
                    //Active=true,
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

        public Task<bool> PostReportDatabasesAsync(ReportDatabase reportDatabase)
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.GetdataWebDb("INSERT INTO Tb_Report(Action,Controller,Language,LanguageType,ByOrder,Active) VALUES('"+reportDatabase.Action+"','"+reportDatabase.Controller+"',N'"+reportDatabase.Language+"','"+reportDatabase.LanguageType+"','"+reportDatabase.ByOrder+ "',1)SELECT SCOPE_IDENTITY();", "WebDb");
            if(dt!=null)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
        private string returnFiled(string value,string field)
        {
            if (value != "" && value!="0" && value!=null)
            {
                return field;
            }
            else
            {
                return "";
            }
        }
        private string Left(string input, int count)
        {
            return input.Substring(0, Math.Min(input.Length, count));
        }
        public Task<bool> PutReportDatabasesAsync(ReportDatabase reportDatabase)
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            string field = "";
            #region Add Field
            field = field + returnFiled(reportDatabase.Action, "Action='" + reportDatabase.Action + "',");
            field = field + returnFiled(reportDatabase.Controller, "Controller='" + reportDatabase.Controller + "',");
            field = field + returnFiled(reportDatabase.Language, "Language=N'"+reportDatabase.Language+ "',");
            field = field + returnFiled(reportDatabase.LanguageType, "LanguageType='"+reportDatabase.LanguageType+"',");
            field = field + returnFiled(reportDatabase.ByOrder.ToString(), "ByOrder='"+reportDatabase.ByOrder+"',");
            #endregion
            var dt = clsCRUD.GetdataWebDb("UPDATE Tb_Report SET "+ Left(field,field.Length-1) + " WHERE ID='"+reportDatabase.ID+"'", "WebDb") ;
            if (dt != null)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> DeleteReportDatabasesAsync(string id)
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.GetdataWebDb("UPDATE Tb_Report SET Active=0 WHERE ID="+id, "WebDb");
            if (dt != null)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
    }
}
