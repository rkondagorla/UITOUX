using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UITOUX.Web.Service.Interfaces;
using UITOUX.Web.Service.Models;
using UITOUX.Web.Service.Repository;

namespace UITOUX.Web.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService brandService;
        public BrandController(IBrandService _brandService)
        {
            this.brandService = _brandService;
        }

        [HttpGet]
        [Route("FetchAllBrand")]
        public async Task<IActionResult> FetchAllBrand()
        {
            try
            {
                var responce = await brandService.GetAllBrand();
                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("FetchBrand/{brandId}")]
        public async Task<IActionResult> FetchBrand(long brandId)
        {
            try
            {
                if (brandId == 0)
                {
                    return new BadRequestObjectResult($"Invalid brandId {brandId}");
                }
                var responce = await brandService.GetBrand(brandId);

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
        [Route("InsertBrand")]
        public async Task<IActionResult> InsertBrand(Brand brand)
        {
            try
            {
                if (brand == null)
                {
                    return new BadRequestObjectResult($"Invalid Brand Object Provided");
                }

                var responce = await brandService.InsertBrand(brand);
                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut]
        [Route("UpdateBannerItem/{bannerItemId}")]
        public async Task<IActionResult> UpdateBrand(long brandId, Brand brand)
        {
            try
            {
                if (brand == null)
                {
                    return new BadRequestObjectResult($"Invalid Brand Object Provided");
                }
                if (brandId < 0)
                {
                    return new BadRequestObjectResult($"Invalid Brand Id Provided");
                }

                var responce = await brandService.UpdateBrand(brandId, brand);

                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("DeleteBrand/{bannerItemId}")]
        public async Task<IActionResult> DeleteBrand(long brandId)
        {
            try
            {
                if (brandId < 0)
                {
                    return new BadRequestObjectResult($"Invalid Brand Id Provided");
                }

                var responce = await brandService.DeleteBrand(brandId);

                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }


    }
}
