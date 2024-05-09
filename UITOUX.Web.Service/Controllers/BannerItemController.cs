using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UITOUX.Web.Service.Interfaces;
using UITOUX.Web.Service.Models;
using UITOUX.Web.Service.Repository;

namespace UITOUX.Web.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerItemController : ControllerBase
    {
        private readonly IBannerItemService bannerItemService;
        public BannerItemController(IBannerItemService _bannerItemService)
        {
            this.bannerItemService = _bannerItemService;
        }
        [HttpGet]
        [Route("FetchAllBannerItem")]
        public async Task<IActionResult> FetchAllBannerItem()
        {
            try
            {
                var responce = await bannerItemService.GetAllBannerItem();
                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("FetchBannerItem/{bannerItemId}")]
        public async Task<IActionResult> FetchBannerItem(long bannerItemId)
        {
            try
            {
                if (bannerItemId == 0)
                {
                    return new BadRequestObjectResult($"Invalid bannerItemId {bannerItemId}");
                }
                var responce = await bannerItemService.GetBannerItem(bannerItemId);

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
        [Route("InsertBannerItem")]
        public async Task<IActionResult> InsertBannerItem(BannerItem bannerItem)
        {
            try
            {
                if (bannerItem == null)
                {
                    return new BadRequestObjectResult($"Invalid BannerItem Object Provided");
                }

                var responce = await bannerItemService.InsertBannerItem(bannerItem);
                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("UpdateBannerItem/{bannerItemId}")]
        public async Task<IActionResult> UpdateBannerItem(long bannerItemId, BannerItem bannerItem)
        {
            try
            {
                if (bannerItem == null)
                {
                    return new BadRequestObjectResult($"Invalid BannerItem Object Provided");
                }
                if (bannerItemId < 0)
                {
                    return new BadRequestObjectResult($"Invalid BannerItem Id Provided");
                }

                var responce = await bannerItemService.UpdateBannerItem(bannerItemId, bannerItem);

                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("DeleteBannerItem/{bannerItemId}")]
        public async Task<IActionResult> DeleteBannerItem(long bannerItemId)
        {
            try
            {
                if (bannerItemId < 0)
                {
                    return new BadRequestObjectResult($"Invalid BannerItem Id Provided");
                }

                var responce = await bannerItemService.DeleteBannerItem(bannerItemId);

                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
