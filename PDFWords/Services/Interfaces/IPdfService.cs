using App.Web.Models;

namespace App.Web.Services.Interfaces
{
    public interface IPdfService
    {
        Task<PDF> ProcessPdfAsync(Stream pdfStream);
        Task<PDF> GetPdfByGuidAsync(Guid guid);

    }
}
