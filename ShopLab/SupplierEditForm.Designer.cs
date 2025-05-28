namespace ShopLab {
    partial class SupplierEditForm {
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(134, 22);
            this.txtName.TabIndex = 0;
            this.txtName.Text = "Имя";
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(12, 40);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(134, 22);
            this.txtContact.TabIndex = 1;
            this.txtContact.Text = "Контакт";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Lime;
            this.btnSave.Location = new System.Drawing.Point(12, 68);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(134, 38);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SupplierEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(158, 125);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.txtName);
            this.Name = "SupplierEditForm";
            this.Text = "SupplierEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Button btnSave;
    }
}