using CoinPriceChecker.Domain.Models;
using CoinPriceCheckerApplication.Dto.CoinDesk;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CoinPriceCheckerApplication
{
    public class CoinPriceCheckerSimpleHttpApplication : ICoinPriceCheckerApplication
    {

        public readonly string _coinDeskApi = "https://api.coindesk.com/v1/";

        private readonly HttpClient _httpClient ;

        public CoinPriceCheckerSimpleHttpApplication()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_coinDeskApi);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Coin>> GetAllCoinsAsync()
        {
            List<Coin> coins = new List<Coin>();
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("bpi/currentprice.json");
                if (response.IsSuccessStatusCode)
                {
                    var resultString = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<CurrentPriceResponse>(resultString);
                    var bitcoinPrice = new Coin()
                    {
                        Provider = Provider.COIN_DESK,
                        ISO = "BTC",
                        Name = result.ChartName,
                    };

                    foreach (var priceIndex in result.BPI.Keys)
                    {
                        bitcoinPrice.PriceIndexes.Add(new PriceIndex()
                        {
                            Code = priceIndex,
                            Name = result.BPI[priceIndex]["description"],
                            Indexes = result.BPI[priceIndex]
                        }); ;
                    }
                    coins.Add(bitcoinPrice);
                }
                return coins;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


}
