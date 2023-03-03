using Microsoft.AspNetCore.Mvc;

namespace api.Infrastructure.Common
{
    /// <summary>
    /// The design pattern used in the Result class is a combination of the Result Object and Fluent Interface patterns.
    /// The Result Object pattern is used to encapsulate the success or failure of an operation, as well as any error messages 
    /// that may result from the operation.This pattern is commonly used in domain-driven design to return results from business logic operations.
    /// The Fluent Interface pattern is used to provide a more readable and expressive interface for constructing the Result object, 
    /// by using method chaining to build the object. The Result class provides several static methods that return Result objects, which can be chained together to construct a more complex result.
    /// </summary>
    public class Result
    {
        private readonly List<string> errors;

        internal Result(bool succeeded, List<string> errors)
        {
            this.Succeeded = succeeded;
            this.errors = errors;
        }

        public bool Succeeded { get; }

        public List<string> Errors
            => this.Succeeded
                ? new List<string>()
                : this.errors;

        public static Result Success
            => new Result(true, new List<string>());

        public static Result Failure(IEnumerable<string> errors)
            => new Result(false, errors.ToList());

        public static implicit operator Result(string error)
            => Failure(new List<string> { error });

        public static implicit operator Result(List<string> errors)
            => Failure(errors.ToList());

        public static implicit operator Result(bool success)
            => success ? Success : Failure(new[] { "Unsuccessful operation." });

        public static implicit operator bool(Result result)
            => result.Succeeded;

        public static implicit operator ActionResult(Result result)
        {
            if (!result.Succeeded)
            {
                return new BadRequestObjectResult(result.Errors);
            }

            return new OkResult();
        }
    }

    /// <summary>
    /// The Result<TData> class is a generic version of the Result class, which includes a Data property that can be used to store additional data along with the result. 
    /// The same design patterns are used in Result<TData> as in the non-generic Result class.
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class Result<TData> : Result
    {
        private readonly TData data;

        private Result(bool succeeded, TData data, List<string> errors)
            : base(succeeded, errors)
            => this.data = data;

        public TData Data
            => this.Succeeded
                ? this.data
                : throw new InvalidOperationException(
                    $"{nameof(this.Data)} is not available with a failed result. Use {this.Errors} instead.");

        public static Result<TData> SuccessWith(TData data)
            => new Result<TData>(true, data, new List<string>());

        public new static Result<TData> Failure(IEnumerable<string> errors)
            => new Result<TData>(false, default, errors.ToList());

        public static implicit operator Result<TData>(string error)
            => Failure(new List<string> { error });

        public static implicit operator Result<TData>(List<string> errors)
            => Failure(errors);

        public static implicit operator Result<TData>(TData data)
            => SuccessWith(data);

        public static implicit operator bool(Result<TData> result)
            => result.Succeeded;

        public static implicit operator ActionResult<TData>(Result<TData> result)
        {
            if (!result.Succeeded)
            {
                return new BadRequestObjectResult(result.Errors);
            }

            return result.Data;
        }
    }
}
