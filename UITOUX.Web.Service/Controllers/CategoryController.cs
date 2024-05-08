using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UITOUX.Web.Service.Interfaces;
using UITOUX.Web.Service.Models;
using UITOUX.Web.Service.Repository;

namespace UITOUX.Web.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService _categoryService)
        {
            this.categoryService = _categoryService;
        }

        [HttpGet]
        [Route("FetchAllCategory")]
        public async Task<IActionResult> FetchAllCategory()
        {
            try
            {
                var responce = await categoryService.GetAllCategory();
                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("FetchCategory/{categoryId}")]
        public async Task<IActionResult> FetchCategory(long categoryId)
        {
            try
            {
                if (categoryId == 0)
                {
                    return new BadRequestObjectResult($"Invalid categoryId {categoryId}");
                }
                var responce = await categoryService.GetCategory(categoryId);

                if (responce == null)
                    return new StatusCodeResult(StatusCodes.Status404NotFound);

                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("InsertCategory")]
        public async Task<IActionResult> InsertCategory(Category category)
        {
            try
            {
                if (category == null)
                {
                    return new BadRequestObjectResult($"Invalid Category Object Provided");
                }

                var responce = await categoryService.InsertCategory(category);
                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("UpdateCategory/{categoryId}")]
        public async Task<IActionResult> UpdateCategory(long categoryId, Category category)
        {
            try
            {
                if (category == null)
                {
                    return new BadRequestObjectResult($"Invalid Category Object Provided");
                }
                if (categoryId < 0)
                {
                    return new BadRequestObjectResult($"Invalid Category Id Provided");
                }

                var responce = await categoryService.UpdateCategory(categoryId, category);

                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("DeleteCategory/{categoryId}")]
        public async Task<IActionResult> DeleteCategory(long categoryId)
        {
            try
            {
                if (categoryId < 0)
                {
                    return new BadRequestObjectResult($"Invalid Category Id Provided");
                }

                var responce = await categoryService.DeleteCategory(categoryId);

                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
