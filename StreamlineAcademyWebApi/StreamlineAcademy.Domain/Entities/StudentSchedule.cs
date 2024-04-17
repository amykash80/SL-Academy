using StreamlineAcademy.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Domain.Entities
{
    public class StudentSchedule:BaseModel
    {
      public Guid? StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
     public Student? Student { get; set; }
      public Guid? ScheduleId { get; set; }
        [ForeignKey(nameof(ScheduleId))]
     public Schedule? Schedule { get; set; }  
    }
}
