namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BancoInicial : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Produto", "Quantidade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produto", "Quantidade", c => c.Int());
        }
    }
}
