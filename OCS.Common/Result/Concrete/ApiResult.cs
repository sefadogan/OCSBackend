using OCS.Common.Result.Abstract;

namespace OCS.Common.Result.Concrete
{
    public class ApiResult<T> : IResult
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public string InternalMessage { get; set; }
        public T Data { get; set; }

        public ICollection<string> Errors { get; set; }
    }
}