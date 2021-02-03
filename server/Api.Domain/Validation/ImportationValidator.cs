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
            RuleFor(imp => imp.Name).NotNull().WithName("Name").WithMessage("Name is mandatory")
                                    .MaximumLength(50).WithName("Name").WithMessage("Name must be up to 50 characters.");
            RuleFor(imp => imp.Quantity).NotNull().WithName("Quantity").WithMessage("Quantity is mandatory")
                                        .GreaterThanOrEqualTo(0).WithName("Quantity").WithMessage("Quantity must be greater than or equal to 0.");
            RuleFor(imp => imp.UnitValue).NotNull().GreaterThanOrEqualTo((decimal)0.0);
            RuleFor(imp => imp.DeliveryDate).NotNull().WithName("DeliveryDate").WithMessage("DeliveryDate is mandatory.")
                                            .GreaterThan(DateTime.Today).WithName("DeliveryDate").WithMessage("DeliveryDate must be greater than today.");
        }
    }
}