using AutoMapper;
using Project2_GSG.Models;
using Project2_GSG.ModelView;
using Project2_GSG.ModelViews;
using Project2_GSG.ModelViews.ModelView;

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
            CreateMap<TodoCreate, Todo>().ReverseMap();
            CreateMap<TodoResponse, Todo>().ReverseMap();
        }
    }
}
