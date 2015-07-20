namespace SupermarketChain.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }

        public int MeasureId { get; set; }

        public virtual Measure Measure { get; set; }
    }
}
