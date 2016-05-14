using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AutoCode.Entity;

namespace AutoCode.CodeCreator.CSharp
{
    public class BLLCreator : CSharpCreatorBase
    {
        public BLLCreator(TextWriter writer, GenNames names, Config config, TableNameEntity table)
            : base(writer, config, names, table,
            GetTableColumns(ConfigManager.DbFactory, ConfigManager.SpecificSql, ConfigManager.Config, names.TableName))
        { }

        public override void Generate()
        {
            throw new NotImplementedException();
        }
    }
}
