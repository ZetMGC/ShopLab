using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopLab {
    public partial class PaymentEditForm : Form {
        private string connString = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=shop";
        private int invoiceId;

        public PaymentEditForm(int invoiceId) {
            InitializeComponent();
            this.invoiceId = invoiceId;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            decimal amount;
            if (!decimal.TryParse(txtAmount.Text, out amount) || amount <= 0) {
                MessageBox.Show("Введите корректную сумму", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = new NpgsqlConnection(connString)) {
                conn.Open();
                var cmd = new NpgsqlCommand("INSERT INTO payments (invoice_id, payment_date, amount) VALUES (@inv, @date, @amount)", conn);
                cmd.Parameters.AddWithValue("inv", invoiceId);
                cmd.Parameters.AddWithValue("date", dtPaymentDate.Value);
                cmd.Parameters.AddWithValue("amount", amount);
                cmd.ExecuteNonQuery();
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
