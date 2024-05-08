using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using UITOUX.Web.Service.DBConfiguration;
using UITOUX.Web.Service.Interfaces;
using UITOUX.Web.Service.Models;

namespace UITOUX.Web.Service.Repository
{
    public class LanguageService : ILanguageService
    {
        private readonly ApplicationDBContext dBContext;
        public LanguageService(ApplicationDBContext applicationDBContext)
        {
            this.dBContext = applicationDBContext;
        }
        public async Task<bool> Deletelanguage(long languageId)
        {
            var language = await dBContext.languages.FindAsync(languageId);
            if (language != null)
            {
                dBContext.languages.Remove(language);
            }
            var response = await dBContext.SaveChangesAsync();
            return response == 1 ? true : false;
        }

        public async Task<List<Language>> GetAllLanguages()
        {
            return await dBContext.languages.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<Language> GetLanguage(long languageId)
        {
            var language = await dBContext.languages.FindAsync(languageId);
            if (language != null)
            {
                return language;
            }
            return null;
        }

        public async Task<bool> Insertlanguage(Language language)
        {
            if (language != null)
                await dBContext.languages.AddAsync(language);
            var response = await dBContext.SaveChangesAsync();
            return response == 1 ? true : false;
        }

        public async Task<bool> Updatelanguage(long languageId, Language _language)
        {
            var language = await dBContext.languages.FindAsync(languageId);
            if (language != null)
            {
                language.Name = _language.Name;
                language.Code = _language.Code;
                language.ISOCode= _language.ISOCode;
                language.Description = _language.Description;
                language.CreatedOn = DateTime.Now;
                language.CreatedBy = _language.CreatedBy;
                language.ModifiedOn = DateTime.Now;
                language.ModifiedBy = _language.ModifiedBy;
                language.IsActive = _language.IsActive;
            }
            var response = await dBContext.SaveChangesAsync();
            return response == 1 ? true : false;
        }
    }
}
