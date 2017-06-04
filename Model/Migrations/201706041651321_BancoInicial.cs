namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BancoInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CostValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductComposition",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.ItemId })
                .ForeignKey("dbo.Product", t => t.ItemId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.ProductRequest",
                c => new
                    {
                        RequestId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RequestId, t.ProductId })
                .ForeignKey("dbo.Product", t => t.ProductId)
                .ForeignKey("dbo.Request", t => t.RequestId)
                .Index(t => t.RequestId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestDate = c.DateTime(nullable: false),
                        Worker = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductRequest", "RequestId", "dbo.Request");
            DropForeignKey("dbo.ProductRequest", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductComposition", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductComposition", "ItemId", "dbo.Product");
            DropIndex("dbo.ProductRequest", new[] { "ProductId" });
            DropIndex("dbo.ProductRequest", new[] { "RequestId" });
            DropIndex("dbo.ProductComposition", new[] { "ItemId" });
            DropIndex("dbo.ProductComposition", new[] { "ProductId" });
            DropTable("dbo.Request");
            DropTable("dbo.ProductRequest");
            DropTable("dbo.ProductComposition");
            DropTable("dbo.Product");
        }
    }
}
