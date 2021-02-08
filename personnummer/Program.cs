/*
Introduktion till programmering och C# L0002B
Inlämningsuppgift 3
Niklas Bergqvist
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personnummer
{
    //Huvudklassen som innehåller main-funktionen.
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        //Main-funktion som kör det grafiska användargränssnittet GUI.
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
