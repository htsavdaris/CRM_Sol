using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CRM_DB
{
    public static class ConnectionFactory
    {

        public static IDbConnection createConnection(string ConnectionString)
        {

            SqlConnection DataConnection = new SqlConnection(ConnectionString);
            return DataConnection;
        }
    }
}
