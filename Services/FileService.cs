using Contracts.Services;
using Entities.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FileService : IFileService
    {
        public string AddFile(IFormFile file, FileTypes fileType, string folderName)
        {
            var path = Path.GetFullPath($"wwwroot/{folderName}/{fileType}");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            var filePath = $"/{DateTime.Now.Ticks}_{file.FileName}";
            using var fs = new FileStream(path + filePath, FileMode.Create);
            file.CopyTo(fs);
            return $"/{folderName}/{fileType}{filePath}";
        }

        public async Task<string> AddFileAsync(IFormFile file, FileTypes fileType, string folderName)
        {
            var path = Path.GetFullPath($"wwwroot/{folderName}/{fileType}");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            var filePath = $"/{DateTime.Now.Ticks}_{file.FileName}";
            await using var fs = new FileStream(path + filePath, FileMode.Create);
            await file.CopyToAsync(fs);
            return $"/{folderName}/{fileType}{filePath}";
        }

        public void DeleteFile(string folderName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/" + folderName);
            if (File.Exists(path))
                File.Delete(path);
        }
    }
}
