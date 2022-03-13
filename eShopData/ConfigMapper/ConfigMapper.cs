using AutoMapper;
using eShopData.DTOs;
using eShopData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopData.ConfigMapper
{
    internal class ConfigMapper : Profile
    {
        public ConfigMapper()
        {
            CreateMap<User,UserModel>().ReverseMap();
        }
    }
}
