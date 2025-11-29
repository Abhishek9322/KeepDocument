using KeepDocument.Data.DBContext;
using KeepDocument.Repositories.Interfaces;

using KeepDocument.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace KeepDocument.Repositories.Implementations
{
    public class DocumentRepository :IDocumentRepository
    {
        /// <summary>
        /// basically the Repository handel the database opration such as the adding and the deletting 
        /// related to the data base 
        /// for better seperation of concern we are using the repository pattern here
        /// no contact with the main business logic Code 
        /// </summary>
        private readonly ApplicationDbContext _context;
        public DocumentRepository(ApplicationDbContext context)
        {
            _context=context;
        }

        public async Task<Document> AddDocument(Document document)
        {
            

            var documents =await  _context.Documents.AddAsync(document); 
            if(documents == null)
            {
                throw new Exception("Failed to add document");
            }
            await _context.SaveChangesAsync();

            return document;
        }

        public async Task<List<Document>> GetDocumentsByUser(string UserId)
        {
            return await _context.Documents
                 .Where(d => d.UserId == UserId)
                 .ToListAsync();
        }
    }
}
