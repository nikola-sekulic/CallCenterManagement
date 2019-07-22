using AutoMapper;
using CallCenter.Core.Dtos;
using CallCenter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCenter.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Reclamations, ReclamationDto>().ReverseMap();
            CreateMap<Employees, EmployeeDto>().ReverseMap();
        }
    }
}
