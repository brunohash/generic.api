namespace Domain.Exceptions
{
    public class CustomValidationException : Exception
    {
        public int Status { get; } = 400;
        public string Type { get; } = "ValidationFailure";
        public string Title { get; } = "Validation error";
        public string Detail { get; } = "One or more validation errors has occurred";

        public CustomValidationException(List<string> errors)
        {
            Errors = errors;
        }

        public List<string> Errors { get; set; }
    }
}

