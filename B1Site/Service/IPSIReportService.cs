using B1Site.Models.PSIReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Service
{
    public interface IPSIReportService
    {
        Task<List<CategoryMaster>> GetCategoryMastersAsync();
        Task<List<ItemGroupMaster>> GetItemGroupMastersAsync();
        Task<List<SourceMaster>> GetSourceMastersAsync();
        Task<List<UnitOfMeasureMaster>> GetUnitOfMeasureMastersAsync();
    }
}
