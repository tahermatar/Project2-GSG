using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Project2_GSG.Core.Manager.Interface;
using Project2_GSG.Models;
using Project2_GSG.ModelView;
using Project2_GSG.ModelViews;
using Project2_GSG.ModelViews.ModelView;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Tazeez.Common.Extensions;


namespace Project2_GSG.Core.Manager
{
    public class UserManager : IUserManager
    {
        private project2_gsgContext _project2_gsgContext;
        private IMapper _mapper;

        public UserManager(project2_gsgContext project2_gsgContext, IMapper mapper)
        {
            _project2_gsgContext = project2_gsgContext;
            _mapper = mapper;
        }

        public UserResponse SignUp(UserRegistrationModel userRegistration)
        {
            if(_project2_gsgContext.Users
                                   .Any(a => a.Email.Equals(userRegistration.Email, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new ServiceValidationException("User already exist");
            }

            var hashPassword = HashPassword(userRegistration.Password);
            var user = _project2_gsgContext.Users.Add(new User
            {
                FirstName = userRegistration.FirstName,
                LastName = userRegistration.LastName,
                Email = userRegistration.Email,
                Password = hashPassword,
                ConfirmPassword = hashPassword,
                Image = string.Empty
            }).Entity;

            _project2_gsgContext.SaveChanges();

            var res = _mapper.Map<UserResponse>(user);
            res.Token = $"Bearer {GenerateJWTToken(user)}";

            return res;
        }

        public UserResponse Login(LoginModel userLogin)
        {
            var user = _project2_gsgContext.Users
                                           .FirstOrDefault(a => a.Email
                                                                 .Equals(userLogin.Email, StringComparison.InvariantCultureIgnoreCase));
            if(user == null || !VerifyHashPassword(userLogin.Password, user.Password)){

                throw new ServiceValidationException(300, "Invalid username or password received");
            }

            var res = _mapper.Map<UserResponse>(user);
            res.Token = $"Bearer {GenerateJWTToken(user)}";

            return res;
        }

        public UserModel UpdateProfile(UserModel request, UserModel currentUser)
        {
            var user = _project2_gsgContext.Users
                                           .FirstOrDefault(a => a.Id == currentUser.Id)
                                           ?? throw new ServiceValidationException("User not found");

            var url = "";

            if (!string.IsNullOrWhiteSpace(request.ImageString))
            {
                url = Helper.Helper.SaveImage(request.ImageString, "ProfileImages");
            }


            user.FirstName = request.FirstName;
            user.LastName = request.LastName;

            if (!string.IsNullOrWhiteSpace(url))
            {
                var baseUrl = "https://localhost:44309/";
                user.Image = @$"{baseUrl}/api/v1/user/fileretrive/profilepic?filename={url}";
            }

            _project2_gsgContext.SaveChanges();
            return _mapper.Map<UserModel>(user);
        }

        public void DeleteUser(UserModel currentUser, int id)
        {
            if (currentUser.Id == id)
            {
                throw new ServiceValidationException("you have no access to delete yourself");
            }

            var user = _project2_gsgContext.Users
                                        .FirstOrDefault(a => a.Id == id)
                                        ?? throw new ServiceValidationException("User not found");

            user.Archived = true;
            _project2_gsgContext.SaveChanges();
        }

        #region private

        private static string HashPassword(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            return hashedPassword;
        }

        private static bool VerifyHashPassword(string password, string HashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, HashedPassword);

        }
        private string GenerateJWTToken(User user)
        {
            var jwtKey = "#taher.key*&^vanthis%$^&*()$%^@#$@!@#%$#project";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, $"{user.FirstName} {user.LastName}"),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("Id", user.Id.ToString()), // هان حكيتله انه بدي متغير اسمه اي دي يكون موجود في التوكن
                new Claim("DateOfJoining", user.CreatedDateUTC.ToString("yyyy-MM-dd")), //التاريخ الي سجل فيه اليوزر عندي بالسسيستم
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var issuer = "test.com";

            var token = new JwtSecurityToken(
                        issuer,
                        issuer,
                        claims,
                        expires: DateTime.Now.AddDays(20),
                        signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion private 
    }
}
