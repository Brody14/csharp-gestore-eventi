﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class Event
    {
        //ATTRIBUTI
        private string title;
        private DateTime date;
        private int maxCapacity;
        private int reservedSeats;

        //COSTRUTTORE

        public Event(string title, DateTime date, int maxCapacity) {
            SetTitle(title);
            SetDate(date);
            SetMaxCapacity(maxCapacity);
            this.reservedSeats = 0;
        }

        //GETTER

        public string GetTitle()
        {
            return this.title;
        }

        public DateTime GetDate() 
        { 
            return this.date; 
        }

        public int GetMaxCapacity()
        {
            return this.maxCapacity;
        }

        public int GetReservedSeats()
        {
            return this.reservedSeats;
        }
        //SETTER

        //evitare che il titolo sia una stringa vuota
        public void SetTitle(string title)
        {
            if(title == "")
            {
                throw new ArgumentException("Il titolo non può essere vuoto");
            }

            this.title = title;
        }

        //evitare che la data sia nel passato
        public void SetDate(DateTime date)
        {

            if(date <= DateTime.Now)
            {
                throw new ArgumentException("La data dell'evento non può essere nel passato");
            }

            this.date = date;
        }

        //evitare che i posti massimi siano negativi
        private void SetMaxCapacity(int maxCapacity)
        {
            if (maxCapacity < 0)
            {
                throw new ArgumentException("La capienza massina non può avere un valore negativo");
            }
            this.maxCapacity = maxCapacity;
        }

        //METODI

        //prenotare posti
        public void ReserveSeat(int seat, DateTime date)
        {
            DateTime now = DateTime.Now;

            if (date <= now) 
            {
                throw new ArgumentException("L'evento è già passato");
            }
            else if (this.reservedSeats + seat > this.maxCapacity)
            {
                throw new ArgumentException("Non ci sono abbastanza posti disponibili");

            }

           this.reservedSeats += seat;
        }

        //cancellare posti
        public void CancelSeat(int seat)
        {
            DateTime now = DateTime.Now;
            if (date < now ) 
            {
                throw new ArgumentException("L'evento è già passato");
            }
            else if (seat > this.reservedSeats)
            {
                throw new ArgumentException("Non puoi cancellare più posti rispetto a quelli prenotati");

            }

            this.reservedSeats -= seat;
        }

        //stampa data formattata e titolo
        public override string ToString()
        {
            return $"{date.ToString("dd/MM/yyyy")} - {title}";
        }

    }
}
