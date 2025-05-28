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
using System.Windows.Forms.DataVisualization.Charting;


namespace ShopLab {
    public partial class ProductPaymentReportForm : Form {
        private string connString = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=shop";
        public ProductPaymentReportForm() {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e) {
            List<int> selectedIds = new List<int>();
            foreach (var item in clbProducts.CheckedItems) {
                var type = item.GetType();
                selectedIds.Add((int)type.GetProperty("Id").GetValue(item));
            }

            if (selectedIds.Count == 0) {
                MessageBox.Show("Выберите хотя бы один товар.");
                return;
            }

            using (var conn = new NpgsqlConnection(connString)) {
                conn.Open();
                var cmd = new NpgsqlCommand(@"
                    SELECT
                        i.invoice_date::date AS date,
                        p.name AS product,
                        SUM(ii.quantity * ii.unit_price) AS amount_due
                    FROM invoice_items ii
                    JOIN invoices i ON i.invoice_id = ii.invoice_id
                    JOIN products p ON p.product_id = ii.product_id
                    LEFT JOIN (
                        SELECT invoice_id, SUM(amount) AS paid
                        FROM payments
                        GROUP BY invoice_id
                    ) pay ON pay.invoice_id = i.invoice_id
                    WHERE i.invoice_date BETWEEN @from AND @to
                      AND p.product_id = ANY(@product_ids)
                      AND COALESCE(pay.paid, 0) < i.total_amount
                    GROUP BY i.invoice_date::date, p.name
                    ORDER BY i.invoice_date::date, p.name;
                ", conn);

                cmd.Parameters.AddWithValue("from", dtFrom.Value.Date);
                cmd.Parameters.AddWithValue("to", dtTo.Value.Date);
                cmd.Parameters.AddWithValue("product_ids", selectedIds.ToArray());

                var adapter = new NpgsqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                // Построение диаграммы
                chart1.Series.Clear();
                chart1.ChartAreas.Clear();
                chart1.Titles.Clear();
                chart1.ChartAreas.Add(new ChartArea("Main"));

                var groupedData = new Dictionary<string, Dictionary<DateTime, decimal>>();

                // Группируем данные: по каждому товару — по датам
                foreach (DataRow row in dt.Rows) {
                    DateTime date = Convert.ToDateTime(row["date"]);
                    string product = row["product"].ToString();
                    decimal amount = Convert.ToDecimal(row["amount_due"]);

                    if (!groupedData.ContainsKey(product))
                        groupedData[product] = new Dictionary<DateTime, decimal>();

                    if (!groupedData[product].ContainsKey(date))
                        groupedData[product][date] = 0;

                    groupedData[product][date] += amount;
                }

                // Добавляем серии по каждому товару
                foreach (var product in groupedData.Keys) {
                    var series = new Series(product) {
                        ChartType = SeriesChartType.Column // Можно поменять на Line или Spline
                    };

                    foreach (var kv in groupedData[product]) {
                        series.Points.AddXY(kv.Key.ToShortDateString(), kv.Value);
                    }

                    chart1.Series.Add(series);
                }

                chart1.Titles.Add("Подлежащие оплате суммы по товарам");

            }
        }

        private void ProductPaymentReportForm_Load(object sender, EventArgs e) {
            using (var conn = new NpgsqlConnection(connString)) {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT product_id, name FROM products", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    clbProducts.Items.Add(new {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    }, true);
                }
            }
            clbProducts.DisplayMember = "Name";
        }

        private void btnExport_Click(object sender, EventArgs e) {
            if (dataGridView1.Rows.Count == 0) {
                MessageBox.Show("Нет данных для экспорта.");
                return;
            }

            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Workbooks.Add();
            Microsoft.Office.Interop.Excel._Worksheet sheet = excelApp.ActiveSheet;

            // Заголовки
            for (int i = 0; i < dataGridView1.Columns.Count; i++) {
                sheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            }

            // Данные
            for (int i = 0; i < dataGridView1.Rows.Count; i++) {
                for (int j = 0; j < dataGridView1.Columns.Count; j++) {
                    sheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                }
            }

            // Открыть Excel
            excelApp.Visible = true;
        }
    }
}
