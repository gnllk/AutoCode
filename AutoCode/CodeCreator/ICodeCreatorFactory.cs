
namespace AutoCode.CodeCreator
{
    public interface ICodeCreatorFactory
    {
        ICodeCreator GetCodeCreator(CodeLanType type);
    }
}
