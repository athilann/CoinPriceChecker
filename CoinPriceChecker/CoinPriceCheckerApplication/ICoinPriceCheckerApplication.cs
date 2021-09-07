using CoinPriceChecker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoinPriceCheckerApplication
{

    public interface ICoinPriceCheckerApplication
    {
        Task<List<Coin>> GetAllCoinsAsync();
    }
}
