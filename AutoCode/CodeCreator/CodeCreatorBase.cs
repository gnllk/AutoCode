using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AutoCode.Entity;
using AutoCode.DbFactory;
using AutoCode.SpecificSql;
using System.Data.Common;
using AutoCode.Utils;
using System.Text.RegularExpressions;

namespace AutoCode.CodeCreator
{
    public abstract class CodeCreatorBase : ICodeCreator
    {
        private Config mConfig = null;

        public Config Config
        {
            get { return mConfig; }
            private set
            {
                if (value == null) throw new ArgumentNullException();
                mConfig = value;
            }
        }

        private TextWriter mWriter = null;

        public TextWriter Writer
        {
            get { return mWriter; }
            private set
            {
                if (value == null) throw new ArgumentNullException();
                mWriter = value;
            }
        }

        private TableNameEntity mTable = null;

        public TableNameEntity Table
        {
            get { return mTable; }
            private set
            {
                if (value == null) throw new ArgumentNullException();
                mTable = value;
            }
        }

        private IEnumerable<ColumnNameEntity> mColumns = null;

        public IEnumerable<ColumnNameEntity> Columns
        {
            get { return mColumns; }
            private set
            {
                if (value == null) throw new ArgumentNullException();
                mColumns = value;
            }
        }

        public CodeCreatorBase(Config config, TextWriter writer, TableNameEntity table, IEnumerable<ColumnNameEntity> columns)
        {
            Config = config;
            Writer = writer;
            Columns = columns;
            Table = table;
        }

        public abstract void Generate();

        protected static List<ColumnNameEntity> GetTableColumns(DbFactoryBase db, SpecificSqlBase sql, Config config, string tableName)
        {
            string conStr = db.CreateConnStr(config.DbServerName,
                config.DbName, config.DbLoginName, config.DbLoginPwd);
            List<ColumnNameEntity> list = null;
            using (DbConnection conn = db.GetConnection(conStr))
            {
                DbCommand cmd = db.GetCommand(conn, sql.GetColumnNameSql(config.DbName, tableName));
                list = DbHelper.GetList<ColumnNameEntity>(cmd);
            }
            return list;
        }

        protected static string AddFixPerLine(string str, string prefix, string suffix)
        {
            if (!string.IsNullOrEmpty(str))
            {
                StringBuilder writer = new StringBuilder();
                StringReader reader = new StringReader(str);
                string line = reader.ReadLine();
                string next = null;
                while (!string.IsNullOrEmpty(line))
                {
                    next = reader.ReadLine();
                    if (!string.IsNullOrEmpty(next))
                        writer.AppendLine(prefix + line + suffix);
                    else
                        writer.Append(prefix + line + suffix);
                    line = next;
                }
                writer.Replace('\r', ' ', writer.Length - 2, 2);
                writer.Replace('\n', ' ', writer.Length - 2, 2);
                return writer.ToString();
            }
            return string.Empty;
        }

        protected virtual string GetTableDescription(TableNameEntity table)
        {
            if (null != table && !string.IsNullOrEmpty(table.Description))
            {
                return table.Description;
            }
            return "其他";
        }

        protected virtual string InheritInterface(string className, string _interface)
        {
            if (!string.IsNullOrEmpty(className) && !string.IsNullOrEmpty(_interface))
            {
                if (className.Contains(':'))
                {
                    return className + ", " + _interface;
                }
                else
                {
                    return className + " : " + _interface;
                }
            }
            return className;
        }

        protected virtual string FirstLetter(string str)
        {
            switch (Config.FirstLetterSelectIndex)
            {
                case (int)FirstLetterCase.Upper: return Tools.FirstLetterToUpper(str);
                case (int)FirstLetterCase.Lower: return Tools.FirstLetterToLower(str);
                default: return str;
            }
        }

        protected virtual string GetObjectName(string tableName, string prefix, string suffix, RegexOptions option = RegexOptions.RightToLeft)
        {
            Regex reg = new Regex("[a-z0-9A-Z]+", option);
            Match match = reg.Match(tableName);
            return match.Success ? (prefix + FirstLetter(match.Value) + suffix)
                : (prefix + FirstLetter(tableName) + suffix);
        }

        protected string TabString(int tabCount = 1)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < tabCount; i++)
            {
                sb.Append("\t");
            }
            return sb.ToString();
        }
    }
}
