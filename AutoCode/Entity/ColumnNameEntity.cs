using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCode.Entity
{
    public class ColumnNameEntity
    {
        /// <summary>
        /// 列名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 列描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 列的数据ID(一般用于区分MSDB)
        /// </summary>
        public int ColumnUserTypeID { get; set; }

        /// <summary>
        /// 列的数据类型名称
        /// </summary>
        public string ColumnDataTypeName { get; set; }

        /// <summary>
        /// 数据的长度(字节)
        /// </summary>
        public int ColumnMaxLength { get; set; }

        /// <summary>
        /// 是否是主键列
        /// </summary>
        public bool IsPrimary { get; set; }

        /// <summary>
        /// 是否是标识列
        /// </summary>
        public bool IsIdentity { get; set; }

        /// <summary>
        /// 是否是唯一列
        /// </summary>
        public bool IsUnique { get; set; }

        /// <summary>
        /// 是否为UNLL
        /// </summary>
        public bool IsNullable { get; set; }
    }
}
