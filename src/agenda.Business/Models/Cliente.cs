using System;
using System.Collections.Generic;
using System.Text;

namespace agenda.Business.Models
{
    public partial class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoCliente TipoCliente { get; set; }
        public Endereco Endereco { get; set; }
        public bool Ativo { get; set; }


    }
}
