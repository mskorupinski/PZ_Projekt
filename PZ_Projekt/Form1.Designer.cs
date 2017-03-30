namespace PZ_Projekt
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialogFile1 = new System.Windows.Forms.OpenFileDialog();
            this.labelFiles = new System.Windows.Forms.Label();
            this.labelFile1 = new System.Windows.Forms.Label();
            this.labelFile2 = new System.Windows.Forms.Label();
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.buttonDelete1 = new System.Windows.Forms.Button();
            this.buttonDelete2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupListControl1 = new GroupedListControl.GroupListControl();
            this.chkSingleItemOnlyMode = new System.Windows.Forms.CheckBox();
            this.comboBoxpodmacierz = new System.Windows.Forms.ComboBox();
            this.labelPodmacierz = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialogFile1
            // 
            this.openFileDialogFile1.FileName = "openFileDialogFile1";
            // 
            // labelFiles
            // 
            this.labelFiles.AutoSize = true;
            this.labelFiles.Location = new System.Drawing.Point(22, 8);
            this.labelFiles.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFiles.Name = "labelFiles";
            this.labelFiles.Size = new System.Drawing.Size(66, 13);
            this.labelFiles.TabIndex = 0;
            this.labelFiles.Text = "Dodane pliki";
            // 
            // labelFile1
            // 
            this.labelFile1.AutoSize = true;
            this.labelFile1.Location = new System.Drawing.Point(22, 21);
            this.labelFile1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFile1.Name = "labelFile1";
            this.labelFile1.Size = new System.Drawing.Size(39, 13);
            this.labelFile1.TabIndex = 1;
            this.labelFile1.Text = "Plik1:  ";
            this.labelFile1.Visible = false;
            // 
            // labelFile2
            // 
            this.labelFile2.AutoSize = true;
            this.labelFile2.Location = new System.Drawing.Point(22, 34);
            this.labelFile2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFile2.Name = "labelFile2";
            this.labelFile2.Size = new System.Drawing.Size(39, 13);
            this.labelFile2.TabIndex = 2;
            this.labelFile2.Text = "Plik2:  ";
            this.labelFile2.Visible = false;
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Location = new System.Drawing.Point(25, 49);
            this.buttonAddFile.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(63, 21);
            this.buttonAddFile.TabIndex = 3;
            this.buttonAddFile.Text = "Dodaj plik";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.buttonAddFile_Click);
            // 
            // buttonDelete1
            // 
            this.buttonDelete1.Location = new System.Drawing.Point(469, 16);
            this.buttonDelete1.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDelete1.Name = "buttonDelete1";
            this.buttonDelete1.Size = new System.Drawing.Size(42, 22);
            this.buttonDelete1.TabIndex = 4;
            this.buttonDelete1.Text = "Usuń";
            this.buttonDelete1.UseVisualStyleBackColor = true;
            this.buttonDelete1.Visible = false;
            this.buttonDelete1.Click += new System.EventHandler(this.buttonDelete1_Click);
            // 
            // buttonDelete2
            // 
            this.buttonDelete2.Location = new System.Drawing.Point(469, 34);
            this.buttonDelete2.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDelete2.Name = "buttonDelete2";
            this.buttonDelete2.Size = new System.Drawing.Size(42, 22);
            this.buttonDelete2.TabIndex = 5;
            this.buttonDelete2.Text = "Usuń";
            this.buttonDelete2.UseVisualStyleBackColor = true;
            this.buttonDelete2.Visible = false;
            this.buttonDelete2.Click += new System.EventHandler(this.buttonDelete2_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(25, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generuj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupListControl1
            // 
            this.groupListControl1.AutoScroll = true;
            this.groupListControl1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.groupListControl1.Location = new System.Drawing.Point(47, 165);
            this.groupListControl1.Margin = new System.Windows.Forms.Padding(2);
            this.groupListControl1.Name = "groupListControl1";
            this.groupListControl1.SingleItemOnlyExpansion = false;
            this.groupListControl1.Size = new System.Drawing.Size(581, 366);
            this.groupListControl1.TabIndex = 6;
            this.groupListControl1.WrapContents = false;
            // 
            // chkSingleItemOnlyMode
            // 
            this.chkSingleItemOnlyMode.AutoSize = true;
            this.chkSingleItemOnlyMode.Checked = true;
            this.chkSingleItemOnlyMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSingleItemOnlyMode.Location = new System.Drawing.Point(47, 141);
            this.chkSingleItemOnlyMode.Margin = new System.Windows.Forms.Padding(2);
            this.chkSingleItemOnlyMode.Name = "chkSingleItemOnlyMode";
            this.chkSingleItemOnlyMode.Size = new System.Drawing.Size(77, 17);
            this.chkSingleItemOnlyMode.TabIndex = 7;
            this.chkSingleItemOnlyMode.Text = "Rozwijanie";
            this.chkSingleItemOnlyMode.UseVisualStyleBackColor = true;
            this.chkSingleItemOnlyMode.CheckedChanged += new System.EventHandler(this.chkSingleItemOnlyMode_CheckedChanged);
            // 
            // comboBoxpodmacierz
            // 
            this.comboBoxpodmacierz.FormattingEnabled = true;
            this.comboBoxpodmacierz.Location = new System.Drawing.Point(274, 137);
            this.comboBoxpodmacierz.Name = "comboBoxpodmacierz";
            this.comboBoxpodmacierz.Size = new System.Drawing.Size(121, 21);
            this.comboBoxpodmacierz.TabIndex = 8;
            this.comboBoxpodmacierz.Visible = false;
            this.comboBoxpodmacierz.SelectedIndexChanged += new System.EventHandler(this.comboBoxpodmacierz_SelectedIndexChanged);
            // 
            // labelPodmacierz
            // 
            this.labelPodmacierz.AutoSize = true;
            this.labelPodmacierz.Location = new System.Drawing.Point(166, 141);
            this.labelPodmacierz.Name = "labelPodmacierz";
            this.labelPodmacierz.Size = new System.Drawing.Size(102, 13);
            this.labelPodmacierz.TabIndex = 9;
            this.labelPodmacierz.Text = "Wybierz podmacierz";
            this.labelPodmacierz.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 600);
            this.Controls.Add(this.labelPodmacierz);
            this.Controls.Add(this.comboBoxpodmacierz);
            this.Controls.Add(this.chkSingleItemOnlyMode);
            this.Controls.Add(this.groupListControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonDelete2);
            this.Controls.Add(this.buttonDelete1);
            this.Controls.Add(this.buttonAddFile);
            this.Controls.Add(this.labelFiles);
            this.Controls.Add(this.labelFile1);
            this.Controls.Add(this.labelFile2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogFile1;
        private System.Windows.Forms.Label labelFiles;
        private System.Windows.Forms.Label labelFile1;
        private System.Windows.Forms.Label labelFile2;
        private System.Windows.Forms.Button buttonAddFile;
        private System.Windows.Forms.Button buttonDelete1;
        private System.Windows.Forms.Button buttonDelete2;

        private System.Windows.Forms.Button button1;
        private GroupedListControl.GroupListControl groupListControl1;
        private System.Windows.Forms.CheckBox chkSingleItemOnlyMode;
        private System.Windows.Forms.ComboBox comboBoxpodmacierz;
        private System.Windows.Forms.Label labelPodmacierz;
    }
}

