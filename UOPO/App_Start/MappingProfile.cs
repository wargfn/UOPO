using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using UOPO.DTOs;
using UOPO.Models;

namespace UOPO.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<GroupCards, GroupCardsDTO>();
            Mapper.CreateMap<GroupCardsDTO, GroupCards>();
            Mapper.CreateMap<AdventuresModel, AdventuresDTO>();
            Mapper.CreateMap<AdventuresDTO, AdventuresModel>();
        }
    }
}