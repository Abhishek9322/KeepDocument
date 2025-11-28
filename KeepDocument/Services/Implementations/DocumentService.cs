
using KeepDocument.DTOs.DocumentSTOs;
using KeepDocument.Helpers.DocumentHelper;
using KeepDocument.Models;
using KeepDocument.Repositories.Interfaces;
using KeepDocument.Services.Interfaces;

namespace KeepDocument.Services.Implementations
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _repository;   
        private readonly IWebHostEnvironment _environment;
        public DocumentService(IDocumentRepository repository,IWebHostEnvironment environment)
        {
            _environment = environment;
            _repository = repository;
        }

        public async Task<Document> UploadDocument(DocumentUploadDto dto, string userId)
        {
            var filePath = await FileHelper.SaveFile(dto.File, _environment.WebRootPath);

            var document = new Document
            {
                FileName = Path.GetFileName(filePath),
                OriginalFileName = dto.File.FileName,
                FilePath = filePath,
                ContentType = dto.File.ContentType,
                UserId = userId,     ///userid is comming null here 
                UploadedAt = DateTime.UtcNow
            };

            return await _repository.AddDocument(document);
        }
    }
}
