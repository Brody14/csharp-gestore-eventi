using System.Diagnostics.Tracing;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Inserisci il titolo del tuo evento:");
            //string newTitle = Console.ReadLine();

            //Console.WriteLine("Inserisci la data del tuo evento (gg/mm/yyyy):");
            //string date = Console.ReadLine();

            //CultureInfo provider = new CultureInfo("it-IT");
            //DateTime newDate = DateTime.ParseExact(date, "dd/MM/yyyy", provider);

            //Console.WriteLine("Inserisci la capienza massima del tuo evento:");
            //int newCapacity = int.Parse(Console.ReadLine());

            //Event newEvent = new Event(newTitle, newDate, newCapacity);

            //Console.WriteLine("Vuoi riservare dei posti? s/n");
            //string answer = Console.ReadLine();

            //int newReservedSeats = 0;

            //if (answer == "s")
            //{
            //    Console.WriteLine("Numero di posti da riservare:");
            //    newReservedSeats = int.Parse(Console.ReadLine());
            //    newEvent.ReserveSeat(newReservedSeats, newDate);
            //    Console.WriteLine($"Numero di posti prenotati: {newEvent.GetReservedSeats()}, Numero di posti disponibili: {newEvent.GetMaxCapacity() - newEvent.GetReservedSeats()}");
            //}
            //else
            //{
            //    Console.WriteLine($"Numero di posti disponibili: {newEvent.GetMaxCapacity()}");
            //}

            //bool cancel = true;

            //while( cancel == true )
            //{
            //    Console.WriteLine("Vuoi disdire dei posti? s/n");
            //    string choice = Console.ReadLine();

            //    if(choice == "s")
            //    {
            //        Console.WriteLine("Quanti posti vuoi disdire?");
            //        int cancelSeat = int.Parse(Console.ReadLine());
            //        newEvent.CancelSeat(cancelSeat);
            //        Console.Write($"Numero di posti disponibili: {newEvent.GetMaxCapacity() - newEvent.GetReservedSeats()}, Numero di posti prenotatati: {newEvent.GetReservedSeats()} ");

            //        ;
            //    }
            //    else
            //    {
            //        cancel = false;
            //        Console.WriteLine("ok");
            //    }

            //}

            Console.WriteLine("Inserisci il titolo del programma di eventi:");
            string title = Console.ReadLine();

            Console.WriteLine("Quanti eventi vuoi aggiungere?");
            int numberOfEvent = int.Parse(Console.ReadLine());

            ProgramEvent programEvent = new ProgramEvent(title);

            int count = programEvent.Events.Count;

            while (count < numberOfEvent)
            {
                try
                {
                    Console.WriteLine($"Inserisci il titolo del {count + 1} evento:");
                    string newTitle = Console.ReadLine();

                    Console.WriteLine($"Inserisci la data del {count + 1} evento (gg/mm/yyyy):");
                    string date = Console.ReadLine();

                    CultureInfo provider = new CultureInfo("it-IT");
                    DateTime newDate = DateTime.ParseExact(date, "dd/MM/yyyy", provider);

                    Console.WriteLine($"Inserisci la capienza massima del {count + 1} evento:");
                    int newCapacity = int.Parse(Console.ReadLine());

                    Event newEvent = new Event(newTitle, newDate, newCapacity);

                    programEvent.Events.Add(newEvent);
                    count++;
                }catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine($"Numero di eventi in programma: {programEvent.Events.Count()}");
            programEvent.PrintProgram();
            Console.WriteLine("Inserisci una data per visualizzare gli eventi di quel giorno:");
            DateTime searchDate = DateTime.Parse(Console.ReadLine());
            List<Event> eventsByDate = programEvent.SearchByDate(searchDate);

            ProgramEvent.PrintList(eventsByDate);
           
        }
    }
}