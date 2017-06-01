namespace Database
{
    using Model;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class DBtriade : DbContext
    {
        public DBtriade(): base("name=DBtriade")
        {
        }

        //Variáveis que representam tabelas em que são armazenados os objetos no banco
        //Usados pelo entity framework para troca de informação entre aplicação e banco de dados
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoSimples> ProdutosSimples { get; set; }
        public DbSet<ProdutoComposto> ProdutosCompostos { get; set; }
        public DbSet<ProdutosDaComposicao> ProdutosDaComposicao { get; set; }
        public DbSet<ProdutosNasRequisicoes> ProdutosNasRequisicoes { get; set; }
        public DbSet<Requisicao> Requisicao { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Modelagem do banco mais específicas feitas pelo Fluent API
            modelBuilder.Conventions.Remove< ManyToManyCascadeDeleteConvention > ();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Chave estrangeira entre ProdutosDaComposicao e ProdutoComposto
            modelBuilder.Entity<ProdutosDaComposicao>()
                        .HasRequired(c => c.ProdutoComposto)
                        .WithMany(s => s.ProdutosDaComposicao)
                        .HasForeignKey(c => c.FKprodutoComposto)
                        .WillCascadeOnDelete(false);
            //Chave estrangeira entre ProdutosDaComposicao e ProdutoSimples
            modelBuilder.Entity<ProdutosDaComposicao>()
                        .HasRequired(c => c.ProdutoSimples)
                        .WithMany(s => s.ProdutosDaComposicao)
                        .HasForeignKey(c => c.FKprodutoSimples)
                        .WillCascadeOnDelete(false);
            //Chave estrangeira entre ProdutosNasRequisicoes e Produto
            modelBuilder.Entity<ProdutosNasRequisicoes>()
                        .HasRequired(pr => pr.Produto)
                        .WithMany(r => r.ProdutosNasRequisicoes)
                        .HasForeignKey(pr => pr.IdProduto)
                        .WillCascadeOnDelete(false);
            //Chave estrangeira entre ProdutosNasRequisicoes e Requisicao
            modelBuilder.Entity<ProdutosNasRequisicoes>()
                        .HasRequired(pr => pr.Requisicao)
                        .WithMany(r => r.ProdutosNasRequisicoes)
                        .HasForeignKey(pr => pr.IdRequisicao)
                        .WillCascadeOnDelete(false);
        }
    }
}