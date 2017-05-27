namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteracaoEntidadeProdutoNasRequisicoes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProdutoEstoques", "Produto_Id", "dbo.Produtoes");
            DropForeignKey("dbo.ProdutoEstoques", "Estoque_Id", "dbo.Estoques");
            DropForeignKey("dbo.ProdutosNasRequisicoesProdutoes", "ProdutosNasRequisicoes_Id", "dbo.ProdutosNasRequisicoes");
            DropForeignKey("dbo.ProdutosNasRequisicoesProdutoes", "Produto_Id", "dbo.Produtoes");
            DropForeignKey("dbo.RequisicaoProdutosNasRequisicoes", "Requisicao_Id", "dbo.Requisicaos");
            DropForeignKey("dbo.RequisicaoProdutosNasRequisicoes", "ProdutosNasRequisicoes_Id", "dbo.ProdutosNasRequisicoes");
            DropIndex("dbo.ProdutoEstoques", new[] { "Produto_Id" });
            DropIndex("dbo.ProdutoEstoques", new[] { "Estoque_Id" });
            DropIndex("dbo.ProdutosNasRequisicoesProdutoes", new[] { "ProdutosNasRequisicoes_Id" });
            DropIndex("dbo.ProdutosNasRequisicoesProdutoes", new[] { "Produto_Id" });
            DropIndex("dbo.RequisicaoProdutosNasRequisicoes", new[] { "Requisicao_Id" });
            DropIndex("dbo.RequisicaoProdutosNasRequisicoes", new[] { "ProdutosNasRequisicoes_Id" });
            DropPrimaryKey("dbo.ProdutosNasRequisicoes");
            AddColumn("dbo.Produtoes", "Quantidade", c => c.Int(nullable: false));
            AddColumn("dbo.ProdutosNasRequisicoes", "IdRequisicao", c => c.Int(nullable: false));
            AddColumn("dbo.ProdutosNasRequisicoes", "IdProduto", c => c.Int(nullable: false));
            AddColumn("dbo.ProdutosNasRequisicoes", "Produto_Id", c => c.Int());
            AddColumn("dbo.ProdutosNasRequisicoes", "Requisicao_Id", c => c.Int());
            AddPrimaryKey("dbo.ProdutosNasRequisicoes", new[] { "IdRequisicao", "IdProduto" });
            CreateIndex("dbo.ProdutosNasRequisicoes", "Produto_Id");
            CreateIndex("dbo.ProdutosNasRequisicoes", "Requisicao_Id");
            AddForeignKey("dbo.ProdutosNasRequisicoes", "Produto_Id", "dbo.Produtoes", "Id");
            AddForeignKey("dbo.ProdutosNasRequisicoes", "Requisicao_Id", "dbo.Requisicaos", "Id");
            DropColumn("dbo.ProdutosNasRequisicoes", "Id");
            DropTable("dbo.Estoques");
            DropTable("dbo.ProdutoEstoques");
            DropTable("dbo.ProdutosNasRequisicoesProdutoes");
            DropTable("dbo.RequisicaoProdutosNasRequisicoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RequisicaoProdutosNasRequisicoes",
                c => new
                    {
                        Requisicao_Id = c.Int(nullable: false),
                        ProdutosNasRequisicoes_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Requisicao_Id, t.ProdutosNasRequisicoes_Id });
            
            CreateTable(
                "dbo.ProdutosNasRequisicoesProdutoes",
                c => new
                    {
                        ProdutosNasRequisicoes_Id = c.Int(nullable: false),
                        Produto_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProdutosNasRequisicoes_Id, t.Produto_Id });
            
            CreateTable(
                "dbo.ProdutoEstoques",
                c => new
                    {
                        Produto_Id = c.Int(nullable: false),
                        Estoque_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Produto_Id, t.Estoque_Id });
            
            CreateTable(
                "dbo.Estoques",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuantidadeNoEstoque = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ProdutosNasRequisicoes", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ProdutosNasRequisicoes", "Requisicao_Id", "dbo.Requisicaos");
            DropForeignKey("dbo.ProdutosNasRequisicoes", "Produto_Id", "dbo.Produtoes");
            DropIndex("dbo.ProdutosNasRequisicoes", new[] { "Requisicao_Id" });
            DropIndex("dbo.ProdutosNasRequisicoes", new[] { "Produto_Id" });
            DropPrimaryKey("dbo.ProdutosNasRequisicoes");
            DropColumn("dbo.ProdutosNasRequisicoes", "Requisicao_Id");
            DropColumn("dbo.ProdutosNasRequisicoes", "Produto_Id");
            DropColumn("dbo.ProdutosNasRequisicoes", "IdProduto");
            DropColumn("dbo.ProdutosNasRequisicoes", "IdRequisicao");
            DropColumn("dbo.Produtoes", "Quantidade");
            AddPrimaryKey("dbo.ProdutosNasRequisicoes", "Id");
            CreateIndex("dbo.RequisicaoProdutosNasRequisicoes", "ProdutosNasRequisicoes_Id");
            CreateIndex("dbo.RequisicaoProdutosNasRequisicoes", "Requisicao_Id");
            CreateIndex("dbo.ProdutosNasRequisicoesProdutoes", "Produto_Id");
            CreateIndex("dbo.ProdutosNasRequisicoesProdutoes", "ProdutosNasRequisicoes_Id");
            CreateIndex("dbo.ProdutoEstoques", "Estoque_Id");
            CreateIndex("dbo.ProdutoEstoques", "Produto_Id");
            AddForeignKey("dbo.RequisicaoProdutosNasRequisicoes", "ProdutosNasRequisicoes_Id", "dbo.ProdutosNasRequisicoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RequisicaoProdutosNasRequisicoes", "Requisicao_Id", "dbo.Requisicaos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProdutosNasRequisicoesProdutoes", "Produto_Id", "dbo.Produtoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProdutosNasRequisicoesProdutoes", "ProdutosNasRequisicoes_Id", "dbo.ProdutosNasRequisicoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProdutoEstoques", "Estoque_Id", "dbo.Estoques", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProdutoEstoques", "Produto_Id", "dbo.Produtoes", "Id", cascadeDelete: true);
        }
    }
}
