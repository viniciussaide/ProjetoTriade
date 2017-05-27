using System;
using System.Collections.Generic;

namespace Model
{
    public class Requisicao
    {
        public int Id { get; set; }
        public DateTime DataRequisicao { get; set; }
        public string Funcionario { get; set; }

        public virtual ICollection<ProdutosNasRequisicoes> ProdutosNasRequisicoes { get; set; }

        public override string ToString()
        {
            string texto = Id +" - "+ DataRequisicao.ToString() + " - " + Funcionario;
            return texto;
        }
    }
}
