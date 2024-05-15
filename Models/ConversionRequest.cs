namespace BambooCardCurrencyConverterAPI.Models
{
    /// <summary>
    /// The conversion request.
    /// </summary>
    public class ConversionRequest
    {
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the from currency.
        /// </summary>
        public string FromCurrency { get; set; }

        /// <summary>
        /// Gets or sets the to currency.
        /// </summary>
        public string ToCurrency { get; set; }
    }
}