using Microsoft.AspNetCore.Mvc;
using App.Web.Models;
using App.Web.Services.Interfaces;
using App.Web.Models.ViewModels;

namespace App.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PdfController : ControllerBase
    {
        private readonly IPdfService _pdfService;

        public PdfController(IPdfService pdfService)
        {
            _pdfService = pdfService;
        }

        [HttpPost("upload")]
        public async Task<ActionResult<PdfView>> GetPdf(Guid guid)
        {
            var pdf = await _pdfService.GetPdfByGuidAsync(guid);
            var viewPdf = new PdfView();
            if (pdf == null)
            {
                return NotFound();
            }
            return Ok(viewPdf.From(pdf));
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<PdfView>> UploadPdf(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is Empty");
            }
            using var stream = file.OpenReadStream();
            var result = await _pdfService.ProcessPdfAsync(stream);
            var pdf = new PdfView();
            return Ok(pdf.From(result));
        }
    }
}
