using System;
using Api.Domain.Entities;

namespace Api.Domain.DTOs
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitValue { get; set; }
        public DateTime DeliveryDate { get; set; }
        
        public Importation ProductBuilder() => new Importation(Name, Quantity, UnitValue, DeliveryDate);
    }
}