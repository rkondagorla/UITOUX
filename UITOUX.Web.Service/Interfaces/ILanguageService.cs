using UITOUX.Web.Service.Models;

namespace UITOUX.Web.Service.Interfaces
{
    public interface ILanguageService
    {
        Task<bool> Insertlanguage(Language language);
        Task<bool> Updatelanguage(long languageId, Language _language);
        Task<bool> Deletelanguage(long languageId);
        Task<List<Language>> GetAllLanguages();
        Task<Language> GetLanguage(long languageId);
    }
}
