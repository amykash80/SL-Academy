using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Domain.Models.Responses
{
    public class CourseResponseModel
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public int? DurationInWeeks { get; set; }
        public string? InstructorName { get; set; }
        public int? Fee { get; set; }
    }
}
