using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace EDMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentController : ControllerBase
    {
        readonly IPublishEndpoint _publishEndpoint;

        public DocumentController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost()]
        public async Task<IActionResult> OnPostUploadAsync(IFormFile file)
        {
            // https://learn.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-10.0

            if (file.Length == 0) return BadRequest();

            var fileExtension = Path.GetExtension(file.FileName);
            var filePath = Path.Combine("../Ingest", Guid.NewGuid().ToString() + fileExtension);

            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }

            await _publishEndpoint.Publish(new IngestDocument { DocumentName = filePath });

            return Accepted();
        }
    }
}
