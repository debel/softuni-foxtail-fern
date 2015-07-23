﻿using System;

namespace SupermarketChain.Models
{
    public class Sale
    {
        public Sale()
        {
            this.SaleCost = this.PricePerUnit * this.Quantity;
        }

        public int Id { get; set; }

        public DateTime SoldDate { get; set; }

        public int Quantity { get; set; }

        public decimal PricePerUnit { get; set; }

        public decimal SaleCost { get; set; }

        public virtual Supermarket Supermarket { get; set; }

        public int SupermarketId { get; set; }

        public virtual Product Product { get; set; }

        public int ProductId { get; set; }
    }
}
