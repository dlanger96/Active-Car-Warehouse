namespace Tbp_projekt
{
    partial class PrikazSkladista
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvAutomobili = new System.Windows.Forms.DataGridView();
            this.txtFkAutomobil = new System.Windows.Forms.TextBox();
            this.txtKolicina = new System.Windows.Forms.TextBox();
            this.txtPozicijaSk = new System.Windows.Forms.TextBox();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnAzuriraj = new System.Windows.Forms.Button();
            this.dgvEvidencija = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lbIdAutomobila = new System.Windows.Forms.Label();
            this.lbNovaKol = new System.Windows.Forms.Label();
            this.lbMjestoUSkladistu = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpPocetak = new System.Windows.Forms.DateTimePicker();
            this.dtpKraj = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutomobili)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvidencija)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAutomobili
            // 
            this.dgvAutomobili.AllowUserToAddRows = false;
            this.dgvAutomobili.AllowUserToDeleteRows = false;
            this.dgvAutomobili.AllowUserToOrderColumns = true;
            this.dgvAutomobili.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAutomobili.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAutomobili.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAutomobili.Location = new System.Drawing.Point(12, 159);
            this.dgvAutomobili.Name = "dgvAutomobili";
            this.dgvAutomobili.ReadOnly = true;
            this.dgvAutomobili.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvAutomobili.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAutomobili.Size = new System.Drawing.Size(554, 198);
            this.dgvAutomobili.TabIndex = 0;
            this.dgvAutomobili.SelectionChanged += new System.EventHandler(this.dgvAutomobili_SelectionChanged);
            // 
            // txtFkAutomobil
            // 
            this.txtFkAutomobil.Location = new System.Drawing.Point(165, 51);
            this.txtFkAutomobil.Name = "txtFkAutomobil";
            this.txtFkAutomobil.Size = new System.Drawing.Size(100, 20);
            this.txtFkAutomobil.TabIndex = 1;
            // 
            // txtKolicina
            // 
            this.txtKolicina.Location = new System.Drawing.Point(432, 54);
            this.txtKolicina.Name = "txtKolicina";
            this.txtKolicina.Size = new System.Drawing.Size(100, 20);
            this.txtKolicina.TabIndex = 2;
            // 
            // txtPozicijaSk
            // 
            this.txtPozicijaSk.Location = new System.Drawing.Point(586, 54);
            this.txtPozicijaSk.Name = "txtPozicijaSk";
            this.txtPozicijaSk.Size = new System.Drawing.Size(100, 20);
            this.txtPozicijaSk.TabIndex = 3;
            // 
            // btnDodaj
            // 
            this.btnDodaj.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDodaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodaj.Location = new System.Drawing.Point(774, 17);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(202, 87);
            this.btnDodaj.TabIndex = 4;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = false;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnAzuriraj
            // 
            this.btnAzuriraj.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnAzuriraj.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAzuriraj.Location = new System.Drawing.Point(990, 20);
            this.btnAzuriraj.Name = "btnAzuriraj";
            this.btnAzuriraj.Size = new System.Drawing.Size(202, 82);
            this.btnAzuriraj.TabIndex = 5;
            this.btnAzuriraj.Text = "Ažuriraj";
            this.btnAzuriraj.UseVisualStyleBackColor = false;
            this.btnAzuriraj.Click += new System.EventHandler(this.btnAzuriraj_Click);
            // 
            // dgvEvidencija
            // 
            this.dgvEvidencija.AllowUserToAddRows = false;
            this.dgvEvidencija.AllowUserToDeleteRows = false;
            this.dgvEvidencija.AllowUserToOrderColumns = true;
            this.dgvEvidencija.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEvidencija.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvidencija.Location = new System.Drawing.Point(12, 416);
            this.dgvEvidencija.Name = "dgvEvidencija";
            this.dgvEvidencija.ReadOnly = true;
            this.dgvEvidencija.RowHeadersWidth = 51;
            this.dgvEvidencija.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEvidencija.Size = new System.Drawing.Size(713, 246);
            this.dgvEvidencija.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 376);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Evidencija";
            // 
            // lbIdAutomobila
            // 
            this.lbIdAutomobila.AutoSize = true;
            this.lbIdAutomobila.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIdAutomobila.Location = new System.Drawing.Point(95, 17);
            this.lbIdAutomobila.Name = "lbIdAutomobila";
            this.lbIdAutomobila.Size = new System.Drawing.Size(256, 24);
            this.lbIdAutomobila.TabIndex = 8;
            this.lbIdAutomobila.Text = "Identifikacijski broj automobila";
            this.lbIdAutomobila.Click += new System.EventHandler(this.label2_Click);
            // 
            // lbNovaKol
            // 
            this.lbNovaKol.AutoSize = true;
            this.lbNovaKol.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbNovaKol.Location = new System.Drawing.Point(457, 20);
            this.lbNovaKol.Name = "lbNovaKol";
            this.lbNovaKol.Size = new System.Drawing.Size(76, 24);
            this.lbNovaKol.TabIndex = 9;
            this.lbNovaKol.Text = "Kolicina";
            // 
            // lbMjestoUSkladistu
            // 
            this.lbMjestoUSkladistu.AutoSize = true;
            this.lbMjestoUSkladistu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMjestoUSkladistu.Location = new System.Drawing.Point(568, 20);
            this.lbMjestoUSkladistu.Name = "lbMjestoUSkladistu";
            this.lbMjestoUSkladistu.Size = new System.Drawing.Size(157, 24);
            this.lbMjestoUSkladistu.TabIndex = 10;
            this.lbMjestoUSkladistu.Text = "Mjesto u skladistu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(305, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Stanje automobila na skladištu";
            // 
            // dtpPocetak
            // 
            this.dtpPocetak.Location = new System.Drawing.Point(6, 89);
            this.dtpPocetak.Name = "dtpPocetak";
            this.dtpPocetak.Size = new System.Drawing.Size(398, 31);
            this.dtpPocetak.TabIndex = 13;
            this.dtpPocetak.ValueChanged += new System.EventHandler(this.dtpPocetak_ValueChanged);
            // 
            // dtpKraj
            // 
            this.dtpKraj.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpKraj.Location = new System.Drawing.Point(6, 183);
            this.dtpKraj.Name = "dtpKraj";
            this.dtpKraj.Size = new System.Drawing.Size(398, 31);
            this.dtpKraj.TabIndex = 14;
            this.dtpKraj.ValueChanged += new System.EventHandler(this.dtpKraj_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpKraj);
            this.groupBox1.Controls.Add(this.dtpPocetak);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(833, 310);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 328);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Evidencija po datumu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Kraj evidencije";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Početak evidencije";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Tbp_projekt.Properties.Resources._1016_hero;
            this.pictureBox1.Location = new System.Drawing.Point(2, 110);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1255, 564);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(774, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(202, 87);
            this.button1.TabIndex = 16;
            this.button1.Text = "Obriši";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PrikazSkladista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 674);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbMjestoUSkladistu);
            this.Controls.Add(this.lbNovaKol);
            this.Controls.Add(this.lbIdAutomobila);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvEvidencija);
            this.Controls.Add(this.btnAzuriraj);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.txtPozicijaSk);
            this.Controls.Add(this.txtKolicina);
            this.Controls.Add(this.txtFkAutomobil);
            this.Controls.Add(this.dgvAutomobili);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "PrikazSkladista";
            this.Text = "PrikazSkladista";
            this.Load += new System.EventHandler(this.PrikazSkladista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutomobili)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvidencija)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAutomobili;
        private System.Windows.Forms.TextBox txtFkAutomobil;
        private System.Windows.Forms.TextBox txtKolicina;
        private System.Windows.Forms.TextBox txtPozicijaSk;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnAzuriraj;
        private System.Windows.Forms.DataGridView dgvEvidencija;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbIdAutomobila;
        private System.Windows.Forms.Label lbNovaKol;
        private System.Windows.Forms.Label lbMjestoUSkladistu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpPocetak;
        private System.Windows.Forms.DateTimePicker dtpKraj;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}