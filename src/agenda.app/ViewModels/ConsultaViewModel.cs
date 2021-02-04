using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace agenda.app.ViewModels
{
    public class ConsultaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataConsulta { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        public DentistaViewModel Dentista { get; set; }

        public ClienteViewModel Cliente { get; set; }
    }
}
