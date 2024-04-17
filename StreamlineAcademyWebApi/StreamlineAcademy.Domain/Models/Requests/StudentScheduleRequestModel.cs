using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Domain.Models.Requests
{
    public class StudentScheduleRequestModel
    {
        public Guid? StudentId { get; set; }
        public Guid? ScheduleId { get; set; }
    }
}
