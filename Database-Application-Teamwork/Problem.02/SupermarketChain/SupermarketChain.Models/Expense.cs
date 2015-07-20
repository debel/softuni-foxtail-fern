namespace SupermarketChain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Expense
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateOfExpense { get; set; }

        [Required]
        public decimal ExpenseAmount { get; set; }

        [Required]
        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
