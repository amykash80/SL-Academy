using Org.BouncyCastle.Asn1.Ocsp;
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
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }
        public async Task<ApiResponse<LocationResponseModel>> AddLocation(LocationRequestModel model)
        {
            if (await locationRepository.FirstOrDefaultAsync(x => x.Address == model.Address) is not null)
                return ApiResponse<LocationResponseModel>.ErrorResponse(APIMessages.LocationManagement.LocationAlreadyRegistered, HttpStatusCodes.Conflict);

            var location = new Location()
            {
                Address = model.Address,
                PostalCode = model.PostalCode,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                AcademyId=model.AcademyId,
                CountryId=model.CountryId,
                StateId=model.StateId,
                CityId=model.CityId,
                IsActive=true,
                CreatedBy = Guid.Empty,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                DeletedBy = Guid.Empty,
                DeletedDate = DateTime.Now,
            };
            var res = await locationRepository.InsertAsync(location);
            if (res > 0)
            {
                var locationResponse = await locationRepository.GetLocationJoinById(location.Id);
                return ApiResponse<LocationResponseModel>.SuccessResponse(locationResponse, HttpStatusCodes.OK.ToString());
            }
            return ApiResponse<LocationResponseModel>.ErrorResponse(APIMessages.TechnicalError, HttpStatusCodes.InternalServerError);
        }
    }
}
