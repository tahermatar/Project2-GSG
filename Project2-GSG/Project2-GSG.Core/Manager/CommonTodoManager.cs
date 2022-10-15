using AutoMapper;
using Project2_GSG.Core.Manager.Interface;
using Project2_GSG.Models;
using Project2_GSG.ModelViews.ModelView;
using System.Linq;
using Tazeez.Common.Extensions;

namespace Project2_GSG.Core.Manager
{
    public class CommonTodoManager : ICommonTodoManager
    {
        private project2_gsgContext _project2_gsgContext;
        private IMapper _mapper;

        public CommonTodoManager(project2_gsgContext project2_gsgContext, IMapper mapper)
        {
            _project2_gsgContext = project2_gsgContext;
            _mapper = mapper;
        }
        public TodoResponse GetTodoRole(TodoResponse todo)
        {
            var dbTodo = _project2_gsgContext.Users
                                          .FirstOrDefault(a => a.Id == todo.Id)
                                          ?? throw new ServiceValidationException("Invalid user id received");

            return _mapper.Map<TodoResponse>(dbTodo);
        }
    }
}
