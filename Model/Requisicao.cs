﻿using System;
using System.Collections.Generic;

namespace Model
{
    public class Requisicao
    {
        //Classe base para objetos do tipo Requisicao.
        public int Id { get; set; }
        public DateTime DataRequisicao { get; set; }
        public string Funcionario { get; set; }

        public virtual ICollection<ProdutosNasRequisicoes> ProdutosNasRequisicoes { get; set; }
    }
}
