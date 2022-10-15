using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project2_GSG.Core.Manager.Interface;
using Project2_GSG.ModelViews;
using System.IO;

namespace Project2_GSG.Controllers
{
    [ApiController]
    [Authorize]
    public class UserController : ApiBaseController
    {
        private IUserManager _userManager;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserManager userManager, ILogger<UserController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [Route("api/user/signUp")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult SignUp([FromBody] UserRegistrationModel userRegistration)
        {
            var user = _userManager.SignUp(userRegistration);
            return Ok(user);
        }

        [Route("api/user/login")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult login([FromBody] LoginModel userLogin)
        {
            var user = _userManager.Login(userLogin);
            return Ok(user);
        }

        [Route("api/user/updateMyProfile")]
        [HttpPut]
        public IActionResult UpdateMyProfile(UserModel request)
        {
            var user = _userManager.UpdateProfile(request, LoggedInUser);

            return Ok(user);
        }

        [Route("api/user/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _userManager.DeleteUser(LoggedInUser, id);
            return Ok();
        }

        [Route("api/user/fileRetrive/profilePic")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Retrive(string fileName)
        {
            var folderPath = Directory.GetCurrentDirectory();
            folderPath = $@"{folderPath}/{fileName}";
            var byteArray = System.IO.File.ReadAllBytes(folderPath);
            return File(byteArray, "image/jpeg", fileName);
        }
    }
}
