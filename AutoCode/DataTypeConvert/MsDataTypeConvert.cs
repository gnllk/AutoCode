using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCode.DataTypeConvert
{
    public class MsDataTypeConvert : DataTypeConvertBase
    {
        public override string ConvertToDataType(Entity.ColumnNameEntity entity)
        {
            switch (entity.ColumnUserTypeID)
            {
                case 34: return "byte[]";
                case 35: return "string";
                case 36: return "Guid";
                case 40: return entity.IsNullable ? "DateTime?" : "DateTime";
                case 41: return entity.IsNullable ? "DateTime?" : "DateTime";
                case 42: return entity.IsNullable ? "DateTime?" : "DateTime";
                case 43: return "string";
                case 48: return "int";
                case 52: return "int";
                case 56: return "int";
                case 58: return entity.IsNullable ? "DateTime?" : "DateTime";
                case 59: return "string";
                case 60: return "double";
                case 61: return entity.IsNullable ? "DateTime?" : "DateTime";
                case 62: return "float";
                case 98: return "string";
                case 99: return "string";
                case 104: return "bool";
                case 106: return "double";
                case 108: return "long";
                case 122: return "float";
                case 127: return "long";
                case 128: return "string";
                case 129: return "string";
                case 130: return "string";
                case 165: return "byte[]";
                case 167: return "string";
                case 173: return "byte[]";
                case 175: return "string";
                case 189: return "long";
                case 231: return "string";
                case 239: return "string";
                case 241: return "string";
                case 256: return "string";
                default: return "string";
            }
        }

        public override string ConvertToDbType(Entity.ColumnNameEntity entity)
        {
            switch (entity.ColumnUserTypeID)
            {
                case 34: return "Binary";
                case 35: return "String";
                case 36: return "Guid";
                case 40: return "DateTime";
                case 41: return "DateTime";
                case 42: return "DateTime";
                case 43: return "String";
                case 48: return "Int32";
                case 52: return "Int32";
                case 56: return "Int32";
                case 58: return "DateTime";
                case 59: return "String";
                case 60: return "Double";
                case 61: return "DateTime";
                case 62: return "Double";
                case 98: return "String";
                case 99: return "String";
                case 104: return "Boolean";
                case 106: return "Double";
                case 108: return "Int64";
                case 122: return "Double";
                case 127: return "Int64";
                case 128: return "String";
                case 129: return "String";
                case 130: return "String";
                case 165: return "Binary";
                case 167: return "String";
                case 173: return "Binary";
                case 175: return "String";
                case 189: return "Int64";
                case 231: return "String";
                case 239: return "String";
                case 241: return "String";
                case 256: return "String";
                default: return "String";
            }
        }

        public override string ConvertToSqlDbType(Entity.ColumnNameEntity entity)
        {
            switch (entity.ColumnUserTypeID)
            {
                case 34: return "image";
                case 35: return "text";
                case 36: return "uniqueidentifier";
                case 40: return "date";
                case 41: return "time";
                case 42: return "datetime2";
                case 43: return "datetimeoffset";
                case 48: return "tinyint";
                case 52: return "smallint";
                case 56: return "int";
                case 58: return "smalldatetime";
                case 59: return "real";
                case 60: return "money";
                case 61: return "datetime";
                case 62: return "float";
                case 98: return "sql_variant";
                case 99: return "ntext";
                case 104: return "bit";
                case 106: return "decimal";
                case 108: return "numeric";
                case 122: return "smallmoney";
                case 127: return "bigint";
                case 128: return "hierarchyid";
                case 129: return "geometry";
                case 130: return "geography";
                case 165: return string.Format("varbinary({0})", entity.ColumnMaxLength);
                case 167: return string.Format("varchar({0})", entity.ColumnMaxLength);
                case 173: return string.Format("binary({0})", entity.ColumnMaxLength);
                case 175: return string.Format("char({0})", entity.ColumnMaxLength);
                case 189: return "timestamp";
                case 231: return string.Format("nvarchar({0})", entity.ColumnMaxLength / 2);
                case 239: return string.Format("nchar({0})", entity.ColumnMaxLength / 2);
                case 241: return "xml";
                case 256: return "sysname";
                default: return "ntext";
            }
        }
    }
}
