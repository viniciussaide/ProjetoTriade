using System;
using System.Collections.Generic;

namespace Model
{
    public class Request
    {
        //Classe base para objetos do tipo Requisicao.
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string Worker { get; set; }

        public virtual ICollection<ProductRequest> Products { get; set; }
    }
}
