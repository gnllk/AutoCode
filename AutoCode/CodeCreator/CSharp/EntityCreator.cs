using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AutoCode.Utils;
using AutoCode.Entity;

namespace AutoCode.CodeCreator.CSharp
{
    public class EntityCreator : CSharpCreatorBase
    {
        public EntityCreator(TextWriter writer, GenNames names, Config config, TableNameEntity table)
            : base(writer, config, names, table,
            GetTableColumns(ConfigManager.DbFactory, ConfigManager.SpecificSql, ConfigManager.Config, names.TableName))
        { }

        public override void Generate()
        {
            WriterReference();
            CreateDirectory(Names.FileName);
            Writer.WriteLine();
            Writer.WriteLine("namespace {0}", Names.NameSpace);
            Writer.WriteLine("{");
            //start of class
            Writer.WriteLine("\t/// <summary>");
            Writer.WriteLine("{0}", AddFixPerLine(GetTableDescription(Table), "\t/// ", string.Empty));
            Writer.WriteLine("\t/// </summary>");
            Writer.WriteLine("\tpublic class {0}", GetObjectName(Names.TableName, Names.Prefix, Names.Suffix));
            Writer.WriteLine("\t{");
            Writer.WriteLine("\t\t#region 公共属性");
            Writer.WriteLine();
            foreach (ColumnNameEntity item in Columns)
            {
                string attr = string.Format("\t\tpublic {0} {1} ", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                Writer.WriteLine("\t\t/// <summary>");
                Writer.WriteLine("\t\t/// {0}", item.Description);
                Writer.WriteLine("\t\t/// </summary>");
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
