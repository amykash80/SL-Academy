using StreamlineAcademy.Domain.Entities;
using StreamlineAcademy.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Domain.Models.Requests
{
    public class ScheduleRequestModel
    {
        [Required(ErrorMessage = "Day of the week is required.")]
        public DayOfWeek? DayOfWeek { get; set; }

        [Required(ErrorMessage = "Start time is required.")]
        public TimeSpan? StartTime { get; set; }

        [Required(ErrorMessage = "End time is required.")]
        public TimeSpan? EndTime { get; set; }

        [Required(ErrorMessage = "Batch ID is required.")]
        public Guid? BatchId { get; set; }
    }

    public class ScheduleUpdateRequest : ScheduleRequestModel  // to update  response 
    {
        public Guid Id { get; set; }
    }
}
