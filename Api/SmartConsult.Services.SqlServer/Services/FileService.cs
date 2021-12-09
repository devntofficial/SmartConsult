using Microsoft.AspNetCore.Http;
using SmartConsult.Data.Services;
using System;
using System.Collections.Generic;

namespace SmartConsult.Services.SqlServer.Services
{
    public class FileService : IFileService
    {
        public void DeleteFiles(Guid id, List<IFormFile> files)
        {
            Console.WriteLine($"For profile {id}, {files.Count} file(s) deleted");
        }

        public bool UploadFiles(Guid id, List<IFormFile> files)
        {
            if (true)
            {
                Console.WriteLine($"For profile {id}, {files.Count} file(s) saved");
                return true;
            }
            return false;
        }
    }
}
