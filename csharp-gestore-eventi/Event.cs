using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class Event
    {
        //ATTRIBUTI
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int MaxCapacity { get; set; }
        public int ReservedSeats { get; set; }

        //COSTRUTTORE

        public Event(string title, DateTime date, int maxCapacity) {
            this.Title = title;
            this.Date = date;
            this.MaxCapacity = maxCapacity;
            this.ReservedSeats = 0;
        }

        //SETTER

        //evitare che il titolo sia una stringa vuota
        public string SetTitle(string title)
        {
            if(title == "")
            {
                throw new ArgumentException("Il titolo non può essere vuoto");
            }
            return title;
        }

        //evitare che la data sia nel passato
        public DateTime SetDate(DateTime date)
        {
            DateTime now = DateTime.Now;
            if(date < now)
            {
                throw new ArgumentException("La data dell'evento non può essere nel passato");
            }
            return date;
        }

        //evitare che i posti massimi siano negativi
        private int SetMaxCapacity(int maxCapacity)
        {
            if (maxCapacity < 0)
            {
                throw new ArgumentException("La capienza massina non può avere un valore negativo");
            }
            return maxCapacity;
        }

        //METODI

        //prenotare posti
        public int ReserveSeat(int seat, DateTime date)
        {
            DateTime now = DateTime.Now;
            if (date < now ^ ReservedSeats + seat > MaxCapacity)
            {
                throw new ArgumentException("L'evento è già passato o non ci sono abbastanza posti disponibili");
            }
            
            return ReservedSeats + seat;
        }

        //cancellare posti
        public int CancelSeat(int seat, DateTime date)
        {
            DateTime now = DateTime.Now;
            if (date < now ^ ReservedSeats - seat < ReservedSeats)
            {
                throw new ArgumentException("L'evento è già passato o non puoi cancellare più posti rispetto a quelli prenotati");
            }
            return ReservedSeats - seat;
        }

        //stampa data formattata e titolo
        public override string ToString()
        {
            return $"{Date.ToString("dd/MM/yyyy")} {Title}";
        }

    }
}
