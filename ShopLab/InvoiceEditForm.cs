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
    public partial class InvoiceEditForm : Form {
        private string connString = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=shop";
        public int? InvoiceId { get; set; } = null;

        public InvoiceEditForm() {
            InitializeComponent();
        }

        private void InvoiceEditForm_Load(object sender, EventArgs e) {
            LoadSuppliers();
            LoadProducts();
            if (InvoiceId.HasValue)
                LoadInvoice(InvoiceId.Value);
        }

        private void LoadSuppliers() {
            using (var conn = new NpgsqlConnection(connString)) {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT supplier_id, name FROM suppliers", conn);
                using (var reader = cmd.ExecuteReader()) {
                    var table = new DataTable();
                    table.Load(reader);
                    cbSupplier.DataSource = table;
                    cbSupplier.DisplayMember = "name";
                    cbSupplier.ValueMember = "supplier_id";
                }
            }
        }

        private void LoadProducts() {
            using (var conn = new NpgsqlConnection(connString)) {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT product_id, name FROM products", conn);
                using (var reader = cmd.ExecuteReader()) {
                    var table = new DataTable();
                    table.Load(reader);

                    var col = new DataGridViewComboBoxColumn {
                        HeaderText = "Товар",
                        DataPropertyName = "product_id",
                        DataSource = table,
                        DisplayMember = "name",
                        ValueMember = "product_id"
                    };
                    dgvItems.Columns.Add(col);
                    dgvItems.Columns.Add("quantity", "Кол-во");
                    dgvItems.Columns.Add("unit_price", "Цена");
                }
            }
        }

        public void LoadInvoice(int invoiceId) {
            InvoiceId = invoiceId;
            using (var conn = new NpgsqlConnection(connString)) {
                conn.Open();

                var cmd = new NpgsqlCommand("SELECT supplier_id, invoice_date, due_date FROM invoices WHERE invoice_id = @id", conn);
                cmd.Parameters.AddWithValue("id", invoiceId);
                using (var reader = cmd.ExecuteReader()) {
                    if (reader.Read()) {
                        cbSupplier.SelectedValue = reader.GetInt32(0);
                        dtInvoiceDate.Value = reader.GetDateTime(1);
                        dtDueDate.Value = reader.GetDateTime(2);
                    }
                }

                var cmdItems = new NpgsqlCommand("SELECT product_id, quantity, unit_price FROM invoice_items WHERE invoice_id = @id", conn);
                cmdItems.Parameters.AddWithValue("id", invoiceId);
                var adapter = new NpgsqlDataAdapter(cmdItems);
                var dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows)
                    dgvItems.Rows.Add(row["product_id"], row["quantity"], row["unit_price"]);
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            using (var conn = new NpgsqlConnection(connString)) {
                conn.Open();
                using (var tx = conn.BeginTransaction()) {
                    int invoiceId;
                    if (InvoiceId.HasValue) {
                        var cmd = new NpgsqlCommand("UPDATE invoices SET supplier_id=@supplier, invoice_date=@date, due_date=@due WHERE invoice_id=@id", conn);
                        cmd.Parameters.AddWithValue("id", InvoiceId.Value);
                        cmd.Parameters.AddWithValue("supplier", cbSupplier.SelectedValue);
                        cmd.Parameters.AddWithValue("date", dtInvoiceDate.Value);
                        cmd.Parameters.AddWithValue("due", dtDueDate.Value);
                        cmd.ExecuteNonQuery();
                        invoiceId = InvoiceId.Value;

                        var deleteCmd = new NpgsqlCommand("DELETE FROM invoice_items WHERE invoice_id = @id", conn);
                        deleteCmd.Parameters.AddWithValue("id", invoiceId);
                        deleteCmd.ExecuteNonQuery();
                    } else {
                        var cmd = new NpgsqlCommand("INSERT INTO invoices (supplier_id, invoice_date, due_date, total_amount) VALUES (@supplier, @date, @due, 0) RETURNING invoice_id", conn);
                        cmd.Parameters.AddWithValue("supplier", cbSupplier.SelectedValue);
                        cmd.Parameters.AddWithValue("date", dtInvoiceDate.Value);
                        cmd.Parameters.AddWithValue("due", dtDueDate.Value);
                        invoiceId = (int)cmd.ExecuteScalar();
                    }

                    decimal total = 0;
                    foreach (DataGridViewRow row in dgvItems.Rows) {
                        if (row.IsNewRow) continue;

                        int productId = Convert.ToInt32(row.Cells[0].Value);
                        decimal quantity = Convert.ToDecimal(row.Cells[1].Value);
                        decimal price = Convert.ToDecimal(row.Cells[2].Value);
                        total += quantity * price;

                        var cmdItem = new NpgsqlCommand("INSERT INTO invoice_items (invoice_id, product_id, quantity, unit_price) VALUES (@inv, @prod, @qty, @price)", conn);
                        cmdItem.Parameters.AddWithValue("inv", invoiceId);
                        cmdItem.Parameters.AddWithValue("prod", productId);
                        cmdItem.Parameters.AddWithValue("qty", quantity);
                        cmdItem.Parameters.AddWithValue("price", price);
                        cmdItem.ExecuteNonQuery();
                    }

                    var updateTotal = new NpgsqlCommand("UPDATE invoices SET total_amount = @total WHERE invoice_id = @id", conn);
                    updateTotal.Parameters.AddWithValue("total", total);
                    updateTotal.Parameters.AddWithValue("id", invoiceId);
                    updateTotal.ExecuteNonQuery();

                    tx.Commit();
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
