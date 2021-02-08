/*
Introduktion till programmering och C# L0002B
Inlämningsuppgift 3
Niklas Bergqvist
870310-4037
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personnummer
{
    //Personklass med egenskaperna: förnamn, efternamn och personnummer.
    class Person
    {
        public String firstName; //förnamn
        public String lastName; //efternamn 
        public String pNbr; //personnummer

        //Konstruktor till klassen Person
        public Person(String firstName, String lastName, String pNbr)
        {
            //Referenser till this.firstName, this.lastName och this.pNbr.
            this.firstName = firstName;
            this.lastName = lastName;
            this.pNbr = pNbr;
        }

        //Funktion som kontrollerar om personnummret är giltigt.
        public string PnbrCheck()
        {
            int res = 0;

            //Gå genom alla siffror i personnummret.
            for (int i = 0; i < pNbr.Length; i++)
            {
                int get_digit = int.Parse(pNbr[i].ToString());

                //Kontrollera om indexet är delbart med 2 för att ta fram varannan siffra i personnummret, 
                //vi börjar med indexet 0 (eftersom 0 är delbart med 2).  
                if (i % 2 == 0)
                {
                    //Multiplicera varannan siffra med 2.  
                    get_digit = 2 * get_digit;

                    //Om siffran är lika med 10 skall 1 + 0 = 1 returneras.
                    if (get_digit == 10)
                    {
                        //1 + 0 = 1 skall returneras.
                        get_digit = 1;
                    }

                    //Om siffran är större än 10 skall 1 + X returneras, där x = 0 i detta fall.
                    if (get_digit > 10)
                    {
                        //Hämta siffran som är större än 10 och konvertera till en sträng.
                        string temp = get_digit.ToString();

                        //Hämta den andra siffran X i 1X och addera 1 + X.
                        int x = int.Parse(temp[1].ToString());
                        get_digit = 1 + x;
                    }

                    //Lägg ihop den totala summan för de siffror som multiplicerats med 2.
                    res = res + get_digit;
                }
                else
                {
                    //Lägg ihop den totala summan för de siffror som multiplicerats med 1.
                    res = res + get_digit;
                }
            }

            //Om summan är delbart med 10 så är personnummret giltigt.
            if (res % 10 == 0)
            {
                return "Personnummret är giltigt.";
            }
            return "Personnummret är inte giltigt.";
        } 


        //Funktion som kollar om det är en man eller kvinna.
        public string GenderCheck()
        {
            string gender;
            //Hämta tredje siffran i födelsenumret.
            int nbr = int.Parse(pNbr[8].ToString());

            //Kolla om den är delbar med 2, i så fall är det en kvinna.
            if (nbr % 2 == 0)
            {
                gender = "Är en kvinna.";
            }
            //Annars är det en man.
            else
            {
                gender = "Är en man.";
            }
            return gender;
        }
    }
}
