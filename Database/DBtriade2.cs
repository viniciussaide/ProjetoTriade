using Model;
using System.Data.Entity;

namespace Database
{
    public class DBtriade2 : DbContext
    {
        public DBtriade2(): base("DBtriade2")
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<ProdutoComposto> ProdutosCompostos { get; set; }
        public DbSet<ProdutosNasRequisicoes> ProdutosNasRequisicoes { get; set; }
        public DbSet<Requisicao> Requisicao { get; set; }
    }
}