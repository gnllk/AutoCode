using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AutoCode.Entity;
using AutoCode.Utils;

namespace AutoCode.CodeCreator.CSharp
{
    public class InterfaceCreator : CSharpCreatorBase
    {
        public InterfaceCreator(TextWriter Writer, GenNames names, Config config, TableNameEntity table)
            : base(Writer, config, names, table,
            GetTableColumns(ConfigManager.DbFactory, ConfigManager.SpecificSql, ConfigManager.Config, names.TableName))
        { }

        public override void Generate()
        {
            WriterReference();
            CreateDirectory(Names.FileName);
            //实体命名空间
            string entitySubNSP = Config.EntitySubNamespace;
            if (entitySubNSP.Length > 0 && entitySubNSP.First() == '.') entitySubNSP = entitySubNSP.Substring(1);
            string enttiyNameSp = string.IsNullOrEmpty(entitySubNSP) ? Config.Namespace : string.Format("{0}.{1}", Config.Namespace, entitySubNSP);
            Writer.WriteLine("using {0};", enttiyNameSp);
            Writer.WriteLine();

            Writer.WriteLine("namespace {0}", Names.NameSpace);
            Writer.WriteLine("{");
            //start of class
            Writer.WriteLine("\t/// <summary>");
            Writer.WriteLine("{0}", AddFixPerLine((GetTableDescription(Table) + "接口"), "\t/// ", string.Empty));
            Writer.WriteLine("\t/// </summary>");
            Writer.WriteLine("\tpublic interface {0}", GetObjectName(Names.TableName, Names.Prefix, Names.Suffix));
            Writer.WriteLine("\t{");
            Writer.WriteLine("\t\t#region 接口");
            Writer.WriteLine();

            string entityClass = GetObjectName(Names.TableName, Config.EntityPrefix, Config.EntitySuffix);
            //Get
            Writer.WriteLine("\t\t/// <summary>");
            Writer.WriteLine("\t\t/// 获取一个实体数据");
            Writer.WriteLine("\t\t/// </summary>");
            List<ColumnNameEntity> primaryColumn = Columns.FindAllForeach(e => e.IsPrimary);
            if (null != primaryColumn && primaryColumn.Count > 0)
            {
                string args = string.Empty;
                int count = primaryColumn.Count;
                int mcount = count - 1;
                for (int i = 0; i < count; i++)
                {
                    var item = primaryColumn[i];
                    Writer.WriteLine("\t\t/// <param name=\"{0}\">{1}</param>", item.Name, item.Description);
                    if (i < mcount)
                        args += string.Format("{0} {1}, ", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                    else
                        args += string.Format("{0} {1}", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                }
                Writer.WriteLine("\t\t/// <returns>返回实体，否则返回NULL</returns>");
                Writer.WriteLine("\t\t{0} Get({1});", entityClass, args);
            }
            else
            {
                Writer.WriteLine("\t\t/// <param name=\"{0}\">{1}</param>", "id", "ID");//default
                Writer.WriteLine("\t\t/// <returns>返回实体，否则返回NULL</returns>");
                Writer.WriteLine("\t\t{0} Get({1});", entityClass, "int id");
            }
            Writer.WriteLine();
            //Delete
            Writer.WriteLine("\t\t/// <summary>");
            Writer.WriteLine("\t\t/// 删除一个实体数据");
            Writer.WriteLine("\t\t/// </summary>");
            if (null != primaryColumn && primaryColumn.Count > 0)
            {
                string args = string.Empty;
                int count = primaryColumn.Count;
                int mcount = count - 1;
                for (int i = 0; i < count; i++)
                {
                    var item = primaryColumn[i];
                    Writer.WriteLine("\t\t/// <param name=\"{0}\">{1}</param>", item.Name, item.Description);
                    if (i < mcount)
                        args += string.Format("{0} {1}, ", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                    else
                        args += string.Format("{0} {1}", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                }
                Writer.WriteLine("\t\t/// <returns>0失败，1成功</returns>");
                Writer.WriteLine("\t\tint Delete({0});", args);
            }
            else
            {
                Writer.WriteLine("\t\t/// <param name=\"{0}\">{1}</param>", "id", "ID");
                Writer.WriteLine("\t\t/// <returns>0失败，1成功</returns>");
                Writer.WriteLine("\t\tint Delete({0});", "int id");
            }

            Writer.WriteLine();
            //Edit
            Writer.WriteLine("\t\t/// <summary>");
            Writer.WriteLine("\t\t/// 编辑一个实体数据");
            Writer.WriteLine("\t\t/// </summary>");
            Writer.WriteLine("\t\t/// <param name=\"item\">实体</param>");
            Writer.WriteLine("\t\t/// <returns>0失败，1成功</returns>");
            Writer.WriteLine("\t\tint Edit({0} item);", entityClass);
            Writer.WriteLine();
            //Add
            Writer.WriteLine("\t\t/// <summary>");
            Writer.WriteLine("\t\t/// 增加一个实体数据，并更新实体的ID为新增ID");
            Writer.WriteLine("\t\t/// </summary>");
            Writer.WriteLine("\t\t/// <param name=\"item\">实体</param>");
            Writer.WriteLine("\t\t/// <returns>0失败，1成功，2已存在</returns>");
            Writer.WriteLine("\t\tint Add(ref {0} item);", entityClass);
            Writer.WriteLine();
            //GetList
            Writer.WriteLine("\t\t/// <summary>");
            Writer.WriteLine("\t\t/// 获取数据列表");
            Writer.WriteLine("\t\t/// </summary>");
            Writer.WriteLine("\t\t/// <returns>返回非NULL列表</returns>");
            Writer.WriteLine("\t\tList<{0}> GetList();", entityClass);
            Writer.WriteLine();

            Writer.WriteLine("\t\t#endregion");
            Writer.WriteLine("\t}");
            //end of class
            Writer.WriteLine("}");
            Writer.Close();
        }
    }
}
