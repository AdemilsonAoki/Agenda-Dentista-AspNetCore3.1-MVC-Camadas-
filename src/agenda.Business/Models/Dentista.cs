using System;
using System.Collections.Generic;
using System.Text;

namespace agenda.Business.Models
{
    public class Dentista : Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string  Imagem { get; set; }
        public bool Ativo { get; set; }


        public IEnumerable<Consulta> Consultas { get; set; }

    }
}
