namespace ShopLab {
    partial class ProductPaymentReportForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.clbProducts = new System.Windows.Forms.CheckedListBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.GreenYellow;
            this.btnGenerate.Location = new System.Drawing.Point(12, 303);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(200, 54);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "Сгенерировать";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(233, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(555, 405);
            this.dataGridView1.TabIndex = 8;
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(12, 275);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(200, 22);
            this.dtTo.TabIndex = 7;
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(12, 231);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(200, 22);
            this.dtFrom.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "От";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "До";
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.DarkOrchid;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExport.Location = new System.Drawing.Point(12, 363);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(200, 54);
            this.btnExport.TabIndex = 12;
            this.btnExport.Text = "Экспорт в Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // clbProducts
            // 
            this.clbProducts.FormattingEnabled = true;
            this.clbProducts.Location = new System.Drawing.Point(12, 12);
            this.clbProducts.Name = "clbProducts";
            this.clbProducts.Size = new System.Drawing.Size(200, 191);
            this.clbProducts.TabIndex = 13;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 427);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(800, 300);
            this.chart1.TabIndex = 14;
            this.chart1.Text = "chart1";
            // 
            // ProductPaymentReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 727);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.clbProducts);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.dtFrom);
            this.Name = "ProductPaymentReportForm";
            this.Text = "ProductPaymentReportForm";
            this.Load += new System.EventHandler(this.ProductPaymentReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.CheckedListBox clbProducts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}