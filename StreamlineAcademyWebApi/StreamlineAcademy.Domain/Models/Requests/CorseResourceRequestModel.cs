using StreamlineAcademy.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Domain.Models.Requests
{
    public class CorseResourceRequestModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Course Type is required")]
        public ResourceType? Type { get; set; }
        [Required(ErrorMessage = "CourseId is required")]
        public Guid CourseId { get; set; }  

    }
}
