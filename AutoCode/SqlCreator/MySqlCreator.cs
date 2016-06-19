using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AutoCode.Entity;

namespace AutoCode.SqlCreator
{
    public class MySqlCreator : ISqlCreator, ISqlBatchCreator
    {
        #region common

        public void DropProcesure(StreamWriter writer, string dbName, string procedureName)
        {
            writer.WriteLine("/*删除存储过程 {0}*/", procedureName);
            writer.WriteLine("USE `{0}`;", dbName);
            writer.WriteLine("DROP procedure IF EXISTS `{0}`;", procedureName);
        }

        public void CreateGetProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName)
        {
            writer.WriteLine("/*创建存储过程 {0}*/", procedureName);
            writer.WriteLine("DELIMITER $$");
            writer.WriteLine("USE `{0}`$$", dbName);
            writer.WriteLine("CREATE PROCEDURE `{0}`", procedureName);
            //参数
            writer.WriteLine("(");
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
                        writer.WriteLine("\t`{0}` {1},", item.Name, ConfigManager.DataTypeConvertor.ConvertToSqlDbType(item));
                        whereCondition += string.Format("T.`{0}` = `{0}` AND ", item.Name);
                    }
                    else
                    {
                        writer.WriteLine("\t`{0}` {1}", item.Name, ConfigManager.DataTypeConvertor.ConvertToSqlDbType(item));
                        whereCondition += string.Format("T.`{0}` = `{0}` ", item.Name);
                    }
                }
            }
            else
            {
                ColumnNameEntity first = columns.First();
                writer.WriteLine("\t`{0}` {1}", first.Name, ConfigManager.DataTypeConvertor.ConvertToSqlDbType(first));
                whereCondition = string.Format("WHERE T.`{0}` = `{0}` ", first.Name);
            }
            writer.WriteLine(")");
            writer.WriteLine("BEGIN");
            //逻辑
            writer.WriteLine();
            writer.WriteLine("\tSELECT * FROM `{0}` AS T {1} LIMIT 0,1;", tableName, whereCondition);
            writer.WriteLine();
            writer.WriteLine("END");
            writer.WriteLine("$$");
            writer.WriteLine("DELIMITER ;");
        }

        public void CreateAddProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName)
        {
            List<ColumnNameEntity> addList = columns.FindAll(e => e.IsIdentity == false);
            ColumnNameEntity identity = columns.Find(e => e.IsIdentity);
            if (null != addList && addList.Count > 0)
            {
                writer.WriteLine("/*创建存储过程 {0}；出参 ReturnValue 为0失败，1成功，2已存在；出参 OutID 为自增ID(如果存在自增ID)*/", procedureName);
                writer.WriteLine("DELIMITER $$");
                writer.WriteLine("USE `{0}`$$", dbName);
                writer.WriteLine("CREATE PROCEDURE `{0}`", procedureName);
                string columsSelect = string.Empty;
                string argsSelect = string.Empty;
                //参数
                writer.WriteLine("(");
                int count = addList.Count;
                int mcount = count - 1;
                for (int i = 0; i < count; i++)
                {
                    var item = addList[i];
                    writer.WriteLine("\t`{0}` {1},", item.Name, ConfigManager.DataTypeConvertor.ConvertToSqlDbType(item));
                    if (i < mcount)
                    {
                        columsSelect += ("`" + item.Name + "`, ");
                        argsSelect += ("`" + item.Name + "`, ");
                    }
                    else
                    {
                        columsSelect += ("`" + item.Name + "`");
                        argsSelect += ("`" + item.Name + "`");
                    }
                }
                if (identity != null)
                {
                    writer.WriteLine("\tout `OutID` {0},", ConfigManager.DataTypeConvertor.ConvertToSqlDbType(identity));
                }
                writer.WriteLine("\tout `ReturnValue` int");
                writer.WriteLine(")");

                writer.WriteLine("BEGIN");
                //逻辑
                writer.WriteLine();
                if (identity != null)
                {
                    writer.WriteLine("\tSET `OutID` = 0;");
                }
                writer.WriteLine("\tSET `ReturnValue` = 0;");
                //判断是否存在bedin
                List<ColumnNameEntity> primaryButNotIdentity = columns.FindAll(e => e.IsPrimary && e.IsIdentity == false);
                if (primaryButNotIdentity == null || primaryButNotIdentity.Count == 0)
                    primaryButNotIdentity = columns.FindAll(e => e.IsUnique && e.IsIdentity == false);
                if (primaryButNotIdentity != null && primaryButNotIdentity.Count > 0)
                {
                    string primaryWhere = string.Empty;
                    for (int i = 0; i < primaryButNotIdentity.Count; i++)
                    {
                        ColumnNameEntity item = primaryButNotIdentity[i];
                        if (i == 0)
                        {
                            primaryWhere = string.Format("where T.`{0}` = `{0}` ", item.Name);
                        }
                        else
                        {
                            primaryWhere += string.Format("and T.`{0}` = `{0}` ", item.Name);
                        }
                    }
                    writer.WriteLine("\tIF EXISTS(select 1 from `{0}` as T {1})", tableName, primaryWhere);
                    writer.WriteLine("\tTHEN");
                    writer.WriteLine("\t\tSET `ReturnValue` = 2;");
                    writer.WriteLine("\tELSE");
                    writer.WriteLine();
                }
                //判断是否存在end
                writer.WriteLine("\t\tINSERT INTO `{0}` ({1})", tableName, columsSelect);
                writer.WriteLine("\t\tVALUES({0});", argsSelect);
                if (identity != null)
                {
                    writer.WriteLine("\t\tSET `OutID` = @@IDENTITY;");
                    writer.WriteLine("\t\tIF `OutID` > 0");
                }
                else
                {
                    writer.WriteLine("\t\tIF ROW_COUNT() > 0");
                }
                writer.WriteLine("\t\tTHEN");
                writer.WriteLine("\t\t\tSET `ReturnValue` = 1;");
                writer.WriteLine("\t\tEND IF;");
                //判断是否存在bedin
                if (primaryButNotIdentity != null && primaryButNotIdentity.Count > 0)
                {
                    writer.WriteLine();
                    writer.WriteLine("\tEND IF;");
                }
                //判断是否存在end
                writer.WriteLine();
                writer.WriteLine("END");
                writer.WriteLine("$$");
                writer.WriteLine("DELIMITER ;");
            }
        }

        public void CreateEditProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName)
        {
            List<ColumnNameEntity> editList = columns.FindAll(e => e.IsIdentity == false || (e.IsIdentity && e.IsPrimary));
            if (null != editList && editList.Count > 0)
            {
                writer.WriteLine("/*创建存储过程 {0}*/", procedureName);
                writer.WriteLine("DELIMITER $$");
                writer.WriteLine("USE `{0}`$$", dbName);
                writer.WriteLine("CREATE PROCEDURE `{0}`", procedureName);
                string setSelect = string.Empty;
                string whereCondition = string.Empty;
                //参数
                writer.WriteLine("(");
                int count = editList.Count;
                ColumnNameEntity first = null;
                for (int i = 0; i < count; i++)
                {
                    var item = editList[i];
                    if (first == null) first = item;
                    writer.WriteLine("\t`{0}` {1},", item.Name, ConfigManager.DataTypeConvertor.ConvertToSqlDbType(item));
                    if (!item.IsIdentity)
                    {
                        setSelect += string.Format("T.`{0}` = `{0}`, ", item.Name);
                    }
                    if (item.IsPrimary)
                    {
                        whereCondition += string.Format("T.`{0}` = `{0}` AND ", item.Name);
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
                if (string.IsNullOrEmpty(whereCondition))
                {
                    ColumnNameEntity tempfirst = columns.First();
                    if (first == null || !tempfirst.Equals(first))
                        writer.WriteLine("\t`{0}` {1},", tempfirst.Name, ConfigManager.DataTypeConvertor.ConvertToSqlDbType(tempfirst));
                    whereCondition = string.Format("T.`{0}` = `{0}` ", tempfirst.Name);
                }
                writer.WriteLine("\tout `ReturnValue` int");
                writer.WriteLine(")");

                writer.WriteLine("BEGIN");
                //逻辑
                writer.WriteLine();
                writer.WriteLine("\tSET `ReturnValue` = 0;");
                writer.WriteLine("\tUPDATE `{0}` AS T SET {1}", tableName, setSelect);
                writer.WriteLine("\tWHERE {0};", whereCondition);
                writer.WriteLine("\tIF ROW_COUNT() > 0");
                writer.WriteLine("\tTHEN");
                writer.WriteLine("\t\tSET `ReturnValue` = 1;");
                writer.WriteLine("\tEND IF;");
                writer.WriteLine();
                writer.WriteLine("END");
                writer.WriteLine("$$");
                writer.WriteLine("DELIMITER ;");
            }
        }

        public void CreateDeleteProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName)
        {
            writer.WriteLine("/*创建存储过程 {0}*/", procedureName);
            writer.WriteLine("DELIMITER $$");
            writer.WriteLine("USE `{0}`$$", dbName);
            writer.WriteLine("CREATE PROCEDURE `{0}`", procedureName);
            //参数
            writer.WriteLine("(");
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
                        writer.WriteLine("\t`{0}` {1},", item.Name, ConfigManager.DataTypeConvertor.ConvertToSqlDbType(item));
                        whereCondition += string.Format("T.`{0}` = `{0}` AND ", item.Name);
                    }
                    else
                    {
                        writer.WriteLine("\t`{0}` {1},", item.Name, ConfigManager.DataTypeConvertor.ConvertToSqlDbType(item));
                        whereCondition += string.Format("T.`{0}` = `{0}` ", item.Name);
                    }
                }
            }
            else
            {
                ColumnNameEntity first = columns.First();
                writer.WriteLine("\t`{0}` {1},", first.Name, ConfigManager.DataTypeConvertor.ConvertToSqlDbType(first));
                whereCondition = string.Format("WHERE T.`{0}` = `{0}` ", first.Name);
            }
            writer.WriteLine("\tout `ReturnValue` int");
            writer.WriteLine(")");

            writer.WriteLine("BEGIN");
            //逻辑
            writer.WriteLine();
            writer.WriteLine("\tSET ReturnValue = 0;");
            writer.WriteLine("\tDELETE T FROM `{0}` AS T {1};", tableName, whereCondition);
            writer.WriteLine("\tIF ROW_COUNT() > 0");
            writer.WriteLine("\tTHEN");
            writer.WriteLine("\t\tSET `ReturnValue` = 1;");
            writer.WriteLine("\tEND IF;");
            writer.WriteLine();
            writer.WriteLine("END");
            writer.WriteLine("$$");
            writer.WriteLine("DELIMITER ;");
        }

        public void CreateGetListProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName)
        {
            writer.WriteLine("/*创建存储过程 {0}*/", procedureName);
            writer.WriteLine("DELIMITER $$");
            writer.WriteLine("USE `{0}`$$", dbName);
            writer.WriteLine("CREATE PROCEDURE `{0}`", procedureName);
            writer.WriteLine("()");
            writer.WriteLine("BEGIN");
            //逻辑
            writer.WriteLine();
            writer.WriteLine("\tSELECT {0} * FROM `{1}` AS T;", string.Empty, tableName);
            writer.WriteLine();
            writer.WriteLine("END");
            writer.WriteLine("$$");
            writer.WriteLine("DELIMITER ;");
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
