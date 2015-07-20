namespace StupermarketChainContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "JINJAAR.Measures",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        MeasureName = c.String(),
                        Product_Id = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("JINJAAR.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "JINJAAR.Products",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ProductName = c.String(),
                        Price = c.Double(nullable: false),
                        VendorId = c.Decimal(precision: 10, scale: 0),
                        MeasureId = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "JINJAAR.Vendors",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        VendorName = c.String(),
                        Product_Id = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("JINJAAR.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("JINJAAR.Vendors", "Product_Id", "JINJAAR.Products");
            DropForeignKey("JINJAAR.Measures", "Product_Id", "JINJAAR.Products");
            DropIndex("JINJAAR.Vendors", new[] { "Product_Id" });
            DropIndex("JINJAAR.Measures", new[] { "Product_Id" });
            DropTable("JINJAAR.Vendors");
            DropTable("JINJAAR.Products");
            DropTable("JINJAAR.Measures");
        }
    }
}
