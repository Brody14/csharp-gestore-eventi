﻿using System.Diagnostics.Tracing;
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

            Console.Write("Inserisci il titolo del programma di eventi:");
            string title = Console.ReadLine();

            Console.Write("Quanti eventi vuoi aggiungere?");
            int numberOfEvent = int.Parse(Console.ReadLine());

            ProgramEvent programEvent = new ProgramEvent(title);

            int count = programEvent.Events.Count;

            while (count < numberOfEvent)
            {
                try
                {
                    Console.WriteLine();
                    Console.Write($"Inserisci il titolo del {count + 1} evento:");
                    string newTitle = Console.ReadLine();

                    Console.Write($"Inserisci la data del {count + 1} evento (gg/mm/yyyy):");
                    string date = Console.ReadLine();

                    CultureInfo provider = new CultureInfo("it-IT");
                    DateTime newDate = DateTime.ParseExact(date, "dd/MM/yyyy", provider);

                    Console.Write($"Inserisci la capienza massima del {count + 1} evento:");
                    int newCapacity = int.Parse(Console.ReadLine());

                    Event newEvent = new Event(newTitle, newDate, newCapacity);

                    programEvent.Events.Add(newEvent);
                    count++;
                }catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Numero di eventi in programma: {programEvent.Events.Count()}");
            programEvent.PrintProgram();

            Console.WriteLine();
            Console.Write("Inserisci una data per visualizzare gli eventi di quel giorno:");
            DateTime searchDate = DateTime.Parse(Console.ReadLine());
            List<Event> eventsByDate = programEvent.SearchByDate(searchDate);

            if(eventsByDate.Count > 0)
            {
                ProgramEvent.PrintList(eventsByDate);
            }
            else
            {
                Console.Write($"Non ci sono eventi per il giorno {searchDate}");
            }

            //programEvent.EmptyList();

            try
            {
                Console.WriteLine();
                Console.WriteLine("Aggiugni anche una conferenza!");
                Console.Write("Inserisci il titolo della conferenza:");
                string confTitle = Console.ReadLine();
                Console.Write("Inserisci la data della conferenza:");
                DateTime confDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Inserisci la capienza massima della conferenza:");
                int confCapacity = int.Parse(Console.ReadLine());
                Console.Write("Inserisci il nome del relatore:");
                string speaker = Console.ReadLine();
                Console.Write("Inserisci il prezzo:");
                double price = double.Parse(Console.ReadLine());

                Conference conf = new Conference(speaker, price, confTitle, confDate, confCapacity);

                programEvent.Events.Add(conf);
                Console.WriteLine();
                Console.Write("Ecco il programma degli eventi, comprese le conferenze:");
                programEvent.PrintProgram();
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

           
        }
    }
}