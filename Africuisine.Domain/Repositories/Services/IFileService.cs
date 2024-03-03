using Microsoft.AspNetCore.Http;

namespace Africuisine.Domain.Repositories.Services
{
    public interface IFileService
    {
        Task Upload(IFormFile file, string path);
        string GenerateUploadPath(string name);
    }
}