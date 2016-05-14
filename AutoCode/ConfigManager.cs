using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using AutoCode.Entity;
using AutoCode.DbFactory;
using AutoCode.SpecificSql;
using AutoCode.DataTypeConvert;
using AutoCode.Utils;

namespace AutoCode
{
    /// <summary>
    /// 配置管理器
    /// </summary>
    public static class ConfigManager
    {
        private static object classLock = new object();

        private static Config m_Config = null;

        /// <summary>
        /// 配置
        /// </summary>
        public static Config Config
        {
            get
            {
                if (m_Config == null)
                    m_Config = new Config();
                return m_Config;
            }
        }

        /// <summary>
        /// 数据库工厂
        /// </summary>
        public static DbFactoryBase DbFactory { get; set; }

        /// <summary>
        /// 脚本
        /// </summary>
        public static SpecificSqlBase SpecificSql { get; set; }

        private static DataTypeConvertBase mDataTypeConvertor = null;

        /// <summary>
        /// 数据类型转换器
        /// </summary>
        public static DataTypeConvertBase DataTypeConvertor
        {
            get
            {
                if (mDataTypeConvertor == null)
                {
                    lock (classLock)
                    {
                        if (mDataTypeConvertor == null)
                        {
                            mDataTypeConvertor = DataTypeConvertFactory.GetCovertor(Config.DbType);
                        }
                    }
                }
                return mDataTypeConvertor;
            }
            set
            {
                mDataTypeConvertor = value;
            }
        }

        /// <summary>
        /// 登陆成功否
        /// </summary>
        public static bool LoginSuccess { get; set; }

        /// <summary>
        /// 是否单击了登陆
        /// </summary>
        public static bool ClickLogin { get; set; }

        /// <summary>
        /// 数据库表
        /// </summary>
        public static List<TableNameEntity> DatabaseTable { get; set; }

        /// <summary>
        /// 载入配置
        /// </summary>
        public static void LoadConfig()
        {
            try
            {
                using (FileStream fs = new FileStream("Config.json", FileMode.Open))
                {
                    StreamReader reader = new StreamReader(fs);
                    string json = reader.ReadToEnd();
                    m_Config = JsonHelper.FromJson<Config>(json);
                }
            }
            catch { }
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        public static void SaveConfig()
        {
            try
            {
                using (FileStream fs = new FileStream("Config.json", FileMode.Create))
                {
                    StreamWriter writer = new StreamWriter(fs);
                    writer.Write(JsonHelper.ToJson(ConfigManager.Config));
                    writer.Close();
                }
            }
            catch { }
        }
    }
}
