using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QuanLyKhachSan.DAL;

namespace QuanLyKhachSan.Presentation
{
    public partial class FormBaoCao : Form
    {
        private readonly PhieuThueDAL phieuThueDAL = new PhieuThueDAL();
        private DataTable dtBaoCaoTheoPhong;

        public FormBaoCao()
        {
            InitializeComponent();
        }

        private void FormBaoCao_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateTimePicker2.Value = DateTime.Now;
            XemBaoCao();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XemBaoCao();
        }

        private void XemBaoCao()
        {
            DateTime tuNgay = dateTimePicker1.Value.Date;
            DateTime denNgay = dateTimePicker2.Value.Date;

            if (denNgay < tuNgay)
            {
                MessageBox.Show("'Đến ngày' phải lớn hơn hoặc bằng 'Từ ngày'!", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1) Bảng doanh thu theo phòng
                dtBaoCaoTheoPhong = phieuThueDAL.LayDoanhThuTheoPhong(tuNgay, denNgay);
                dataGridView1.Rows.Clear();
                decimal tongDoanhThu = 0;
                int tongSoPhieu = 0;

                foreach (DataRow row in dtBaoCaoTheoPhong.Rows)
                {
                    string maPhong = row["MaPhong"].ToString();
                    int soPhieu = Convert.ToInt32(row["SoPhieu"]);
                    decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);

                    dataGridView1.Rows.Add(maPhong, soPhieu, doanhThu.ToString("N0") + " đ");
                    tongDoanhThu += doanhThu;
                    tongSoPhieu += soPhieu;
                }

                // 2) Biểu đồ doanh thu theo ngày
                DataTable dtTheoNgay = phieuThueDAL.LayDoanhThuTheoNgay(tuNgay, denNgay);
                VeBieuDo(dtTheoNgay);

                this.Text = $"Báo cáo doanh thu - Tổng: {tongDoanhThu:N0} đ ({tongSoPhieu} phiếu)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VeBieuDo(DataTable dtTheoNgay)
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Titles.Add("Doanh thu theo ngày");

            Series series = new Series("Doanh thu")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            foreach (DataRow row in dtTheoNgay.Rows)
            {
                DateTime ngay = Convert.ToDateTime(row["Ngay"]);
                decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);
                series.Points.AddXY(ngay.ToString("dd/MM"), doanhThu);
            }

            chart1.Series.Add(series);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dtBaoCaoTheoPhong == null || dtBaoCaoTheoPhong.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu báo cáo để xuất. Vui lòng bấm 'Xem báo cáo' trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Tệp CSV (*.csv)|*.csv",
                FileName = $"BaoCaoDoanhThu_{DateTime.Now:yyyyMMddHHmmss}.csv"
            })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Phòng,Số phiếu,Doanh thu");

                    foreach (DataRow row in dtBaoCaoTheoPhong.Rows)
                    {
                        sb.AppendLine($"{row["MaPhong"]},{row["SoPhieu"]},{row["DoanhThu"]}");
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Xuất báo cáo thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất báo cáo:\n" + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
