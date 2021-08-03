using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
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
<<<<<<< HEAD

        internal object Getdata(object p1, object p2)
        {
            throw new NotImplementedException();
        }

        internal object Getdata(object p)
        {
            throw new NotImplementedException();
=======
        public DataTable GetdataWebDb(string sql,string type)
        {

            DataTable tb = new DataTable();
            SqlDataAdapter dtp = new SqlDataAdapter(sql, ConnectionString.constrDb);
            try
            {
                dtp.Fill(tb);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return tb;
>>>>>>> 58a55fb7e8c8d589bd0ecb1632900c7926e284f9
        }
    }
}
