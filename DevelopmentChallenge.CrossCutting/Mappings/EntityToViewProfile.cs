using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DevelopmentChallenge.Domain.Entities;
using DevelopmentChallenge.Domain.Queries.Result;
using DevelopmentChallenge.Domain.View;

namespace DevelopmentChallenge.CrossCutting.Mappings
{
    public class EntityToViewProfile : Profile
    {
        public EntityToViewProfile()
        {
            CreateMap<MDRQueryResult, ViewMDR>()
            .ForMember(s => s.Adquirinte, c => c.MapFrom(m => m.Adquirente))
            .ForMember(s => s.Taxa, c => c.MapFrom(m => m.Taxas)).ReverseMap();

            CreateMap<Taxa, ViewTaxa>()
            .ForMember(s => s.Bandeira, c => c.MapFrom(m => m.Bandeira))
            .ForMember(s => s.Credito, c => c.MapFrom(m => m.Credito))
            .ForMember(s => s.Debito, c => c.MapFrom(m => m.Debito)).ReverseMap();
        }
    }
}