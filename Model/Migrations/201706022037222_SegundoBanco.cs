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
                        IdProdutoComposto = c.Int(nullable: false),
                        IdProdutoSimples = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        ProdutoComposto_Id = c.Int(nullable: false),
                        ProdutoSimples_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdProdutoComposto, t.IdProdutoSimples })
                .ForeignKey("dbo.Product", t => t.ProdutoComposto_Id)
                .ForeignKey("dbo.Product", t => t.ProdutoSimples_Id)
                .Index(t => t.ProdutoComposto_Id)
                .Index(t => t.ProdutoSimples_Id);
            
            CreateTable(
                "dbo.ProductRequest",
                c => new
                    {
                        IdRequisicao = c.Int(nullable: false),
                        IdProduto = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        Produto_Id = c.Int(nullable: false),
                        Requisicao_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdRequisicao, t.IdProduto })
                .ForeignKey("dbo.Product", t => t.Produto_Id)
                .ForeignKey("dbo.Request", t => t.Requisicao_Id)
                .Index(t => t.Produto_Id)
                .Index(t => t.Requisicao_Id);
            
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
            DropForeignKey("dbo.ProductRequest", "Requisicao_Id", "dbo.Request");
            DropForeignKey("dbo.ProductRequest", "Produto_Id", "dbo.Product");
            DropForeignKey("dbo.ProductComposition", "ProdutoSimples_Id", "dbo.Product");
            DropForeignKey("dbo.ProductComposition", "ProdutoComposto_Id", "dbo.Product");
            DropIndex("dbo.ProductRequest", new[] { "Requisicao_Id" });
            DropIndex("dbo.ProductRequest", new[] { "Produto_Id" });
            DropIndex("dbo.ProductComposition", new[] { "ProdutoSimples_Id" });
            DropIndex("dbo.ProductComposition", new[] { "ProdutoComposto_Id" });
            DropTable("dbo.Request");
            DropTable("dbo.ProductRequest");
            DropTable("dbo.ProductComposition");
            DropTable("dbo.Product");
        }
    }
}
