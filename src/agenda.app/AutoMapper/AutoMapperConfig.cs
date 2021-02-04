using agenda.app.ViewModels;
using agenda.Business.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agenda.app.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Dentista, DentistaViewModel>().ReverseMap();
            CreateMap<Consulta, ConsultaViewModel>().ReverseMap();
        }
    }
}
