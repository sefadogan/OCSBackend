using OCS.Common.Result.Abstract;

namespace OCS.Common.Result.Concrete
{
    public class Result : IResult
    {
        public Result(bool isSuccessful, string message) : this(isSuccessful)
        {
            Message = message;
        }

        public Result(bool isSuccessful)
        {
            IsSuccessful = isSuccessful;
        }

        public bool IsSuccessful { get; }
        public string Message { get; }
    }
}