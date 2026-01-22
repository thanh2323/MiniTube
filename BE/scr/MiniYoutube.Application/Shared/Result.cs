using System;

namespace MiniYoutube.Application.Shared
{
    public class Result
    {

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }


        protected Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None)
            {
                throw new InvalidOperationException();
            }

            if (!isSuccess && error == Error.None)
            {
                throw new InvalidOperationException();
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        // Ensure: Conditions must be met
        public Result Ensure(Func<bool> predicate, Error error)
        {
            if (IsFailure)
            {
                return this;
            }

            return predicate() ? this : Failure(error);
        }

        // Match: Return value based on state
        public TOut Match<TOut>(Func<TOut> onSuccess, Func<Error, TOut> onFailure)
        {
            return IsSuccess ? onSuccess() : onFailure(Error);
        }

        public static Result Success() => new(true, Error.None);
        public static Result Failure(Error error) => new(false, error);
        public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);
        public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);
        public static Result<TValue> Create<TValue>(TValue? value) => value is not null ? Success(value) : Failure<TValue>(Error.None);


    }

    public class Result<TValue> : Result
    {
        private readonly TValue? _value;

        protected internal Result(TValue? value, bool isSuccess, Error error)
            : base(isSuccess, error)
        {
            _value = value;
        }

        public TValue Value => IsSuccess
            ? _value!
            : throw new InvalidOperationException("The value of a failure result can not be accessed.");

        public static implicit operator Result<TValue>(TValue value) => Success(value);

        // Map: Transform value
        public Result<TNew> Map<TNew>(Func<TValue, TNew> mapping)
        {
            return IsSuccess ? Result.Success(mapping(Value)) : Result.Failure<TNew>(Error);
        }

        // Bind: Transform to another Result
        public Result<TNew> Bind<TNew>(Func<TValue, Result<TNew>> binding)
        {
            return IsSuccess ? binding(Value) : Result.Failure<TNew>(Error);
        }

        // Ensure: Validate value
        public Result<TValue> Ensure(Func<TValue, bool> predicate, Error error)
        {
            if (IsFailure)
            {
                return this;
            }

            return predicate(Value) ? this : Result.Failure<TValue>(error);
        }

        // Match: Return value based on state
        public TOut Match<TOut>(Func<TValue, TOut> onSuccess, Func<Error, TOut> onFailure)
        {
            return IsSuccess ? onSuccess(Value) : onFailure(Error);
        }
    }
}
