using System;
using Api.Domain.Entities;

namespace Api.Domain.DTOs
{
    public class ImportationResponseDto
    {
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitValue { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public decimal? TotalValue { get; set; }

        public static explicit operator ImportationResponseDto(Importation importation)
        {
            return new ImportationResponseDto() {
                Name = importation.Name,
                Quantity = importation.Quantity,
                UnitValue = importation.UnitValue,
                DeliveryDate = importation.DeliveryDate,
                TotalValue = importation.UnitValue * importation.Quantity
            };
        }
    }
}