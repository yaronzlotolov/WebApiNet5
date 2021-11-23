using System;

namespace ExchangeRate
{
    public class ExchangeRate
    {
        public string Date { get; set; }

        //public string Date2 => DateTime.Parse(Date).ToString("dd-MM-yyyy");
        public string From { get; set; }

        public string To { get; set; }

        public float Rate {get; set;}
    }
}
