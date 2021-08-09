using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Models.Home
{
    public class ReportDatabase
    {
        public int ID { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Language { get; set; }
        public string LanguageType { get; set; }
        public int ByOrder { get; set; }
    }
}
