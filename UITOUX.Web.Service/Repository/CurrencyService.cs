using Microsoft.EntityFrameworkCore;
using UITOUX.Web.Service.DBConfiguration;
using UITOUX.Web.Service.Interfaces;
using UITOUX.Web.Service.Models;

namespace UITOUX.Web.Service.Repository
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ApplicationDBContext dBContext;
        public CurrencyService(ApplicationDBContext applicationDBContext)
        {
            this.dBContext = applicationDBContext;
            
        }

        public async Task<bool> DeleteCurrency(long currencyId)
        {
            var currency = await dBContext.currencies.FindAsync(currencyId);
            if (currency != null)
            {
                dBContext.currencies.Remove(currency);
            }
            var response = await dBContext.SaveChangesAsync();
            return response == 1 ? true : false;
        }

        public async Task<List<Currency>> GetAllCurrency()
        {
            return await dBContext.currencies.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<Currency> GetCurrency(long currencyId)
        {
            var currency = await dBContext.currencies.FindAsync(currencyId);
            if (currency != null)
            {
                return currency;
            }
            return null;
        }

        public async Task<bool> InsertCurrency(Currency currency)
        {
            if (currency != null)
                await dBContext.currencies.AddAsync(currency);
            var response = await dBContext.SaveChangesAsync();
            return response == 1 ? true : false;
        }

        public async Task<bool> UpdateCurrency(long currencyId, Currency _currency)
        {
            var currency = await dBContext.currencies.FindAsync(currencyId);
            if (currency != null)
            {
                currency.Name = _currency.Name;
                currency.Code = _currency.Code;
                currency.ISOCode = _currency.ISOCode;
                currency.Description = _currency.Description;
                currency.CreatedOn = DateTime.Now;
                currency.CreatedBy = _currency.CreatedBy;
                currency.ModifiedOn = DateTime.Now;
                currency.ModifiedBy = _currency.ModifiedBy;
                currency.IsActive = _currency.IsActive;
            }
            var response = await dBContext.SaveChangesAsync();
            return response == 1 ? true : false;
        }
    }
}
