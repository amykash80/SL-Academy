using StreamlineAcademy.Application.Abstractions.IRepositories;
using StreamlineAcademy.Domain.Entities;
using StreamlineAcademy.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Persistence.Repositories
{
    public class ScheduleRepository:BaseRepository<Schedule>,IScheduleRepository
    {
        private readonly StreamlineDbContet context;

        public ScheduleRepository(StreamlineDbContet context):base(context)
        {
            this.context = context;
        }
    }
}
