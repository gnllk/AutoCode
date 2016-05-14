using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoCode.DataTypeConvert;

namespace AutoCode
{
    public static class DataTypeConvertFactory
    {
        public static DataTypeConvertBase GetCovertor(DatabaseType dbtype)
        {
            switch (dbtype)
            {
                case DatabaseType.MsSqlClient: return new MsDataTypeConvert();
                case DatabaseType.MySqlClient: return new MySqlDataTypeConvert();
                default: throw new NotImplementedException(string.Format("{0}的类型没有实现", dbtype.ToString()));
            }
        }
    }
}
