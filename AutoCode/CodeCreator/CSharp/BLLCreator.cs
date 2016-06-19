using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AutoCode.Entity;
using AutoCode.Utils;

namespace AutoCode.CodeCreator.CSharp
{
    public class BLLCreator : CreatorBase
    {
        public BLLCreator(TextWriter writer, GenNames names, Config config, TableNameEntity table)
            : base(config, writer, names, table,
            GetTableColumns(ConfigManager.DbFactory, ConfigManager.SpecificSql, ConfigManager.Config, names.TableName))
        { }

        public override void Generate()
        {
            var writer = Writer;
            WriteReference();
            writer.WriteLine();
            WriteNameSpace();
            writer.WriteLine("{");
            //start of class
            WriteClassComment(1, "/// ", "BLL实现");
            string bllFullName = string.Format("{0}{1}", Names.BLLClassName, Names.BLLInheritanceName);
            writer.WriteLine("\tpublic class {0}", bllFullName);
            writer.WriteLine("\t{");
            writer.WriteLine("\t\t#region BLL实现");
            writer.WriteLine();

            //属性
            writer.WriteLine("\t\tprivate {0} m_DAL = null;", Names.InterfaceClassName);
            writer.WriteLine();
            writer.WriteLine("\t\t/// <summary>");
            writer.WriteLine("\t\t/// 数据访问层");
            writer.WriteLine("\t\t/// </summary>");
            writer.WriteLine("\t\tpublic {0} DAL", Names.InterfaceClassName);
            writer.WriteLine("\t\t{");
            writer.WriteLine("\t\t\tget");
            writer.WriteLine("\t\t\t{");
            writer.WriteLine("\t\t\t\tif(null == m_DAL)");
            writer.WriteLine("\t\t\t\t{");
            writer.WriteLine("\t\t\t\t\tm_DAL = new {0}();", Names.DALClassName);
            writer.WriteLine("\t\t\t\t}");
            writer.WriteLine("\t\t\t\treturn m_DAL;");
            writer.WriteLine("\t\t\t}");
            writer.WriteLine("\t\t}");
            writer.WriteLine();
            //Get
            writer.WriteLine("\t\t/// <summary>");
            writer.WriteLine("\t\t/// 获取一个实体数据");
            writer.WriteLine("\t\t/// </summary>");
            List<ColumnNameEntity> primaryColumn = Columns.FindAllForeach(e => e.IsPrimary == true);
            if (null != primaryColumn && primaryColumn.Count > 0)
            {
                string args = string.Empty;
                string realArgs = string.Empty;
                int count = primaryColumn.Count;
                int mcount = count - 1;
                for (int i = 0; i < count; i++)
                {
                    var item = primaryColumn[i];
                    writer.WriteLine("\t\t/// <param name=\"{0}\">{1}</param>", item.Name, item.Description);
                    if (i < mcount)
                    {
                        args += string.Format("{0} {1}, ", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                        realArgs += string.Format("{0}, ", item.Name);
                    }
                    else
                    {
                        args += string.Format("{0} {1}", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                        realArgs += string.Format("{0}", item.Name);
                    }
                }
                writer.WriteLine("\t\t/// <returns>返回实体，否则返回NULL</returns>");
                writer.WriteLine("\t\tpublic {0} Get({1})", Names.EntityClassName, args);
                writer.WriteLine("\t\t{");
                writer.WriteLine("\t\t\treturn this.DAL.Get({0});", realArgs);
            }
            else
            {
                writer.WriteLine("\t\t/// <param name=\"{0}\">{1}</param>", "id", "ID");
                writer.WriteLine("\t\t/// <returns>返回实体，否则返回NULL</returns>");
                writer.WriteLine("\t\tpublic {0} Get({1})", Names.EntityClassName, "int id");
                writer.WriteLine("\t\t{");
                writer.WriteLine("\t\t\treturn this.DAL.Get({0});", "id");
            }
            writer.WriteLine("\t\t}");
            writer.WriteLine();
            //Delete
            writer.WriteLine("\t\t/// <summary>");
            writer.WriteLine("\t\t/// 删除一个实体数据");
            writer.WriteLine("\t\t/// </summary>");
            if (null != primaryColumn && primaryColumn.Count > 0)
            {
                string args = string.Empty;
                string realArgs = string.Empty;
                int count = primaryColumn.Count;
                int mcount = count - 1;
                for (int i = 0; i < count; i++)
                {
                    var item = primaryColumn[i];
                    writer.WriteLine("\t\t/// <param name=\"{0}\">{1}</param>", item.Name, item.Description);
                    if (i < mcount)
                    {
                        args += string.Format("{0} {1}, ", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                        realArgs += string.Format("{0}, ", item.Name);
                    }
                    else
                    {
                        args += string.Format("{0} {1}", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                        realArgs += string.Format("{0}", item.Name);
                    }
                }
                writer.WriteLine("\t\t/// <returns>0失败，1成功</returns>");
                writer.WriteLine("\t\tpublic int Delete({0})", args);
                writer.WriteLine("\t\t{");
                writer.WriteLine("\t\t\treturn this.DAL.Delete({0});", realArgs);
            }
            else
            {
                writer.WriteLine("\t\t/// <param name=\"{0}\">{1}</param>", "id", "ID");
                writer.WriteLine("\t\t/// <returns>0失败，1成功</returns>");
                writer.WriteLine("\t\tpublic int Delete({0})", "int id");
                writer.WriteLine("\t\t{");
                writer.WriteLine("\t\t\treturn this.DAL.Delete({0});", "id");
            }
            writer.WriteLine("\t\t}");
            writer.WriteLine();
            //Edit
            writer.WriteLine("\t\t/// <summary>");
            writer.WriteLine("\t\t/// 编辑一个实体数据");
            writer.WriteLine("\t\t/// </summary>");
            writer.WriteLine("\t\t/// <param name=\"item\">实体</param>");
            writer.WriteLine("\t\t/// <returns>0失败，1成功</returns>");
            writer.WriteLine("\t\tpublic int Edit({0} item)", Names.EntityClassName);
            writer.WriteLine("\t\t{");
            writer.WriteLine("\t\t\treturn this.DAL.Edit(item);");
            writer.WriteLine("\t\t}");
            writer.WriteLine();
            //Add
            writer.WriteLine("\t\t/// <summary>");
            writer.WriteLine("\t\t/// 增加一个实体数据，并更新实体的ID为新增ID");
            writer.WriteLine("\t\t/// </summary>");
            writer.WriteLine("\t\t/// <param name=\"item\">实体</param>");
            writer.WriteLine("\t\t/// <returns>0失败，1成功，2已存在</returns>");
            writer.WriteLine("\t\tpublic int Add(ref {0} item)", Names.EntityClassName);
            writer.WriteLine("\t\t{");
            writer.WriteLine("\t\t\treturn this.DAL.Add(ref item);");
            writer.WriteLine("\t\t}");
            writer.WriteLine();
            //GetList
            writer.WriteLine("\t\t/// <summary>");
            writer.WriteLine("\t\t/// 获取数据列表");
            writer.WriteLine("\t\t/// </summary>");
            writer.WriteLine("\t\t/// <returns>返回非NULL列表</returns>");
            writer.WriteLine("\t\tpublic List<{0}> GetList()", Names.EntityClassName);
            writer.WriteLine("\t\t{");
            writer.WriteLine("\t\t\treturn this.DAL.GetList();");
            writer.WriteLine("\t\t}");
            writer.WriteLine();

            writer.WriteLine("\t\t#endregion");
            writer.WriteLine("\t}");
            //end of class
            writer.WriteLine("}");
            writer.Close();
        }

        protected override void WriteReference()
        {
            base.WriteReference();
            Writer.WriteLine("using {0}", Names.EntityNameSpace);
            Writer.WriteLine("using {0}", Names.InterfaceNameSpace);
            Writer.WriteLine("using {0}", Names.DALNameSpace);
        }

        protected override void WriteNameSpace()
        {
            Writer.WriteLine("namespace {0}", Names.BLLNameSpace);
        }
    }
}
