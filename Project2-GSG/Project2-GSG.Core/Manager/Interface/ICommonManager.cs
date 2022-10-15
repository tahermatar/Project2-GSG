using Project2_GSG.ModelViews;

namespace Project2_GSG.Core.Manager.Interface
{
    public interface ICommonManager : IManager
    {
        public UserModel GetUserRole(UserModel user);
    }
}
