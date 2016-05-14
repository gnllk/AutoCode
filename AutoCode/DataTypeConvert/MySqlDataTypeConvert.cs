using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AutoCode.DataTypeConvert
{
    public class MySqlDataTypeConvert : DataTypeConvertBase
    {
        public override string ConvertToDataType(Entity.ColumnNameEntity entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.ColumnDataTypeName))
            {
                string type = entity.ColumnDataTypeName.ToUpper();

                if (type.StartsWith("BIGINT") && type.EndsWith("UNSIGNED")) return "ulong";
                else if (type.StartsWith("BIGINT")) return "long";

                if (type.StartsWith("INT") && type.EndsWith("UNSIGNED")) return "uint";
                else if (type.StartsWith("INT")) return "int";

                if (type.StartsWith("MEDIUMINT") && type.EndsWith("UNSIGNED")) return "ushort";
                else if (type.StartsWith("MEDIUMINT")) return "short";

                if (type.StartsWith("SMALLINT") && type.EndsWith("UNSIGNED")) return "ushort";
                else if (type.StartsWith("SMALLINT")) return "short";



                if (type.StartsWith("REAL")) return "double";
                if (type.StartsWith("DECIMAL")) return "decimal";
                if (type.StartsWith("DOUBLE")) return "double";
                if (type.StartsWith("FLOAT")) return "float";
                if (type.StartsWith("BIT")) return "bool";

                if (type.StartsWith("BLOB")
                    || type.StartsWith("BINARY")
                    || type.StartsWith("LONGBLOB")
                    || type.StartsWith("MEDIUMBLOB")
                    || type.StartsWith("TINYBLOB")
                    || type.StartsWith("VARBINARY")) return "byte[]";

                if (type.StartsWith("DATETIME")
                    || type.StartsWith("DATE")
                    || type.StartsWith("YEAR")
                    || type.StartsWith("TIME")) return entity.IsNullable ? "DateTime?" : "DateTime";

                if (type.StartsWith("TIMESTAMP")) return "long";

                if (type.StartsWith("VARCHAR")
                    || type.StartsWith("NVARCHAR")
                    || type.StartsWith("CHAR")
                    || type.StartsWith("TINYTEXT")
                    || type.StartsWith("TEXT")
                    || type.StartsWith("MEDIUMTEXT")
                    || type.StartsWith("LONGTEXT")) return "string";


                if (type.StartsWith("TINYINT") && GetNumberStr(type) == "1") return "bool";
                else if (type.StartsWith("TINYINT") && type.EndsWith("UNSIGNED")) return "byte";
                else if (type.StartsWith("TINYINT")) return "byte";
            }
            return "string";
        }

        private string GetNumberStr(string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                Match m = NumberReg.Match(str);
                if (m.Success)
                {
                    return m.Value;
                }
            }
            return string.Empty;
        }

        private Regex mNumberReg = null;

        private Regex NumberReg
        {
            get
            {
                if (mNumberReg == null)
                {
                    mNumberReg = new Regex(@"[0-9]+");
                }
                return mNumberReg;
            }
        }

        public override string ConvertToDbType(Entity.ColumnNameEntity entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.ColumnDataTypeName))
            {
                string type = entity.ColumnDataTypeName.ToUpper();

                if (type.StartsWith("BIGINT") && type.EndsWith("UNSIGNED")) return "UInt64";
                else if (type.StartsWith("BIGINT")) return "Int64";

                if (type.StartsWith("INT") && type.EndsWith("UNSIGNED")) return "UInt32";
                else if (type.StartsWith("INT")) return "Int32";

                if (type.StartsWith("MEDIUMINT") && type.EndsWith("UNSIGNED")) return "UInt16";
                else if (type.StartsWith("MEDIUMINT")) return "Int16";

                if (type.StartsWith("SMALLINT") && type.EndsWith("UNSIGNED")) return "UInt16";
                else if (type.StartsWith("SMALLINT")) return "Int16";

                if (type.StartsWith("TINYINT") && type.EndsWith("UNSIGNED")) return "UInt16";
                else if (type.StartsWith("TINYINT")) return "Int16";

                if (type.StartsWith("REAL")) return "Double";
                if (type.StartsWith("DECIMAL")) return "Decimal";
                if (type.StartsWith("DOUBLE")) return "Double";
                if (type.StartsWith("FLOAT")) return "Single";
                if (type.StartsWith("BIT")) return "bool";

                if (type.StartsWith("BLOB")
                    || type.StartsWith("BINARY")
                    || type.StartsWith("LONGBLOB")
                    || type.StartsWith("MEDIUMBLOB")
                    || type.StartsWith("TINYBLOB")
                    || type.StartsWith("VARBINARY")) return "Binary";

                if (type.StartsWith("DATETIME")
                    || type.StartsWith("DATE")
                    || type.StartsWith("YEAR")
                    || type.StartsWith("TIME")) return "DateTime";

                if (type.StartsWith("TIMESTAMP")) return "UInt64";

                if (type.StartsWith("VARCHAR")
                    || type.StartsWith("NVARCHAR")
                    || type.StartsWith("CHAR")
                    || type.StartsWith("TINYTEXT")
                    || type.StartsWith("TEXT")
                    || type.StartsWith("MEDIUMTEXT")
                    || type.StartsWith("LONGTEXT")) return "String";
            }
            return "String";
        }

        public override string ConvertToSqlDbType(Entity.ColumnNameEntity entity)
        {
            return entity.ColumnDataTypeName;
        }
    }
}
