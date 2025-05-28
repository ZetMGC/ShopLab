namespace ShopLab {
    partial class ProductEditForm {
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
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(146, 22);
            this.txtName.TabIndex = 0;
            this.txtName.Text = "Название";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(12, 40);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(146, 22);
            this.txtUnit.TabIndex = 1;
            this.txtUnit.Text = "Единицы измерения";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.GreenYellow;
            this.btnSave.Location = new System.Drawing.Point(12, 68);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(146, 41);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ProductEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(172, 122);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.txtName);
            this.Name = "ProductEditForm";
            this.Text = "ProductEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Button btnSave;
    }
}