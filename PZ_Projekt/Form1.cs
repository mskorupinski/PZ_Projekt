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
        DataTable table = new DataTable();
        DataTable table2 = new DataTable();
        public Form1()
        {
            InitializeComponent();
            
            table.Columns.Add("Podmacierz", typeof(string));
 
            table.Columns.Add("Wartość energetyczna", typeof(string));
            table.Columns.Add("Opis", typeof(string));

            table2.Columns.Add("Podmacierz", typeof(string));
            table2.Columns.Add("Wartość energetyczna", typeof(string));
            table2.Columns.Add("Opis", typeof(string));
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
                for (int i=0; i<one.Count; i+=4)
                {
                    /*
                    if (licznik == 4)
                    {

                        richTextBox1.Text += "\n";
                        licznik = 0;
                    }
                    */
                    //richTextBox1.Text+= temp2.ToString();
                    //richTextBox1.Text += " ";
                    table.Rows.Add(one[i], one[i+2],one[i+3]);
                    licznik++;

                }
                dataGridView1.DataSource = table;
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
                
                for (int i = 0; i < two.Count; i += 4)
                {
                    /*
                    if (licznik == 4)
                    {

                        richTextBox1.Text += "\n";
                        licznik = 0;
                    }
                    */
                    //richTextBox1.Text+= temp2.ToString();
                    //richTextBox1.Text += " ";
                    table2.Rows.Add(two[i], two[i + 2], two[i + 3]);
                    

                }
                dataGridView2.DataSource = table2;
                sr.Close();
                sr.Close();
            }
        }

        static List<string> dane(string[] tab)
        {
            string[] dane = null;
            List<string> lista = new List<string>();
            string pattern = @"^\s[1-9]\s+[1-9][0-9]*\s+[-]*[1-9]+[0-9]+.[0-9][0-9]*";
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
