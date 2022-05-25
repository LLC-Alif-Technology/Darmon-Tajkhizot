using Entities.Enums;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IFileService
    {
        Task<string> AddFileAsync(IFormFile formFile, FileTypes fileType, string folderName);
        string AddFile(IFormFile formFile, FileTypes filetype, string folderName);
        void DeleteFile(string folderName);
    }
}
