using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExchangeRate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeRateController : ControllerBase
    {
        private readonly ILogger<ExchangeRateController> _logger;
        private readonly ExchangeRateClient client;

        public ExchangeRateController(ILogger<ExchangeRateController> logger, ExchangeRateClient client)
        {
            _logger = logger;
            this.client = client;
        }

        [HttpGet]
        [Route("{from}/{to}")]
        public async Task<ExchangeRate> Get(string from, string to)
        {
            var getrate = await client.GetExchangeRateAsync(from, to);

            return new ExchangeRate
            {
               // FromCurrency = rate.query[0].from,
                Rate = (float)getrate.result,
                Date = DateTime.Parse(getrate.date).ToString("dd-MM-yyyy"),
                From = getrate.query.from,
                To = getrate.query.to
            };
        }
    }
}
