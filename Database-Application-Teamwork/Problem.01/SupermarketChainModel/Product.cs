using System.Collections.Generic;

public class Product
{
    private ICollection<Measure> measures;
    private ICollection<Vendor> vendors; 
    public int Id { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
    public int?  VendorId { get; set; }
    public int? MeasureId { get; set; }

    public virtual ICollection<Measure> Measures
    {
        get { return this.measures; }
        set { this.measures = value; }
    }

    public virtual ICollection<Vendor> Vendors
    {
        get { return this.vendors; }
        set { this.vendors = value; }
    }
}

