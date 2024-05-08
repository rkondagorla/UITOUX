using Microsoft.EntityFrameworkCore;
using UITOUX.Web.Service.DBConfiguration;
using UITOUX.Web.Service.Interfaces;
using UITOUX.Web.Service.Models;

namespace UITOUX.Web.Service.Repository
{
    public class BannerService: IBannerService
    {
        private readonly ApplicationDBContext dBContext;
        public BannerService(ApplicationDBContext applicationDBContext)
        {
            this.dBContext = applicationDBContext;
            
        }

        public async Task<bool> DeleteBanner(long bannerId)
        {
            var banner = await dBContext.banners.FindAsync(bannerId);
            if (banner != null)
            {
                dBContext.banners.Remove(banner);
            }
            var response = await dBContext.SaveChangesAsync();
            return response == 1 ? true : false;
        }

        public async Task<List<Banner>> GetAllBanner()
        {
            return await dBContext.banners.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<Banner> GetBanner(long bannerId)
        {
            var banner = await dBContext.banners.FindAsync(bannerId);
            if (banner != null)
            {
                return banner;
            }
            return null;
        }

        public async Task<bool> InsertBanner(Banner banner)
        {
            if (banner != null)
                await dBContext.banners.AddAsync(banner);
            var response = await dBContext.SaveChangesAsync();
            return response == 1 ? true : false;
        }

        public async Task<bool> UpdateBanner(long bannerId, Banner _banner)
        {
            var banner = await dBContext.banners.FindAsync(bannerId);
            if (banner != null)
            {
                banner.Code = _banner.Code;
                banner.Description = _banner.Description;
                banner.StartDate = _banner.StartDate;
                banner.EndDate= _banner.EndDate;
                banner.CreatedOn = DateTime.Now;
                banner.CreatedBy = _banner.CreatedBy;
                banner.ModifiedOn = DateTime.Now;
                banner.ModifiedBy = _banner.ModifiedBy;
                banner.IsActive = _banner.IsActive;
            }
            var response = await dBContext.SaveChangesAsync();
            return response == 1 ? true : false;
        }
    }
}
