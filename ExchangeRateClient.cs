using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace ExchangeRate
{

    public class ExchangeRateClient
    {
        private readonly HttpClient httpClient;
        private readonly ServiceSettings settings;

        public ExchangeRateClient(HttpClient httpClient, IOptions<ServiceSettings> options)
        {
            this.httpClient = httpClient;
            settings = options.Value;
        }

        public record Query (string from, string to);
        public record ExchangeRate ( Query query, decimal result, string date);
        
        public async Task<ExchangeRate> GetExchangeRateAsync(string from, string to)
        {
            var getrate = await httpClient.GetFromJsonAsync<ExchangeRate>
                ($"https://{settings.ExchangeRateHost}/convert?from={from}&to={to}");
            return getrate;
        }

    }
}