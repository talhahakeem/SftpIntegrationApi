using Microsoft.AspNetCore.Http;

namespace SftpIntegrationApi.Interfaces
{
    public interface ISftpService
    {
        Task UploadFileAsync(IFormFile file);

        Task<Stream> GetFileAsync(string fileName);
    }
}