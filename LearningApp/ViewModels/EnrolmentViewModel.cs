using LearningApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningApp.ViewModels
{
    public class EnrolmentViewModel
    {
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable< Course> Courses{ get; set; }
        public Course Course { get; set; }
        public IEnumerable<Plan> Plans { get; set; }
        public Enrolment Enrolment { get; set; }
    }
}