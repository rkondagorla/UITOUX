using UITOUX.Web.Service.Models;

namespace UITOUX.Web.Service.Interfaces
{
    public interface IBannerService
    {
        Task<bool> InsertBanner(Banner banner);
        Task<bool> UpdateBanner(long bannerId, Banner banner);
        Task<bool> DeleteBanner(long bannerId);
        Task<List<Banner>> GetAllBanner();
        Task<Banner> GetBanner(long bannerId);
    }
}
