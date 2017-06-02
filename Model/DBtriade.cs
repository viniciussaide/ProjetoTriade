namespace Model
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class DBtriade : DbContext
    {
        public DBtriade(): base("name=DBtriade")
        {
        }

        //Variáveis que representam tabelas em que são armazenados os objetos no banco
        //Usados pelo entity framework para troca de informação entre aplicação e banco de dados
        public DbSet<Product> Produtos { get; set; }
        public DbSet<ProductComposition> ProdutosDaComposicao { get; set; }
        public DbSet<ProductRequest> ProdutosNasRequisicoes { get; set; }
        public DbSet<Request> Requisicao { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Modelagem do banco mais específicas feitas pelo Fluent API
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention> ();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<ProductComposition>()
                .HasKey(x => new { x.IdProdutoComposto, x.IdProdutoSimples });

            modelBuilder.Entity<ProductComposition>()
                .HasRequired(x => x.ProdutoComposto)
                .WithMany(x => x.ProdutosSimples);

            modelBuilder.Entity<ProductComposition>()
                .HasRequired(x => x.ProdutoSimples)
                .WithMany(x => x.ProdutosCompostos);


            modelBuilder.Entity<ProductRequest>()
                .HasKey(x => new { x.IdRequisicao, x.IdProduto });

            modelBuilder.Entity<ProductRequest>()
                .HasRequired(x => x.Requisicao)
                .WithMany(x => x.ProdutosNasRequisicoes);

            modelBuilder.Entity<ProductRequest>()
                .HasRequired(x => x.Produto)
                .WithMany(x => x.ProdutosNasRequisicoes);


            ////Chave estrangeira entre ProdutosDaComposicao e ProdutoComposto
            //modelBuilder.Entity<ProductComposition>()
            //            .HasRequired(c => c.ProdutoComposto)
            //            .WithMany(s => s.ProdutosDaComposicao)
            //            .HasForeignKey(c => c.FKprodutoComposto)
            //            .WillCascadeOnDelete(false);
            ////Chave estrangeira entre ProdutosDaComposicao e ProdutoSimples
            //modelBuilder.Entity<ProductComposition>()
            //            .HasRequired(c => c.ProdutoSimples)
            //            .WithMany(s => s.ProdutosDaComposicao)
            //            .HasForeignKey(c => c.FKprodutoSimples)
            //            .WillCascadeOnDelete(false);
            //Chave estrangeira entre ProdutosNasRequisicoes e Produto
            //modelBuilder.Entity<ProductRequest>()
            //            .HasRequired(pr => pr.Produto)
            //            .WithMany(r => r.ProdutosNasRequisicoes)
            //            .HasForeignKey(pr => pr.IdProduto)
            //            .WillCascadeOnDelete(false);
            ////Chave estrangeira entre ProdutosNasRequisicoes e Requisicao
            //modelBuilder.Entity<ProductRequest>()
            //            .HasRequired(pr => pr.Requisicao)
            //            .WithMany(r => r.ProdutosNasRequisicoes)
            //            .HasForeignKey(pr => pr.IdRequisicao)
            //            .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}