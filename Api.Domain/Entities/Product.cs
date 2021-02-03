using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class Product
    {
        public Product() {  }
        public Product(string name, int quantity, decimal unitaryValue, DateTime deliveryDate)
        {
            Name = name;
            Quantity = quantity;
            UnitValue = unitaryValue;
            DeliveryDate = deliveryDate;

            Validate();
        }

        public Product(Product p)
        {
            Name = p.Name;
            Quantity = p.Quantity;
            UnitValue = p.UnitValue;
            DeliveryDate = p.DeliveryDate;

            Validate();
        }
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage="Name is mandatory")]
        [StringLength(50, MinimumLength=3)]
        public string Name { get; set; }
        
        [Required(ErrorMessage="Quantity is mandatory")]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Required(ErrorMessage="Unity value is mandatory")]
        [Range(0.00, double.MaxValue)]
        [DisplayFormat(DataFormatString="{0:N2")]
        public decimal UnitValue { get; set; }

        [Required(ErrorMessage="Delivery date is mandatory")]
        [DisplayFormat(DataFormatString="dd/mm/yyyy")]
          
        public DateTime DeliveryDate { get; set; }      
        
        #region Methods
        private void Validate()
        {

        }
        #endregion
    }
}