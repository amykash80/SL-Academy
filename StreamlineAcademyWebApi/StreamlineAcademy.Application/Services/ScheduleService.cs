using StreamlineAcademy.Application.Abstractions.IRepositories;
using StreamlineAcademy.Application.Abstractions.IServices;
using StreamlineAcademy.Application.Shared;
using StreamlineAcademy.Domain.Entities;
using StreamlineAcademy.Domain.Models.Requests;
using StreamlineAcademy.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Application.Services
{
    public class ScheduleService:IScheduleService
    {
        private readonly IScheduleRepository scheduleRepository;
        private readonly IBatchRepository batchRepository;

        public ScheduleService(IScheduleRepository scheduleRepository,IBatchRepository batchRepository)
        {
            this.scheduleRepository = scheduleRepository;
            this.batchRepository = batchRepository;
        }

        public async Task<ApiResponse<ScheduleResponseModel>> CreateSchedule(ScheduleRequestModel request)
        {
            var existingBatch = await batchRepository.GetByIdAsync(x => x.Id == request.BatchId);
            if (existingBatch == null)
                return ApiResponse<ScheduleResponseModel>.ErrorResponse(APIMessages.ScheduleManagement.BatchNotFoundForSchedule, HttpStatusCodes.NotFound);
            if (request.StartTime >= request.EndTime)
                return ApiResponse<ScheduleResponseModel>.ErrorResponse("Start time must be before end time.", HttpStatusCodes.BadRequest);
            var schedule = new Schedule()
            {
                DayOfWeek = request.DayOfWeek!.Value,
                StartTime = request.StartTime!.Value,
                EndTime = request.EndTime!.Value,
                BatchId = request.BatchId!.Value,
                IsActive = true,
                CreatedBy = Guid.Empty,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                DeletedBy = Guid.Empty,
                DeletedDate = DateTime.Now,
            };  
            var res = await scheduleRepository.InsertAsync(schedule);
            if (res > 0)
            {
                var scheduleResponse = new ScheduleResponseModel
                {
                    Id = schedule.Id,
                    DayOfWeek = schedule.DayOfWeek,
                    StartTime = schedule.StartTime,
                    EndTime = schedule.EndTime,
                    BatchName = existingBatch.BatchName 
                };
                return ApiResponse<ScheduleResponseModel>.SuccessResponse(scheduleResponse, APIMessages.ScheduleManagement.ScheduleAdded, HttpStatusCodes.Created);
            }
            return ApiResponse<ScheduleResponseModel>.ErrorResponse(APIMessages.TechnicalError, HttpStatusCodes.InternalServerError);
        }

        public async Task<ApiResponse<IEnumerable<ScheduleResponseModel>>> GetAllSchedulesByBatchId(Guid batchId)
        {
            var schedules = await GetByIdAsync(schedule => schedule.BatchId == batchId);

            if (schedules != null && schedules.Any())
            {
                // Map schedules to response models
                var scheduleResponseList = schedules.Select(schedule => new ScheduleResponseModel
                {
                    Id = schedule.Id,
                    DayOfWeek = schedule.DayOfWeek,
                    StartTime = schedule.StartTime,
                    EndTime = schedule.EndTime,
                    BatchName = schedule.Batch?.BatchName // Include batch name in the response
                });

                return ApiResponse<IEnumerable<ScheduleResponseModel>>.SuccessResponse(scheduleResponseList, $"Found {schedules.Count()} schedules for batch {schedules.First().Batch.BatchName}.");
            }

            return ApiResponse<IEnumerable<ScheduleResponseModel>>.ErrorResponse($"No schedules found for batch with ID {batchId}.", HttpStatusCodes.NotFound);
        }

    }

}
