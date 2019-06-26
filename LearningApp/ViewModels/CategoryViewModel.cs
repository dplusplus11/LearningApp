using LearningApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningApp.ViewModels
{
    public class CategoryViewModel
    {
       
        public IEnumerable<Course> Courses { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Language> Language { get; set; }

    }
}