﻿using StreamlineAcademy.Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Domain.Models.Responses
{
    public class FileResponseModel
    {
        public Guid?  Id { get; set; }
        public string? FilePath { get; set; }
    }
}
