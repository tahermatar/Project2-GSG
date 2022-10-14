using AutoMapper;
using Project2_GSG.Models;
using Project2_GSG.ModelView;
using Project2_GSG.ModelViews;
using Project2_GSG.ModelViews.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_GSG.Core.Mapper
{
    public class Mapping : Profile 
    {
        public Mapping()
        {
            CreateMap<UserResponse, User>().ReverseMap();
            CreateMap<UserResult, User>().ReverseMap();
            CreateMap<LoginModel, User>().ReverseMap();
            CreateMap<UserRegistrationModel, User>().ReverseMap();
            CreateMap<UserModel, User>().ReverseMap();
        }
    }
}
