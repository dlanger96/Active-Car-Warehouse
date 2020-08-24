namespace Tbp_projekt
{
    partial class StatistikaNarucivanja
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dgvNarucivanje = new System.Windows.Forms.DataGridView();
            this.chartNarucivanje = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNarucivanje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNarucivanje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNarucivanje
            // 
            this.dgvNarucivanje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNarucivanje.Location = new System.Drawing.Point(520, 274);
            this.dgvNarucivanje.Name = "dgvNarucivanje";
            this.dgvNarucivanje.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNarucivanje.Size = new System.Drawing.Size(257, 150);
            this.dgvNarucivanje.TabIndex = 0;
            // 
            // chartNarucivanje
            // 
            chartArea6.Name = "ChartArea1";
            this.chartNarucivanje.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartNarucivanje.Legends.Add(legend6);
            this.chartNarucivanje.Location = new System.Drawing.Point(37, 76);
            this.chartNarucivanje.Name = "chartNarucivanje";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chartNarucivanje.Series.Add(series6);
            this.chartNarucivanje.Size = new System.Drawing.Size(413, 362);
            this.chartNarucivanje.TabIndex = 1;
            this.chartNarucivanje.Text = "chart1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Tbp_projekt.Properties.Resources.preuzmi;
            this.pictureBox1.Location = new System.Drawing.Point(536, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(224, 227);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Grafički prikaz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(515, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tablični prikaz";
            // 
            // StatistikaNarucivanja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chartNarucivanje);
            this.Controls.Add(this.dgvNarucivanje);
            this.Name = "StatistikaNarucivanja";
            this.Text = "StatistikaNarucivanja";
            this.Load += new System.EventHandler(this.StatistikaNarucivanja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNarucivanje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNarucivanje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNarucivanje;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNarucivanje;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}