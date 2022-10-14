using System.ComponentModel;

namespace Project2_GSG.ModelViews.ModelView
{
    public class UserResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DefaultValue("")]
        public string Image { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }
    }
}
