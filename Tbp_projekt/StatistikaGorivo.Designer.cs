namespace Tbp_projekt
{
    partial class StatistikaGorivo
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartGorivo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvGorivo = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartGorivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGorivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // chartGorivo
            // 
            chartArea1.Name = "ChartArea1";
            this.chartGorivo.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartGorivo.Legends.Add(legend1);
            this.chartGorivo.Location = new System.Drawing.Point(34, 146);
            this.chartGorivo.Name = "chartGorivo";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "Vrsta goriva";
            this.chartGorivo.Series.Add(series1);
            this.chartGorivo.Size = new System.Drawing.Size(416, 300);
            this.chartGorivo.TabIndex = 0;
            this.chartGorivo.Text = "chart1";
            // 
            // dgvGorivo
            // 
            this.dgvGorivo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGorivo.Location = new System.Drawing.Point(558, 66);
            this.dgvGorivo.Name = "dgvGorivo";
            this.dgvGorivo.Size = new System.Drawing.Size(334, 184);
            this.dgvGorivo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Grafički prikaz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(554, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tablični prikaz";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(310, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Prikaz vrsta motora ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Tbp_projekt.Properties.Resources.CG_2889_Regular_vs_Premium_Gas_01_scaled;
            this.pictureBox1.Location = new System.Drawing.Point(12, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(892, 484);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // StatistikaGorivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 495);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvGorivo);
            this.Controls.Add(this.chartGorivo);
            this.Controls.Add(this.pictureBox1);
            this.Name = "StatistikaGorivo";
            this.Text = "StatistikaGorivo";
            this.Load += new System.EventHandler(this.StatistikaGorivo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartGorivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGorivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartGorivo;
        private System.Windows.Forms.DataGridView dgvGorivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}