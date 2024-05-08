using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UITOUX.Web.Service.Interfaces;
using UITOUX.Web.Service.Models;
using UITOUX.Web.Service.Repository;

namespace UITOUX.Web.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly IBannerService bannerService;
        public BannerController(IBannerService _bannerService)
        {
            this.bannerService = _bannerService;
        }

        [HttpGet]
        [Route("FetchAllBanner")]
        public async Task<IActionResult> FetchAllBanner()
        {
            try
            {
                var responce = await bannerService.GetAllBanner();
                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet]
        [Route("FetchBanner/{bannerId}")]
        public async Task<IActionResult> FetchBanner(long bannerId)
        {
            try
            {
                if (bannerId == 0)
                {
                    return new BadRequestObjectResult($"Invalid bannerId {bannerId}");
                }
                var responce = await bannerService.GetBanner(bannerId);

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
        [Route("InsertBanner")]
        public async Task<IActionResult> InsertBanner(Banner banner)
        {
            try
            {
                if (banner == null)
                {
                    return new BadRequestObjectResult($"Invalid Banner Object Provided");
                }

                var responce = await bannerService.InsertBanner(banner);
                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPut]
        [Route("UpdateBanner/{bannerId}")]
        public async Task<IActionResult> UpdateBanner(long bannerId, Banner banner)
        {
            try
            {
                if (banner == null)
                {
                    return new BadRequestObjectResult($"Invalid Banner Object Provided");
                }
                if (bannerId < 0)
                {
                    return new BadRequestObjectResult($"Invalid Banner Id Provided");
                }

                var responce = await bannerService.UpdateBanner(bannerId, banner);

                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("DeleteBanner/{bannerId}")]
        public async Task<IActionResult> DeleteBanner(long bannerId)
        {
            try
            {
                if (bannerId < 0)
                {
                    return new BadRequestObjectResult($"Invalid Banner Id Provided");
                }

                var responce = await bannerService.DeleteBanner(bannerId);

                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
