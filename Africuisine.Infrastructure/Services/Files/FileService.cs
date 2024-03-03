using Africuisine.Domain.Repositories.Services;
using Microsoft.AspNetCore.Http;

namespace Africuisine.Infrastructure.Services.Files
{
    public class FileService : IFileService
    {
        public string GenerateUploadPath(string name)
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var uploadDir = Directory.CreateDirectory(Path.Combine(baseDir, "Uploads","Pictures", "Profile")); 
            return Path.Combine(uploadDir.FullName, name);
        }

        public async Task Upload(IFormFile file, string path)
        {
            using(var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }
    }
}