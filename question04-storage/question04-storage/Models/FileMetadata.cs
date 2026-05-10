using System;

namespace question04_storage.Models
{
    public class FileMetadata
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public long Size { get; set; }
        public string ContentType { get; set; } = null!;
        public string Extension { get; set; } = null!;
        public string? Location { get; set; }
        public DateTime TimestampProcessed { get; set; }
        public string BlobPath { get; set; } = null!;
    }
}