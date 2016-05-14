using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace AutoCode.DbFactory
{
    public abstract class DbFactoryBase
    {
        public abstract string CreateConnStr(string dbServer, string dbName, string loginName, string password);

        public abstract DbConnection GetConnection(string connStr);

        public virtual DbCommand GetCommand(DbConnection conn, string sql)
        {
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;
            return cmd;
        }

        public virtual DbCommand GetCommand(DbConnection conn, string procedureName, DbParameterCollection param)
        {
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = procedureName;
            if (param != null)
            {
                foreach (var p in param)
                    cmd.Parameters.Add(p);
            }
            return cmd;
        }
    }
}
