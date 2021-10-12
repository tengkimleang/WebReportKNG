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
        Task<bool> PostReportDatabasesAsync(ReportDatabase reportDatabase);
        Task<bool> PutReportDatabasesAsync(ReportDatabase reportDatabase);
        Task<bool> DeleteReportDatabasesAsync(string id);
        Task<List<User>> GetUsersAsync();
        Task<List<Department>> GetDepartmentsAsync();
        Task<List<ReportPermission>> GetReportPermissionsAsync();
        Task<bool> PostDepartmentAsync(string department);
        Task<bool> PostUsersAsync(User user);
        Task<bool> DeleteUserAsync(string id);
    }
}
