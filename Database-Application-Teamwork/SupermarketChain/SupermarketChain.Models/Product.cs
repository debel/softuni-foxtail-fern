namespace SupermarketChain.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data;

    public class Product
    {
        private ICollection<Income> incomeses;

        public Product()
        {
            this.incomeses = new HashSet<Income>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }

        public int MeasureId { get; set; }

        public virtual Measure Measure { get; set; }
        public virtual ICollection<Income> Incomeses { get; set; }

    }
}
