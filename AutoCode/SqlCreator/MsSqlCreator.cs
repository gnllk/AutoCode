using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AutoCode.Entity;

namespace AutoCode.SqlCreator
{
    public class MsSqlCreator : ISqlCreator, ISqlBatchCreator
    {
        #region common

        public void DropProcesure(StreamWriter writer, string dbName, string procedureName)
        {
            writer.Write("--删除存储过程 {0}\r\n", procedureName);
            writer.Write("IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[{0}]') AND type in (N'P', N'PC'))\r\n"
                + "\tDROP PROCEDURE [dbo].[{0}]\r\n"
                + "GO\r\n", procedureName);
        }

        public void CreateGetProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName)
        {
            writer.Write("--创建存储过程 {0}\r\n", procedureName);
            writer.WriteLine("CREATE PROCEDURE {0}", procedureName);
            //参数
            string whereCondition = string.Empty;
            List<ColumnNameEntity> primaryColumn = columns.FindAll(e => e.IsPrimary);
            if (null != primaryColumn && primaryColumn.Count > 0)
            {
                int count = primaryColumn.Count;
                int mcount = count - 1;
                whereCondition += "WHERE ";
                for (int i = 0; i < count; i++)
                {
                    var item = primaryColumn[i];
                    if (i < mcount)
                    {
                        writer.WriteLine("\t@{0} {1},", item.Name, ConfigManager.DataTypeConvertor.ConvertToSqlDbType(item));
                        whereCondition += string.Format("{0} = @{0} AND ", item.Name);
                    }
                    else
                    {
                        writer.WriteLine("\t@{0} {1}", item.Name, ConfigManager.DataTypeConvertor.ConvertToSqlDbType(item));
                        whereCondition += string.Format("{0} = @{0} ", item.Name);
                    }
                }
            }
            else
            {
                writer.WriteLine("\t@{0} {1}", "id", "int");
                whereCondition = string.Format("WHERE {0} = @{0} ", "id");
            }
            writer.WriteLine("AS");
            writer.WriteLine("BEGIN");
            writer.WriteLine("\tSET NOCOUNT ON;");
            //逻辑
            writer.WriteLine();
            writer.WriteLine("\tSELECT TOP(1) * FROM {0} {1}", tableName, whereCondition);
            writer.WriteLine();
            writer.WriteLine("END");
            writer.WriteLine("GO");
        }

        public void CreateAddProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName)
        {
            List<ColumnNameEntity> addList = columns.FindAll(e => e.IsIdentity == false);
            if (null != addList && addList.Count > 0)
            {
                writer.Write("--创建存储过程 {0}\r\n", procedureName);
                writer.WriteLine("CREATE PROCEDURE {0}", procedureName);
                string columsSelect = string.Empty;
                string argsSelect = string.Empty;
                //参数
                int count = addList.Count;
                int mcount = count - 1;
                for (int i = 0; i < count; i++)
                {
                    var item = addList[i];
                    writer.WriteLine("\t@{0} {1},", item.Name, ConfigManager.DataTypeConvertor.ConvertToSqlDbType(item));
                    if (i < mcount)
                    {
                        columsSelect += (item.Name + ", ");
                        argsSelect += ("@" + item.Name + ", ");
                    }
                    else
                    {
                        columsSelect += item.Name;
                        argsSelect += ("@" + item.Name);
                    }
                }
                writer.WriteLine("\t@OutID int out,");
                writer.WriteLine("\t@ReturnValue int out");

                writer.WriteLine("AS");
                writer.WriteLine("BEGIN");
                writer.WriteLine("\tSET NOCOUNT ON;");
                //逻辑
                writer.WriteLine();
                writer.WriteLine("\tSET @OutID = 0;");
                writer.WriteLine("\tSET @ReturnValue = 0;");
                writer.WriteLine("\tINSERT INTO {0} ({1})", tableName, columsSelect);
                writer.WriteLine("\tVALUES({0})", argsSelect);
                writer.WriteLine("\tSET @OutID = @@IDENTITY;");
                writer.WriteLine("\tIF(@OutID > 0)");
                writer.WriteLine("\t\tSET @ReturnValue = 1;");
                writer.WriteLine();
                writer.WriteLine("END");
                writer.WriteLine("GO");
            }
        }

        public void CreateEditProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName)
        {
            List<ColumnNameEntity> editList = columns.FindAll(e => e.IsIdentity == false || (e.IsIdentity && e.IsPrimary));
            if (null != editList && editList.Count > 0)
            {
                writer.Write("--创建存储过程 {0}\r\n", procedureName);
                writer.WriteLine("CREATE PROCEDURE {0}", procedureName);
                string setSelect = string.Empty;
                string whereCondition = string.Empty;
                //参数
                int count = editList.Count;
                for (int i = 0; i < count; i++)
                {
                    var item = editList[i];
                    writer.WriteLine("\t@{0} {1},", item.Name, ConfigManager.DataTypeConvertor.ConvertToSqlDbType(item));
                    if (!item.IsPrimary && !item.IsIdentity)
                    {
                        setSelect += string.Format("{0} = @{0}, ", item.Name);
                    }
                    if (item.IsPrimary)
                    {
                        whereCondition += string.Format("{0} = @{0} AND ", item.Name);
                    }
                }
                if (!string.IsNullOrEmpty(setSelect))
                {
                    setSelect = setSelect.Substring(0, setSelect.Length - 2);
                }
                if (!string.IsNullOrEmpty(whereCondition))
                {
                    whereCondition = whereCondition.Substring(0, whereCondition.Length - 5);
                }
                writer.WriteLine("\t@ReturnValue int out");

                writer.WriteLine("AS");
                writer.WriteLine("BEGIN");
                writer.WriteLine("\tSET NOCOUNT ON;");
                //逻辑
                writer.WriteLine();
                writer.WriteLine("\tSET @ReturnValue = 0;");
                writer.WriteLine("\tUPDATE {0} SET {1}", tableName, setSelect);
                writer.WriteLine("\tWHERE {0}", whereCondition);
                writer.WriteLine("\tIF(@@ERROR = 0 AND @@ROWCOUNT > 0)");
                writer.WriteLine("\t\tSET @ReturnValue = 1;");
                writer.WriteLine();
                writer.WriteLine("END");
                writer.WriteLine("GO");
            }
        }

        public void CreateDeleteProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName)
        {
            writer.Write("--创建存储过程 {0}\r\n", procedureName);
            writer.WriteLine("CREATE PROCEDURE {0}", procedureName);
            //参数
            string whereCondition = string.Empty;
            List<ColumnNameEntity> primaryColumn = columns.FindAll(e => e.IsPrimary);
            if (null != primaryColumn && primaryColumn.Count > 0)
            {
                int count = primaryColumn.Count;
                int mcount = count - 1;
                whereCondition += "WHERE ";
                for (int i = 0; i < count; i++)
                {
                    var item = primaryColumn[i];
                    if (i < mcount)
                    {
                        writer.WriteLine("\t@{0} {1},", item.Name, ConfigManager.DataTypeConvertor.ConvertToSqlDbType(item));
                        whereCondition += string.Format("{0} = @{0} AND ", item.Name);
                    }
                    else
                    {
                        writer.WriteLine("\t@{0} {1},", item.Name, ConfigManager.DataTypeConvertor.ConvertToSqlDbType(item));
                        whereCondition += string.Format("{0} = @{0} ", item.Name);
                    }
                }
            }
            else
            {
                writer.WriteLine("\t@{0} {1}", "id", "int");
                whereCondition = string.Format("WHERE {0} = @{0} ", "id");
            }
            writer.WriteLine("\t@ReturnValue int out");
            writer.WriteLine("AS");
            writer.WriteLine("BEGIN");
            writer.WriteLine("\tSET NOCOUNT ON;");
            //逻辑
            writer.WriteLine();
            writer.WriteLine("\tSET @ReturnValue = 0;");
            writer.WriteLine("\tDELETE FROM {0} {1}", tableName, whereCondition);
            writer.WriteLine("\tIF(@@ERROR = 0 AND @@ROWCOUNT > 0)");
            writer.WriteLine("\t\tSET @ReturnValue = 1;");
            writer.WriteLine();
            writer.WriteLine("END");
            writer.WriteLine("GO");
        }

        public void CreateGetListProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName)
        {
            writer.Write("--创建存储过程 {0}\r\n", procedureName);
            writer.WriteLine("CREATE PROCEDURE {0}", procedureName);
            writer.WriteLine("AS");
            writer.WriteLine("BEGIN");
            writer.WriteLine("\tSET NOCOUNT ON;");
            //逻辑
            writer.WriteLine();
            writer.WriteLine("\tSELECT {0} * FROM {1}", string.Empty, tableName);
            writer.WriteLine();
            writer.WriteLine("END");
            writer.WriteLine("GO");
        }

        #endregion common

        #region batch

        public void CreateBatchAddProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName)
        {
            throw new NotImplementedException();
        }

        public void CreateBatchEditProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName)
        {
            throw new NotImplementedException();
        }

        public void CreateBatchDeleteProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName)
        {
            throw new NotImplementedException();
        }

        #endregion batch
    }
}
