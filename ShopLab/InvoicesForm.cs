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

    public partial class InvoicesForm : Form {
        private string connString = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=shop";

        private void LoadInvoices() {
            using (var conn = new NpgsqlConnection(connString)) {
                conn.Open();
                string query = @"
                    SELECT i.invoice_id, s.name AS supplier, i.invoice_date, i.total_amount, i.due_date
                    FROM invoices i
                    JOIN suppliers s ON i.supplier_id = s.supplier_id
                    ORDER BY i.invoice_date DESC";
                var adapter = new NpgsqlDataAdapter(query, conn);
                var dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        public InvoicesForm() {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadInvoices();

        private void btnAdd_Click(object sender, EventArgs e) {
            var form = new InvoiceEditForm();
            if (form.ShowDialog() == DialogResult.OK)
                LoadInvoices();
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            if (dataGridView1.CurrentRow == null) return;

            int invoiceId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["invoice_id"].Value);
            var form = new InvoiceEditForm();
            form.LoadInvoice(invoiceId);
            if (form.ShowDialog() == DialogResult.OK)
                LoadInvoices();
        }

        private void InvoicesForm_Load(object sender, EventArgs e) => LoadInvoices();

        private void button1_Click(object sender, EventArgs e) {
            if (dataGridView1.CurrentRow == null) return;

            int invoiceId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["invoice_id"].Value);
            var form = new PaymentsForm(invoiceId);
            form.ShowDialog();
        }
    }
}
