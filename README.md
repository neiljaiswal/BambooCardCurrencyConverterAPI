# BambooCard Currency Converter API

This is a currency converter API built using ASP.NET Core. It leverages the Frankfurter API to provide exchange rates and allows for currency conversions.

## Requirements

- .NET 8 SDK or later

## How to Run

1. Clone the repository:
   ```sh
   git clone https://github.com/neiljaiswal/BambooCardCurrencyConverterAPI.git
   cd CurrencyConverterAPI
   ```

2. Restore the dependencies:
   ```sh
   dotnet restore
   ```

3. Run the application:
   ```sh
   dotnet run
   ```

## Endpoints

### Retrieve Latest Exchange Rates

**GET /api/currencyconverter/latest?baseCurrency=EUR**

Retrieves the latest exchange rates for a specific base currency.

### Convert Currency Amounts

**POST /api/currencyconverter/convert**

Converts amounts between different currencies. Excludes TRY, PLN, THB, and MXN.

### Retrieve Historical Rates

**POST /api/currencyconverter/historical**

Returns a set of historical rates for a given period using pagination based on a specific base currency.

## Assumptions

- The Frankfurter API may occasionally fail to respond on the first request, so the implementation includes retry logic.
- The API handles pagination for historical rates to manage large data sets efficiently.