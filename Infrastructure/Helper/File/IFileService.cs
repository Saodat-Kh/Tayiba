using Microsoft.AspNetCore.Http;

namespace Infrastructure.File;

public interface IFileService
{
    Task<string> SaveFile(IFormFile file, string relativeFolder);
    Task DeleteFile(string relativePath);
}