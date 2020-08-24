namespace Tbp_projekt
{
    partial class Automobili
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAutomobili = new System.Windows.Forms.DataGridView();
            this.txtPretrazivanjeNaziv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbProizvodaci = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbVrstaAutomobila = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutomobili)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAutomobili
            // 
            this.dgvAutomobili.AllowUserToAddRows = false;
            this.dgvAutomobili.AllowUserToDeleteRows = false;
            this.dgvAutomobili.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAutomobili.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAutomobili.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAutomobili.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAutomobili.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvAutomobili.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAutomobili.Location = new System.Drawing.Point(12, 61);
            this.dgvAutomobili.Name = "dgvAutomobili";
            this.dgvAutomobili.ReadOnly = true;
            this.dgvAutomobili.RowHeadersWidth = 51;
            this.dgvAutomobili.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAutomobili.Size = new System.Drawing.Size(1249, 472);
            this.dgvAutomobili.TabIndex = 0;
            this.dgvAutomobili.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAutomobili_CellContentClick);
            this.dgvAutomobili.SelectionChanged += new System.EventHandler(this.dgvAutomobili_SelectionChanged);
            // 
            // txtPretrazivanjeNaziv
            // 
            this.txtPretrazivanjeNaziv.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPretrazivanjeNaziv.Location = new System.Drawing.Point(193, 595);
            this.txtPretrazivanjeNaziv.Name = "txtPretrazivanjeNaziv";
            this.txtPretrazivanjeNaziv.Size = new System.Drawing.Size(245, 29);
            this.txtPretrazivanjeNaziv.TabIndex = 2;
            this.txtPretrazivanjeNaziv.TextChanged += new System.EventHandler(this.txtPretrazivanjeNaziv_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(193, 548);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pretraži automobil po nazivu";
            // 
            // cbProizvodaci
            // 
            this.cbProizvodaci.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProizvodaci.FormattingEnabled = true;
            this.cbProizvodaci.Location = new System.Drawing.Point(471, 592);
            this.cbProizvodaci.Name = "cbProizvodaci";
            this.cbProizvodaci.Size = new System.Drawing.Size(177, 32);
            this.cbProizvodaci.TabIndex = 4;
            this.cbProizvodaci.DropDownClosed += new System.EventHandler(this.cbProizvodaci_DropDownClosed);
            this.cbProizvodaci.SelectedValueChanged += new System.EventHandler(this.cbProizvodaci_SelectedValueChanged);
            this.cbProizvodaci.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbProizvodaci_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(467, 548);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pretraži proizvođače";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(502, 633);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 40);
            this.button1.TabIndex = 6;
            this.button1.Text = "Resetiraj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Tbp_projekt.Properties.Resources._8e4a2f66cf05c1f4b4f4a5c87c89086c_car_search_service_logo_by_vexels;
            this.pictureBox2.Location = new System.Drawing.Point(38, 539);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(134, 129);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Tbp_projekt.Properties.Resources.brand_names_;
            this.pictureBox1.Location = new System.Drawing.Point(249, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 506);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // cbVrstaAutomobila
            // 
            this.cbVrstaAutomobila.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVrstaAutomobila.FormattingEnabled = true;
            this.cbVrstaAutomobila.Location = new System.Drawing.Point(683, 592);
            this.cbVrstaAutomobila.Name = "cbVrstaAutomobila";
            this.cbVrstaAutomobila.Size = new System.Drawing.Size(229, 32);
            this.cbVrstaAutomobila.TabIndex = 8;
            this.cbVrstaAutomobila.DropDownClosed += new System.EventHandler(this.cbVrstaAutomobila_DropDownClosed);
            this.cbVrstaAutomobila.SelectedValueChanged += new System.EventHandler(this.cbVrstaAutomobila_SelectedValueChanged);
            this.cbVrstaAutomobila.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbVrstaAutomobila_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(679, 548);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Pretraži po vrsti automobila";
            // 
            // Automobili
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 686);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbVrstaAutomobila);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbProizvodaci);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPretrazivanjeNaziv);
            this.Controls.Add(this.dgvAutomobili);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Automobili";
            this.Text = "Automobili";
            this.Load += new System.EventHandler(this.Automobili_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutomobili)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAutomobili;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtPretrazivanjeNaziv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbProizvodaci;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cbVrstaAutomobila;
        private System.Windows.Forms.Label label3;
    }
}