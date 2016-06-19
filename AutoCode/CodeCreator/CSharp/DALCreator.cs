using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AutoCode.Entity;
using AutoCode.Utils;

namespace AutoCode.CodeCreator.CSharp
{
    public class DALCreator : CreatorBase
    {
        public DALCreator(TextWriter writer, GenNames names, Config config, TableNameEntity table)
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
            WriteClassComment(1, "/// ", "DAL实现");

            string interfaceName = string.Format("{0}{1}", Names.InterfaceClassName, Names.InterfaceInheritanceName);
            string dalFullName = string.Format("{0}{1}", Names.DALClassName, Names.DALInheritanceName);
            writer.WriteLine("\tpublic class {0}", InheritInterface(dalFullName, interfaceName));
            writer.WriteLine("\t{");
            writer.WriteLine("\t\t#region DAL实现");
            writer.WriteLine();

            string entityClass = Names.EntityClassName;
            string procedurePrefix = Config.ProcedurePrefix;
            string procedurePrefix_ = string.IsNullOrEmpty(procedurePrefix) ? string.Empty : procedurePrefix + "_";
            string procedureSuffix = Config.ProcedureSuffix;
            string procedureSuffix_ = string.IsNullOrEmpty(procedureSuffix) ? string.Empty : "_" + procedureSuffix;
            //Get
            writer.WriteLine("\t\t/// <summary>");
            writer.WriteLine("\t\t/// 获取一个实体数据");
            writer.WriteLine("\t\t/// </summary>");
            List<ColumnNameEntity> primaryColumn = Columns.FindAllForeach(e => e.IsPrimary);
            if (null != primaryColumn && primaryColumn.Count > 0)
            {
                string args = string.Empty;
                int count = primaryColumn.Count;
                int mcount = count - 1;
                for (int i = 0; i < count; i++)
                {
                    var item = primaryColumn[i];
                    writer.WriteLine("\t\t/// <param name=\"{0}\">{1}</param>", item.Name, item.Description);
                    if (i < mcount)
                        args += string.Format("{0} {1}, ", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                    else
                        args += string.Format("{0} {1}", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                }
                writer.WriteLine("\t\t/// <returns>返回实体，否则返回NULL</returns>");
                writer.WriteLine("\t\tpublic {0} Get({1})", entityClass, args);
                writer.WriteLine("\t\t{");
                writer.WriteLine("\t\t\tDatabase db = GetDB();");
                writer.WriteLine("\t\t\tDbCommand cmd = db.GetStoredProcCommand(\"{0}\");", string.Format("{0}{1}{2}_Get", procedurePrefix_, Names.TableName, procedureSuffix_));
                for (int i = 0; i < count; i++)
                {
                    var item = primaryColumn[i];
                    writer.WriteLine("\t\t\tdb.AddInParameter(cmd, \"{0}\", DbType.{1}, {0});", item.Name, ConfigManager.DataTypeConvertor.ConvertToDbType(item));
                }
            }
            else
            {
                writer.WriteLine("\t\t/// <param name=\"{0}\">{1}</param>", "id", "ID");
                writer.WriteLine("\t\t/// <returns>返回实体，否则返回NULL</returns>");
                writer.WriteLine("\t\tpublic {0} Get({1})", entityClass, "int id");
                writer.WriteLine("\t\t{");
                writer.WriteLine("\t\t\tDatabase db = GetDB();");
                writer.WriteLine("\t\t\tDbCommand cmd = db.GetStoredProcCommand(\"{0}\");", string.Format("{0}{1}{2}_Get", procedurePrefix_, Names.TableName, procedureSuffix_));
                writer.WriteLine("\t\t\tdb.AddInParameter(cmd, \"{0}\", DbType.{1}, {0});", "id", "Int32");
            }
            writer.WriteLine("\t\t\t{0} entity = null;", entityClass);
            writer.WriteLine("\t\t\tusing (IDataReader reader = db.ExecuteReader(cmd))");
            writer.WriteLine("\t\t\t{");
            writer.WriteLine("\t\t\t\tif (reader.Read())");
            writer.WriteLine("\t\t\t\t{");
            writer.WriteLine("\t\t\t\t\tentity = ConvertToEntity<{0}>(reader);", entityClass);
            writer.WriteLine("\t\t\t\t}");
            writer.WriteLine("\t\t\t}");
            writer.WriteLine("\t\t\treturn entity;");
            writer.WriteLine("\t\t}");
            writer.WriteLine();
            //Delete
            writer.WriteLine("\t\t/// <summary>");
            writer.WriteLine("\t\t/// 删除一个实体数据");
            writer.WriteLine("\t\t/// </summary>");
            if (null != primaryColumn && primaryColumn.Count > 0)
            {
                string args = string.Empty;
                int count = primaryColumn.Count;
                int mcount = count - 1;
                for (int i = 0; i < count; i++)
                {
                    var item = primaryColumn[i];
                    writer.WriteLine("\t\t/// <param name=\"{0}\">{1}</param>", item.Name, item.Description);
                    if (i < mcount)
                        args += string.Format("{0} {1}, ", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                    else
                        args += string.Format("{0} {1}", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                }
                writer.WriteLine("\t\t/// <returns>0失败，1成功</returns>");
                writer.WriteLine("\t\tpublic int Delete({0})", args);
                writer.WriteLine("\t\t{");
                writer.WriteLine("\t\t\tDatabase db = GetDB();");
                writer.WriteLine("\t\t\tDbCommand cmd = db.GetStoredProcCommand(\"{0}\");", string.Format("{0}{1}{2}_Delete", procedurePrefix_, Names.TableName, procedureSuffix_));
                for (int i = 0; i < count; i++)
                {
                    var item = primaryColumn[i];
                    writer.WriteLine("\t\t\tdb.AddInParameter(cmd, \"{0}\", DbType.{1}, {0});", item.Name, ConfigManager.DataTypeConvertor.ConvertToDbType(item));
                }
            }
            else
            {
                writer.WriteLine("\t\t/// <param name=\"{0}\">{1}</param>", "id", "ID");
                writer.WriteLine("\t\t/// <returns>0失败，1成功</returns>");
                writer.WriteLine("\t\tpublic int Delete({0})", "int id");
                writer.WriteLine("\t\t{");
                writer.WriteLine("\t\t\tDatabase db = GetDB();");
                writer.WriteLine("\t\t\tDbCommand cmd = db.GetStoredProcCommand(\"{0}\");", string.Format("{0}{1}{2}_Get", procedurePrefix_, Names.TableName, procedureSuffix_));
                writer.WriteLine("\t\t\tdb.AddInParameter(cmd, \"{0}\", DbType.{1}, {0});", "id", "Int32");
            }
            writer.WriteLine("\t\t\tdb.AddOutParameter(cmd, \"{0}\", DbType.{1}, 32);", "ReturnValue", "Int32");
            writer.WriteLine("\t\t\tdb.ExecuteNonQuery(cmd);");
            writer.WriteLine("\t\t\treturn Convert.ToInt32(db.GetParameterValue(cmd, \"ReturnValue\"));");
            writer.WriteLine("\t\t}");
            writer.WriteLine();
            //Edit
            writer.WriteLine("\t\t/// <summary>");
            writer.WriteLine("\t\t/// 编辑一个实体数据");
            writer.WriteLine("\t\t/// </summary>");
            writer.WriteLine("\t\t/// <param name=\"item\">实体</param>");
            writer.WriteLine("\t\t/// <returns>0失败，1成功</returns>");
            writer.WriteLine("\t\tpublic int Edit({0} item)", entityClass);
            writer.WriteLine("\t\t{");
            writer.WriteLine("\t\t\tDatabase db = GetDB();");
            writer.WriteLine("\t\t\tDbCommand cmd = db.GetStoredProcCommand(\"{0}\");", string.Format("{0}{1}{2}_Edit", procedurePrefix_, Names.TableName, procedureSuffix_));
            List<ColumnNameEntity> editList = Columns.FindAllForeach(e => e.IsIdentity == false || (e.IsIdentity && e.IsPrimary));
            if (null != editList && editList.Count > 0)
            {
                foreach (var item in editList)
                {
                    writer.WriteLine("\t\t\tdb.AddInParameter(cmd, \"{0}\", DbType.{1}, item.{0});", item.Name, ConfigManager.DataTypeConvertor.ConvertToDbType(item));
                }
            }
            writer.WriteLine("\t\t\tdb.AddOutParameter(cmd, \"{0}\", DbType.{1}, 32);", "ReturnValue", "Int32");
            writer.WriteLine("\t\t\tdb.ExecuteNonQuery(cmd);");
            writer.WriteLine("\t\t\treturn Convert.ToInt32(db.GetParameterValue(cmd, \"ReturnValue\"));");
            writer.WriteLine("\t\t}");
            writer.WriteLine();
            //Add
            writer.WriteLine("\t\t/// <summary>");
            writer.WriteLine("\t\t/// 增加一个实体数据，并更新实体的ID为新增ID");
            writer.WriteLine("\t\t/// </summary>");
            writer.WriteLine("\t\t/// <param name=\"item\">实体</param>");
            writer.WriteLine("\t\t/// <returns>0失败，1成功，2已存在</returns>");
            writer.WriteLine("\t\tpublic int Add(ref {0} item)", entityClass);
            writer.WriteLine("\t\t{");
            writer.WriteLine("\t\t\tDatabase db = GetDB();");
            writer.WriteLine("\t\t\tDbCommand cmd = db.GetStoredProcCommand(\"{0}\");", string.Format("{0}{1}{2}_Add", procedurePrefix_, Names.TableName, procedureSuffix_));
            List<ColumnNameEntity> addList = Columns.FindAllForeach(e => e.IsIdentity == false);
            if (null != addList && addList.Count > 0)
            {
                foreach (var item in addList)
                {
                    writer.WriteLine("\t\t\tdb.AddInParameter(cmd, \"{0}\", DbType.{1}, item.{0});", item.Name, ConfigManager.DataTypeConvertor.ConvertToDbType(item));
                }
            }
            writer.WriteLine("\t\t\tdb.AddOutParameter(cmd, \"{0}\", DbType.{1}, 32);", "ReturnValue", "Int32");
            ColumnNameEntity identity = Columns.FindForeach(e => e.IsIdentity);
            if (identity != null)
            {
                writer.WriteLine("\t\t\tdb.AddOutParameter(cmd, \"{0}\", DbType.{1}, 32);", "OutID", ConfigManager.DataTypeConvertor.ConvertToDbType(identity));
            }
            writer.WriteLine("\t\t\tdb.ExecuteNonQuery(cmd);");
            if (identity != null)
            {
                writer.WriteLine("\t\t\titem.{0} = Convert.To{1}(db.GetParameterValue(cmd, \"OutID\"));",
                    identity.Name, ConfigManager.DataTypeConvertor.ConvertToDbType(identity));
            }
            writer.WriteLine("\t\t\treturn Convert.ToInt32(db.GetParameterValue(cmd, \"ReturnValue\"));");
            writer.WriteLine("\t\t}");
            writer.WriteLine();
            //GetList
            writer.WriteLine("\t\t/// <summary>");
            writer.WriteLine("\t\t/// 获取数据列表");
            writer.WriteLine("\t\t/// </summary>");
            writer.WriteLine("\t\t/// <returns>返回非NULL列表</returns>");
            writer.WriteLine("\t\tpublic List<{0}> GetList()", entityClass);
            writer.WriteLine("\t\t{");
            writer.WriteLine("\t\t\tDatabase db = GetDB();");
            writer.WriteLine("\t\t\tDbCommand cmd = db.GetStoredProcCommand(\"{0}\");", string.Format("{0}{1}{2}_GetList", procedurePrefix_, Names.TableName, procedureSuffix_));
            writer.WriteLine("\t\t\tList<{0}> list = new List<{0}>();", entityClass);
            writer.WriteLine("\t\t\tusing (IDataReader reader = db.ExecuteReader(cmd))");
            writer.WriteLine("\t\t\t{");
            writer.WriteLine("\t\t\t\twhile (reader.Read())");
            writer.WriteLine("\t\t\t\t{");
            writer.WriteLine("\t\t\t\t\tvar entity = ConvertToEntity<{0}>(reader);", entityClass);
            writer.WriteLine("\t\t\t\t\tif(null != entity) list.Add(entity);");
            writer.WriteLine("\t\t\t\t}");
            writer.WriteLine("\t\t\t}");
            writer.WriteLine("\t\t\treturn list;");
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
            Writer.WriteLine("using Microsoft.Practices.EnterpriseLibrary.Data;");
            Writer.WriteLine("using System.Data.Common;");
            Writer.WriteLine("using System.Data;");
            Writer.WriteLine("using {0};", Names.EntityNameSpace);
            Writer.WriteLine("using {0};", Names.InterfaceNameSpace);
        }

        protected override void WriteNameSpace()
        {
            Writer.WriteLine("namespace {0}", Names.DALNameSpace);
        }
    }
}
