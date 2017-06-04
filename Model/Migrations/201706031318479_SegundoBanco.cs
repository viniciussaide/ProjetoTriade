namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SegundoBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        PrecoCusto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecoVenda = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductComposition",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProdutoId, t.ItemId })
                .ForeignKey("dbo.Product", t => t.ItemId)
                .ForeignKey("dbo.Product", t => t.ProdutoId)
                .Index(t => t.ProdutoId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.ProductRequest",
                c => new
                    {
                        RequisicaoId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RequisicaoId, t.ProductId })
                .ForeignKey("dbo.Product", t => t.ProductId)
                .ForeignKey("dbo.Request", t => t.RequisicaoId)
                .Index(t => t.RequisicaoId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataRequisicao = c.DateTime(nullable: false),
                        Funcionario = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductRequest", "RequisicaoId", "dbo.Request");
            DropForeignKey("dbo.ProductRequest", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductComposition", "ProdutoId", "dbo.Product");
            DropForeignKey("dbo.ProductComposition", "ItemId", "dbo.Product");
            DropIndex("dbo.ProductRequest", new[] { "ProductId" });
            DropIndex("dbo.ProductRequest", new[] { "RequisicaoId" });
            DropIndex("dbo.ProductComposition", new[] { "ItemId" });
            DropIndex("dbo.ProductComposition", new[] { "ProdutoId" });
            DropTable("dbo.Request");
            DropTable("dbo.ProductRequest");
            DropTable("dbo.ProductComposition");
            DropTable("dbo.Product");
        }
    }
}
