namespace SupermarketChain.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ROSI.Measures",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ROSI.Products",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VendorId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MeasureId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ROSI.Measures", t => t.MeasureId, cascadeDelete: true)
                .ForeignKey("ROSI.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.VendorId)
                .Index(t => t.MeasureId);
            
            CreateTable(
                "ROSI.Vendors",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("ROSI.Products", "VendorId", "ROSI.Vendors");
            DropForeignKey("ROSI.Products", "MeasureId", "ROSI.Measures");
            DropIndex("ROSI.Products", new[] { "MeasureId" });
            DropIndex("ROSI.Products", new[] { "VendorId" });
            DropTable("ROSI.Vendors");
            DropTable("ROSI.Products");
            DropTable("ROSI.Measures");
        }
    }
}
