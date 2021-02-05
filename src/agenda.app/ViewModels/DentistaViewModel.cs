using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace agenda.app.ViewModels
{
    public class DentistaViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Imagem { get; set; }
       // public IFormFile ImagemUPload { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }


        public IEnumerable<ConsultaViewModel> Consultas { get; set; }
    }
}
