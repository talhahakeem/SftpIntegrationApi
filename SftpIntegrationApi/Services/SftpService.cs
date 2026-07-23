using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Renci.SshNet;
using SftpIntegrationApi.Interfaces;
using SftpIntegrationApi.Models;

namespace SftpIntegrationApi.Services
{
    public class SftpService : ISftpService
    {
        private readonly SftpSettings _settings;

        public SftpService(IOptions<SftpSettings> options)
        {
            _settings = options.Value;
        }

        public async Task UploadFileAsync(IFormFile file)
        {
            using var client = new SftpClient(
                _settings.Host,
                _settings.Port,
                _settings.Username,
                _settings.Password);

            client.Connect();

            using var stream = file.OpenReadStream();

            var remoteFilePath = $"{_settings.RemotePath}/{file.FileName}";

            client.UploadFile(stream, remoteFilePath);

            client.Disconnect();

            await Task.CompletedTask;
        }

        public async Task<Stream> GetFileAsync(string fileName)
        {
            using var client = new SftpClient(
                _settings.Host,
                _settings.Port,
                _settings.Username,
                _settings.Password);

            client.Connect();

            var remoteFilePath = $"{_settings.RemotePath}/{fileName}";

            var memoryStream = new MemoryStream();

            client.DownloadFile(remoteFilePath, memoryStream);

            client.Disconnect();

            memoryStream.Position = 0;

            return await Task.FromResult(memoryStream);
        }
    }
}