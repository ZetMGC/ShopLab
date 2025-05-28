namespace ShopLab {
    partial class PaymentEditForm {
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
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.dtPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.GreenYellow;
            this.btnSave.Location = new System.Drawing.Point(12, 118);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 54);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvItems
            // 
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Location = new System.Drawing.Point(233, 12);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersWidth = 51;
            this.dgvItems.RowTemplate.Height = 24;
            this.dgvItems.Size = new System.Drawing.Size(555, 253);
            this.dgvItems.TabIndex = 6;
            // 
            // dtPaymentDate
            // 
            this.dtPaymentDate.Location = new System.Drawing.Point(12, 42);
            this.dtPaymentDate.Name = "dtPaymentDate";
            this.dtPaymentDate.Size = new System.Drawing.Size(200, 22);
            this.dtPaymentDate.TabIndex = 5;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(13, 90);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(199, 22);
            this.txtAmount.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Сумма";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Дата оплаты";
            // 
            // PamentEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 282);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.dtPaymentDate);
            this.Name = "PamentEditForm";
            this.Text = "PamentEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DateTimePicker dtPaymentDate;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}