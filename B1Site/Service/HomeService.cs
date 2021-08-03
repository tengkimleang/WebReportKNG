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
    }
}
