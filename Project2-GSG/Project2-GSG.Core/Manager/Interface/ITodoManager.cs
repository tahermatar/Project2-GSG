using Project2_GSG.ModelViews.ModelView;

namespace Project2_GSG.Core.Manager.Interface
{
    public interface ITodoManager
    {
        public TodoResponse CreateItem(TodoCreate createItem);
        public TodoResponse AddItem(TodoCreate createItem);
        public TodoResponse UpdateItem(TodoResponse currentItem, TodoResponse request);
        public void DeleteItem(TodoResponse currentItem, int id);
    }
}
