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

        internal object Getdata(object p1, object p2)
        {
            throw new NotImplementedException();
        }

        internal object Getdata(object p)
        {
            throw new NotImplementedException();
        }
    }
}
