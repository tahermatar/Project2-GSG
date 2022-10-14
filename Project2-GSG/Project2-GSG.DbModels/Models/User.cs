﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Project2_GSG.Models
{
    public partial class User
    {
        //public User()
        //{
        //    Todos = new HashSet<Todo>();
        //}

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Image { get; set; }
        public bool IsAdmin { get; set; }

        //[Timestamp]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDateUTC { get; set; }

        //[Timestamp]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedDateUTC { get; set; }
        public bool Archived { get; set; }

        public virtual ICollection<Todo> Todos { get; set; }
    }
}
