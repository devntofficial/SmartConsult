using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace SmartConsult.Data.Services
{
    public interface IFileService
    {
        bool UploadFiles(Guid id, List<IFormFile> files);
        void DeleteFiles(Guid id, List<IFormFile> files);
    }
}
