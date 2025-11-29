using System.Runtime.CompilerServices;

namespace KeepDocument.Models
{
    public class Document
    {
        public int Id { get; set; } 
        public string FileName { get; set; }     //stored file name
        public string OriginalFileName { get; set; } //name uploaded by user
        public string StoredFileName { get; set; }
        public string FilePath { get; set; } //relative path    
        public long Size { get; set; }
        public string ContentType { get; set; } // MIME type
        public string RelativePath { get; set; }
        public string ThumbnailPath { get; set; }
        public string UserId { get; set; } // Owner of the document
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;


    }
}
