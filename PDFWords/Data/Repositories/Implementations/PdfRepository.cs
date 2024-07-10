using App.Web.Data.Repositories.Interfaces;
using App.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Data.Repositories.Implementations
{
    public class PdfRepository : IPdfRepository
    {
        private readonly ApplicationDbContext _context;
        public PdfRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PDF> CreateAsync(PDF pdf)
        {
            await _context.AddAsync(pdf);
            await _context.SaveChangesAsync();
            return pdf;
        }

        public async Task<PDF> GetByGuidAsync(Guid guid)
        {
            return await _context.PDFs.FindAsync(guid) ?? throw new Exception("No pdf with that Id could be found");
        }

    }
}
