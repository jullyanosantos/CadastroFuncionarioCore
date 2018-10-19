using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<FuncionarioViewModel, Funcionario>()
                .ForMember(d => d.Nascimento, o => o.MapFrom(x => DateTime.ParseExact(x.Nascimento, "ddMMyyyy", System.Globalization.CultureInfo.InstalledUICulture)));
        }
    }
}