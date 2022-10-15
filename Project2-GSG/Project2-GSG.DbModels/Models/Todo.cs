using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2_GSG.Models
{
    public partial class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DefaultValue("")]
        public string Image { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public int UserId { get; set; }
        public int CreatorId { get; set; }

        //[Timestamp]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDateUTC { get; set; }

        //[Timestamp]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedDateUTC { get; set; }
        public bool Archived { get; set; }

        public virtual User User { get; set; }
    }
}
