using AutoCode.SqlCreator;

namespace AutoCode
{
    public interface ISqlCreatorFactory
    {
        ISqlCreator GetSqlCreator(DatabaseType dbtype);
    }
}
