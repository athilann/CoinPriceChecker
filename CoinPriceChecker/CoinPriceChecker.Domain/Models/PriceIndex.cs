using System.Collections.Generic;

namespace CoinPriceChecker.Domain.Models
{
    public class PriceIndex
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Dictionary<string,string> Indexes { get; set; }
        public PriceIndex()
        {
            Indexes = new Dictionary<string, string>();
        }
    }
}