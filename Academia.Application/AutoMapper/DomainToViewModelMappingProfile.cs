using Academia.Application.ViewModel;
using Academia.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappingProfile";
            }
        }

        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteVM>();
            CreateMap<Endereco, EnderecoVM>();
            CreateMap<Cliente, ClienteEnderecoVM>();
            CreateMap<Endereco, ClienteEnderecoVM>();
        }
    }
}
