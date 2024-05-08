using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UITOUX.Web.Service.Interfaces;
using UITOUX.Web.Service.Models;

namespace UITOUX.Web.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService languageService;
        public LanguageController(ILanguageService languageService)
        {
            this.languageService = languageService;
        }
        [HttpGet]
        [Route("FetchAllLanguages")]
        public async Task<IActionResult> FetchAllLanguages()
        {
            try
            {
                var responce = await languageService.GetAllLanguages();
                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        [Route("FetchLanguage/{languageId}")]
        public async Task<IActionResult> FetchLanguage(long languageId)
        {
            try
            {
                if (languageId == 0)
                {
                    return new BadRequestObjectResult($"Invalid languageId {languageId}");
                }
                var responce = await languageService.GetLanguage(languageId);

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
        [Route("InsertLanguage")]
        public async Task<IActionResult> InsertLanguage(Language language)
        {
            try
            {
                if (language == null)
                {
                    return new BadRequestObjectResult($"Invalid Language Object Provided");
                }

                var responce = await languageService.Insertlanguage(language);
                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut]
        [Route("UpdateLanguage/{languageId}")]
        public async Task<IActionResult> UpdateLanguage(long languageId, Language language)
        {
            try
            {
                if (language == null)
                {
                    return new BadRequestObjectResult($"Invalid Language Object Provided");
                }
                if(languageId < 0)
                {
                    return new BadRequestObjectResult($"Invalid Language Id Provided");
                }

                var responce = await languageService.Updatelanguage(languageId,language);

                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete]
        [Route("DeleteLanguage/{languageId}")]
        public async Task<IActionResult> DeleteLanguage(long languageId)
        {
            try
            {
                if (languageId < 0)
                {
                    return new BadRequestObjectResult($"Invalid Language Id Provided");
                }

                var responce = await languageService.Deletelanguage(languageId);

                return new OkObjectResult(responce);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
