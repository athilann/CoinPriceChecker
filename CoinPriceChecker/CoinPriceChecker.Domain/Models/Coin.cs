using System;
using System.Collections.Generic;
using System.Text;

namespace CoinPriceChecker.Domain.Models
{
    public class Coin
    {
        public string Name { get; set; }
        public string ISO { get; set; }
        public Provider Provider { get; set; }
        public List<PriceIndex> PriceIndexes { get; set; }

        public Coin()
        {
            PriceIndexes = new List<PriceIndex>();
        }

    }
}
