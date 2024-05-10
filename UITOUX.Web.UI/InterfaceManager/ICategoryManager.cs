using UITOUX.Web.UI.Models;

namespace UITOUX.Web.UI.InterfaceManager
{
    public interface ICategoryManager
    {
        Task<bool> InsertCategory(Category category);
        Task<bool> UpdateCategory(long categoryId, Category category);
        Task<bool> DeleteCategory(long categoryId);
        Task<List<Category>> GetAllCategory();
        Task<Category> GetCategory(long categoryId);
    }
}
