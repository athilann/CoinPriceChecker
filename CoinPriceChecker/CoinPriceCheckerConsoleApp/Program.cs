using CoinPriceChecker.Domain.Models;
using System;

namespace CoinPriceCheckerConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Coin coin = new Coin();
            Console.WriteLine($"Name: {coin.Name} ISO: {coin.ISO}")
        }
    }
}
