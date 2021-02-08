using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personnummer
{
    //Klass för användargränssnittet.
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //Funktion för klick-knappen.
        private void button1_Click(object sender, EventArgs e)
        {
            String firstName = textBox1.Text.ToString();
            String lastName = textBox2.Text.ToString();
            String pNbr  = textBox3.Text.ToString();

            richTextBox1.AppendText("Namn: " + firstName + " ");
            richTextBox1.AppendText(lastName +"." + "\n");
            richTextBox1.AppendText("Personnummer: " + pNbr  + ". " + "\n");

            //Skapa ett nytt objekt av Person-klassen.
            Person person = new Person(firstName, lastName, pNbr );

            richTextBox1.AppendText(System.Environment.NewLine);
            richTextBox1.AppendText(person.GenderCheck());
            richTextBox1.AppendText(System.Environment.NewLine);
            richTextBox1.AppendText(person.PnbrCheck());

        }

        //Rensa textboxen med en klickknapp.
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = String.Empty;
        }
    }
}
