using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Domain.Models.Responses
{
    public class ScheduleResponseModel
    {
        public Guid? Id { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public string? BatchName { get; set; }
    }
}
