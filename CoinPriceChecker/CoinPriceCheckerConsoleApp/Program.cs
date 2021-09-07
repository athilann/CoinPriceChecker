using CoinPriceChecker.Domain.Models;
using CoinPriceCheckerApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinPriceCheckerConsoleApp
{
    class Program
    {
        public static ICoinPriceCheckerApplication _applicationService = new CoinPriceCheckerSimpleHttpApplication();

        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {

            List<Coin> coins = await _applicationService.GetAllCoinsAsync();

            var coin = coins.Where(w => w.ISO == "BTC" && w.Provider == Provider.COIN_DESK).SingleOrDefault();

            var priceIndex = coin.PriceIndexes.Where(w => w.Code == "EUR").SingleOrDefault();

            Console.WriteLine($"{coin.ISO} Price {priceIndex.Code} {priceIndex.Indexes["rate"]}.");

            Console.ReadLine();
        }
    }
}
