using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoCode.Entity;

namespace AutoCode.DataTypeConvert
{
    public abstract class DataTypeConvertBase
    {
        /// <summary>
        /// 转为C#类型
        /// </summary>
        /// <param name="entity">列实体</param>
        /// <returns></returns>
        public abstract string ConvertToDataType(ColumnNameEntity entity);

        /// <summary>
        /// 转为企业库入参类型
        /// </summary>
        /// <param name="entity">列实体</param>
        /// <returns></returns>
        public abstract string ConvertToDbType(ColumnNameEntity entity);
      
        /// <summary>
        /// 转为数据库sql类型
        /// </summary>
        /// <param name="entity">列实体</param>
        /// <returns></returns>
        public abstract string ConvertToSqlDbType(ColumnNameEntity entity);
    }
}
