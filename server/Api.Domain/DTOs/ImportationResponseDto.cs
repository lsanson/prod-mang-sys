using System;
using Api.Domain.Entities;

namespace Api.Domain.DTOs
{
    public class ImportationResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitValue { get; set; }
        public DateTime? DeliveryDate { get; set; }

        public static explicit operator ImportationResponseDto(Importation importation)
        {
            return new ImportationResponseDto() {
                Id = importation.Id.ToString(),
                Name = importation.Name,
                Quantity = importation.Quantity,
                UnitValue = importation.UnitValue,
                DeliveryDate = importation.DeliveryDate
            };
        }
    }
}