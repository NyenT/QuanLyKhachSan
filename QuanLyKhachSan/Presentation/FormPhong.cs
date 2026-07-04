using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using QuanLyKhachSan.DAL;
using QuanLyKhachSan.Entity;

namespace QuanLyKhachSan.Presentation
{
    public partial class FormPhong : Form
    {
        private readonly PhongDAL phongDAL = new PhongDAL();
        private string maPhongDangChon = null;

        private const string TRONG = "Trống";
        private const string DA_THUE = "Đang thuê";
        private const string DANG_DON = "Đang dọn dẹp";

        public FormPhong()
        {
            InitializeComponent();
        }

        private void FormPhong_Load(object sender, EventArgs e)
        {
            cboTinhTrang.Items.Clear();
            cboTinhTrang.Items.AddRange(new object[] { TRONG, DA_THUE, DANG_DON });
            cboTinhTrang.SelectedIndex = 0;

            TaiDuLieu();
        }

        /// <summary>Tải danh sách phòng từ CSDL và vẽ lại các thẻ phòng.</summary>
        private void TaiDuLieu()
        {
            try
            {
                DataTable dt = phongDAL.LayDanhSachPhong();
                VeThePhong(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phòng:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Vẽ mỗi phòng thành một thẻ (card) màu theo tình trạng bên trong FlowLayoutPanel.</summary>
        private void VeThePhong(DataTable dt)
        {
            flpPhong.Controls.Clear();

            foreach (DataRow row in dt.Rows)
            {
                string maPhong = row["MaPhong"].ToString();
                string tenPhong = row["TenPhong"].ToString();
                string loaiPhong = row["LoaiPhong"].ToString();
                decimal gia = Convert.ToDecimal(row["Gia"]);
                string tinhTrang = row["TinhTrang"].ToString();

                Panel the = new Panel
                {
                    Width = 130,
                    Height = 90,
                    Margin = new Padding(6),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = MauTheoTinhTrang(tinhTrang),
                    Tag = maPhong,
                    Cursor = Cursors.Hand
                };

                Label lbl = new Label
                {
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Text = $"{tenPhong}\n({loaiPhong})\n{gia:N0} đ\n{tinhTrang}",
                    ForeColor = (tinhTrang == DA_THUE) ? Color.White : Color.Black,
                    Tag = maPhong,
                    Cursor = Cursors.Hand
                };

                the.Controls.Add(lbl);
                the.Click += The_Click;
                lbl.Click += The_Click;

                flpPhong.Controls.Add(the);
            }
        }

        private Color MauTheoTinhTrang(string tinhTrang)
        {
            switch (tinhTrang)
            {
                case DA_THUE: return Color.IndianRed;
                case DANG_DON: return Color.Orange;
                default: return Color.White;
            }
        }

        private void The_Click(object sender, EventArgs e)
        {
            string maPhong = (sender as Control)?.Tag?.ToString();
            if (string.IsNullOrEmpty(maPhong)) return;
            ChonPhong(maPhong);
        }

        private void ChonPhong(string maPhong)
        {
            try
            {
                DataTable dt = phongDAL.LayDanhSachPhong();
                DataRow[] rows = dt.Select($"MaPhong = '{maPhong.Replace("'", "''")}'");
                if (rows.Length == 0) return;

                DataRow row = rows[0];
                maPhongDangChon = maPhong;
                txtMaPhong.Text = row["MaPhong"].ToString();
                txtTenPhong.Text = row["TenPhong"].ToString();
                cboLoaiPhong.Text = row["LoaiPhong"].ToString();
                txtGia.Text = row["Gia"].ToString();
                cboTinhTrang.Text = row["TinhTrang"].ToString();

                txtMaPhong.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn phòng:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool KiemTraDauVao(out Phong phong)
        {
            phong = null;
            string maPhong = txtMaPhong.Text.Trim();
            string tenPhong = txtTenPhong.Text.Trim();
            string loaiPhong = cboLoaiPhong.Text.Trim();
            string tinhTrang = cboTinhTrang.Text.Trim();

            if (string.IsNullOrEmpty(maPhong) || string.IsNullOrEmpty(tenPhong))
            {
                MessageBox.Show("Vui lòng nhập Mã phòng và Tên phòng!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtGia.Text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal gia) || gia <= 0)
            {
                MessageBox.Show("Giá phòng phải là một số dương!", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(tinhTrang)) tinhTrang = TRONG;

            phong = new Phong(maPhong, tenPhong, loaiPhong, gia, tinhTrang);
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDauVao(out Phong phong)) return;

            try
            {
                bool ok = phongDAL.ThemPhong(phong);
                if (ok)
                {
                    MessageBox.Show("Thêm phòng thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoi();
                    TaiDuLieu();
                }
                else
                {
                    MessageBox.Show("Không thể thêm phòng. Mã phòng có thể đã tồn tại.", "Thất bại",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phòng:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maPhongDangChon))
            {
                MessageBox.Show("Vui lòng chọn phòng cần sửa (bấm vào thẻ phòng)!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtMaPhong.Enabled = true;
            if (!KiemTraDauVao(out Phong phong)) return;

            try
            {
                bool ok = phongDAL.SuaPhong(phong);
                if (ok)
                {
                    MessageBox.Show("Cập nhật phòng thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoi();
                    TaiDuLieu();
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật. Phòng có thể không tồn tại.", "Thất bại",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật phòng:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maPhongDangChon))
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa (bấm vào thẻ phòng)!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa phòng '{maPhongDangChon}'?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            try
            {
                bool ok = phongDAL.XoaPhong(maPhongDangChon);
                if (ok)
                {
                    MessageBox.Show("Xóa phòng thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoi();
                    TaiDuLieu();
                }
                else
                {
                    MessageBox.Show("Không thể xóa phòng.", "Thất bại",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa phòng (có thể phòng đang có phiếu thuê liên kết):\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            maPhongDangChon = null;
            txtMaPhong.Clear();
            txtTenPhong.Clear();
            cboLoaiPhong.Text = string.Empty;
            txtGia.Clear();
            cboTinhTrang.SelectedIndex = 0;
            txtMaPhong.Enabled = true;
        }
    }
}
