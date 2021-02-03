namespace Api.Domain.Validation
{
    public sealed class ValidationError 
    {
        public string Property { get; set; }
        public string Message { get; set; }
        
        public ValidationError(string property, string message)
        {
            Property = property;
            Message = message;
        }
    }
}