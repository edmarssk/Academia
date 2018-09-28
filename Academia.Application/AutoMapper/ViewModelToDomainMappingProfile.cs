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
    public class ViewModelToDomainMappingProfile: Profile
    {

        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappingProfile";
            }
        }
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteVM, Cliente>();
            CreateMap<EnderecoVM, Endereco>();
            CreateMap<ClienteEnderecoVM, Cliente>();
            CreateMap<ClienteEnderecoVM, Endereco>();
        }
    }
}
