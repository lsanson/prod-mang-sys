using System;
using System.ComponentModel.DataAnnotations;
using Api.Domain.Entities;

namespace Api.Domain.Validation
{
    public class ImportationDateCompare : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (Importation)validationContext.ObjectInstance;
            var today = DateTime.Today;
            var deliveryDate = Convert.ToDateTime(value);

            if (deliveryDate > today)
            {
                return ValidationResult.Success;
            }
            else {
                return new ValidationResult(
                                "Delivery date must be greater than today"
                );
            }
        }
    }
}