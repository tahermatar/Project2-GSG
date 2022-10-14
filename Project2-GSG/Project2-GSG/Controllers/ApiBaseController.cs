using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Project2_GSG.ModelViews;
using System.Linq;
using Tazeez.Common.Extensions;

namespace Project2_GSG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController : Controller
    {
        private UserModel _loggedInUser;

        protected UserModel LoggedInUser
        {
            get
            {
                if (_loggedInUser != null)
                {
                    return _loggedInUser;
                }

                Request.Headers.TryGetValue("Authorization", out StringValues Token);

                if (string.IsNullOrWhiteSpace(Token))
                {
                    _loggedInUser = null;
                    return _loggedInUser;
                }

                var ClaimId = User.Claims.FirstOrDefault(c => c.Type == "Id");

                if (ClaimId == null || !int.TryParse(ClaimId.Value, out int id))
                {
                    throw new ServiceValidationException(401, "Invalid or expired token");
                }

                return _loggedInUser;
            }
        }
    }
}
