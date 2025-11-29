
using KeepDocument.DTOs.DocumentSTOs;
using KeepDocument.Helpers.DocumentHelper;
using KeepDocument.Models;
using KeepDocument.Repositories.Interfaces;
using KeepDocument.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace KeepDocument.Services.Implementations
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _repository;   
        private readonly IWebHostEnvironment _environment;
        private readonly string _baseUrl;

        public DocumentService(IDocumentRepository repository,IWebHostEnvironment environment,IConfiguration config)
        {
            _environment = environment;
            _repository = repository;
            _baseUrl = config["BaseUrl"];
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
                RelativePath = filePath,
                StoredFileName = Path.GetFileName(filePath),
                ThumbnailPath = await FileHelper.SaveFile(dto.File, _environment.WebRootPath),
                UserId = userId,     ///userid is comming null here 
                UploadedAt = DateTime.UtcNow
            };

            return await _repository.AddDocument(document);
        }

        public async Task<IEnumerable<DocumentResponseDto>> GetDocumentsByUser(string userId)
        {
           var documents=await _repository.GetDocumentsByUser(userId);

            return documents
                .OrderBy(o => o.FileName)
                .Select(g => new DocumentResponseDto
                {
                    Id = g.Id,
                    FileName = g.FileName,
                    FileUrl = $"{_baseUrl}/document/{g.StoredFileName}",
                    ThumbnailUrl = $"{_baseUrl}/document/thumbnails/{g.ThumbnailPath}"

                })
                .ToList();
        }
    }
}
