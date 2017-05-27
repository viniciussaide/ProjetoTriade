namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correcao004 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProdutosNasRequisicoes", "Produto_Id", "dbo.Produtoes");
            DropIndex("dbo.ProdutosNasRequisicoes", new[] { "Produto_Id" });
            DropColumn("dbo.ProdutosNasRequisicoes", "Produto_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProdutosNasRequisicoes", "Produto_Id", c => c.Int());
            CreateIndex("dbo.ProdutosNasRequisicoes", "Produto_Id");
            AddForeignKey("dbo.ProdutosNasRequisicoes", "Produto_Id", "dbo.Produtoes", "Id");
        }
    }
}
