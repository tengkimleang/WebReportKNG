using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Models.Home
{
    public class MasterViewCreateUser
    {
        public List<Department> Departments { get; set; }
        public List<ReportPermission> ReportPermissions { get; set; }
    }
}
