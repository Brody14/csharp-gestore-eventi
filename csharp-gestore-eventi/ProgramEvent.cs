using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class ProgramEvent
    {
        public string Title { get; set; }
        public List<Event> Events {  get; set; }

        //COSTRUTTORE
        public ProgramEvent(string title) 
        {
            this.Title = title;
            Events = new List<Event>();
        }

        //METODI

        //aggiungo un evento alla lista
        public void AddEvent(Event e)
        {
            Events.Add(e);
        }

        //creo una lista di eventi per data
        public List<Event> SearchByDate(DateTime date)
        {
            List<Event> eventsByDate = new List<Event>();
            foreach (Event e in Events)
            {
                if(date == e.GetDate())
                {
                    eventsByDate.Add(e);
                }
            }

            return eventsByDate;
        }

        //stampo una lista di eventi
        public static void PrintList(List<Event> list)
        {
            foreach(Event e in list)
            {
                Console.WriteLine($"{e.ToString()}, Posti prenotati: {e.GetReservedSeats()}, Capacità Massima: {e.GetMaxCapacity()}");
            }
        }

        //totale eventi presenti 
        public int EventsCount()
        {
            return Events.Count;
        }

        //svuotare la lista
        public void EmptyList()
        {
            Events.Clear();
        }

        public void PrintProgram()
        {
            Console.WriteLine($"Titolo Programma: {this.Title}\n\t");
            foreach (Event e in Events)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
