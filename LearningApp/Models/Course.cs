using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LearningApp.Models
{
    [Table("Course", Schema = "dbo")]
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        public string Introduction { get; set; }
        [Required]
        public string WhyLearn { get; set; }
        [Required]
        public string TakeAwaySkills { get; set; }
        [Required]
        public string Prerequisites { get; set; }
        [Required]
        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public int? TimeToComplete { get; set; }
        [Required]
        [Range(0,1, ErrorMessage ="This value can be only 0 or 1.")]
        public byte ProCourse { get; set; }

    }
}