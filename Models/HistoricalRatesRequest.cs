namespace BambooCardCurrencyConverterAPI.Models
{
    /// <summary>
    /// The historical rates request.
    /// </summary>
    public class HistoricalRatesRequest
    {
        /// <summary>
        /// Gets or sets the base currency.
        /// </summary>
        public string BaseCurrency { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        public int PageSize { get; set; } = 10;
    }
}