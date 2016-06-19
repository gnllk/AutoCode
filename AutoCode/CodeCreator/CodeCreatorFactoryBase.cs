using AutoCode.CodeCreator.CSharp;
using AutoCode.DbFactory;
using AutoCode.Entity;
using AutoCode.SpecificSql;
using AutoCode.Utils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Text;

namespace AutoCode.CodeCreator
{
    public abstract class CodeCreatorFactoryBase
    {
        #region private

        private Config mConfig = null;

        private GenNames mNames = null;

        private TableNameEntity mTableName = null;

        private TextWriter mTextWriter = null;

        private EntityCreator mCsCreator = null;

        #endregion

        public Config Config
        {
            get { return mConfig; }
            private set
            {
                if (value == null) throw new ArgumentNullException();
                mConfig = value;
            }
        }

        public GenNames Names
        {
            get { return mNames; }
            private set
            {
                if (value == null) throw new ArgumentNullException();
                mNames = value;
            }
        }

        public TableNameEntity TableName
        {
            get { return mTableName; }
            private set
            {
                if (value == null) throw new ArgumentNullException();
                mTableName = value;
            }
        }

        public TextWriter TextWriter
        {
            get { return mTextWriter; }
            private set
            {
                if (value == null) throw new ArgumentNullException();
                mTextWriter = value;
            }
        }

        public CodeCreatorFactoryBase(TextWriter writer, GenNames names, Config config, TableNameEntity table)
        {
            Config = config;
            TextWriter = writer;
            Names = names;
            TableName = table;
        }
    }
}
