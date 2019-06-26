using LearningApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningApp.ViewModels
{
    public class CourseViewModel
    { 
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Language> Languages { get; set; }
        public Course Course { get; set; }

    }
}