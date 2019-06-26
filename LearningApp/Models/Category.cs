using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LearningApp.Models
{
    [Table("Category", Schema = "dbo")]
    public class Category
    {
        

        public Category()
        {
            Course = new List<Course>();
        }

        
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="Category name is required.")]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string WhatWillYouLearn { get; set; }

        
        public ICollection<Course> Course;

    }
}