using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;

namespace AutoCode.DbFactory
{
    public class MsDbFactory : DbFactoryBase
    {
        public override DbConnection GetConnection(string connStr)
        {
            DbConnection conn = new SqlConnection(connStr);
            return conn;
        }

        public override string CreateConnStr(string dbServer, string dbName, string loginName, string password)
        {
            return string.Format("Database={0};Server={1};User={2};Password={3}",
                    dbName, dbServer, loginName, password);
        }
    }
}
