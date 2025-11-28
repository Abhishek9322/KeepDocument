using KeepDocument.DTOs.DocumentSTOs;
using KeepDocument.Models;

namespace KeepDocument.Services.Interfaces
{
    public interface IDocumentService
    {
        Task<Document> UploadDocument(DocumentUploadDto dto, string userId);
    }
}
