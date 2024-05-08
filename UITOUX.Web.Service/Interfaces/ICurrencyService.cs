using UITOUX.Web.Service.Models;

namespace UITOUX.Web.Service.Interfaces
{
    public interface ICurrencyService
    {
        Task<bool> InsertCurrency(Currency currency);
        Task<bool> UpdateCurrency(long currencyId, Currency currency);
        Task<bool> DeleteCurrency(long currencyId);
        Task<List<Currency>> GetAllCurrency();
        Task<Currency> GetCurrency(long currencyId);
    }
}
