using System.Collections.Generic;

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int  VendorId { get; set; }
    public int MeasureId { get; set; }

    public virtual Vendor Vendor { get; set; }

    public virtual  Measure Measure { get; set; }
}

