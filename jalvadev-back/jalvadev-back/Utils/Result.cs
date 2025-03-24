namespace jalvadev_back.Utils
{
    public class Result<T>
    {
        public bool IsSuccess { get; }

        public string Message { get; }

        public T Value { get; set; }

        private Result(bool IsSuccess, string Message, T Value)
        {
            this.IsSuccess = IsSuccess;
            this.Message = Message;
            this.Value = Value;
        }

        public static Result<T> Success(T value) => new Result<T>(true, "", value);

        public static Result<T> Failure(string message) => new Result<T>(false, message, default);
    }
}
