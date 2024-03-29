using Microsoft.AspNetCore.Http;
using StreamlineAcademy.Application.Abstractions.Identity;
using StreamlineAcademy.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Infrastructure.Identity
{
    public class ContextService : IContextService
    {
        private readonly IHttpContextAccessor httpContextAccessor;


		public ContextService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public Guid? GetUserId()
        {
            var userId = httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == AppClaimTypes.UserId)?.Value;

            if (userId == null)
                return null;

            Guid.TryParse(userId, out Guid result);
            return result;
        }

		public string? GetRoleName()
		{
			
		    return httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == AppClaimTypes.UserRole)?.Value;
			
		}
	}
}