/*
Introduktion till programmering och C# L0002B
Inlämningsuppgift 2
Niklas Bergqvist
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace salesPeople
{
    //Klassen Program innehåller main-funktionen.
    class Program
    {
        //Programmets main-funktion.
        static void Main(string[] args)
        {
            //Skapa ett nytt objekt
            Program salesPeople = new Program();
            PersonHandler handler = new PersonHandler(salesPeople);

            //Kalla på AddPerson och PrintRes funktionerna för att driva programmet.
            handler.AddPerson();
            handler.PrintRes();
        }
    }

    //Person-klassen som definerar ett Person-objekt med egenskaperna: namn, personnummer, distrikt och totalt antal försäljningar per person.
    class Person
    {
        //Konstruktor
        public Person(string name, string pnbr, string district, int totSales)
        {
            //Sätt this.name till name etc..
            this.name = name;
            this.pnbr = pnbr;
            this.district = district;
            this.totSales = totSales;
        }

        //Get och set metoder för de olika egenskaperna i klassen.
        public string name
        {
            get;
            set;
        }
        public string pnbr
        {
            get;
            set;
        }
        public string district
        {
            get;
            set;
        }
        public int totSales
        {
            get;
            set;
        }
    }

    //Personhanterar-klass
    class PersonHandler
    {
        //Dela upp försäljarna i fyra olika listor baserat på nivå.
        private Program salesPeople;

        List<Person> level_1 = new List<Person>();
        List<Person> level_2 = new List<Person>();
        List<Person> level_3 = new List<Person>();
        List<Person> level_4 = new List<Person>();

        //Konstruktor för personhanterar-klassen.
        public PersonHandler(Program salesPeople)
        {
            //Sätt this.salesPeople som salesPeople
            this.salesPeople = salesPeople;
        }

        //Metod för att lägga in en försäljare i en av de olika listorna baserat försäljningsnivåerna.
        public void AddPerson()
        {
            //Användaren matar in antal säljare
            string input;
            Console.WriteLine("Välj antal säljare: ");
            input = Console.ReadLine();

            //Användaren matar in personnummret på formen: ÅÅMMDDXXXX
            int input2 = int.Parse(input);
            int ppl_counter = 0;

            //Loopa så länge vi har en säljare
            while (ppl_counter < input2)
            {
                //Mata in namnet på försäljaren.
                Console.WriteLine("Namn: ");
                string name = Console.ReadLine();

                Console.WriteLine("Personnummer: (på formen: YYMMDDXXXX) ");
                string pnbr = Console.ReadLine();

                //Ifall personnummret inte har 10 siffror så mata in igen.
                if (pnbr.Length != 10)
                {
                    Console.WriteLine("Personnummer måste vara på formen: YYMMDDXXXX");
                    while (pnbr.Length != 10)
                    {
                        Console.WriteLine("Persnr: (på formen: YYMMDDXXXX) ");
                        pnbr = Console.ReadLine();
                    }
                }

                //Mata in distrikt
                Console.WriteLine("Distrikt: ");
                string district = Console.ReadLine();

                //Mata in totala antalet försäljningar.
                Console.WriteLine("Antal: ");
                int totSales = int.Parse(Console.ReadLine());

                //Skapa en försäljare med de egenskaper som användaren just matade in.
                Person salesperson = new Person(name, pnbr, district, totSales);

                //Om det totala antalet försäljningar är mindre än 50 så lägg till försäljaren till nivå 1.
                if (totSales < 50 && totSales >= 0)
                {
                    level_1.Add(salesperson);
                    ppl_counter++;
                }
                //Om det totala antalet försäljningar är mellan 50 och 99 så lägg till försäljaren till nivå 2.
                else if (totSales >= 50 && totSales < 100)
                {
                    level_2.Add(salesperson);
                    ppl_counter++;
                }
               // Om det totala antalet försäljningar är mellan 100 och 199 så lägg till försäljaren till nivå 3.
                else if (totSales >= 100 && totSales < 200)
                {
                    level_3.Add(salesperson);
                    ppl_counter++;
                }
                // Om det totala antalet försäljningar är över 199 så lägg till försäljaren till nivå 4.
                else if (totSales >= 200)
                {
                    level_4.Add(salesperson);
                    ppl_counter++;
                }
            }

            //Sortera de olika nivåerna var för sig från lägst antal försäljningar till högst antal försäljningar.
            level_1.Sort((person_1, person_2) => person_1.totSales.CompareTo(person_2.totSales));
            level_2.Sort((person_1, person_2) => person_1.totSales.CompareTo(person_2.totSales));
            level_3.Sort((person_1, person_2) => person_1.totSales.CompareTo(person_2.totSales));
            level_4.Sort((person_1, person_2) => person_1.totSales.CompareTo(person_2.totSales));
        }

        //Metod för att skriva ut resultatet både i konsol och till fil.
        public void PrintRes()
        {
            //Döp filen som skall skrivas ut som: "Output + dagens datum + .txt".
            string filenamne = "Output" + DateTime.UtcNow.ToString("yyMMdd_hhmmss") + ".txt";
            string path = Path.Combine(@"./", filenamne);

            //Skapa ett StreamWriter-objekt för att skriva filen.
            StreamWriter file = new StreamWriter(path, true);

            //Egenskaperna som skall skrivas till filen och konsolen.
            string name1 = "Namn: ";
            string prnbr = "Personnummer: ";
            string district1 = "Distrikt: ";
            string nbr1 = "Antal: ";

            //Använd PadRight för att snygga til formatteringen.
            file.WriteLine("{0} \t {1} \t {2} \t {3}", name1.PadRight(20, ' '), prnbr.PadRight(10, ' '), district1.PadRight(15, ' '), nbr1.PadRight(10, ' '));
            Console.WriteLine("{0} \t {1} \t {2} \t {3}", name1.PadRight(20, ' '), prnbr.PadRight(10, ' '), district1.PadRight(15, ' '), nbr1.PadRight(10, ' '));

            int res = 0;

            //Gå genom alla försäljarna i nivå 1.
            foreach (Person salesperson in level_1)
            {
                res = level_1.Count;

                string count1 = salesperson.totSales.ToString();

                //Skriv ut till fil och till konsol
                file.WriteLine("{0} \t {1} \t {2} \t {3}", salesperson.name.PadRight(15, ' '), salesperson.pnbr.PadRight(15, ' '), salesperson.district.PadRight(15, ' '), count1.PadRight(10, ' '));
                Console.WriteLine("{0} \t {1} \t {2} \t {3}", salesperson.name.PadRight(15, ' '), salesperson.pnbr.PadRight(15, ' '), salesperson.district.PadRight(15, ' '), count1.PadRight(10, ' '));
            }
            //Skriv ut antalet försäljare i nivå 1 ifall det finns några.
            if (level_1.Count != 0)
            {
                file.WriteLine(res + " säljare har nått nivå 1: 0-49 artiklar" + "\n");
                Console.WriteLine(res + " säljare har nått nivå 1: 0-49 artiklar" + "\n");
            }

            //Gå genom alla försäljarna i nivå 2.
            foreach (Person salesperson in level_2)
            {
                res = level_2.Count;

                //Skriv ut till fil och till konsol
                string count2 = salesperson.totSales.ToString();
                file.WriteLine("{0} \t {1} \t {2} \t {3}", salesperson.name.PadRight(15, ' '), salesperson.pnbr.PadRight(15, ' '), salesperson.district.PadRight(15, ' '), count2.PadRight(10, ' '));
                Console.WriteLine("{0} \t {1} \t {2} \t {3}", salesperson.name.PadRight(15, ' '), salesperson.pnbr.PadRight(15, ' '), salesperson.district.PadRight(15, ' '), count2.PadRight(10, ' '));
            }

            //Skriv ut antalet försäljare i nivå 2 ifall det finns några.
            if (level_2.Count != 0)
            {
                file.WriteLine(res + " säljare har nått nivå 2: 50-99 artiklar" + "\n");
                Console.WriteLine(res + " säljare har nått nivå 2: 50-99 artiklar" + "\n");
            }

            //Gå genom alla försäljarna i nivå 3.
            foreach (Person salesperson in level_3)
            {
                res = level_3.Count;
                //Skriv ut till fil och till konsol
                string count3 = salesperson.totSales.ToString();
                file.WriteLine("{0} \t {1} \t {2} \t {3}", salesperson.name.PadRight(15, ' '), salesperson.pnbr.PadRight(15, ' '), salesperson.district.PadRight(15, ' '), count3.PadRight(10, ' '));
                Console.WriteLine("{0} \t {1} \t {2} \t {3}", salesperson.name.PadRight(15, ' '), salesperson.pnbr.PadRight(15, ' '), salesperson.district.PadRight(15, ' '), count3.PadRight(10, ' '));
            }

            //Skriv ut antalet försäljare i nivå 3 ifall det finns några.
            if (level_3.Count != 0)
            {
                file.WriteLine(res + " säljare har nått nivå 3: 100-199 artiklar" + "\n");
                Console.WriteLine(res + " säljare har nått nivå 3: 100-199 artiklar" + "\n");
            }
            //Gå genom alla försäljarna i nivå 4.
            foreach (Person salesperson in level_4)
            {
                //Skriv ut till fil och till konsol
                res = level_4.Count;
                string count4 = salesperson.totSales.ToString();
                file.WriteLine("{0} \t {1} \t {2} \t {3}", salesperson.name.PadRight(15, ' '), salesperson.pnbr.PadRight(15, ' '), salesperson.district.PadRight(15, ' '), count4.PadRight(10, ' '));
                Console.WriteLine("{0} \t {1} \t {2} \t {3}", salesperson.name.PadRight(15, ' '), salesperson.pnbr.PadRight(15, ' '), salesperson.district.PadRight(15, ' '), count4.PadRight(10, ' '));
            }

            //Skriv ut antalet försäljare i nivå 4 ifall det finns några.
            if (level_4.Count != 0)
            {
                file.WriteLine(res + " säljare har nått nivå 4: över 199 artiklar" + "\n");
                Console.WriteLine(res + " säljare har nått nivå 4: över 199 artiklar" + "\n");
            }

            //Stänga utsktiftsfilen.
            file.Close();
        }
    }
}
