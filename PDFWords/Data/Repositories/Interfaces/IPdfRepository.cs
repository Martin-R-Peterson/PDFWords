using App.Web.Models;
namespace App.Web.Data.Repositories.Interfaces
{
    public interface IPdfRepository
    {
        Task<PDF> GetByGuidAsync(Guid guid);
        Task<PDF> CreateAsync(PDF pdf);

    }
}
