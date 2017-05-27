namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BancoInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estoques",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuantidadeNoEstoque = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        PrecoCusto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecoVenda = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProdutoComposto_Id = c.Int(),
                        ProdutoComposto_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProdutoCompostoes", t => t.ProdutoComposto_Id)
                .ForeignKey("dbo.ProdutoCompostoes", t => t.ProdutoComposto_Id1)
                .Index(t => t.ProdutoComposto_Id)
                .Index(t => t.ProdutoComposto_Id1);
            
            CreateTable(
                "dbo.ProdutosNasRequisicoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuantidadeDeProdutos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Requisicaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataRequisicao = c.DateTime(nullable: false),
                        Funcionario = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProdutoCompostoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuantidadeContidaDoProdutoSimples = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProdutoEstoques",
                c => new
                    {
                        Produto_Id = c.Int(nullable: false),
                        Estoque_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Produto_Id, t.Estoque_Id })
                .ForeignKey("dbo.Produtoes", t => t.Produto_Id, cascadeDelete: true)
                .ForeignKey("dbo.Estoques", t => t.Estoque_Id, cascadeDelete: true)
                .Index(t => t.Produto_Id)
                .Index(t => t.Estoque_Id);
            
            CreateTable(
                "dbo.ProdutosNasRequisicoesProdutoes",
                c => new
                    {
                        ProdutosNasRequisicoes_Id = c.Int(nullable: false),
                        Produto_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProdutosNasRequisicoes_Id, t.Produto_Id })
                .ForeignKey("dbo.ProdutosNasRequisicoes", t => t.ProdutosNasRequisicoes_Id, cascadeDelete: true)
                .ForeignKey("dbo.Produtoes", t => t.Produto_Id, cascadeDelete: true)
                .Index(t => t.ProdutosNasRequisicoes_Id)
                .Index(t => t.Produto_Id);
            
            CreateTable(
                "dbo.RequisicaoProdutosNasRequisicoes",
                c => new
                    {
                        Requisicao_Id = c.Int(nullable: false),
                        ProdutosNasRequisicoes_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Requisicao_Id, t.ProdutosNasRequisicoes_Id })
                .ForeignKey("dbo.Requisicaos", t => t.Requisicao_Id, cascadeDelete: true)
                .ForeignKey("dbo.ProdutosNasRequisicoes", t => t.ProdutosNasRequisicoes_Id, cascadeDelete: true)
                .Index(t => t.Requisicao_Id)
                .Index(t => t.ProdutosNasRequisicoes_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "ProdutoComposto_Id1", "dbo.ProdutoCompostoes");
            DropForeignKey("dbo.Produtoes", "ProdutoComposto_Id", "dbo.ProdutoCompostoes");
            DropForeignKey("dbo.RequisicaoProdutosNasRequisicoes", "ProdutosNasRequisicoes_Id", "dbo.ProdutosNasRequisicoes");
            DropForeignKey("dbo.RequisicaoProdutosNasRequisicoes", "Requisicao_Id", "dbo.Requisicaos");
            DropForeignKey("dbo.ProdutosNasRequisicoesProdutoes", "Produto_Id", "dbo.Produtoes");
            DropForeignKey("dbo.ProdutosNasRequisicoesProdutoes", "ProdutosNasRequisicoes_Id", "dbo.ProdutosNasRequisicoes");
            DropForeignKey("dbo.ProdutoEstoques", "Estoque_Id", "dbo.Estoques");
            DropForeignKey("dbo.ProdutoEstoques", "Produto_Id", "dbo.Produtoes");
            DropIndex("dbo.RequisicaoProdutosNasRequisicoes", new[] { "ProdutosNasRequisicoes_Id" });
            DropIndex("dbo.RequisicaoProdutosNasRequisicoes", new[] { "Requisicao_Id" });
            DropIndex("dbo.ProdutosNasRequisicoesProdutoes", new[] { "Produto_Id" });
            DropIndex("dbo.ProdutosNasRequisicoesProdutoes", new[] { "ProdutosNasRequisicoes_Id" });
            DropIndex("dbo.ProdutoEstoques", new[] { "Estoque_Id" });
            DropIndex("dbo.ProdutoEstoques", new[] { "Produto_Id" });
            DropIndex("dbo.Produtoes", new[] { "ProdutoComposto_Id1" });
            DropIndex("dbo.Produtoes", new[] { "ProdutoComposto_Id" });
            DropTable("dbo.RequisicaoProdutosNasRequisicoes");
            DropTable("dbo.ProdutosNasRequisicoesProdutoes");
            DropTable("dbo.ProdutoEstoques");
            DropTable("dbo.ProdutoCompostoes");
            DropTable("dbo.Requisicaos");
            DropTable("dbo.ProdutosNasRequisicoes");
            DropTable("dbo.Produtoes");
            DropTable("dbo.Estoques");
        }
    }
}
