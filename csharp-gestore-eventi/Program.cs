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
            DateTime newDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci la capienza massima del tuo evento:");
            int newCapacity = int.Parse(Console.ReadLine());

            Event newEvent = new Event(newTitle, newDate, newCapacity);

            Console.WriteLine("Vuoi riservare dei posti? S/N");
            string answer = Console.ReadLine();

            


        }
    }
}