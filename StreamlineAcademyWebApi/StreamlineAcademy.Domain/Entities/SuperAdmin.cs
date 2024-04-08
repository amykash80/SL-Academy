using StreamlineAcademy.Domain.Enums;
using StreamlineAcademy.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Domain.Entities
{
    public  class SuperAdmin:BaseModel
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; }
        public UserRole UserRole { get; set; }
        public Guid? CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public Country? Country { get; set; }
        public Guid? StateId { get; set; }
        [ForeignKey(nameof(StateId))]
        public State? State { get; set; }
        public Guid? CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public City? City { get; set; }
    }
}
