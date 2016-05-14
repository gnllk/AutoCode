using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace AutoCode
{
    public class Config
    {
        public Config()
        {
            SaveFilePath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Namespace = "AutoCode";
            CodeEncode = "gb2312";
            CodeEncodeSelectIndex = 0;
            ProcedureEncode = "gb2312";
            ProcedureEncodeSelectIndex = 0;
            DbType = DatabaseType.MsSqlClient;

            EntitySubNamespace = "Entity";
            EntityPrefix = string.Empty;
            EntitySuffix = "Entity";

            InterfaceSubNamespace = "IDAL";
            InterfacePrefix = "I";
            InterfaceSuffix = "DAL";

            DALSubNamespace = "DAL";
            DALPrefix = string.Empty;
            DALSuffix = "DAL : BaseDAL";

            BLLSubNamespace = "BLL";
            BLLPrefix = string.Empty;
            BLLSuffix = "BLL : BaseBLL";

            ProcedurePrefix = "AutoCode";
            ProcedureSuffix = string.Empty;

            DbServerName = "127.0.0.1";
            DbLoginName = "sa";
            DbLoginPwd = "123456";
            DbLoginTypeSelectIndex = 0;
            DbName = string.Empty;

        }

        /// <summary>
        /// 默认的配置
        /// </summary>
        public void DefaultConfig()
        {
            SaveFilePath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Namespace = "AutoCode";
            CodeEncode = "gb2312";
            CodeEncodeSelectIndex = 0;
            ProcedureEncode = "gb2312";
            ProcedureEncodeSelectIndex = 0;
            DbType = DatabaseType.MsSqlClient;

            EntitySubNamespace = "Entity";
            EntityPrefix = string.Empty;
            EntitySuffix = "Entity";

            InterfaceSubNamespace = "IDAL";
            InterfacePrefix = "I";
            InterfaceSuffix = "DAL";

            DALSubNamespace = "DAL";
            DALPrefix = string.Empty;
            DALSuffix = "DAL : BaseDAL";

            BLLSubNamespace = "BLL";
            BLLPrefix = string.Empty;
            BLLSuffix = "BLL : BaseBLL";

            ProcedurePrefix = "AutoCode";
            ProcedureSuffix = string.Empty;
        }

        #region 基本配置

        /// <summary>
        /// 基础命名空间
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// 文件保存根路径
        /// </summary>
        public string SaveFilePath { get; set; }

        /// <summary>
        /// 代码编码方式
        /// </summary>
        public string CodeEncode { get; set; }

        /// <summary>
        /// 代码编码方式定位
        /// </summary>
        public int CodeEncodeSelectIndex { get; set; }

        /// <summary>
        /// 存储过程编码方式
        /// </summary>
        public string ProcedureEncode { get; set; }

        /// <summary>
        /// 存储过程编码方式定位
        /// </summary>
        public int ProcedureEncodeSelectIndex { get; set; }

        /// <summary>
        /// 首字母大小写选项定位，0忽略，1大写，2小写
        /// </summary>
        public int FirstLetterSelectIndex { get; set; }

        #endregion 基本配置

        #region 实体配置

        public string EntitySubNamespace { get; set; }
        public string EntityPrefix { get; set; }
        public string EntitySuffix { get; set; }

        #endregion 实体配置

        #region 接口配置

        public string InterfaceSubNamespace { get; set; }
        public string InterfacePrefix { get; set; }
        public string InterfaceSuffix { get; set; }

        #endregion 接口配置

        #region DAL配置

        public string DALSubNamespace { get; set; }
        public string DALPrefix { get; set; }
        public string DALSuffix { get; set; }

        #endregion DAL配置

        #region BLL配置

        public string BLLSubNamespace { get; set; }
        public string BLLPrefix { get; set; }
        public string BLLSuffix { get; set; }

        #endregion BLL配置

        #region 数据库配置

        public DatabaseType DbType { get; set; }

        public string DbServerName { get; set; }

        public int DbLoginTypeSelectIndex { get; set; }

        public string DbLoginName { get; set; }

        public string DbLoginPwd { get; set; }

        public string DbName { get; set; }

        #endregion 数据库配置

        #region 存储过程配置

        public string ProcedurePrefix { get; set; }
        public string ProcedureSuffix { get; set; }

        #endregion 存储过程配置
    }

    public enum FirstLetterCase
    {
        Ignore = 0, Upper = 1, Lower = 2
    }
}
