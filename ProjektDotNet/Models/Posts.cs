﻿using System.ComponentModel.DataAnnotations;

//One to many
namespace ProjektDotNet.Models
{
    public class Posts
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public virtual ICollection<User>? Users { get; set; }
    }
}
