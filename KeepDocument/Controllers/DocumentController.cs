using KeepDocument.DTOs.DocumentSTOs;
using KeepDocument.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KeepDocument.Controllers
{
    [Authorize]
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
            if (userId == null)
                return Unauthorized("User Id Is Null here ");
            

            var result=await _service.UploadDocument(dto, userId);
            if(result==null)
                return NotFound("User ID And Document Not Found..");

            return Ok(result);
        }

        [HttpGet("GetAllDocument")]
        public async Task<IActionResult> GetMyDocument()    //To Get All Document Belongs to Loged in User 
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return Unauthorized("Invalid token..");

            var result=await _service.GetDocumentsByUser(userId);
            if (result == null)
                return NotFound("Document Not Found..");

            return Ok(result);
        }

    }
}
