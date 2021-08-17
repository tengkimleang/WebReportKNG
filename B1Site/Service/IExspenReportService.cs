using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B1Site.Models.ExspenReport;

namespace B1Site.Service
{
    public  interface IExspenReportService
    {

        Task<string> GetExspenReportAsync(DateTime datefrom,DateTime dateto);
    }
}
