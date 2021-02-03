using System;

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

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitValue { get; set; }  
        public DateTime DeliveryDate { get; set; }      
        
        #region Methods
        private void Validate()
        {

        }
        #endregion
    }
}