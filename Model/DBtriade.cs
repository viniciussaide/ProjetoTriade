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
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<ProductComposition>()
                .HasKey(x => new { x.ProdutoId, x.ItemId });

            modelBuilder.Entity<ProductComposition>()
                .HasRequired(x => x.Produto)
                .WithMany(x => x.Itens);

            modelBuilder.Entity<ProductComposition>()
                .HasRequired(x => x.Item)
                .WithMany(x => x.Produtos);

            modelBuilder.Entity<ProductRequest>()
                .HasKey(x => new { x.RequisicaoId, x.ProductId });

            modelBuilder.Entity<ProductRequest>()
                .HasRequired(x => x.Requisicao)
                .WithMany(x => x.Produtos);

            modelBuilder.Entity<ProductRequest>()
                .HasRequired(x => x.Produto)
                .WithMany(x => x.Requisicoes);

            //base.OnModelCreating(modelBuilder);
        }
    }
}