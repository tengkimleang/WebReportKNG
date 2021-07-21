using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Service
{
   public interface ISaleReportbySerialService
    {
        Task<string> GeSaleserialreport(DateTime datefrom,DateTime dateto,string byItemgroup);

    }
}
