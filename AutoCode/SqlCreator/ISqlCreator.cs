using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AutoCode.Entity;

namespace AutoCode.SqlCreator
{
    public interface ISqlCreator
    {
        void DropProcesure(StreamWriter writer, string dbName, string procedureName);

        void CreateGetProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName);

        void CreateAddProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName);

        void CreateEditProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName);

        void CreateDeleteProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName);

        void CreateGetListProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName);
    }
}
