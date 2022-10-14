using AutoMapper;
using Project2_GSG.Core.Manager.Interface;
using Project2_GSG.Models;
using Project2_GSG.ModelViews.ModelView;
using System;
using System.Linq;
using Tazeez.Common.Extensions;

namespace Project2_GSG.Core.Manager
{
    public class TodoManager : ITodoManager
    {
        private project2_gsgContext _project2_gsgContext;
        private IMapper _mapper;
        public TodoManager(project2_gsgContext project2_gsgContext
                          ,IMapper mapper)
        {
            _project2_gsgContext = project2_gsgContext;
            _mapper = mapper;
        }

        public TodoResponse CreateItem(TodoCreate createItem)
        {
            if (_project2_gsgContext.Todos
                                   .Any(a => a.Title.Equals(createItem.Title, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new ServiceValidationException("Item already exist");
            }

            var Item = _project2_gsgContext.Add(new Todo
            {
                Title = createItem.Title,
                Content = createItem.Content,
                Image = string.Empty
            }).Entity;

            _project2_gsgContext.SaveChanges();

            var res = _mapper.Map<TodoResponse>(Item);

            return res;
        }

        public TodoResponse AddItem(TodoCreate createItem)
        {
            var item = _project2_gsgContext.Todos
                                           .FirstOrDefault(a => a.Id == createItem.UserId)
                                           ?? throw new ServiceValidationException("User not found");

            var Item = _project2_gsgContext.Add(new Todo
            {
                Title = createItem.Title,
                Content = createItem.Content,
                Image = string.Empty
            }).Entity;

            _project2_gsgContext.SaveChanges();

            var res = _mapper.Map<TodoResponse>(Item);

            return res;
        }

        public TodoResponse UpdateItem(TodoResponse currentItem, TodoResponse request)
        {
            var item = _project2_gsgContext.Todos
                                           .FirstOrDefault(a => a.Id == currentItem.Id)
                                           ?? throw new ServiceValidationException("User not found");

            var url = "";

            if (!string.IsNullOrWhiteSpace(request.ImageString))
            {
                url = Helper.Helper.SaveImage(request.ImageString, "ProfileImages");
            }


            item.Title= request.Title;
            item.Content = request.Content;

            if (!string.IsNullOrWhiteSpace(url))
            {
                var baseUrl = "https://localhost:44309/";
                item.Image = @$"{baseUrl}/api/v1/user/fileretrive/profilepic?filename={url}";
            }

            _project2_gsgContext.SaveChanges();
            return _mapper.Map<TodoResponse>(item);
        }

        public void DeleteItem(TodoResponse currentItem, int id)
        {
            if (currentItem.Id == id)
            {
                throw new ServiceValidationException("you have no access to delete yourself");
            }

            var item = _project2_gsgContext.Todos
                                        .FirstOrDefault(a => a.Id == id)
                                        ?? throw new ServiceValidationException("User not found");

            item.Archived = true;
            _project2_gsgContext.SaveChanges();
        }
    }
}
