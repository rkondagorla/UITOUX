using UITOUX.Web.Service.Models;

namespace UITOUX.Web.Service.Interfaces
{
    public interface IBannerItemService
    {
        Task<bool> InsertBannerItem(BannerItem bannerItem);
        Task<bool> UpdateBannerItem(long bannerItemId, BannerItem bannerItem);
        Task<bool> DeleteBannerItem(long bannerItemId);
        Task<List<BannerItem>> GetAllBannerItem();
        Task<BannerItem> GetBannerItem(long bannerItemId);
    }
}
