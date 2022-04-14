using AutoMapper;
using eShopData.DTOs;
using eShopData.DTOs.User;
using eShopData.Entities;

namespace eShopData.ConfigMapper
{
    public class ConfigMapper : Profile
    {
        public ConfigMapper()
        {
            CreateMap<User,UserModel>().ReverseMap();
            CreateMap<User, RegisterModel>().ReverseMap();
            CreateMap<User, LoginModel>().ReverseMap();
        }
    }
}
