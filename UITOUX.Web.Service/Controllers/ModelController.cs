using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UITOUX.Web.Service.Interfaces;
using UITOUX.Web.Service.Models;
using UITOUX.Web.Service.Repository;

namespace UITOUX.Web.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModelService modelService;
        public ModelController(IModelService _modelService)
        {
            this.modelService = _modelService;
        }

        [HttpGet]
        [Route("FetchAllModel")]
        public async Task<IActionResult> FetchAllModel()
        {
            try
            {
                var responce = await modelService.GetAllModel();
                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        [Route("FetchModel/{modelId}")]
        public async Task<IActionResult> FetchModel(long modelId)
        {
            try
            {
                if (modelId == 0)
                {
                    return new BadRequestObjectResult($"Invalid modelId {modelId}");
                }
                var responce = await modelService.GetModel(modelId);

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
        [Route("InsertModel")]
        public async Task<IActionResult> InsertModel(Model model)
        {
            try
            {
                if (model == null)
                {
                    return new BadRequestObjectResult($"Invalid model Object Provided");
                }

                var responce = await modelService.InsertModel(model);
                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("UpdateModel/{modelId}")]
        public async Task<IActionResult> UpdateModel(long modelId, Model model)
        {
            try
            {
                if (model == null)
                {
                    return new BadRequestObjectResult($"Invalid Model Object Provided");
                }
                if (modelId < 0)
                {
                    return new BadRequestObjectResult($"Invalid Model Id Provided");
                }

                var responce = await modelService.UpdateModel(modelId, model);

                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("DeleteModel/{modelId}")]
        public async Task<IActionResult> DeleteModel(long modelId)
        {
            try
            {
                if (modelId < 0)
                {
                    return new BadRequestObjectResult($"Invalid Model Id Provided");
                }

                var responce = await modelService.DeleteModel(modelId);

                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }


    }
}
