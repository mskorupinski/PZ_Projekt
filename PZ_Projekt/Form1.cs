﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GroupedListControl;
using System.IO;

namespace PZ_Projekt
{
    public partial class Form1 : Form
    {
        public string _File1Stream { get; set; }
        public string _File2Stream { get; set; }

        public string _File1Name { get; set; }
        public string _File2Name { get; set; }
        private int _MatrixCount { get; set; }

        ContextMenuStrip _ListGroupContextMenu;
        ToolStripMenuItem _addOption = new ToolStripMenuItem("Add");
        ToolStripMenuItem _editOption = new ToolStripMenuItem("Edit");
        ToolStripMenuItem _deleteOption = new ToolStripMenuItem("Delete");

        private GroupListControl glc;



        public Form1()
        {
            InitializeComponent();
                       
            //  Set up the context menu to use with the GroupedList Items:
            _ListGroupContextMenu = new ContextMenuStrip();

            // Add some sample ContextMenuStrip Items:
            _addOption = new ToolStripMenuItem("Add");
            _addOption.Click += new EventHandler(addOption_Click);
            _ListGroupContextMenu.Items.Add(_addOption);

            _editOption = new ToolStripMenuItem("Edit");
            _editOption.Click += new EventHandler(editOption_Click);
            _ListGroupContextMenu.Items.Add(_editOption);

            _deleteOption = new ToolStripMenuItem("Delete");
            _deleteOption.Click += new EventHandler(deleteOption_Click);
            _ListGroupContextMenu.Items.Add(_deleteOption);

        }

        List<string> one;
        List<string> two;

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            if (openFileDialogFile1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialogFile1.FileName.IndexOf(".out") > -1)
                {
                    if (string.IsNullOrEmpty(_File1Stream))
                    {
                        _File1Stream = openFileDialogFile1.FileName;
                        _File1Name = _File1Stream.Substring(_File1Stream.LastIndexOf('\\') + 1);
                        labelFile1.Text += _File1Name;
                        labelFile1.Visible = true;
                        buttonDelete1.Visible = true;

                    }
                    else if (string.IsNullOrEmpty(_File1Stream) || string.IsNullOrEmpty(_File2Stream))
                    {
                        if (_File1Stream != openFileDialogFile1.FileName)
                        {
                            _File2Stream = openFileDialogFile1.FileName;
                            _File2Name = _File2Stream.Substring(_File2Stream.LastIndexOf('\\') + 1);
                            labelFile2.Text += _File2Name;
                            labelFile2.Visible = true;
                            buttonDelete2.Visible = true;
                            button1.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Podany plik już instnieje", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dodano maksymalna liczbe plików", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Błędny format pliku", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void buttonDelete1_Click(object sender, EventArgs e)
        {
            labelFile1.Text = "Plik1:  ";
            if (string.IsNullOrEmpty(this._File2Stream))
            {
                this._File1Name = null;
                this._File1Stream = null;
                labelFile1.Visible = false;
                buttonDelete1.Visible = false;
            }
            else
            {
                labelFile2.Text = "Plik2:  ";
                this._File1Name = this._File2Name;
                labelFile1.Text += this._File1Name;
                this._File1Stream = this._File2Stream;
                this._File2Name = null;
                this._File2Stream = null;
                labelFile2.Visible = false;
                buttonDelete2.Visible = false;
            }
        }

        private void buttonDelete2_Click(object sender, EventArgs e)
        {
            labelFile2.Text = "Plik2:";
            this._File2Name = null;
            this._File2Stream = null;
            labelFile2.Visible = false;
            buttonDelete2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader sr = new
            System.IO.StreamReader(this._File1Stream);
            List<string> temp = new List<string>();
            while (!sr.EndOfStream)
            {
                temp.Add(sr.ReadLine());
            }
            one = dane(temp.ToArray<string>());


            _MatrixCount = Convert.ToInt32(one[(one.Count - 4)]);
            for( int i=1;i<=_MatrixCount;i++)
            {
                this.comboBoxpodmacierz.Items.Add(i);
                this.comboBoxpodmacierz.SelectedItem = 1;
            }         
            sr.Close();

            sr = new
               System.IO.StreamReader(_File2Stream);
            temp = new List<string>();
            while (!sr.EndOfStream)
            {
                temp.Add(sr.ReadLine());
            }
            two = dane(temp.ToArray<string>());
                   
            sr.Close();

            glc = this.groupListControl1;
            glc.Visible = false;
            glc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            if (glc != null && glc.Controls != null)
            {
                while (glc.Controls.Count > 0)
                    glc.Controls.RemoveAt(0);
            }
                // Add some sample columns:
            for (int i = 0; i < one.Count; i += 4)
            {
                if (Convert.ToInt32(one[i]) == Convert.ToInt32(this.comboBoxpodmacierz.Text))
                {
                    ListGroup lg = new ListGroup();
                

                    lg.Columns.Add(one[i], 120);
                    lg.Columns.Add(one[i + 2], 150);
                    lg.Columns.Add(one[i + 3], 150);
                    lg.Columns.Add("Liczba falowa", 150);
                    lg.Columns.Add("Długość fali", 150);
                    lg.Columns.Add("Przejście", 150);
                    lg.Name = "Group " + i;


                    List<string> wynik = oblicz(this.comboBoxpodmacierz.Text, one[i+2], two);

                    for (int j = 0; j < wynik.Count; j += 6)
                    {
                        ListViewItem item = lg.Items.Add(wynik[j]);
                        item.SubItems.Add(wynik[j + 1]);
                        item.SubItems.Add(wynik[j + 2]);
                        item.SubItems.Add(wynik[j + 3]);
                        item.SubItems.Add(wynik[j + 4]);
                        item.SubItems.Add(wynik[j + 5]);
                    }

                    // Add handling for the columnRightClick Event:
                    lg.ColumnRightClick += new ListGroup.ColumnRightClickHandler(lg_ColumnRightClick);
                    //lg.GroupCollapsed += new ListGroup.GroupExpansionHandler(lg_GroupCollapsed);
                    lg.GroupExpanded += new ListGroup.GroupExpansionHandler(lg_GroupExpanded);
                    lg.MouseClick += new MouseEventHandler(lg_MouseClick);

                    glc.Controls.Add(lg);
                }
            }
            glc.Visible = true;
            this.labelPodmacierz.Visible = true;
            this.comboBoxpodmacierz.Visible = true;
            this.chkSingleItemOnlyMode.Visible = true;
          

        }

        public bool SingleItemOnlyExpansion { get; set; }

        void lg_GroupExpanded(object sender, EventArgs e )
        {
            // Grab a reference to the ListGroup which sent the message:
            ListGroup expanded = (ListGroup)sender;
           
           //ListViewHitTestInfo info = expanded.HitTest(e.X, e.Y);
           // ListViewItem itemTemp = info.Item;
            // If Single item only expansion, collapse all ListGroups in except
            // the one currently exanding:
            if (this.SingleItemOnlyExpansion)
            {
                this.SuspendLayout();
                foreach (ListGroup lgTemp in this.Controls)
                {
                    
                    if (!lgTemp.Equals(expanded))
                    
                        lgTemp.Collapse();
                }
                this.ResumeLayout(true);
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

        void lg_MouseClick(object sender, MouseEventArgs e)
        {
            ListGroup lg = (ListGroup)sender;

            ListViewHitTestInfo info = lg.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;

            if (e.Button == MouseButtons.Right)
            {
                // Tuck the Active ListGroup into the Tag property:
                _ListGroupContextMenu.Tag = lg;

                // Make sure the Delete and Edit options are enabled:
                _editOption.Enabled = true;
                _deleteOption.Enabled = true;

                // Because we are not using the GroupedList's own ContextMenuStrip, 
                // we need to use the PointToClient method so that the menu appears 
                // in the correct position relative to the control:
                _ListGroupContextMenu.Show(lg, lg.PointToClient(MousePosition));
            }

        }



        void lg_ColumnRightClick(object sender, ColumnClickEventArgs e)
        {
            ListGroup lg = (ListGroup)sender;

            // Tuck the Active ListGroup into the Tag property:
            _ListGroupContextMenu.Tag = lg;

            // If the header is right-clicked, the user has not indicated an item to edit or delete.
            // Disable those options:
            _editOption.Enabled = false;
            _deleteOption.Enabled = false;

            // Because we are not using the GroupedList's own ContextMenuStrip, 
            // we need to use the PointToClient method so that the menu appears 
            // in the correct position relative to the control:
            _ListGroupContextMenu.Show(lg, lg.PointToClient(MousePosition));
        }



        void deleteOption_Click(object sender, EventArgs e)
        {
            var menuItem = (ToolStripMenuItem)sender;
            var menu = menuItem.Owner;
            var selectedGroup = (ListGroup)menu.Tag;

            // Only one selected item allowed for this demo:
            var selectedItem = selectedGroup.SelectedItems[0];

            string groupName = selectedGroup.Name;
            string itemName = selectedItem.Text;

            MessageBox.Show("Delete  " + itemName + " from " + selectedGroup.Name);
        }



        void editOption_Click(object sender, EventArgs e)
        {
            var menuItem = (ToolStripMenuItem)sender;
            var menu = menuItem.Owner;
            var selectedGroup = (ListGroup)menu.Tag;

            // Only one selected item allowed for this demo:
            var selectedItem = selectedGroup.SelectedItems[0];

            string groupName = selectedGroup.Name;
            string itemName = selectedItem.Text;

            MessageBox.Show("Edit  " + itemName + " from " + selectedGroup.Name);
        }



        void addOption_Click(object sender, EventArgs e)
        {
            var menuItem = (ToolStripMenuItem)sender;
            var menu = menuItem.Owner;
            var selectedGroup = (ListGroup)menu.Tag;

            MessageBox.Show("Add a new item to " + selectedGroup.Name);
        }

        // Determine whether or not to use SingleItemOnly Expansion:
        private void chkSingleItemOnlyMode_CheckedChanged(object sender, EventArgs e)
        {
            this.groupListControl1.SingleItemOnlyExpansion = this.chkSingleItemOnlyMode.Checked;
            if (this.groupListControl1.SingleItemOnlyExpansion)
            {
                this.groupListControl1.CollapseAll();
            }
            else
            {
                this.groupListControl1.ExpandAll();
            }
        }

        private void comboBoxpodmacierz_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (glc!=null && glc.Controls != null)
            {
                while (glc.Controls.Count>0)
                    glc.Controls.RemoveAt(0);
                glc.Visible = false;
                for (int i = 0; i < one.Count; i += 4)
                {
                    if (Convert.ToInt32(one[i]) == Convert.ToInt32(this.comboBoxpodmacierz.Text))
                    {
                        ListGroup lg = new ListGroup();

                        lg.Columns.Add(one[i], 120);
                        lg.Columns.Add(one[i + 2], 150);
                        lg.Columns.Add(one[i + 3], 150);
                        lg.Columns.Add("Liczba falowa", 150);
                        lg.Columns.Add("Długość fali", 150);
                        lg.Columns.Add("Przejście", 150);
                        lg.Name = "Group " + i;

                        List<string> wynik = oblicz(this.comboBoxpodmacierz.Text, one[i], two);

                        for (int j = 0; j < wynik.Count; j += 6)
                        {
                            ListViewItem item = lg.Items.Add(wynik[j]);
                            item.SubItems.Add(wynik[j + 1]);
                            item.SubItems.Add(wynik[j + 2]);
                            item.SubItems.Add(wynik[j + 3]);
                            item.SubItems.Add(wynik[j + 4]);
                            item.SubItems.Add(wynik[j + 5]);


                        }
                        lg.ColumnRightClick += new ListGroup.ColumnRightClickHandler(lg_ColumnRightClick);
                        lg.MouseClick += new MouseEventHandler(lg_MouseClick);

                        glc.Controls.Add(lg);
                    }
                }
                glc.Visible = true;
                comboBoxpodmacierz.Enabled = false;
                comboBoxpodmacierz.Enabled = true;
            }
        }

        static List<String> oblicz(String numer_macierzy, string energia, List<string> Two)
        {
            List<String> wynik = new List<String>();
            for (int i = 0; i < Two.Count; i++)
            {

                if (i % 4 == 0)
                {
                    if (Int32.Parse(numer_macierzy) - 1 == Int32.Parse(Two[i]) || Int32.Parse(numer_macierzy) == Int32.Parse(Two[i]) || Int32.Parse(numer_macierzy) + 1 == Int32.Parse(Two[i]))
                    {
                        wynik.Add(Two[i]);
                        Double Energia_one = Double.Parse(energia.Replace(".",","));
                        Double Energia_two = Double.Parse(Two[i + 2].Replace(".",","));
                        Double Liczba_falowa = Math.Abs(Energia_two - Energia_one);
                        wynik.Add(Two[i + 2].ToString());
                        wynik.Add(Two[i + 3].ToString());
                        wynik.Add(Liczba_falowa.ToString());
                        if (Liczba_falowa >= 50000)
                        {
                            Double dlugosc = Math.Round(100000000 / Liczba_falowa,4);
                            
                            wynik.Add(dlugosc.ToString());
                        }
                        if (Liczba_falowa < 50000)
                        {
                            Double n = 1 + (8060.51 + 2480990 / (132.2474 - Math.Pow((Liczba_falowa / 10000), 2) + 17455.7 / (39.32957 - Math.Pow((Liczba_falowa / 10000),2)))) * 0.00000001;
                            Double dlugosc = Math.Round(100000000 / (Liczba_falowa*n),4);
                            wynik.Add(dlugosc.ToString());


                        }
                        if (Energia_two - Energia_one > 0)
                        {
                            wynik.Add("▲");
                        }
                        else
                            wynik.Add("▼");
                    }


                }

              

            }

            return wynik;
        }




    }
}
