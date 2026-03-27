using Microsoft.AspNetCore.Http;

namespace Infrastructure.File;

public class FileService(string rootPath) : IFileService
{
    public async Task<string> SaveFile(IFormFile file, string relativeFolder)
    {
        var path = Path.Combine(rootPath, relativeFolder);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var filePath = Path.Combine(path, fileName);
        await using FileStream fileStream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(fileStream);
        return Path.Combine(relativeFolder, fileName);

    }

    public Task DeleteFile(string relativePath)
    {
        var full = Path.Combine(rootPath, "wwwroot", relativePath.Replace("/", Path.DirectorySeparatorChar.ToString()));
        if(System.IO.File.Exists(full)) 
            System.IO.File.Delete(full);

        return Task.CompletedTask;
    }
}