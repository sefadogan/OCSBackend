﻿using OCS.Common.Result.Abstract;

namespace OCS.Common.Result.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool isSuccessful, string message) : base(isSuccessful, message)
        {
            Data = data;
        }

        public DataResult(T data, bool isSuccessful) : base(isSuccessful)
        {
            Data = data;
        }

        public T Data { get; }
    }
}