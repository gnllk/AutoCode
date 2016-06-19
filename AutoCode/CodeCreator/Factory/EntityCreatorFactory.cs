using AutoCode.CodeCreator.CSharp;
using AutoCode.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoCode.CodeCreator.Factory
{
    public class EntityCreatorFactory : CodeCreatorFactoryBase
    {
        private EntityCreator mCsCreator = null;

        public EntityCreator CsCreator
        {
            get
            {
                if (mCsCreator == null)
                {
                    lock (this)
                    {
                        if (mCsCreator == null)
                        {
                            mCsCreator = new EntityCreator(TextWriter, Names, Config, TableName);
                        }
                    }
                }
                return mCsCreator;
            }
            set
            {
                mCsCreator = value;
            }
        }

        public EntityCreatorFactory(TextWriter writer, GenNames names, Config config, TableNameEntity table)
            : base(writer, names, config, table) { }

        public ICodeCreator GetCodeCreator(CodeLanType type)
        {
            switch (type)
            {
                case CodeLanType.CSharp: return CsCreator;
                case CodeLanType.Java:
                default: throw new NotImplementedException(string.Format("{0}的类型没有实现", type));
            }
        }
    }
}
