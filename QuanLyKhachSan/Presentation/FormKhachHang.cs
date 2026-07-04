using System;
using System.Data;
using System.Windows.Forms;
using QuanLyKhachSan.DAL;
using QuanLyKhachSan.Entity;

namespace QuanLyKhachSan.Presentation
{
    public partial class FormKhachHang : Form
    {
        private readonly KhachHangDAL khachHangDAL = new KhachHangDAL();
        private DataTable dtKhachHang;

        public FormKhachHang()
        {
            InitializeComponent();
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            TaiDuLieu();
        }

        /// <summary>Tải (hoặc tải lại) toàn bộ danh sách khách hàng lên lưới.</summary>
        private void TaiDuLieu()
        {
            try
            {
                dtKhachHang = khachHangDAL.LayDanhSachKhachHang();
                dgvKhachHang.DataSource = dtKhachHang;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string tuKhoa = txtTimKiem.Text.Trim();
                dgvKhachHang.DataSource = string.IsNullOrEmpty(tuKhoa)
                    ? khachHangDAL.LayDanhSachKhachHang()
                    : khachHangDAL.TimKiemKhachHang(tuKhoa);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
            txtMaKH.Text = row.Cells["MaKH"].Value?.ToString() ?? string.Empty;
            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? string.Empty;
            txtCCCD.Text = row.Cells["CCCD"].Value?.ToString() ?? string.Empty;
            txtSDT.Text = row.Cells["SDT"].Value?.ToString() ?? string.Empty;
            txtDiaChi.Text = row.Cells["DiaChiCol"].Value?.ToString() ?? string.Empty;

            // Không cho phép đổi Mã KH khi đang sửa (khóa chính)
            txtMaKH.Enabled = false;
        }

        /// <summary>Kiểm tra dữ liệu nhập trước khi Thêm/Sửa. Trả về false nếu không hợp lệ.</summary>
        private bool KiemTraDauVao(out KhachHang kh)
        {
            kh = null;
            string maKH = txtMaKH.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string cccd = txtCCCD.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();

            if (string.IsNullOrEmpty(maKH) || string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập Mã KH và Họ tên!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!string.IsNullOrEmpty(sdt) && !System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^[0-9]{9,11}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ (chỉ gồm 9-11 chữ số)!", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            kh = new KhachHang(maKH, hoTen, cccd, sdt, diaChi);
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDauVao(out KhachHang kh)) return;

            try
            {
                bool ok = khachHangDAL.ThemKhachHang(kh);
                if (ok)
                {
                    MessageBox.Show("Thêm khách hàng thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoi();
                    TaiDuLieu();
                }
                else
                {
                    MessageBox.Show("Không thể thêm khách hàng. Vui lòng kiểm tra lại Mã KH (có thể đã tồn tại).",
                        "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null || dgvKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa trong danh sách!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Khi sửa, tạm bật lại để KiemTraDauVao đọc được giá trị, nhưng vẫn dùng đúng MaKH đã chọn
            txtMaKH.Enabled = true;
            if (!KiemTraDauVao(out KhachHang kh)) return;

            try
            {
                bool ok = khachHangDAL.SuaKhachHang(kh);
                if (ok)
                {
                    MessageBox.Show("Cập nhật khách hàng thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoi();
                    TaiDuLieu();
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật. Khách hàng có thể không tồn tại.", "Thất bại",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật khách hàng:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null || dgvKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa trong danh sách!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maKH = dgvKhachHang.SelectedRows[0].Cells["MaKH"].Value?.ToString();
            if (string.IsNullOrEmpty(maKH)) return;

            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng '{maKH}'?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            try
            {
                bool ok = khachHangDAL.XoaKhachHang(maKH);
                if (ok)
                {
                    MessageBox.Show("Xóa khách hàng thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoi();
                    TaiDuLieu();
                }
                else
                {
                    MessageBox.Show("Không thể xóa khách hàng.", "Thất bại",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa khách hàng (có thể khách hàng đang có phiếu thuê liên kết):\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            txtMaKH.Clear();
            txtHoTen.Clear();
            txtCCCD.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtMaKH.Enabled = true;
            dgvKhachHang.ClearSelection();
        }
    }
}
