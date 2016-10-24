using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Mikser
{
    public partial class Form1 : Form
    {
        public static int licznik;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = new StreamReader(File.OpenRead(ofd.FileName));
                string path = System.IO.Path.GetDirectoryName(ofd.FileName);

                int liczbaLini = File.ReadAllLines(ofd.FileName).Length;
                int liczbaLiniZapis = 29 + (liczbaLini * 6);

                string[] czytajLinie = File.ReadAllLines(ofd.FileName);

                //29 lini pusty magazyn + 6 każdy 1 towar
                string[] zapisLinie = new string[liczbaLiniZapis];
                System.IO.StreamWriter newFile = new System.IO.StreamWriter(@"C:\Wynik.epp");

                licznik = 0;

                //szablon
                zapisLinie[licznik] = "[INFO]";
                licznik++;
                zapisLinie[licznik] = "\"1.05\",3,1250,\"Subiekt GT\",\"TT\",\"TT\",\"TT\",,,,\"555-55-55-555\",\"MAG\",\"Główny\",\"Magazyn główny\",,1,20161024202118,20161024202118,\"Szef\",20161024202118,\"Polska\",\"PL\",,0";
                licznik++;
                zapisLinie[licznik] = "";
                licznik++;
                zapisLinie[licznik] = "[NAGLOWEK]";
                licznik++;
                zapisLinie[licznik] = "\"TOWARY\"";
                licznik++;
                zapisLinie[licznik] = "";
                licznik++;
                zapisLinie[licznik] = "[ZAWARTOSC]";
                licznik++;
                
                //1 człon z pliku zaczytanego
                
                for (int i = 1; i < liczbaLini; i++ )
                {
                    string[] stringTemp = czytajLinie[i].Split(';');
                    zapisLinie[licznik++] = "1," + stringTemp[0] + ",," + stringTemp[0] + "," + stringTemp[1] + "," + stringTemp[2] + "," +
                        stringTemp[1] + ",,,\"szt.\",\"8\",8.0000,\"8\",8.0000,0.0000,0.0000,,0,,,,0.0000,0,,,0,\"szt.\",0.0000,0.0000,,0,,0,0,,,,,,,,";
                }

                //szablon
                zapisLinie[licznik] = "";
                licznik++;

                zapisLinie[licznik] = "[NAGLOWEK]";
                licznik++;

                zapisLinie[licznik] = "\"CENNIK\"";
                licznik++;

                zapisLinie[licznik] = "";
                licznik++;

                zapisLinie[licznik] = "[ZAWARTOSC]";
                licznik++;

                //2 człon z pliku zaczytanego
                for (int i = 1; i < liczbaLini; i++)
                {
                    string[] stringTemp = czytajLinie[i].Split(';');
                    zapisLinie[licznik++] = stringTemp[0] + ",\"Detaliczna\",0.0000,0.0000,10.0000,0.0000,0.0000";
                    zapisLinie[licznik++] = stringTemp[0] + ",\"Hurtowa\",0.0000,0.0000,5.0000,0.0000,0.0000";
                    zapisLinie[licznik++] = stringTemp[0] + ",\"Specjalna\",0.0000,0.0000,3.0000,0.0000,0.0000";
                }

                //szablon
                zapisLinie[licznik] = "";
                licznik++;

                zapisLinie[licznik] = "[NAGLOWEK]";
                licznik++;

                zapisLinie[licznik] = "\"GRUPYTOWAROW\"";
                licznik++;

                zapisLinie[licznik] = "";
                licznik++;

                zapisLinie[licznik] = "[ZAWARTOSC]";
                licznik++;

                //3 czło z pliku zaczytanego
                for (int i = 1; i < liczbaLini; i++)
                {
                    string[] stringTemp = czytajLinie[i].Split(';');
                    zapisLinie[licznik++] = stringTemp[0] + ",\"Podstawowa\",";
                }

                //szablon
                zapisLinie[licznik] = "";
                licznik++;

                zapisLinie[licznik] = "[NAGLOWEK]";
                licznik++;

                zapisLinie[licznik] = "\"CECHYTOWAROW\"";
                licznik++;

                zapisLinie[licznik] = "";
                licznik++;

                zapisLinie[licznik] = "[ZAWARTOSC]";
                licznik++;

                zapisLinie[licznik] = "";
                licznik++;

                zapisLinie[licznik] = "[NAGLOWEK]";
                licznik++;

                zapisLinie[licznik] = "\"DODATKOWETOWAROW\"";
                licznik++;

                zapisLinie[licznik] = "";
                licznik++;

                zapisLinie[licznik] = "[ZAWARTOSC]";
                licznik++;

                //4 człon z pliku zaczytanego
                for (int i = 1; i < liczbaLini; i++)
                {
                    string[] stringTemp = czytajLinie[i].Split(';');
                    zapisLinie[licznik++] = stringTemp[0] + ",0,0,0.0000,0,0,0";
                }



                    //zapsi do pliku
                    foreach (string line in zapisLinie)
                    {
                        newFile.WriteLine(line);
                    }


                newFile.Close();

                MessageBox.Show(String.Format("Zrobione ;))"));
                
            }
        }
    }
}
