using App.Web.Models;
using App.Web.Services.Interfaces;
using App.Web.Data.Repositories.Interfaces;

namespace App.Web.Services.Implementations
{
    public class PdfService : IPdfService
    {
        private readonly IPdfRepository _pdfrepository;
        private readonly IPdfParserService _parserService;

        public PdfService(IPdfParserService pdfParserService, IPdfRepository pdfRepository)
        {
            _pdfrepository = pdfRepository;
            _parserService = pdfParserService;
        }
        public async Task<PDF> ProcessPdfAsync(Stream pdfStream)
        {
            var (words, characters, duplicateWords) = await _parserService.ParsedPdfAsync(pdfStream);

            var pdf = new PDF
            {
                Characters = characters,
                Words = words,
                DuplicateWords = duplicateWords
            };
            return await _pdfrepository.CreateAsync(pdf);
        }

        public async Task<PDF> GetPdfByGuidAsync(Guid guid)
        {
            return await _pdfrepository.GetByGuidAsync(guid);
        }
    }
}
