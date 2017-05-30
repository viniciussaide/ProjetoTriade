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


        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoSimples> ProdutosSimples { get; set; }
        public DbSet<ProdutoComposto> ProdutosCompostos { get; set; }
        public DbSet<ProdutosDaComposicao> ProdutosDaComposicao { get; set; }
        public DbSet<ProdutosNasRequisicoes> ProdutosNasRequisicoes { get; set; }
        public DbSet<Requisicao> Requisicao { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove< ManyToManyCascadeDeleteConvention > ();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<ProdutosDaComposicao>()
                        .HasRequired(c => c.ProdutoComposto)
                        .WithMany(s => s.ProdutosDaComposicao)
                        .HasForeignKey(c => c.FKprodutoComposto)
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<ProdutosDaComposicao>()
                        .HasRequired(c => c.ProdutoSimples)
                        .WithMany(s => s.ProdutosDaComposicao)
                        .HasForeignKey(c => c.FKprodutoSimples)
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<ProdutosNasRequisicoes>()
                        .HasRequired(pr => pr.Produto)
                        .WithMany(r => r.ProdutosNasRequisicoes)
                        .HasForeignKey(pr => pr.IdProduto)
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<ProdutosNasRequisicoes>()
                        .HasRequired(pr => pr.Requisicao)
                        .WithMany(r => r.ProdutosNasRequisicoes)
                        .HasForeignKey(pr => pr.IdRequisicao)
                        .WillCascadeOnDelete(false);
        }
    }
}