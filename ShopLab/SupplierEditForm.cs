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
    public partial class SupplierEditForm : Form {

        private string connString = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=shop";
        public int? SupplierId { get; set; } = null;

        public void LoadSupplier(int supplierId) {
            SupplierId = supplierId;
            using (var conn = new NpgsqlConnection(connString)) {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT name, contact_info FROM suppliers WHERE supplier_id = @id", conn);
                cmd.Parameters.AddWithValue("id", supplierId);
                var reader = cmd.ExecuteReader();
                if (reader.Read()) {
                    txtName.Text = reader.GetString(0);
                    txtContact.Text = reader.IsDBNull(1) ? "" : reader.GetString(1);
                }
            }
        }

        public SupplierEditForm() {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            using (var conn = new NpgsqlConnection(connString)) {
                conn.Open();
                NpgsqlCommand cmd;
                if (SupplierId.HasValue) {
                    cmd = new NpgsqlCommand("UPDATE suppliers SET name=@name, contact_info=@contact WHERE supplier_id=@id", conn);
                    cmd.Parameters.AddWithValue("id", SupplierId.Value);
                } else {
                    cmd = new NpgsqlCommand("INSERT INTO suppliers (name, contact_info) VALUES (@name, @contact)", conn);
                }

                cmd.Parameters.AddWithValue("name", txtName.Text);
                cmd.Parameters.AddWithValue("contact", string.IsNullOrWhiteSpace(txtContact.Text) ? DBNull.Value : (object)txtContact.Text);
                cmd.ExecuteNonQuery();
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
