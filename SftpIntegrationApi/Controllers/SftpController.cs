using Microsoft.AspNetCore.Mvc;
using SftpIntegrationApi.Interfaces;

namespace SftpIntegrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SftpController : ControllerBase
    {
        private readonly ISftpService _sftpService;

        public SftpController(ISftpService sftpService)
        {
            _sftpService = sftpService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Please select a file.");
            }

            await _sftpService.UploadFileAsync(file);

            return Ok(new
            {
                Message = "File uploaded successfully.",
                FileName = file.FileName
            });
        }

        [HttpGet("file/{fileName}")]
        public async Task<IActionResult> GetFile(string fileName)
        {
            var fileStream = await _sftpService.GetFileAsync(fileName);

            return File(fileStream, "application/octet-stream", fileName);
        }
    }
}