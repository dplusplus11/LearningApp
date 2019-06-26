using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LearningApp.Models
{
    [Table("Language", Schema="dbo")]
    public class Language
    {
        [Key][Required]
        public int Id { get; set; }
        [Required][MaxLength(50)]
        public string Name { get; set; }
    }
}