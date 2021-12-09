using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace SmartConsult.Data.Requests
{
    public class FileRequestData : IRequest<bool>
    {
        public Guid ProfileId { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
