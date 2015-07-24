using System;

namespace SupermarketChain.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Sale
    {
        private Product product;
        public Sale()
        {
            this.SaleCost = this.product.Price * this.Quantity;
        }

        public int Id { get; set; }

        public DateTime SoldDate { get; set; }

        public int Quantity { get; set; }

        [NotMapped]
        public decimal SaleCost { get; private set; }

        public virtual Supermarket Supermarket { get; set; }

        public int SupermarketId { get; set; }

        public virtual Product Product
        {
            get
            {
                return this.product;
            }
            set
            {
                this.product = value;
            }
        }

        public int ProductId { get; set; }
    }
}
