namespace SupermarketChain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Income
    {
        [Key]
        public int Id { get; set; }

        public decimal IncomeValue { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
