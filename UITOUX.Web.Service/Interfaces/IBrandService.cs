using UITOUX.Web.Service.Models;

namespace UITOUX.Web.Service.Interfaces
{
    public interface IBrandService
    {
        Task<bool> InsertBrand(Brand brand);
        Task<bool> UpdateBrand(long brandId, Brand brand);
        Task<bool> DeleteBrand(long brandId);
        Task<List<Brand>> GetAllBrand();
        Task<Brand> GetBrand(long brandId);

    }
}
