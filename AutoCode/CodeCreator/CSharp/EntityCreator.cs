using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AutoCode.Utils;
using AutoCode.Entity;

namespace AutoCode.CodeCreator.CSharp
{
    public class EntityCreator : CreatorBase
    {
        public EntityCreator(TextWriter writer, GenNames names, Config config, TableNameEntity table)
            : base(config, writer, names, table,
            GetTableColumns(ConfigManager.DbFactory, ConfigManager.SpecificSql, ConfigManager.Config, names.TableName))
        { }

        public override void Generate()
        {
            WriteReference();
            Writer.WriteLine();
            WriteNameSpace();
            Writer.WriteLine("{");
            //start of class
            WriteClassComment(1, "/// ", "实体");
            Writer.WriteLine("\tpublic class {0}", GetObjectName(Names.TableName, Names.Prefix, Names.Suffix));
            Writer.WriteLine("\t{");
            Writer.WriteLine("\t\t#region 公共属性");
            Writer.WriteLine();
            foreach (ColumnNameEntity item in Columns)
            {
                string attr = FirstLetter(string.Format("\t\tpublic {0} {1} ",
                    ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name));

                WriteComment(item.Description, 2, "/// ");
                Writer.WriteLine(attr + "{ get; set; }");
                Writer.WriteLine();
            }
            Writer.WriteLine("\t\t#endregion");
            Writer.WriteLine("\t}");
            //end of class
            Writer.WriteLine("}");
            Writer.Flush();
        }
    }
}
