using System.Diagnostics.Tracing;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inserisci il titolo del tuo evento:");
            string newTitle = Console.ReadLine();

            Console.WriteLine("Inserisci la data del tuo evento (gg/mm/yyyy):");
            DateTime newDate = DateTime.Parse(Console.ReadLine());
 
            Console.WriteLine("Inserisci la capienza massima del tuo evento:");
            int newCapacity = int.Parse(Console.ReadLine());

            Event newEvent = new Event(newTitle, newDate, newCapacity);

            Console.WriteLine("Vuoi riservare dei posti? s/n");
            string answer = Console.ReadLine();

            if (answer == "s")
            {
                Console.WriteLine("Numero di posti da riservare:");
                int newReservedSeats = int.Parse(Console.ReadLine());
                newEvent.ReserveSeat(newReservedSeats);
                Console.Write($"Numero di posti prenotati: {newReservedSeats}, Numero di posti disponibili: {newCapacity}");
            }
            else
            {
                Console.Write($"Numero di posti disponibili: {newCapacity}");
            }


        }
    }
}