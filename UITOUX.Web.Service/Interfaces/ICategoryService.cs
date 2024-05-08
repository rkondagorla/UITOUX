using UITOUX.Web.Service.Models;

namespace UITOUX.Web.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<bool> InsertCategory(Category category);
        Task<bool> UpdateCategory(long categoryId, Category category);
        Task<bool> DeleteCategory(long categoryId);
        Task<List<Category>> GetAllCategory();
        Task<Category> GetCategory(long categoryId);
    }
}
