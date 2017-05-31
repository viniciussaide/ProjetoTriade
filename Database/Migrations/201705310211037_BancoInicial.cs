namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BancoInicial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProdutosDaComposicao", "FKprodutoComposto", "dbo.Produto");
            RenameColumn(table: "dbo.Produto", name: "FKprodutoComposto", newName: "ProdutosDaComposicao_FKprodutoComposto");
            AddColumn("dbo.Produto", "ProdutosDaComposicao_FKprodutoSimples", c => c.Int());
            CreateIndex("dbo.Produto", new[] { "ProdutosDaComposicao_FKprodutoComposto", "ProdutosDaComposicao_FKprodutoSimples" });
            AddForeignKey("dbo.Produto", new[] { "ProdutosDaComposicao_FKprodutoComposto", "ProdutosDaComposicao_FKprodutoSimples" }, "dbo.ProdutosDaComposicao", new[] { "FKprodutoComposto", "FKprodutoSimples" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", new[] { "ProdutosDaComposicao_FKprodutoComposto", "ProdutosDaComposicao_FKprodutoSimples" }, "dbo.ProdutosDaComposicao");
            DropIndex("dbo.Produto", new[] { "ProdutosDaComposicao_FKprodutoComposto", "ProdutosDaComposicao_FKprodutoSimples" });
            DropColumn("dbo.Produto", "ProdutosDaComposicao_FKprodutoSimples");
            RenameColumn(table: "dbo.Produto", name: "ProdutosDaComposicao_FKprodutoComposto", newName: "FKprodutoComposto");
            AddForeignKey("dbo.ProdutosDaComposicao", "FKprodutoComposto", "dbo.Produto", "Id");
        }
    }
}
