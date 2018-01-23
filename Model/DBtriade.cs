namespace Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class DBtriade : DbContext
    {
        //Variáveis que representam tabelas em que são armazenados os objetos no banco
        //Usados pelo entity framework para troca de informação entre aplicação e banco de dados
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductComposition> ProductComposition { get; set; }
        public DbSet<ProductRequest> ProductRequest { get; set; }
        public DbSet<Request> Request { get; set; }

        public DBtriade()
            : base("name=DBtriade")
        {
            //Database.SetInitializer<DBtriade>(new CreateDatabaseIfNotExists<DBtriade>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Modelagem do banco mais específicas feitas pelo Fluent API
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<ProductComposition>()
                .HasKey(x => new { x.ProductId, x.ItemId });

            modelBuilder.Entity<ProductComposition>()
                .HasRequired(x => x.Product)
                .WithMany(x => x.Itens);

            modelBuilder.Entity<ProductComposition>()
                .HasRequired(x => x.Item)
                .WithMany(x => x.Products);

            modelBuilder.Entity<ProductRequest>()
                .HasKey(x => new { x.RequestId, x.ProductId });

            modelBuilder.Entity<ProductRequest>()
                .HasRequired(x => x.Request)
                .WithMany(x => x.Products);

            modelBuilder.Entity<ProductRequest>()
                .HasRequired(x => x.Product)
                .WithMany(x => x.Requests);
        }
    }
}