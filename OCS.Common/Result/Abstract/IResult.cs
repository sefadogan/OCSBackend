namespace OCS.Common.Result.Abstract
{
    public interface IResult
    {
        bool IsSuccessful { get; }
        string Message { get; }
    }
}