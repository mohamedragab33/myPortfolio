using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Mapper
{
    public class maps: Profile
    {
        public maps()
        {
            CreateMap<PortfileItems, Portfolies>();
            CreateMap<EntityBase, Portfolies>();
        }
    }
}
