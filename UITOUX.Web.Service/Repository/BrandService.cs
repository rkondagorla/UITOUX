using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UITOUX.Web.Service.DBConfiguration;
using UITOUX.Web.Service.Interfaces;
using UITOUX.Web.Service.Models;

namespace UITOUX.Web.Service.Repository
{
    public class BrandService : IBrandService
    {
        private readonly ApplicationDBContext dBContext;
        public BrandService(ApplicationDBContext applicationDBContext)
        {
            this.dBContext = applicationDBContext;
        }

        public async Task<bool> DeleteBrand(long brandId)
        {
            var brand = await dBContext.brands.FindAsync(brandId);
            if (brand != null)
            {
                dBContext.brands.Remove(brand);
            }
            var response = await dBContext.SaveChangesAsync();
            return response == 1 ? true : false;
        }

        public async Task<List<Brand>> GetAllBrand()
        {
            return await dBContext.brands.Where(x => x.IsActive).Include(x => x.models).ToListAsync();
        }

        public async Task<Brand> GetBrand(long brandId)
        {
            var responce = await dBContext.brands.Where(x => x.BrandId == brandId).FirstOrDefaultAsync();

            return responce;

        }

        public async Task<bool> InsertBrand(Brand brand)
        {
            if (brand != null)
                await dBContext.brands.AddAsync(brand);
            var response = await dBContext.SaveChangesAsync();
            return response == 1 ? true : false;
        }

        public async Task<bool> UpdateBrand(long brandId, Brand _brand)
        {
            var brand = await dBContext.brands.FindAsync(brandId);
            if (brand != null)
            {
                brand.Name = _brand.Name;
                brand.Code = _brand.Code;
                brand.ImagePath = _brand.ImagePath;
                brand.CreatedOn = DateTime.Now;
                brand.CreatedBy = _brand.CreatedBy;
                brand.ModifiedOn = DateTime.Now;
                brand.ModifiedBy = _brand.ModifiedBy;
                brand.IsActive = _brand.IsActive;
            }
            var response = await dBContext.SaveChangesAsync();
            return response == 1 ? true : false;
        }
    }
}
