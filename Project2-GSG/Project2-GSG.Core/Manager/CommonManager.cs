using AutoMapper;
using Project2_GSG.Core.Manager.Interface;
using Project2_GSG.Models;
using Project2_GSG.ModelViews;
using System.Linq;
using Tazeez.Common.Extensions;

namespace Project2_GSG.Core.Manager
{
    public class CommonManager : ICommonManager
    {
        private project2_gsgContext _project2_gsgContext;
        private IMapper _mapper;

        public CommonManager(project2_gsgContext project2_gsgContext, IMapper mapper)
        {
            _project2_gsgContext = project2_gsgContext;
            _mapper = mapper;
        }
        public UserModel GetUserRole(UserModel user)
        {
            var dbUser = _project2_gsgContext.Users
                                          .FirstOrDefault(a => a.Id == user.Id)
                                          ?? throw new ServiceValidationException("Invalid user id received");

            return _mapper.Map<UserModel>(dbUser);
        }
    }
}
