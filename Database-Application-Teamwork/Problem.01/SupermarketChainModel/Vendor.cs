using System.Collections.Generic;

public class Vendor
{
    private ICollection<Product> products;

    public Vendor()
    {
        this.products = new HashSet<Product>();
    }
    public int Id { get; set; }
    public string VendorName { get; set; }

    public ICollection<Product> Products
    {
        get { return this.products; }
        set { this.products = value; }
    }
}

