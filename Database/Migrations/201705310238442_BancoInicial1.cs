namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BancoInicial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produto", new[] { "ProdutosDaComposicao_FKprodutoComposto", "ProdutosDaComposicao_FKprodutoSimples" }, "dbo.ProdutosDaComposicao");
            DropForeignKey("dbo.ProdutosDaComposicao", "FKprodutoComposto", "dbo.Produto");
            DropForeignKey("dbo.ProdutosDaComposicao", "FKprodutoSimples", "dbo.Produto");
            AddColumn("dbo.Produto", "ProdutosDaComposicao_FKprodutoComposto1", c => c.Int());
            AddColumn("dbo.Produto", "ProdutosDaComposicao_FKprodutoSimples1", c => c.Int());
            AddColumn("dbo.Produto", "ProdutosDaComposicao_FKprodutoComposto2", c => c.Int());
            AddColumn("dbo.Produto", "ProdutosDaComposicao_FKprodutoSimples2", c => c.Int());
            CreateIndex("dbo.Produto", new[] { "ProdutosDaComposicao_FKprodutoComposto1", "ProdutosDaComposicao_FKprodutoSimples1" });
            CreateIndex("dbo.Produto", new[] { "ProdutosDaComposicao_FKprodutoComposto2", "ProdutosDaComposicao_FKprodutoSimples2" });
            AddForeignKey("dbo.Produto", new[] { "ProdutosDaComposicao_FKprodutoComposto1", "ProdutosDaComposicao_FKprodutoSimples1" }, "dbo.ProdutosDaComposicao", new[] { "FKprodutoComposto", "FKprodutoSimples" });
            AddForeignKey("dbo.Produto", new[] { "ProdutosDaComposicao_FKprodutoComposto2", "ProdutosDaComposicao_FKprodutoSimples2" }, "dbo.ProdutosDaComposicao", new[] { "FKprodutoComposto", "FKprodutoSimples" });
            AddForeignKey("dbo.ProdutosDaComposicao", "FKprodutoComposto", "dbo.Produto", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProdutosDaComposicao", "FKprodutoSimples", "dbo.Produto", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdutosDaComposicao", "FKprodutoSimples", "dbo.Produto");
            DropForeignKey("dbo.ProdutosDaComposicao", "FKprodutoComposto", "dbo.Produto");
            DropForeignKey("dbo.Produto", new[] { "ProdutosDaComposicao_FKprodutoComposto2", "ProdutosDaComposicao_FKprodutoSimples2" }, "dbo.ProdutosDaComposicao");
            DropForeignKey("dbo.Produto", new[] { "ProdutosDaComposicao_FKprodutoComposto1", "ProdutosDaComposicao_FKprodutoSimples1" }, "dbo.ProdutosDaComposicao");
            DropIndex("dbo.Produto", new[] { "ProdutosDaComposicao_FKprodutoComposto2", "ProdutosDaComposicao_FKprodutoSimples2" });
            DropIndex("dbo.Produto", new[] { "ProdutosDaComposicao_FKprodutoComposto1", "ProdutosDaComposicao_FKprodutoSimples1" });
            DropColumn("dbo.Produto", "ProdutosDaComposicao_FKprodutoSimples2");
            DropColumn("dbo.Produto", "ProdutosDaComposicao_FKprodutoComposto2");
            DropColumn("dbo.Produto", "ProdutosDaComposicao_FKprodutoSimples1");
            DropColumn("dbo.Produto", "ProdutosDaComposicao_FKprodutoComposto1");
            AddForeignKey("dbo.ProdutosDaComposicao", "FKprodutoSimples", "dbo.Produto", "Id");
            AddForeignKey("dbo.ProdutosDaComposicao", "FKprodutoComposto", "dbo.Produto", "Id");
            AddForeignKey("dbo.Produto", new[] { "ProdutosDaComposicao_FKprodutoComposto", "ProdutosDaComposicao_FKprodutoSimples" }, "dbo.ProdutosDaComposicao", new[] { "FKprodutoComposto", "FKprodutoSimples" });
        }
    }
}
