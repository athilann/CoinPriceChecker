using System;
using System.Collections.Generic;
using System.Text;

namespace CoinPriceCheckerApplication.Dto.CoinDesk
{
    public class CurrentPriceResponse
    {
        public Dictionary<string, string> Time { get; set; }
        public Dictionary<string, Dictionary<string, string>> BPI { get; set; }
        public string Disclaimer { get; set; }
        public string ChartName { get; set; }
    }
}
