namespace App.Web.Services.Interfaces
{
    public interface IPdfParserService
    {
        Task<(int Words, int Characters, int DuplicateWords)> ParsedPdfAsync(Stream pdfStream);
    }
}
