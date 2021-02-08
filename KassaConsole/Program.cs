/*
Introduktion till programmering och C# L0002B
Inlämningsuppgift 1 
Niklas Bergqvist
*/

using System;

namespace kassa
{
    class Program
    {
        static void Main(string[] args)
        {
            //Spara de olika valörerna som används i en array.
            int[] values = new int[] { 500, 100, 50, 20, 10, 5, 1 };

            int price = 0;
            int paid = 0;

            //Läs in priset i en variabel.
            Console.WriteLine("Ange pris: ");
            price = int.Parse(Console.ReadLine());

            //Läs in betalningen i en variabel.
            Console.WriteLine("Betalt: ");
            paid = int.Parse(Console.ReadLine());

            //Om priset eller betalningen är negativ kan programmet inte gå vidare.
            if (price < 0 || paid < 0)
            {
                Console.WriteLine("Priset eller betalningen kan inte vara negativ.");
                return;
            }

            int sum = paid - price;

            //Om användaren betalat för lite kan programmet inte gå vidare.
            if (paid < price)
            {
                Console.WriteLine("Betalningen måste vara mer än priset.");
                return;
            }

            Console.WriteLine(" ");
            Console.WriteLine("Växel tillbaka: ");

            //Gå genom alla individuella valörer i arrayen.
            foreach (int value in values)
            {
                //Räkna ut växel och uppdatera summan.
                int change = sum / value;
                sum = sum - (change * value);

                //Om man får växel tillbaka kolla vilka mynt och lappar som skall utbetalas.
                if (change != 0)
                {
                    //Konvertera nuvarande valörsträngen till int.
                    int enkrona = Int32.Parse($"{value}");

                    //Kolla om vi får tillbaka en eller flera mynt och skriv ut det som enkrona eller flera enkronor.
                    if (enkrona == 1 && change == 1)
                    {
                        Console.WriteLine(change + " " + "enkrona");
                    }
                    else if (enkrona == 1 && change > 1)
                    {
                        Console.WriteLine(change + " " + "enkronor");
                    }
                    //Samma sak för fem- och tiokronorsmynten som för enkronorna. 
                    int femkrona = Int32.Parse($"{value}");
                    if (femkrona == 5 && change == 1)
                    {
                        Console.WriteLine(change + " " + "femkrona");
                    }
                    else if (femkrona == 5 && change > 1)
                    {
                        Console.WriteLine(change + " " + "femkronor");
                    }

                    int tiokrona = Int32.Parse($"{value}");
                    if (tiokrona == 10 && change == 1)
                    {
                        Console.WriteLine(change + " " + "tiokrona");
                    }

                    else if (tiokrona == 10 && change > 1)
                    {
                        Console.WriteLine(change + " " + "tiokronor");
                    }

                    //Kolla samma sak för sedlarna (20, 50, 100, 500) som för mynten.
                    int tjugolapp = Int32.Parse($"{value}");
                    if (tjugolapp == 20 && change == 1)
                    {
                        Console.WriteLine(change + " " + "tjugolapp");
                    }

                    else if (tiokrona == 20 && change > 1)
                    {
                        Console.WriteLine(change + " " + "tjugolappar");
                    }

                    int femtiolapp = Int32.Parse($"{value}");
                    if (femtiolapp == 50 && change == 1)
                    {
                        Console.WriteLine(change + " " + "femtiolapp");
                    }

                    else if (femtiolapp == 50 && change > 1)
                    {
                        Console.WriteLine(change + " " + "femtiolappar");
                    }

                    int hundralapp = Int32.Parse($"{value}");
                    if (hundralapp == 100 && change == 1)
                    {
                        Console.WriteLine(change + " " + "hundralapp");
                    }

                    else if (hundralapp == 100 && change > 1)
                    {
                        Console.WriteLine(change + " " + "hundralappar");
                    }

                    int femhundralapp = Int32.Parse($"{value}");
                    if (femhundralapp == 500 && change == 1)
                    {
                        Console.WriteLine(change + " " + "femhundralapp");
                    }

                    else if (femhundralapp == 500 && change > 1)
                    {
                        Console.WriteLine(change + " " + "femhundralappar");
                    }
                }
            }
        }
    }
}
