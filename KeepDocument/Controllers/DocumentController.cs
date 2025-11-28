using KeepDocument.DTOs.DocumentSTOs;
using KeepDocument.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KeepDocument.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _service;
        public DocumentController(IDocumentService Service)
        {
            _service = Service;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] DocumentUploadDto dto)
        {
            var userId=User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result=await _service.UploadDocument(dto, userId);
            return Ok(result);
        }

    }
}
