using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AutoCode.Entity;

namespace AutoCode.SqlCreator
{
    public abstract class SqlCreatorBase
    {
        public abstract void DropProcesure(StreamWriter writer, string dbName, string procedureName);

        public abstract void CreateGetProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName);

        public abstract void CreateAddProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName);

        public abstract void CreateEditProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName);

        public abstract void CreateDeleteProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName);

        public abstract void CreateGetListProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName);
    }
}
