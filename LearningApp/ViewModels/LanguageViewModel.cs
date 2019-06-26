using LearningApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningApp.ViewModels
{
    public class LanguageViewModel
    { 
        public IEnumerable<Course> Courses { get; set; }
        public Language Language { get; set; }

    }
}