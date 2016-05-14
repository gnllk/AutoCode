using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCode.SpecificSql
{
    public class MySqlSpecificSql : SpecificSqlBase
    {
        protected const string mGetDatabaseNameSql = "SELECT SCHEMA_NAME as Name "
            + "FROM `information_schema`.`SCHEMATA`";

        protected const string mGetTableNameSql = "select table_name as Name, table_comment as Description "
            + "from information_schema.tables where TABLE_TYPE = 'BASE TABLE' and TABLE_SCHEMA='{0}'"
            + "order by table_name";

        protected const string mGetColumnNameSql = "select column_name as Name,column_comment as Description, "
            + "character_maximum_length as ColumnMaxLength, "
            + "column_type as ColumnDataTypeName, "
            + "case is_nullable when 'YES' then true else false end as IsNullable, "
            + "case column_key when 'PRI' then true else false end as IsPrimary, "
            + "case column_key when 'UNI' then true when 'PRI' then true else false end as IsUnique, "
            + "case extra when 'auto_increment' then true else false end as IsIdentity "
            + "from information_schema.columns where table_schema='{0}' and table_name='{1}'";

        public override string GetDatabaseNameSql()
        {
            return string.Format(mGetDatabaseNameSql);
        }

        public override string GetTableNameSql(string dbName)
        {
            return string.Format(mGetTableNameSql, dbName);
        }

        public override string GetColumnNameSql(string dbName, string tbName)
        {
            return string.Format(mGetColumnNameSql, dbName, tbName);
        }
    }
}
