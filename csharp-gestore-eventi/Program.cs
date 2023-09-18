using System.Diagnostics.Tracing;
using System.Security.Cryptography.X509Certificates;

namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inserisci il titolo del tuo evento:");
            string newTitle = Console.ReadLine();
            Console.WriteLine("Inserisci la data del tuo evento:");
            string newDate = Console.ReadLine();
            Console.WriteLine("Inserisci la capienza massima del tuo evento:");
            int newCapacity = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci i posti già prenotati per il tuo evento:");
            int newReservedSeats = int.Parse(Console.ReadLine());


        }
    }
}