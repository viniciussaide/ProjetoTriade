namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BancoInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        PrecoCusto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecoVenda = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        ProdutosDaComposicao_FKprodutoComposto = c.Int(),
                        ProdutosDaComposicao_FKprodutoSimples = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProdutosDaComposicao", t => new { t.ProdutosDaComposicao_FKprodutoComposto, t.ProdutosDaComposicao_FKprodutoSimples })
                .Index(t => new { t.ProdutosDaComposicao_FKprodutoComposto, t.ProdutosDaComposicao_FKprodutoSimples });
            
            CreateTable(
                "dbo.ProdutosNasRequisicoes",
                c => new
                    {
                        IdRequisicao = c.Int(nullable: false),
                        IdProduto = c.Int(nullable: false),
                        QuantidadeDeProdutos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdRequisicao, t.IdProduto })
                .ForeignKey("dbo.Produto", t => t.IdProduto)
                .ForeignKey("dbo.Requisicao", t => t.IdRequisicao)
                .Index(t => t.IdRequisicao)
                .Index(t => t.IdProduto);
            
            CreateTable(
                "dbo.Requisicao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataRequisicao = c.DateTime(nullable: false),
                        Funcionario = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProdutosDaComposicao",
                c => new
                    {
                        FKprodutoComposto = c.Int(nullable: false),
                        FKprodutoSimples = c.Int(nullable: false),
                        QuantidadeContidaDoProdutoSimples = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FKprodutoComposto, t.FKprodutoSimples })
                .ForeignKey("dbo.Produto", t => t.FKprodutoComposto)
                .ForeignKey("dbo.Produto", t => t.FKprodutoSimples)
                .Index(t => t.FKprodutoComposto)
                .Index(t => t.FKprodutoSimples);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdutosDaComposicao", "FKprodutoSimples", "dbo.Produto");
            DropForeignKey("dbo.ProdutosDaComposicao", "FKprodutoComposto", "dbo.Produto");
            DropForeignKey("dbo.Produto", new[] { "ProdutosDaComposicao_FKprodutoComposto", "ProdutosDaComposicao_FKprodutoSimples" }, "dbo.ProdutosDaComposicao");
            DropForeignKey("dbo.ProdutosNasRequisicoes", "IdRequisicao", "dbo.Requisicao");
            DropForeignKey("dbo.ProdutosNasRequisicoes", "IdProduto", "dbo.Produto");
            DropIndex("dbo.ProdutosDaComposicao", new[] { "FKprodutoSimples" });
            DropIndex("dbo.ProdutosDaComposicao", new[] { "FKprodutoComposto" });
            DropIndex("dbo.ProdutosNasRequisicoes", new[] { "IdProduto" });
            DropIndex("dbo.ProdutosNasRequisicoes", new[] { "IdRequisicao" });
            DropIndex("dbo.Produto", new[] { "ProdutosDaComposicao_FKprodutoComposto", "ProdutosDaComposicao_FKprodutoSimples" });
            DropTable("dbo.ProdutosDaComposicao");
            DropTable("dbo.Requisicao");
            DropTable("dbo.ProdutosNasRequisicoes");
            DropTable("dbo.Produto");
        }
    }
}
