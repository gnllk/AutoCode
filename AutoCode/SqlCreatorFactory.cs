using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoCode.SqlCreator;

namespace AutoCode
{
    public static class SqlCreatorFactory
    {
        private static object classLock = new object();

        private static MsSqlCreator mMsSqlCreator = null;
        private static MsSqlCreator MsSqlCreator
        {
            get
            {
                if (mMsSqlCreator == null)
                {
                    lock (classLock)
                    {
                        if (mMsSqlCreator == null)
                        {
                            mMsSqlCreator = new MsSqlCreator();
                        }
                    }
                }
                return mMsSqlCreator;
            }
        }

        private static MySqlCreator mMySqlCreator = null;
        private static MySqlCreator MySqlCreator
        {
            get
            {
                if (mMySqlCreator == null)
                {
                    lock (classLock)
                    {
                        if (mMySqlCreator == null)
                        {
                            mMySqlCreator = new MySqlCreator();
                        }
                    }
                }
                return mMySqlCreator;
            }
        }

        public static ISqlCreator GetSqlCreator(DatabaseType dbtype)
        {
            switch (dbtype)
            {
                case DatabaseType.MsSqlClient: return MsSqlCreator;
                case DatabaseType.MySqlClient: return MySqlCreator;
                default: throw new NotImplementedException(string.Format("{0}的类型没有实现", dbtype.ToString()));
            }
        }

        public static void Clear()
        {
            mMsSqlCreator = null;
            mMySqlCreator = null;
        }
    }
}
