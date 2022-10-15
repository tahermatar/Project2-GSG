using Project2_GSG.ModelViews;
using Project2_GSG.ModelViews.ModelView;

namespace Project2_GSG.Core.Manager.Interface
{
    public interface IUserManager : IManager
    {
        public UserResponse SignUp(UserRegistrationModel userReg);
        public UserResponse Login(LoginModel userReg);
        public UserModel UpdateProfile(UserModel request, UserModel currentUser);
        public void DeleteUser(UserModel currentUser, int id);
    }
}
