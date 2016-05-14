using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AutoCode.Entity;
using System.Data.Common;
using AutoCode.Utils;
using AutoCode.DbFactory;
using AutoCode.SpecificSql;
using System.Text.RegularExpressions;

namespace AutoCode.CodeCreator.CSharp
{
    public abstract class CSharpCreatorBase : CodeCreatorBase
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

        private GenNames mNames = null;

        public GenNames Names
        {
            get { return mNames; }
            private set
            {
                if (value == null) throw new ArgumentNullException();
                mNames = value;
            }
        }

        public CSharpCreatorBase(TextWriter writer, Config config,
            GenNames names, TableNameEntity table, IEnumerable<ColumnNameEntity> columns)
            : base(writer, table, columns)
        {
            Config = config;
            Names = names;
        }

        protected void WriterReference()
        {
            Writer.WriteLine("using System;");
            Writer.WriteLine("using System.Collections.Generic;");
            Writer.WriteLine("using System.Linq;");
            Writer.WriteLine("using System.Text;");
        }

        protected static IList<ColumnNameEntity> GetTableColumns(DbFactoryBase db, SpecificSqlBase sql, Config config, string tableName)
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

        protected static void CreateDirectory(string fileName)
        {
            string filePath = Path.GetDirectoryName(fileName);
            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
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

        protected string GetObjectName(string tableName, string prefix, string suffix)
        {
            Regex reg = new Regex("[a-z0-9A-Z]+", RegexOptions.RightToLeft);
            Match match = reg.Match(tableName);
            return match.Success ? (prefix + FirstLetter(match.Value) + suffix)
                : (prefix + FirstLetter(tableName) + suffix);
        }

        protected string FirstLetter(string str)
        {
            switch (Config.FirstLetterSelectIndex)
            {
                case (int)FirstLetterCase.Upper: return Tools.FirstLetterToUpper(str);
                case (int)FirstLetterCase.Lower: return Tools.FirstLetterToLower(str);
                default: return str;
            }
        }

        protected string GetTableDescription(TableNameEntity table)
        {
            if (null != table && !string.IsNullOrEmpty(table.Description))
            {
                return table.Description;
            }
            return "其他";
        }
    }
}
