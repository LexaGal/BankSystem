using System;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class CurrencyConvertor
    {
        public List<Tuple<string, string, double>> Coefficients { get; private set; }

        public CurrencyConvertor()
        {
            Coefficients = new List<Tuple<string, string, double>>
            {
                new Tuple<string, string, double>("USD", "BYR", 14240.0),
                new Tuple<string, string, double>("BYR", "USD", 7.02247191011236e-5),
                new Tuple<string, string, double>("EUR", "BYR", 15550.0),
                new Tuple<string, string, double>("BYR", "EUR", 6.430868167202572e-5),
                new Tuple<string, string, double>("RUB", "BYR", 284.0),
                new Tuple<string, string, double>("BYR", "RUB", 0.0035211267605634),
                new Tuple<string, string, double>("USD", "EUR", 0.9157556270096463),
                new Tuple<string, string, double>("EUR", "USD", 1.091994382022472),
                new Tuple<string, string, double>("USD", "RUB", 50.1408),
                new Tuple<string, string, double>("RUB", "USD", 0.0199438381517646),
                new Tuple<string, string, double>("EUR", "RUB", 54.5775),
                new Tuple<string, string, double>("RUB", "EUR", 0.0183225688241491),
                new Tuple<string, string, double>("USD", "USD", 1),
                new Tuple<string, string, double>("EUR", "EUR", 1),
                new Tuple<string, string, double>("BYR", "BYR", 1),
                new Tuple<string, string, double>("RUB", "RUB", 1)
            };
        }
        
    }
}