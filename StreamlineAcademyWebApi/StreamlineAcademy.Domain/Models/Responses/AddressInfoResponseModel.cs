﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Domain.Models.Responses
{
    public class AddressInfoResponseModel
    {
        public Guid Id { get; set; }
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
        public string? CountryName { get; set; }
        public string? StateName { get; set; }
        public string? CityName { get; set; }
    }

    public class AddressInfoUpdateModel
    {
        
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
        public string? CountryName { get; set; }
        public string? StateName { get; set; }
        public string? CityName { get; set; }
    }
}
