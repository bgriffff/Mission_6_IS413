﻿using System.ComponentModel.DataAnnotations;

namespace mission_6.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
