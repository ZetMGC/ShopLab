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
    public partial class ProductsForm : Form {
        private string connString = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=shop";

        public ProductsForm() {
            InitializeComponent();
        }

        private void LoadProducts() {
            using (var conn = new NpgsqlConnection(connString)) {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT product_id, name, unit FROM products", conn);
                var adapter = new NpgsqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e) {
            LoadProducts();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            var form = new ProductEditForm();
            if (form.ShowDialog() == DialogResult.OK)
                LoadProducts();
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            if (dataGridView1.CurrentRow == null) return;

            int productId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["product_id"].Value);
            var form = new ProductEditForm();
            form.LoadProduct(productId);
            if (form.ShowDialog() == DialogResult.OK)
                LoadProducts();
        }
    }
}
