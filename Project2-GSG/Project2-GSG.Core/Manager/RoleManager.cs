using AutoMapper;
using Project2_GSG.Core.Manager.Interface;
using Project2_GSG.Models;
using Project2_GSG.ModelViews;
using System.Linq;

namespace Project2_GSG.Core.Manager
{
    public class RoleManager : IRoleManager
    {
        private project2_gsgContext _project2_gsgContext;
        private IMapper _mapper;

        public RoleManager(project2_gsgContext project2_gsgContext, IMapper mapper)
        {
            _project2_gsgContext = project2_gsgContext;
            _mapper = mapper;
        }
        public bool CheckAccess(UserModel userModel)
        {
            var isAdmin = _project2_gsgContext.Users
                                       .Any(a => a.Id == userModel.Id
                                                 && a.IsAdmin);
            return isAdmin;
        }
    }
}
