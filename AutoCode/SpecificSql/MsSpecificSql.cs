using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCode.SpecificSql
{
    public class MsSpecificSql : SpecificSqlBase
    {
        protected const string mGetDatabaseNameSql = "SELECT [name] as Name "
            + " FROM [master].[sys].[databases] where database_id > 4";

        protected const string mGetTableNameSql = "select A.name as Name, B.value as Description "
            + "from(select * from {0}..sysobjects where type = N'U') as A "
            + "left join {0}.sys.extended_properties as B "
            + "on A.id = B.major_id and B.minor_id = 0 and B.name = 'MS_Description' "
            + "order by A.name";

        protected const string mGetColumnNameSql = "select A.name as Name, A.user_type_id as ColumnUserTypeID, "
            + "A.max_length as ColumnMaxLength, A.is_identity as IsIdentity, "
            + "A.is_nullable as IsNullable, D.is_primary_key as IsPrimary, "
            + "D.is_unique as IsUnique, B.value as Description "
            + "from( select * from {0}.sys.columns where object_id = OBJECT_ID(N'{1}')) as A "
            + "left join {0}.sys.extended_properties as B "
            + "on A.object_id = B.major_id and A.column_id = B.minor_id and B.name = 'MS_Description' "
            + "left join {0}.sys.index_columns as C "
            + "on A.object_id = C.object_id and A.column_id = C.column_id "
            + "left join {0}.sys.indexes as D "
            + "on A.object_id = D.object_id and C.index_id = D.index_id";

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
