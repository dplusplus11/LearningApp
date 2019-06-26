using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LearningApp.Models
{
    [Table("Plan", Schema = "dbo")]
    public class Plan
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double Fee { get; set; }
        public byte Duration { get; set; }
        public byte Discount { get; set; }

        
    }
}