using Microsoft.AspNetCore.Mvc;
using Tesseract;

namespace EDMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentController : ControllerBase
    {

        [HttpGet(Name = "GetDocumentContent")]
        public string Get()
        {
            using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
            {
                using (var img = Pix.LoadFromFile("Ingest/sample.jpg"))
                {
                    using (var page = engine.Process(img))
                    {
                        var text = page.GetText();
                        return text;
                    }
                }
            }
        }
    }
}
