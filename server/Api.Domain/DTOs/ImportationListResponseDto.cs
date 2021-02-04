using System;
using Api.Domain.Entities;

namespace Api.Domain.DTOs
{
    public class ImportationListResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public decimal? TotalValue { get; set; }

        public static explicit operator ImportationListResponseDto(Importation importation)
        {
            return new ImportationListResponseDto() {
                Id = importation.Id,
                Name = importation.Name,
                Quantity = importation.Quantity,
                DeliveryDate = importation.DeliveryDate,
                TotalValue = importation.UnitValue * importation.Quantity
            };
        }
    }
}