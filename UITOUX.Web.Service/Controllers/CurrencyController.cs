using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UITOUX.Web.Service.Interfaces;
using UITOUX.Web.Service.Models;
using UITOUX.Web.Service.Repository;

namespace UITOUX.Web.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {

        private readonly ICurrencyService currencyservice;
        public CurrencyController(ICurrencyService _currencyservice)
        {
            this.currencyservice = _currencyservice;
        }

        [HttpGet]
        [Route("FetchAllCurrency")]
        public async Task<IActionResult> FetchAllCurrency()
        {
            try
            {
                var responce = await currencyservice.GetAllCurrency();
                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("FetchCurrency/{currencyId}")]
        public async Task<IActionResult> FetchCurrency(long currencyId)
        {
            try
            {
                if (currencyId == 0)
                {
                    return new BadRequestObjectResult($"Invalid currencyId {currencyId}");
                }
                var responce = await currencyservice.GetCurrency(currencyId);

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
        [Route("InsertCurrency")]
        public async Task<IActionResult> InsertCurrency(Currency currency)
        {
            try
            {
                if (currency == null)
                {
                    return new BadRequestObjectResult($"Invalid Currency Object Provided");
                }

                var responce = await currencyservice.InsertCurrency(currency);
                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("UpdateCurrency/{currencyId}")]
        public async Task<IActionResult> UpdateCurrency(long currencyId, Currency currency)
        {
            try
            {
                if (currency == null)
                {
                    return new BadRequestObjectResult($"Invalid Currency Object Provided");
                }
                if (currencyId < 0)
                {
                    return new BadRequestObjectResult($"Invalid Currency Id Provided");
                }

                var responce = await currencyservice.UpdateCurrency(currencyId,currency);

                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete]
        [Route("DeleteCurrency/{currencyId}")]
        public async Task<IActionResult> DeleteCurrency(long currencyId)
        {
            try
            {
                if (currencyId < 0)
                {
                    return new BadRequestObjectResult($"Invalid Currency Id Provided");
                }

                var responce = await currencyservice.DeleteCurrency(currencyId);

                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }



    }
}
