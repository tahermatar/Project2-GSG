using Project2_GSG.ModelViews.ModelView;

namespace Project2_GSG.Core.Manager.Interface
{
    public interface ICommonTodoManager : IManager
    {
        public TodoResponse GetTodoRole(TodoResponse user);
    }
}
