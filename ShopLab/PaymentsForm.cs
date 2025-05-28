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
    public partial class PaymentsForm : Form {
        private string connString = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=shop";
        public int InvoiceId { get; set; }

        public PaymentsForm(int invoiceId) {
            InitializeComponent();
            InvoiceId = invoiceId;
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void PaymentsForm_Load(object sender, EventArgs e) {
            LoadPayments();
        }

        private void LoadPayments() {
            using (var conn = new NpgsqlConnection(connString)) {
                conn.Open();

                var cmd = new NpgsqlCommand("SELECT payment_id, payment_date, amount FROM payments WHERE invoice_id = @id ORDER BY payment_date", conn);
                cmd.Parameters.AddWithValue("id", InvoiceId);
                var adapter = new NpgsqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                // Сумма оплат
                decimal total = 0;
                foreach (DataRow row in dt.Rows)
                    total += Convert.ToDecimal(row["amount"]);

                lblTotalPaid.Text = $"Оплачено: {total:N2} ₽";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            var form = new PaymentEditForm(InvoiceId);
            if (form.ShowDialog() == DialogResult.OK)
                LoadPayments();
        }
    }
}
