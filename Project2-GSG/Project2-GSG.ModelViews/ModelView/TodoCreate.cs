using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_GSG.ModelViews.ModelView
{
    public class TodoCreate
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public int UserId { get; set; }
    }
}
