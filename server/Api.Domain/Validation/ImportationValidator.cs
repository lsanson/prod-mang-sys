using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Api.Domain.Entities;
using FluentValidation;

namespace Api.Domain.Validation
{
    public class ImportationValidator : AbstractValidator<Importation>
    {
        public ImportationValidator()
        {
            RuleFor(imp => imp.Name).NotNull().WithName("Name").WithMessage("Name is required")
                                    .MaximumLength(50).WithName("Name").WithMessage("Name must be up to 50 characters.");

            RuleFor(imp => imp.Quantity).NotNull().WithName("Quantity").WithMessage("Quantity is required")
                                        .GreaterThan(0).WithName("Quantity").WithMessage("Quantity must be greater than or equal to 0.");

            RuleFor(imp => imp.UnitValue).NotNull().WithName("UnitValue").WithMessage("UnitValue is required")
                                        .GreaterThan((decimal)0.0).WithName("UnitValue").WithMessage("UnitValue must be greater than or equal to 0.");
                                        
            RuleFor(imp => imp.DeliveryDate).NotNull().WithName("DeliveryDate").WithMessage("DeliveryDate is required.")
                                            .GreaterThan(DateTime.Today).WithName("DeliveryDate").WithMessage("DeliveryDate must be greater than today.");
        }
    }
}