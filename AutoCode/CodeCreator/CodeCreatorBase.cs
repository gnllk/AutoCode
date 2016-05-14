using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AutoCode.Entity;

namespace AutoCode.CodeCreator
{
    public abstract class CodeCreatorBase : ICodeCreator
    {
        private TextWriter mWriter = null;

        public TextWriter Writer
        {
            get { return mWriter; }
            private set
            {
                if (value == null) throw new ArgumentNullException();
                mWriter = value;
            }
        }

        private TableNameEntity mTable = null;

        public TableNameEntity Table
        {
            get { return mTable; }
            private set
            {
                if (value == null) throw new ArgumentNullException();
                mTable = value;
            }
        }

        private IEnumerable<ColumnNameEntity> mColumns = null;

        public IEnumerable<ColumnNameEntity> Columns
        {
            get { return mColumns; }
            private set
            {
                if (value == null) throw new ArgumentNullException();
                mColumns = value;
            }
        }

        public CodeCreatorBase(TextWriter writer, TableNameEntity table, IEnumerable<ColumnNameEntity> columns)
        {
            Writer = writer;
            Columns = columns;
            Table = table;
        }

        public abstract void Generate();
    }
}
