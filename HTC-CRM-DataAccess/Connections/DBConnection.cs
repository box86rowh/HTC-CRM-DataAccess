using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTC_CRM_DataAccess.Connections
{
    public static class DBConnection
    {

        public static IDbConnection GetConnection()
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString);
            return conn;
        }
    }
}
