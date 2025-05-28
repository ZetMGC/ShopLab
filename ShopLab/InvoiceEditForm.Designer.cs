namespace ShopLab {
    partial class InvoiceEditForm {
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
            this.cbSupplier = new System.Windows.Forms.ComboBox();
            this.dtInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.dtDueDate = new System.Windows.Forms.DateTimePicker();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // cbSupplier
            // 
            this.cbSupplier.FormattingEnabled = true;
            this.cbSupplier.Location = new System.Drawing.Point(12, 12);
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Size = new System.Drawing.Size(200, 24);
            this.cbSupplier.TabIndex = 0;
            // 
            // dtInvoiceDate
            // 
            this.dtInvoiceDate.Location = new System.Drawing.Point(12, 42);
            this.dtInvoiceDate.Name = "dtInvoiceDate";
            this.dtInvoiceDate.Size = new System.Drawing.Size(200, 22);
            this.dtInvoiceDate.TabIndex = 1;
            // 
            // dtDueDate
            // 
            this.dtDueDate.Location = new System.Drawing.Point(12, 70);
            this.dtDueDate.Name = "dtDueDate";
            this.dtDueDate.Size = new System.Drawing.Size(200, 22);
            this.dtDueDate.TabIndex = 2;
            // 
            // dgvItems
            // 
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Location = new System.Drawing.Point(233, 12);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersWidth = 51;
            this.dgvItems.RowTemplate.Height = 24;
            this.dgvItems.Size = new System.Drawing.Size(555, 253);
            this.dgvItems.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.GreenYellow;
            this.btnSave.Location = new System.Drawing.Point(12, 98);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 54);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // InvoiceEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 273);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.dtDueDate);
            this.Controls.Add(this.dtInvoiceDate);
            this.Controls.Add(this.cbSupplier);
            this.Name = "InvoiceEditForm";
            this.Text = "InvoiceEditForm";
            this.Load += new System.EventHandler(this.InvoiceEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSupplier;
        private System.Windows.Forms.DateTimePicker dtInvoiceDate;
        private System.Windows.Forms.DateTimePicker dtDueDate;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Button btnSave;
    }
}