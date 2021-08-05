using B1Site.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Service
{
    public interface IHomeService
    {
        Task<List<CompanyDatabase>> GetCompanyDatabasesAsync();
        Task<Login> GetLoginsAsync(string user, string passsword);
        Task<List<ReportDatabase>> GetReportDatabasesAsync();
        Task<List<LanguageTypeDatabase>> GetLanguageTypeDatabasesAsync();
    }
}
