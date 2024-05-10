using UITOUX.Web.Service.Models;

namespace UITOUX.Web.Service.Interfaces
{
    public interface IModelService
    {

        Task<bool> InsertModel(Model model);
        Task<bool> UpdateModel(long modelId, Model model);
        Task<bool> DeleteModel(long modelId);
        Task<List<Model>> GetAllModel();
        Task<Model> GetModel(long modelId);
    }
}
