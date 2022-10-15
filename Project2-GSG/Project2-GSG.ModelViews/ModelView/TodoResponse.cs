using System.ComponentModel;

namespace Project2_GSG.ModelViews.ModelView
{
    public class TodoResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DefaultValue("")]
        public string Image { get; set; }
        public string ImageString { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        //public string Token { get; set; }
    }
}
