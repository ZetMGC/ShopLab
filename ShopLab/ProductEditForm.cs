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
    public partial class ProductEditForm : Form {
        private string connString = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=shop";
        public int? ProductId { get; set; } = null;

        public ProductEditForm() {
            InitializeComponent();
        }

        public void LoadProduct(int productId) {
            ProductId = productId;
            using (var conn = new NpgsqlConnection(connString)) {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT name, unit FROM products WHERE product_id = @id", conn);
                cmd.Parameters.AddWithValue("id", productId);
                var reader = cmd.ExecuteReader();
                if (reader.Read()) {
                    txtName.Text = reader.GetString(0);
                    txtUnit.Text = reader.GetString(1);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            using (var conn = new NpgsqlConnection(connString)) {
                conn.Open();
                NpgsqlCommand cmd;

                if (ProductId.HasValue) {
                    cmd = new NpgsqlCommand("UPDATE products SET name = @name, unit = @unit WHERE product_id = @id", conn);
                    cmd.Parameters.AddWithValue("id", ProductId.Value);
                } else {
                    cmd = new NpgsqlCommand("INSERT INTO products (name, unit) VALUES (@name, @unit)", conn);
                }

                cmd.Parameters.AddWithValue("name", txtName.Text);
                cmd.Parameters.AddWithValue("unit", txtUnit.Text);
                cmd.ExecuteNonQuery();
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
