namespace OCS.Common.Result.Abstract
{
    public interface IPagingResult<T> : IResult
    {
        IQueryable<T> Data { get; }
        int TotalItemCount { get; }
    }
}
