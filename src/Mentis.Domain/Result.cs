namespace Mentis.Domain
{
    public class Result
    {
        public Result(bool isSuccess = true, string message = "")
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }

        public static Result Success() => new();
        public static Result Error(string mensagem) => new 
            (false, mensagem);
    }

    public class Result<T> : Result
    {
        public Result(T? data, bool isSucces = true, string mensagem = "")
            : base(isSucces, mensagem)
        {
            Data = data;
        }

        public T? Data { get; private set; }

        public static Result<T> Sucesso(T data) 
            => new(data);
        public static Result<T> Erro(string mensagem)
            => new(default, false, mensagem);
    }
}
