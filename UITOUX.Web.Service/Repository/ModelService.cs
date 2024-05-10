using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UITOUX.Web.Service.DBConfiguration;
using UITOUX.Web.Service.Interfaces;
using UITOUX.Web.Service.Models;

namespace UITOUX.Web.Service.Repository
{
    public class ModelService : IModelService
    {
        private readonly ApplicationDBContext dBContext;
        public ModelService(ApplicationDBContext applicationDBContext)
        {
            this.dBContext = applicationDBContext;

        }

        public async Task<bool> DeleteModel(long modelId)
        {
            var model = await dBContext.models.FindAsync(modelId);
            if (model != null)
            {
                dBContext.models.Remove(model);
            }
            var response = await dBContext.SaveChangesAsync();
            return response == 1 ? true : false;
        }

        public async Task<List<Model>> GetAllModel()
        {
            return await dBContext.models.Where(x => x.IsActive).Include(x => x.brand).ToListAsync();
        }

        public async Task<Model> GetModel(long modelId)
        {
            var model = await dBContext.models.FindAsync(modelId);
            if (model != null)
            {
                return model;
            }
            return null;
        }

        public async Task<bool> InsertModel(Model model)
        {
            if (model != null)
                await dBContext.models.AddAsync(model);
            var response = await dBContext.SaveChangesAsync();
            return response == 1 ? true : false;
        }

        public async Task<bool> UpdateModel(long modelId, Model _model)
        {
            var model = await dBContext.models.FindAsync(modelId);
            if (model != null)
            {
                model.BrandId = _model.BrandId;
                model.Name = _model.Name;
                model.Code = _model.Code;
                model.CreatedOn = DateTime.Now;
                model.CreatedBy = _model.CreatedBy;
                model.ModifiedOn = DateTime.Now;
                model.ModifiedBy = _model.ModifiedBy;
                model.IsActive = _model.IsActive;
            }
            var response = await dBContext.SaveChangesAsync();
            return response == 1 ? true : false;
        }
    }
}
