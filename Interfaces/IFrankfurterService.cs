using BambooCardCurrencyConverterAPI.Models;

namespace BambooCardCurrencyConverterAPI.Interfaces
{
    /// <summary>
    /// The frankfurter service.
    /// </summary>
    public interface IFrankfurterService
    {
        Task<ExchangeRate> GetLatestRatesAsync(string baseCurrency);
        Task<ExchangeRate> ConvertCurrencyAsync(decimal amount, string fromCurrency, string toCurrency);
        Task<ExchangeRate> GetHistoricalRatesAsync(string baseCurrency, DateTime startDate, DateTime endDate);
    }
}
