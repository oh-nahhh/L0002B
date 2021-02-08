using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kassa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //Knapp för att rensa textboxen.
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = String.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] values = new int[] { 500, 100, 50, 20, 10, 5, 1 };

            int price = 0;
            int paid = 0;

            String input = priceTxtBox.Text;
            if (input != null && input != "")
            {
                price = int.Parse(input);
            }

            String input2 = paidTxtBox.Text;
            if (input2 != null && input2 != "")
            {
                paid = int.Parse(input2);
            }

            if (price < 0 || paid < 0)
            {
                MessageBox.Show("Priset eller betalningen kan inte vara negativ.");
                return;
            }

            if (price > paid)
            {
                MessageBox.Show("Betalningen måste vara mer än priset.");
                return;
            }

            int sum = paid - price;

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
                        richTextBox1.Text += change.ToString() + " " + "enkrona" + Environment.NewLine;
                    }
                    else if (enkrona == 1 && change > 1)
                    {
                        richTextBox1.Text += change.ToString() + " " + "enkronor" + Environment.NewLine;
                    }
                    //Samma sak för fem- och tiokronorsmynten som för enkronorna. 
                    int femkrona = Int32.Parse($"{value}");
                    if (femkrona == 5 && change == 1)
                    {
                        richTextBox1.Text += change.ToString() + " " + "femkrona" + Environment.NewLine;
                    }
                    else if (femkrona == 5 && change > 1)
                    {
                        richTextBox1.Text += change.ToString() + " " + "femkronor" + Environment.NewLine;
                    }

                    int tiokrona = Int32.Parse($"{value}");
                    if (tiokrona == 10 && change == 1)
                    {
                        richTextBox1.Text += change.ToString() + " " + "tiokrona" + Environment.NewLine;
                    }

                    else if (tiokrona == 10 && change > 1)
                    {
                        richTextBox1.Text += change.ToString() + " " + "tiokronor" + Environment.NewLine;
                    }

                    //Kolla samma sak för sedlarna (20, 50, 100, 500) som för mynten.
                    int tjugolapp = Int32.Parse($"{value}");
                    if (tjugolapp == 20 && change == 1)
                    {
                        richTextBox1.Text += change.ToString() + " " + "tjugolapp" + Environment.NewLine;
                    }

                    else if (tiokrona == 20 && change > 1)
                    {
                        richTextBox1.Text += change.ToString() + " " + "tjugolappar" + Environment.NewLine;
                    }

                    int femtiolapp = Int32.Parse($"{value}");
                    if (femtiolapp == 50 && change == 1)
                    {
                        richTextBox1.Text += change.ToString() + " " + "femtiolapp" + Environment.NewLine;
                    }

                    else if (femtiolapp == 50 && change > 1)
                    {
                        richTextBox1.Text += change.ToString() + " " + "femtiolappar" + Environment.NewLine;
                    }

                    int hundralapp = Int32.Parse($"{value}");
                    if (hundralapp == 100 && change == 1)
                    {
                        richTextBox1.Text += change.ToString() + " " + "hundralapp" + Environment.NewLine;
                    }

                    else if (hundralapp == 100 && change > 1)
                    {
                        richTextBox1.Text += change.ToString() + " " + "hundralappar" + Environment.NewLine;
                    }

                    int femhundralapp = Int32.Parse($"{value}");
                    if (femhundralapp == 500 && change == 1)
                    {
                        richTextBox1.Text += change.ToString() + " " + "femhundralapp" + Environment.NewLine;
                    }

                    else if (femhundralapp == 500 && change > 1)
                    {
                        richTextBox1.Text += change.ToString() + " " + "femhundralappar" + Environment.NewLine;
                    }
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

