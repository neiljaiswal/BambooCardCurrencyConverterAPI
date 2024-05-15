namespace BambooCardCurrencyConverterAPI.Models
{
    /// <summary>
    /// The historical rates response.
    /// </summary>
    public class HistoricalRatesResponse
    {
        /// <summary>
        /// Gets or sets the base.
        /// </summary>
        public string Base { get; set; }
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Gets or sets the rates.
        /// </summary>
        public Dictionary<string, decimal> Rates { get; set; }
    }
}
