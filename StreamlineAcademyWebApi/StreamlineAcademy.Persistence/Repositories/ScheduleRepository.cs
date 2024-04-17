using Microsoft.EntityFrameworkCore;
using StreamlineAcademy.Application.Abstractions.IRepositories;
using StreamlineAcademy.Domain.Entities;
using StreamlineAcademy.Domain.Models.Responses;
using StreamlineAcademy.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Persistence.Repositories
{
    public class ScheduleRepository : BaseRepository<Schedule>, IScheduleRepository
    {
        private readonly StreamlineDbContet context;

        public ScheduleRepository(StreamlineDbContet context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Schedule>> GetAsync(Expression<Func<Schedule, bool>> predicate)
        {
            return await context.Schedules
                .Include(s => s.Batch) // Include if there's a navigation property to Batch
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<List<ScheduleResponseModel>> GetAllSchedules()
        {
            var schedules = await context.Schedules
                .Include(s => s.Batch)
                .Select(s => new ScheduleResponseModel
                {
                    Id = s.Id,
                    DayOfWeek = s.DayOfWeek,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime,
                    BatchName = s.Batch!.BatchName
                })
                .ToListAsync();

            return schedules;
        }

        
    }
}
