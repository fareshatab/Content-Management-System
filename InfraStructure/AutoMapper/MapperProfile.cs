using AutoMapper;
using CMS.Core.Dtos;
using Core.DTOs;
using Core.ViewModels;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Mapping
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile(){
            CreateMap<User, UserViewModel>().ForMember(x=>x.UserType,x=>x.MapFrom(x=>x.UserType.ToString()));
            CreateMap<CreateUserDto, User>();
            CreateMap<User, UpdateUserDto>().ForMember(x=>x.Image,x=>x.Ignore());
            CreateMap<UpdateUserDto, User>().ForMember(x => x.ImgURL, x => x.Ignore());

            CreateMap<Category, CategoryViewModel>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, UpdateCategoryDto>();


            CreateMap<Advertisment, AdvertisementViewModel>().ForMember(x => x.StartDate, x => x.MapFrom(x => x.StartDate.ToString("yyyy:MM:dd"))).ForMember(x => x.EndDate, x => x.MapFrom(x => x.EndDate.ToString("yyyy:MM:dd")));
            CreateMap<CreateAdvertisementDto, Advertisment>().ForMember(x => x.ImageURL, x => x.Ignore()).ForMember(x => x.Owner, x => x.Ignore());
            CreateMap<UpdateAdvertisementDto, Advertisment>().ForMember(x => x.ImageURL, x => x.Ignore()).ForMember(x => x.Owner, x => x.Ignore());
            CreateMap<Advertisment, UpdateAdvertisementDto>().ForMember(x => x.Image, x => x.Ignore());


        }

    }
}
