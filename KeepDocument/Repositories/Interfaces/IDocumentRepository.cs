
using KeepDocument.Models;

namespace KeepDocument.Repositories.Interfaces
{
    public interface IDocumentRepository
    {
      Task<Document> AddDocument(Document document);

      Task<List<Document>> GetDocumentsByUser(string UserId);
    }
}
