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
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms.DataVisualization.Charting;


namespace ShopLab {
    public partial class SupplierReportForm : Form {
        private string connString = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=shop";

        public SupplierReportForm() {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e) {
            using (var conn = new NpgsqlConnection(connString)) {
                conn.Open();
                var cmd = new NpgsqlCommand(@"
                    SELECT
                        s.name AS supplier,
                        COUNT(i.invoice_id) AS invoice_count,
                        SUM(i.total_amount) AS total_invoiced,
                        COALESCE(SUM(p.paid), 0) AS total_paid,
                        SUM(i.total_amount) - COALESCE(SUM(p.paid), 0) AS total_unpaid,
                        SUM(
                            CASE
                                WHEN i.due_date < CURRENT_DATE AND (COALESCE(p.paid, 0) < i.total_amount)
                                THEN i.total_amount - COALESCE(p.paid, 0)
                                ELSE 0
                            END
                        ) AS overdue
                    FROM invoices i
                    JOIN suppliers s ON i.supplier_id = s.supplier_id
                    LEFT JOIN (
                        SELECT invoice_id, SUM(amount) AS paid
                        FROM payments
                        GROUP BY invoice_id
                    ) p ON i.invoice_id = p.invoice_id
                    WHERE i.invoice_date BETWEEN @from AND @to
                    GROUP BY s.name
                    ORDER BY s.name", conn);

                cmd.Parameters.AddWithValue("from", dtFrom.Value.Date);
                cmd.Parameters.AddWithValue("to", dtTo.Value.Date);

                var adapter = new NpgsqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                // Построение диаграммы
                chart1.Series.Clear();
                chart1.ChartAreas.Clear();
                chart1.Titles.Clear();
                chart1.ChartAreas.Add(new ChartArea("Main"));

                var seriesPaid = new Series("Оплачено") {
                    ChartType = SeriesChartType.Column
                };

                var seriesUnpaid = new Series("Не оплачено") {
                    ChartType = SeriesChartType.Column
                };

                var seriesOverdue = new Series("Просрочено") {
                    ChartType = SeriesChartType.Column
                };

                foreach (DataRow row in dt.Rows) {
                    string supplier = row["supplier"].ToString();
                    decimal paid = Convert.ToDecimal(row["total_paid"]);
                    decimal unpaid = Convert.ToDecimal(row["total_unpaid"]);
                    decimal overdue = Convert.ToDecimal(row["overdue"]);

                    seriesPaid.Points.AddXY(supplier, paid);
                    seriesUnpaid.Points.AddXY(supplier, unpaid);
                    seriesOverdue.Points.AddXY(supplier, overdue);
                }

                chart1.Series.Add(seriesPaid);
                chart1.Series.Add(seriesUnpaid);
                chart1.Series.Add(seriesOverdue);

                chart1.Titles.Add("Сравнение оплат по поставщикам");

            }


        }

        private void btnExport_Click(object sender, EventArgs e) {
            if (dataGridView1.Rows.Count == 0) return;

            var excelApp = new Excel.Application();
            excelApp.Workbooks.Add();
            Excel._Worksheet sheet = excelApp.ActiveSheet;

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

            excelApp.Visible = true;
        }
    }
}
