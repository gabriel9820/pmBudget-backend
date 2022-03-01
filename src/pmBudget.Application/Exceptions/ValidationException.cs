namespace pmBudget.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; }

        public ValidationException(string message = "Uma ou mais validações falharam") : base(message)
        {
            Errors = new List<string>();
        }

        public ValidationException(IEnumerable<string> errors) : this()
        {
            foreach (var error in errors)
            {
                Errors.Add(error);
            }
        }
    }
}
