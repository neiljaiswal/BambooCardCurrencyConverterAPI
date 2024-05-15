# BambooCard Currency Converter API

This is a currency converter API built using ASP.NET Core. It uses the Frankfurter API to provide exchange rates and allows for currency conversions.

## Requirements

- .NET 8 SDK or later

## How to Run

Clone the repository:
git clone https://github.com/yourusername/CurrencyConverterAPI.git
cd CurrencyConverterAPI
dotnet restore
dotnet run

Endpoints

GET /api/currencyconverter/latest?baseCurrency=EUR
Retrieves the latest exchange rates for a specific base currency.

POST /api/currencyconverter/convert
Converts amounts between different currencies. Excludes TRY, PLN, THB, and MXN.

POST /api/currencyconverter/historical
Returns a set of historical rates for a given period using pagination based on a specific base currency.

Assumptions

The Frankfurter API may occasionally fail to respond on the first request, so the implementation includes retry logic.
The API handles pagination for historical rates to manage large data sets efficiently.
Enhancements
Add more robust error handling and logging.
Improve the retry mechanism to handle specific status codes differently.
Cache the exchange rates to reduce the number of requests to the Frankfurter API.
