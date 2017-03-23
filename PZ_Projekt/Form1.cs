using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PZ_Projekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> one;
        List<string> two;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                List<string> temp= new List<string>();
                while (!sr.EndOfStream)
                {
                   temp.Add(sr.ReadLine());
                }
                one = dane(temp.ToArray<string>());
                int licznik =0;
                foreach (string temp2 in one)
                {

                    if (licznik == 4)
                    {
                        richTextBox1.Text += "\n";
                        licznik = 0;
                    }
                    richTextBox1.Text+= temp2.ToString();
                    richTextBox1.Text += " ";
                    licznik++;

                }
                sr.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                List<string> temp = new List<string>();
                while (!sr.EndOfStream)
                {
                    temp.Add(sr.ReadLine());
                }
                two = dane(temp.ToArray<string>());
                int licznik2 = 0;
                foreach (string temp2 in two)
                {

                    if (licznik2 == 4)
                    {
                        richTextBox2.Text += "\n";

                        licznik2 = 0;
                    }
                    richTextBox2.Text += temp2.ToString();
                    richTextBox2.Text += " ";
                    licznik2++;

                }
                sr.Close();
            }
        }

        static List<string> dane(string[] tab)
        {
            string[] dane = null;
            List<string> lista = new List<string>();
            string pattern = @"^\s[1-9]\s+[1-9][0-9]*\s+[-]*[1-9]+[0-9]+.[0-9][0-9]*\s+[-]*[1-9][0-9]*.[0-9][0-9]*";
            string pattern1 = @"^\s[1-9]\s+[1-9][0-9]*\s+[-]*[1-9]+[0-9]+.[0-9][0-9]*\s+[-]*[1-9][0-9]*.[0-9][0-9]*.{0,71}";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            Regex rgx1 = new Regex(pattern1, RegexOptions.IgnoreCase);
            for (int i = 0; i < tab.Length; i++)
            {
                string input;
                input = tab[i];
                MatchCollection matches = rgx.Matches(input);
                MatchCollection matches1 = rgx1.Matches(input);
                if (matches.Count > 0)
                {
                    int n = 0;
                    //Console.WriteLine("{0} ({1} matches):", input, matches.Count);
                    foreach (Match match in matches)
                    {

                        //Console.WriteLine("   " + match.Value);
                        String[] splitTab = match.Value.Split(' ');
                        for (int j = 0; j < splitTab.Length; j++)
                        {
                            if (splitTab[j] != "")
                            {

                                Console.WriteLine(splitTab[j]);
                                lista.Add(splitTab[j]);

                            }

                        }
                        foreach (Match match1 in matches1)
                        {
                            Console.WriteLine(match1.Value.Substring(match1.Value.Length - 10));
                            lista.Add(match1.Value.Substring(match1.Value.Length - 10));
                        }
                    }
                }
            }
            return lista;
        }
    }
}
