using AutoCode.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoCode.SqlCreator
{
    public interface ISqlBatchCreator
    {
        void CreateBatchAddProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName);

        void CreateBatchEditProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName);

        void CreateBatchDeleteProcedure(StreamWriter writer, List<ColumnNameEntity> columns, string dbName, string tableName, string procedureName);
    }
}
