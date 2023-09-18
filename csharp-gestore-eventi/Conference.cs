using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class Conference : Event
    {
        public string Speaker {  get; set; }
        public double Price { get; set; }

        public Conference(string speaker, double price, string title, DateTime date, int maxCapacity) : base(title, date, maxCapacity)
        {
           SetSpeaker(speaker);
           SetPrice(price);
        }

        //SETTER
        public void SetSpeaker(string speaker)
        {
            if (speaker == "") 
            {
                throw new ArgumentException("Il nome del relatore non può essere vuoto");
            }
            this.Speaker = speaker;
        }

        public void SetPrice(double price)
        {
            if (price < 0)
            {
                throw new ArgumentException("Il prezzo non può essere inferiore a 0 euro");
            }

            this.Price = price;
        }

        //METODI

        public string FormatPrice()
        {
            return this.Price.ToString("0.00");
        }

        public override string ToString()
        {
            return $"{base.ToString()} -  {this.Speaker} - {FormatPrice()} euro";
        }
    }
}
