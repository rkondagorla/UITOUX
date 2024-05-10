using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using UITOUX.Web.UI.Helpers;
using UITOUX.Web.UI.InterfaceManager;
using UITOUX.Web.UI.Models;
using UITOUX.Web.UI.URLConstants;

namespace UITOUX.Web.UI.DataManagers
{
    public class CategoryDataManager : ICategoryManager
    {
        private readonly HttpClient httpClient = null;
        private readonly UIConfig UIConfig;

        public CategoryDataManager(IOptions<UIConfig> _uiConfig)
        {
            httpClient = new HttpClient();
            UIConfig = _uiConfig.Value;
            httpClient.BaseAddress = new Uri(UIConfig.BaseUrl);
            httpClient.Timeout = new TimeSpan(0, 0, 30);
            httpClient.DefaultRequestHeaders.Clear();
        }

        public async Task<bool> DeleteCategory(long categoryId)
        {
            var uri = Path.Combine(CategoryConstants.DeleteCategory, categoryId.ToString());
            var response = await httpClient.DeleteAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var responceContent = JsonConvert.DeserializeObject<bool>(content);
                return responceContent ? responceContent : false;
            }
            return false;
        }

        public async Task<List<Category>> GetAllCategory()
        {
            //CategoryConstants
            var response = await httpClient.GetAsync(CategoryConstants.GetAllCategory);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var responceContent = JsonConvert.DeserializeObject<List<Category>>(content);
                return responceContent != null ? responceContent : new List<Category>();
            }
            return new List<Category>();
        }

        public async Task<Category> GetCategory(long categoryId)
        {
            var uri = Path.Combine(CategoryConstants.DeleteCategory, categoryId.ToString());
            var response = await httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var responceContent = JsonConvert.DeserializeObject<Category>(content);
                return responceContent != null ? responceContent : null;
            }
            return null;

        }

        public async Task<bool> InsertCategory(Category category)
        {
            var _category = JsonConvert.SerializeObject(category);
            var requestContent = new StringContent(_category, Encoding.UTF8, "application/json");
            var responce = await httpClient.PostAsync(CategoryConstants.InsertCategory, requestContent);
            if (responce.IsSuccessStatusCode)
            {
                var content = await responce.Content.ReadAsStringAsync();
                var responceContent = JsonConvert.DeserializeObject<bool>(content);
                return responceContent ? responceContent : false;
            }
            return false;
        }

        public async Task<bool> UpdateCategory(long _categoryId, Category _category)
        {
            var category = JsonConvert.SerializeObject(_category);

            var requestContent = new StringContent(category, Encoding.UTF8, "application/json");

            var uri = Path.Combine(CategoryConstants.UpdateCategory, _categoryId.ToString());

            var response = await httpClient.PutAsync(uri, requestContent);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var responceContent = JsonConvert.DeserializeObject<bool>(content);
                return responceContent ? responceContent : false;
            }
            return false;
        }
    }
}
