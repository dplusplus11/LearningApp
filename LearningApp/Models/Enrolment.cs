using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LearningApp.Models
{
    [Table("Enrolment", Schema ="dbo")]
    public class Enrolment
    {
        private Enrolment enrolment;

        public Enrolment()
        {
        }

        public Enrolment(int id)
        {
        }

        public Enrolment(Enrolment enrolment)
        {
            this.enrolment = enrolment;
        }
        

        [Key, Column(Order = 0)][Required]
        public int CourseID { get; set; }
        [Key, Column(Order = 1)][Required]
        public int StudentID { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
        
        [Required]
        public DateTime? EnrolledAt
        {
            get; set;
        }
        public int PlanID { get; set; }
        public Plan Plan { get; set; }

    }
}