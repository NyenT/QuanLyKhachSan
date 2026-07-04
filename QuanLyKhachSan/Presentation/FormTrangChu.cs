using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QuanLyKhachSan.DAL;
using QuanLyKhachSan.Entity;

namespace QuanLyKhachSan.Presentation
{
    public partial class FormTrangChu : Form
    {
        private readonly PhongDAL phongDAL = new PhongDAL();
        private readonly PhieuThueDAL phieuThueDAL = new PhieuThueDAL();
        private readonly TaiKhoan taiKhoanDangNhap;

        public FormTrangChu() : this(null)
        {
        }

        public FormTrangChu(TaiKhoan taiKhoan)
        {
            InitializeComponent();
            taiKhoanDangNhap = taiKhoan;
        }

        private void FormTrangChu_Load(object sender, EventArgs e)
        {
            if (taiKhoanDangNhap != null)
            {
                lblTitle.Text = $"Trang Chủ - Xin chào, {taiKhoanDangNhap.TenDangNhap} ({taiKhoanDangNhap.VaiTro})";
            }

            TaiDuLieuDashboard();
        }

        /// <summary>Nạp lại số liệu tổng quan (phòng trống/đang thuê, doanh thu hôm nay, biểu đồ 7 ngày gần nhất).</summary>
        private void TaiDuLieuDashboard()
        {
            try
            {
                DataTable dtPhong = phongDAL.LayDanhSachPhong();
                int soPhongTrong = 0;
                int soPhongDaThue = 0;

                foreach (DataRow row in dtPhong.Rows)
                {
                    string tinhTrang = row["TinhTrang"].ToString();
                    if (tinhTrang == "Trống") soPhongTrong++;
                    else if (tinhTrang == "Đang thuê") soPhongDaThue++;
                }

                lblSoPhongTrong.Text = $"Phòng trống\n{soPhongTrong}";
                lblSoPhongDaThue.Text = $"Đang thuê\n{soPhongDaThue}";

                DateTime homNay = DateTime.Now.Date;
                decimal doanhThuHomNay = phieuThueDAL.TinhTongDoanhThu(homNay, homNay);
                lblTongDoanhThu.Text = $"Doanh thu hôm nay\n{doanhThuHomNay:N0} đ";

                VeBieuDo7NgayGanNhat();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu tổng quan:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VeBieuDo7NgayGanNhat()
        {
            DateTime tuNgay = DateTime.Now.Date.AddDays(-6);
            DateTime denNgay = DateTime.Now.Date;

            DataTable dtTheoNgay = phieuThueDAL.LayDoanhThuTheoNgay(tuNgay, denNgay);

            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Titles.Add("Doanh thu 7 ngày gần nhất");

            Series series = new Series("Doanh thu")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,
                IsValueShownAsLabel = false
            };

            for (DateTime ngay = tuNgay; ngay <= denNgay; ngay = ngay.AddDays(1))
            {
                DataRow[] rows = dtTheoNgay.Select($"Ngay = #{ngay:MM/dd/yyyy}#");
                decimal doanhThu = rows.Length > 0 ? Convert.ToDecimal(rows[0]["DoanhThu"]) : 0;
                series.Points.AddXY(ngay.ToString("dd/MM"), doanhThu);
            }

            chart1.Series.Add(series);
        }

        private void btnMenuKhachHang_Click(object sender, EventArgs e)
        {
            using (FormKhachHang form = new FormKhachHang())
            {
                form.ShowDialog();
            }
            TaiDuLieuDashboard();
        }

        private void btnMenuPhong_Click(object sender, EventArgs e)
        {
            using (FormPhong form = new FormPhong())
            {
                form.ShowDialog();
            }
            TaiDuLieuDashboard();
        }

        private void btnMenuPhieuThue_Click(object sender, EventArgs e)
        {
            using (FormPhieuThue form = new FormPhieuThue())
            {
                form.ShowDialog();
            }
            TaiDuLieuDashboard();
        }

        private void btnMenuNhanVien_Click(object sender, EventArgs e)
        {
            using (FormNhanVien form = new FormNhanVien())
            {
                form.ShowDialog();
            }
        }

        private void btnMenuBaoCao_Click(object sender, EventArgs e)
        {
            using (FormBaoCao form = new FormBaoCao())
            {
                form.ShowDialog();
            }
        }

        private void btnMenuDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {
        }

        private void panelChart_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
