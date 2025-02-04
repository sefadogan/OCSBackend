namespace OCS.Common.Result.Abstract
{
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
    }
}