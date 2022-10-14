using Project2_GSG.ModelViews;

namespace Project2_GSG.Core.Manager.Interface
{
    public interface IRoleManager : IManager
    {
        public bool CheckAccess(UserModel userModel);
    }
}
