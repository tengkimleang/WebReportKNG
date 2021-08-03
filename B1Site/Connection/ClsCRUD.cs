using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Connection
{
    public class ClsCRUD
    {
        public DataTable Getdata(String sql)
        {
            DataTable tb = new DataTable();
            SqlDataAdapter dtp = new SqlDataAdapter(sql, ConnectionString.constr);
            try
            {
                dtp.Fill(tb);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return tb;
        }
        public DataTable GetdataWebDb(string sql,string type)
        {
            DataTable tb = new DataTable();
            SqlDataAdapter dtp = new SqlDataAdapter(sql, ConnectionString.constrWeb);
            try
            {
                dtp.Fill(tb);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return tb;
        }
    }
}
