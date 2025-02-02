﻿using System.ComponentModel.DataAnnotations;

namespace myshop.Entities.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; } = string.Empty;    
        public string Description { get; set; } = string.Empty ;
        public DateTime CreatedDate { get; set; }   = DateTime.Now;
    }
}
