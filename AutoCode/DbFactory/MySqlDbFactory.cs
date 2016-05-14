using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace AutoCode.DbFactory
{
    public class MySqlDbFactory : DbFactoryBase
    {
        public override DbConnection GetConnection(string connStr)
        {
            DbConnection conn = new MySqlConnection(connStr);
            return conn;
        }

        public override string CreateConnStr(string dbServer, string dbName, string loginName, string password)
        {
            return string.Format("server={0};database={1};User Id={2};Password={3};Persist Security Info=True;",
                dbServer, dbName, loginName, password);
        }
    }
}
