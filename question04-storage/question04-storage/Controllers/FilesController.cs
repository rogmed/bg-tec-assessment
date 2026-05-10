using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using question04_storage.Data;
using question04_storage.Models;

namespace question04_storage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly FileDbContext _db;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName;

        public FilesController(FileDbContext db, BlobServiceClient blobServiceClient, IConfiguration config)
        {
            _db = db;
            _blobServiceClient = blobServiceClient;
            _containerName = config.GetValue<string>("AzureStorage:ContainerName") ?? "uploads";
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file, [FromForm] string? location)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var container = _blobServiceClient.GetBlobContainerClient(_containerName);
            await container.CreateIfNotExistsAsync(PublicAccessType.None);

            var extension = Path.GetExtension(file.FileName);
            var blobName = $"{Guid.NewGuid()}{extension}";
            var blobClient = container.GetBlobClient(blobName);

            var headers = new BlobHttpHeaders { ContentType = file.ContentType };

            using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, headers);
            }

            var metadata = new FileMetadata
            {
                Id = Guid.NewGuid(),
                Name = Path.GetFileNameWithoutExtension(file.FileName),
                Size = file.Length,
                ContentType = file.ContentType ?? "application/octet-stream",
                Extension = extension,
                Location = location,
                TimestampProcessed = DateTime.UtcNow,
                BlobPath = blobClient.Uri.ToString()
            };

            _db.FileMetadatas.Add(metadata);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = metadata.Id }, metadata);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var items = await _db.FileMetadatas.OrderByDescending(x => x.TimestampProcessed).ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _db.FileMetadatas.FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
    }
}
