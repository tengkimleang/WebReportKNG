using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Connection
{
    public class ConnectionString
    {
        public ConnectionString(string ConSTRWeb,string ConSTRDB,string DataSources,string userName,string passWord)
        {
            constrWeb = ConSTRWeb;
            constrDb = ConSTRDB;
            DataSource = DataSources;
            UserName = userName;
            PassWord = passWord;
        }
        public static string constr { get; set; }
        public static string constrWeb { get; set; }
        public static string constrDb { get; set; }
        public static string DataSource { get; set; }
        public static string UserName { get; set; }
        public static string PassWord { get; set; }
    }
}
