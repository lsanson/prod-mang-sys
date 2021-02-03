using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Validation
{
    public static class EntityValidator
    {
        public static IEnumerable<ValidationResult> GetValidationErrors(object obj)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(obj);
            Validator.TryValidateObject(obj, context, validationResults, true);
            return validationResults;
        }
    }
}