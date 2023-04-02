﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AbbyWeb.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1 and 100 only")]
        public int DisplayOrder { get; set; }
    }
}
