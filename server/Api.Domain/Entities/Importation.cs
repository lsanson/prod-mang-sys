using System;
using System.Collections.Generic;
using Api.Domain.Validation;
using FluentValidation.Results;

namespace Api.Domain.Entities
{
    public class Importation
    {
        public Importation() {  }
        public Importation(string name, int quantity, decimal unitaryValue, DateTime deliveryDate)
        {
            Name = name;
            Quantity = quantity;
            UnitValue = unitaryValue;
            DeliveryDate = deliveryDate;
        }

        public Importation(Importation p)
        {
            Name = p.Name;
            Quantity = p.Quantity;
            UnitValue = p.UnitValue;
            DeliveryDate = p.DeliveryDate;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
        
        public int? Quantity { get; set; }

        public decimal? UnitValue { get; set; }

        public DateTime? DeliveryDate { get; set; }      
        
        #region Methods
        public ValidationResult Validate()
        {
            var validator = new ImportationValidator();
            return validator.Validate(this);
        }

        #endregion
    }
}