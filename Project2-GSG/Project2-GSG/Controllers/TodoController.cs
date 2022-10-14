using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project2_GSG.Attributes;
using Project2_GSG.Core.Manager.Interface;
using Project2_GSG.ModelViews.ModelView;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project2_GSG.Controllers
{
    [ApiController]
    [Authorize]
    public class TodoController : ApiBaseController
    {
        private ITodoManager _todoManager;
        private readonly ILogger<TodoController> _logger;

        public TodoController(ITodoManager todoManager, ILogger<TodoController> logger)
        {
            _todoManager = todoManager;
            _logger = logger;
        }

        // GET: api/<TodoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TodoController>
        [Route("api/todo/createItem")]
        [HttpPost]
        public IActionResult CreateItem([FromBody] TodoCreate createItem)
        {
            var item = _todoManager.CreateItem(createItem);
            return Ok(item);
        }

        [Route("api/todo/AddItem")]
        [Project2_GSGAuthrize]
        [HttpPost]
        public IActionResult AddItem([FromBody] TodoCreate id, TodoCreate createItem)
        {
            var item = _todoManager.AddItem(createItem, id);
            return Ok(item);
        }

        // PUT api/<TodoController>/5
        [Route("api/todo/updateItem")]
        [HttpPut]
        public IActionResult UpdateItem(TodoResponse request)
        {
            var item = _todoManager.UpdateItem(LoggedInTodo, request);
            return Ok(item);
        }

        [Route("api/todo/fileRetrive/profilePic")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Retrive(string fileName)
        {
            var folderPath = Directory.GetCurrentDirectory();
            folderPath = $@"{folderPath}/{fileName}";
            var byteArray = System.IO.File.ReadAllBytes(folderPath);
            return File(byteArray, "image/jpeg", fileName);
        }

        // DELETE api/<TodoController>/5
        [Route("api/todo/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _todoManager.DeleteItem(LoggedInTodo, id);
            return Ok();
        }
    }
}
