using AMDemo.Controllers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMDemo
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<SubDTO, Sub>();
            CreateMap<InternalDTO, Internal>()
                   .ForMember(dest =>
                       dest.Line,
                       opt => opt.MapFrom(src => src.LineDTO)); //Mapeamento de campos diferentes
        }
    }
}