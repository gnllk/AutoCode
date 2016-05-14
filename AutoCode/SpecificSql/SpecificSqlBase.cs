using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCode.SpecificSql
{
    public abstract class SpecificSqlBase
    {
        public abstract string GetDatabaseNameSql();

        public abstract string GetTableNameSql(string dbName);

        public abstract string GetColumnNameSql(string dbName, string tbName);
    }
}
