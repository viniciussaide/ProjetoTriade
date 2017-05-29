﻿using Database;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class ProdutosController
    {
        public DBtriade Banco { get; set; }

        public ProdutosController()
        {
            Banco = new DBtriade();
        }

        public void Salvar(ProdutoSimples produtoSimples)
        {
            Banco.Produtos.Add(produtoSimples);
            Banco.SaveChanges();
        }

        public void Salvar(ProdutoComposto produtoComposto)
        {
            Banco.Produtos.Add(produtoComposto);
            Banco.SaveChanges();
        }

        public IList<Produto> Listar()
        {
            return Banco.Produtos.ToList();
        }

        public IList<ProdutoComposto> ListarProdutosCompostos()
        {
            return Banco.ProdutosCompostos.ToList();
        }

        public IList<ProdutoSimples> ListarProdutosSimples()
        {
            return Banco.ProdutosSimples.ToList();
        }

        public ProdutoSimples SelecionarProdutosSimples(int id)
        {
            return Banco.ProdutosSimples.Where(x => x.Id == id).FirstOrDefault();
        }

        public ProdutoComposto SelecionarProdutosCompostos(int id)
        {
            return Banco.ProdutosCompostos.Where(x => x.Id == id).FirstOrDefault();
        }

        public Produto Selecionar(int id)
        {
            return Banco.Produtos.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Alterar(Produto produto)
        {
            ProdutoSimples produtoSalvar = Banco.ProdutosSimples.Where(x => x.Id == produto.Id).First();
            produtoSalvar.Nome = produto.Nome;
            produtoSalvar.PrecoCusto = produto.PrecoCusto;
            produtoSalvar.PrecoVenda = produto.PrecoVenda;
            Banco.SaveChanges();
        }

        //public void Alterar(ProdutoSimples produtoSimples)
        //{
        //    ProdutoSimples produtoSalvar = Banco.ProdutosSimples.Where(x => x.Id == produtoSimples.Id).First();
        //    produtoSalvar.Nome = produtoSimples.Nome;
        //    produtoSalvar.PrecoCusto = produtoSimples.PrecoCusto;
        //    produtoSalvar.PrecoVenda = produtoSimples.PrecoVenda;
        //    produtoSalvar.Quantidade = produtoSimples.Quantidade;
        //    Banco.SaveChanges();
        //}

        public void Alterar(ProdutoComposto produtoComposto)
        {
            ProdutoComposto produtoSalvar = Banco.ProdutosCompostos.Where(x => x.Id == produtoComposto.Id).First();
            produtoSalvar.Nome = produtoComposto.Nome;
            produtoSalvar.PrecoCusto = produtoComposto.PrecoCusto;
            produtoSalvar.PrecoVenda = produtoComposto.PrecoVenda;
            Banco.SaveChanges();
        }

        public void Excluir(Produto produto)
        {
            Produto produtoExcluir = Banco.Produtos.Where(x => x.Id == produto.Id).First();
            Banco.Set<Produto>().Remove(produtoExcluir);
            Banco.SaveChanges();
        }
    }
}
