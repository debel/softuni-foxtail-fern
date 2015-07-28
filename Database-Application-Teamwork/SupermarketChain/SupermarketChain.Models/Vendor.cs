﻿namespace SupermarketChain.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Vendor
    {
        private ICollection<Product> products;
        private ICollection<Expense> expenses;

        public Vendor()
        {
            this.products = new HashSet<Product>();
            this.expenses = new HashSet<Expense>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }

        public virtual ICollection<Expense> Expenses
        {
            get { return this.expenses; }
            set { this.expenses = value; }
        } 
    }
}
