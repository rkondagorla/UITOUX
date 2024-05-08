using Microsoft.EntityFrameworkCore;
using UITOUX.Web.Service.DBConfiguration;
using UITOUX.Web.Service.Interfaces;
using UITOUX.Web.Service.Models;

namespace UITOUX.Web.Service.Repository
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDBContext dBContext;
        public CategoryService(ApplicationDBContext applicationDBContext)
        {
            this.dBContext = applicationDBContext;
        }

        public async Task<bool> DeleteCategory(long categoryId)
        {
            var category = await dBContext.categories.FindAsync(categoryId);
            if (category != null)
            {
                dBContext.categories.Remove(category);
            }
            var response = await dBContext.SaveChangesAsync();
            return response == 1 ? true : false;
        }

        public async Task<List<Category>> GetAllCategory()
        {
            return await dBContext.categories.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<Category> GetCategory(long categoryId)
        {
            var category = await dBContext.categories.FindAsync(categoryId);
            if (category != null)
            {
                return category;
            }
            return null;
        }

        public async Task<bool> InsertCategory(Category category)
        {
            if (category != null)
                await dBContext.categories.AddAsync(category);
            var response = await dBContext.SaveChangesAsync();
            return response == 1 ? true : false;
        }

        public async Task<bool> UpdateCategory(long categoryId, Category _category)
        {
            var category = await dBContext.categories.FindAsync(categoryId);
            if (category != null)
            {
                category.Name = _category.Name;
                category.Code = _category.Code;
                category.ParentCategoryId= _category.ParentCategoryId;
                category.CreatedOn = DateTime.Now;
                category.CreatedBy = _category.CreatedBy;
                category.ModifiedOn = DateTime.Now;
                category.ModifiedBy = _category.ModifiedBy;
                category.IsActive = _category.IsActive;
            }
            var response = await dBContext.SaveChangesAsync();
            return response == 1 ? true : false;
        }
    }
}
