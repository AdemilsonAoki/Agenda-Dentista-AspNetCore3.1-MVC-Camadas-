using System;
using System.Collections.Generic;
using System.Text;

namespace agenda.Business.Models
{
    public class Consulta : Entity
    {
        public Guid DentistaId { get; set; }
        public Guid  ClienteId { get; set; }

        public DateTime DataConsulta { get; set; }

        public string Descricao { get; set; }


        //Ef Relation
        public Dentista Dentista { get; set; }

        public Cliente Cliente { get; set; }


    }
}
