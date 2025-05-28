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
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btnProducts_Click(object sender, EventArgs e) {
            ProductsForm productsForm = new ProductsForm();
            productsForm.ShowDialog();
        }

        private void btnSuppliers_Click(object sender, EventArgs e) {
            SuppliersForm suppliersForm = new SuppliersForm();
            suppliersForm.ShowDialog();
        }

        private void btnInvoices_Click(object sender, EventArgs e) {
            InvoicesForm invoicesForm = new InvoicesForm();
            invoicesForm.ShowDialog();
        }

        private void btnSupplierReport_Click(object sender, EventArgs e) {
            var form = new SupplierReportForm();
            form.ShowDialog();
        }

        private void btnProductReport_Click(object sender, EventArgs e) {
            var form = new ProductPaymentReportForm();
            form.ShowDialog();
        }
    }
}
