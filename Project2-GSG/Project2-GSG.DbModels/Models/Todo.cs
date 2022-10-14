using System;
using System.Collections.Generic;

#nullable disable

namespace Project2_GSG.Models
{
    public partial class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDateUTC { get; set; }
        public DateTime UpdatedDateUTC { get; set; }
        public bool Archived { get; set; }

        public virtual User User { get; set; }
    }
}
