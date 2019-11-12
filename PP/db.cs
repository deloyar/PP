using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PP
{
    public static class Db
    {

        public static string getConnectionString()
        {
            string conn=ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            return conn;
        }
    }
}
