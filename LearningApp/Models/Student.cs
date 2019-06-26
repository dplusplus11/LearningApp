using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LearningApp.Models
{
    [Table("Student", Schema = "dbo")]
    public class Student
    {
        public Student()
        {
            Joined = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        [MaxLength(20)]
        public string Username { get; set; }
        [MaxLength(30)]
        public string GitHub { get; set; }
        [MaxLength(150)]
        public string Location { get; set; }
        public DateTime Joined { get; set; }
        public DateTime? BirthDate { get; set; }

    }
}