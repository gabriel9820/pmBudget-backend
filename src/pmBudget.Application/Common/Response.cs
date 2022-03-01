namespace pmBudget.Application.Common
{
    public class Response<T> where T : class
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public Response() { }

        private Response(bool success, string message, T data, IEnumerable<string> errors)
        {
            Success = success;
            Message = message;
            Data = data;
            Errors = errors;
        }

        public static Response<T> Ok(string message = null, T data = null)
        {
            return new Response<T>(true, message, data, null);
        }

        public static Response<T> Error(string message = null, IEnumerable<string> errors = null)
        {
            return new Response<T>(false, message, null, errors);
        }
    }
}
