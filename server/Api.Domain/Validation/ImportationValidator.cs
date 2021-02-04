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
            RuleFor(imp => imp.Name).NotNull().WithName("Nome do Produto").WithMessage("O nome do produto é obrigatório")
                                    .MaximumLength(50).WithName("Nome do Produto").WithMessage("Nome do Produto deve ter até 50 caracteres");

            RuleFor(imp => imp.Quantity).NotNull().WithName("Quantidade").WithMessage("Quantidade é obrigatório is required")
                                        .GreaterThan(0).WithName("Quantidade").WithMessage("Quantidade deve ser maior ou igual a 0.");

            RuleFor(imp => imp.UnitValue).NotNull().WithName("Valor Unitário").WithMessage("Valor Unitário é obrigatório")
                                        .GreaterThan((decimal)0.0).WithName("Valor Unitário").WithMessage("Valor Unitário deve ser maior ou igual a 0.");
                                        
            RuleFor(imp => imp.DeliveryDate).NotNull().WithName("Data de Entrega").WithMessage("Data de Entrega is required.")
                                            .GreaterThan(DateTime.Today).WithName("Data de Entrega").WithMessage("Data de Entrega deve ser posterior a hoje.");
        }
    }
}