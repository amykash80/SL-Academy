using StreamlineAcademy.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Domain.Entities
{
    public class Course:BaseModel
    {  
        public string? Name { get; set; }
        public string? Category { get; set; }
        public int? DurationInWeeks{ get; set; }
        public string? InstructorName { get; set; }
        public int? Fee { get; set; }
        public Guid? InstructorId { get; set; }
        [ForeignKey(nameof(InstructorId))]
        public Instructor? Instructor { get; set; }
        public Guid? CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public CourseCategory? CourseCategory { get; set; } 
        
    }
}
