using BambooCardCurrencyConverterAPI.Models;
using BambooCardCurrencyConverterAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BambooCardCurrencyConverterAPI.Controllers
{
    /// <summary>
    /// The currency converter controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyConverterController(FrankfurterService frankfurterService) : ControllerBase
    {
        private readonly FrankfurterService _frankfurterService = frankfurterService;
        private static readonly HashSet<string> ExcludedCurrencies = ["TRY", "PLN", "THB", "MXN"];

        /// <summary>
        /// Gets the latest rates.
        /// </summary>
        /// <param name="baseCurrency">The base currency.</param>
        /// <returns>A Task.</returns>
        [HttpGet("latest")]
        public async Task<IActionResult> GetLatestRates([FromQuery] string baseCurrency = "EUR")
        {
            try
            {
                var rates = await _frankfurterService.GetLatestRatesAsync(baseCurrency);
                return Ok(rates);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Converts the currency.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>A Task.</returns>
        [HttpPost("convert")]
        public async Task<IActionResult> ConvertCurrency([FromBody] ConversionRequest request)
        {
            if (ExcludedCurrencies.Contains(request.FromCurrency) || ExcludedCurrencies.Contains(request.ToCurrency))
            {
                return BadRequest("Currency conversion not supported for TRY, PLN, THB, and MXN.");
            }

            try
            {
                var result = await _frankfurterService.ConvertCurrencyAsync(request.Amount, request.FromCurrency, request.ToCurrency);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Gets the historical rates.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>A Task.</returns>
        [HttpPost("historical")]
        public async Task<IActionResult> GetHistoricalRates([FromBody] HistoricalRatesRequest request)
        {
            try
            {
                var rates = await _frankfurterService.GetHistoricalRatesAsync(request.BaseCurrency, request.StartDate, request.EndDate);
                var paginatedRates = rates.Rates
                    .Skip((request.Page - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                return Ok(new { rates.Base, rates.Date, Rates = paginatedRates });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}