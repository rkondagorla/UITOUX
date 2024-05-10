using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using UITOUX.Web.UI.InterfaceManager;

namespace UITOUX.Web.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryManager categoryManager;
        private readonly INotyfService notyfService;
        public CategoryController(ICategoryManager categoryManager,
            INotyfService notyfService)
        {
            this.categoryManager = categoryManager;
            this.notyfService = notyfService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FetchCategories()
        {
            try
            {
                var response = await categoryManager.GetAllCategory();
                return Json(new { data = response });
            }
            catch (Exception ex)
            {
                notyfService.Error(ex.Message);
                throw ex;

            }
        }
    }
}
