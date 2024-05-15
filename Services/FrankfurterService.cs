using BambooCardCurrencyConverterAPI.Interfaces;
using BambooCardCurrencyConverterAPI.Models;
using Newtonsoft.Json;
using RestSharp;

namespace BambooCardCurrencyConverterAPI.Services
{
    /// <summary>
    /// The frankfurter service.
    /// </summary>
    public class FrankfurterService : IFrankfurterService
    {
        private const string BaseUrl = "https://api.frankfurter.app";
        private readonly RestClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrankfurterService"/> class.
        /// </summary>
        public FrankfurterService()
        {
            _client = new RestClient(BaseUrl);
        }

        /// <summary>
        /// Gets the latest rates async.
        /// </summary>
        /// <param name="baseCurrency">The base currency.</param>
        /// <returns>A Task.</returns>
        public async Task<ExchangeRate> GetLatestRatesAsync(string baseCurrency)
        {
            var request = new RestRequest($"/latest?from={baseCurrency}", Method.Get);
            return await ExecuteRequestAsync<ExchangeRate>(request);
        }

        /// <summary>
        /// Converts the currency async.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="fromCurrency">The from currency.</param>
        /// <param name="toCurrency">The to currency.</param>
        /// <returns>A Task.</returns>
        public async Task<ExchangeRate> ConvertCurrencyAsync(decimal amount, string fromCurrency, string toCurrency)
        {
            var request = new RestRequest($"/latest?amount={amount}&from={fromCurrency}&to={toCurrency}", Method.Get);
            return await ExecuteRequestAsync<ExchangeRate>(request);
        }

        /// <summary>
        /// Gets the historical rates async.
        /// </summary>
        /// <param name="baseCurrency">The base currency.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>A Task.</returns>
        public async Task<ExchangeRate> GetHistoricalRatesAsync(string baseCurrency, DateTime startDate, DateTime endDate)
        {
            var request = new RestRequest($"/{startDate:yyyy-MM-dd}..{endDate:yyyy-MM-dd}?from={baseCurrency}", Method.Get);
            return await ExecuteRequestAsync<ExchangeRate>(request);
        }

        private async Task<T> ExecuteRequestAsync<T>(RestRequest request)
        {
            RestResponse response = null;
            for (int i = 0; i < 3; i++)
            {
                response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful) break;
                await Task.Delay(1000); // Wait for a second before retrying
            }

            if (!response.IsSuccessful)
            {
                throw new Exception("Failed to retrieve data from Frankfurter API.");
            }

            return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}