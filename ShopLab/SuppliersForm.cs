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
    public partial class SuppliersForm : Form {
        private string connString = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=shop";

        public SuppliersForm() {
            InitializeComponent();
        }

        private void LoadSuppliers() {
            using (var conn = new NpgsqlConnection(connString)) {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT supplier_id, name, contact_info FROM suppliers", conn);
                var adapter = new NpgsqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e) {
            LoadSuppliers();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            var form = new SupplierEditForm();
            if (form.ShowDialog() == DialogResult.OK)
                LoadSuppliers();
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            if (dataGridView1.CurrentRow == null) return;

            int supplierId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["supplier_id"].Value);
            var form = new SupplierEditForm();
            form.LoadSupplier(supplierId);
            if (form.ShowDialog() == DialogResult.OK)
                LoadSuppliers();
        }
    }
}
