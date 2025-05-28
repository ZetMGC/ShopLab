namespace ShopLab {
    partial class Form1 {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnSuppliers = new System.Windows.Forms.Button();
            this.btnInvoices = new System.Windows.Forms.Button();
            this.btnSupplierReport = new System.Windows.Forms.Button();
            this.btnProductReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProducts
            // 
            this.btnProducts.Location = new System.Drawing.Point(7, 12);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(75, 38);
            this.btnProducts.TabIndex = 0;
            this.btnProducts.Text = "Товары";
            this.btnProducts.UseVisualStyleBackColor = true;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.Location = new System.Drawing.Point(88, 12);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(113, 38);
            this.btnSuppliers.TabIndex = 1;
            this.btnSuppliers.Text = "Поставщики";
            this.btnSuppliers.UseVisualStyleBackColor = true;
            this.btnSuppliers.Click += new System.EventHandler(this.btnSuppliers_Click);
            // 
            // btnInvoices
            // 
            this.btnInvoices.Location = new System.Drawing.Point(207, 12);
            this.btnInvoices.Name = "btnInvoices";
            this.btnInvoices.Size = new System.Drawing.Size(113, 38);
            this.btnInvoices.TabIndex = 2;
            this.btnInvoices.Text = "Накладные";
            this.btnInvoices.UseVisualStyleBackColor = true;
            this.btnInvoices.Click += new System.EventHandler(this.btnInvoices_Click);
            // 
            // btnSupplierReport
            // 
            this.btnSupplierReport.Location = new System.Drawing.Point(7, 56);
            this.btnSupplierReport.Name = "btnSupplierReport";
            this.btnSupplierReport.Size = new System.Drawing.Size(178, 38);
            this.btnSupplierReport.TabIndex = 3;
            this.btnSupplierReport.Text = "Отчёт по поставщикам";
            this.btnSupplierReport.UseVisualStyleBackColor = true;
            this.btnSupplierReport.Click += new System.EventHandler(this.btnSupplierReport_Click);
            // 
            // btnProductReport
            // 
            this.btnProductReport.Location = new System.Drawing.Point(191, 56);
            this.btnProductReport.Name = "btnProductReport";
            this.btnProductReport.Size = new System.Drawing.Size(167, 38);
            this.btnProductReport.TabIndex = 4;
            this.btnProductReport.Text = "Отчёт по товарам";
            this.btnProductReport.UseVisualStyleBackColor = true;
            this.btnProductReport.Click += new System.EventHandler(this.btnProductReport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 112);
            this.Controls.Add(this.btnProductReport);
            this.Controls.Add(this.btnSupplierReport);
            this.Controls.Add(this.btnInvoices);
            this.Controls.Add(this.btnSuppliers);
            this.Controls.Add(this.btnProducts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnSuppliers;
        private System.Windows.Forms.Button btnInvoices;
        private System.Windows.Forms.Button btnSupplierReport;
        private System.Windows.Forms.Button btnProductReport;
    }
}

