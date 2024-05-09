using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UITOUX.Web.Service.DBConfiguration;
using UITOUX.Web.Service.Interfaces;
using UITOUX.Web.Service.Models;

namespace UITOUX.Web.Service.Repository
{
    public class BannerItemService : IBannerItemService
    {
        private readonly ApplicationDBContext dBContext;
        public BannerItemService(ApplicationDBContext applicationDBContext)
        {
            this.dBContext = applicationDBContext;
        }

        public async Task<bool> DeleteBannerItem(long bannerItemId)
        {
            var bannerItem = await dBContext.bannerItems.FindAsync(bannerItemId);
            if (bannerItem != null)
            {
                dBContext.bannerItems.Remove(bannerItem);
            }
            var response = await dBContext.SaveChangesAsync();
            return response == 1 ? true : false;
        }

        public async Task<List<BannerItem>> GetAllBannerItem()
        {
            return await dBContext.bannerItems.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<BannerItem> GetBannerItem(long bannerItemId)
        {
            var bannerItem = await dBContext.bannerItems.FindAsync(bannerItemId);
            if (bannerItem != null)
            {
                return bannerItem;
            }
            return null;
        }

        public async Task<bool> InsertBannerItem(BannerItem bannerItem)
        {
            if (bannerItem != null)
                await dBContext.bannerItems.AddAsync(bannerItem);
            var response = await dBContext.SaveChangesAsync();
            return response == 1 ? true : false;
        }

        public async Task<bool> UpdateBannerItem(long bannerItemId, BannerItem _bannerItem)
        {
            var bannerItem = await dBContext.bannerItems.FindAsync(bannerItemId);
            if (bannerItem != null)
            {
                bannerItem.BannerId = _bannerItem.BannerId;
                bannerItem.CategoryId = _bannerItem.CategoryId;
                bannerItem.URL = _bannerItem.URL;
                bannerItem.Code = _bannerItem.Code;
                bannerItem.Description = _bannerItem.Description;
                bannerItem.CreatedOn = DateTime.Now;
                bannerItem.CreatedBy = _bannerItem.CreatedBy;
                bannerItem.ModifiedOn = DateTime.Now;
                bannerItem.ModifiedBy = _bannerItem.ModifiedBy;
                bannerItem.IsActive = _bannerItem.IsActive;
            }
            var response = await dBContext.SaveChangesAsync();
            return response == 1 ? true : false;
        }
    }
}
