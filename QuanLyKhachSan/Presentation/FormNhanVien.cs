using System;
using System.Data;
using System.Windows.Forms;
using QuanLyKhachSan.DAL;
using QuanLyKhachSan.Entity;

namespace QuanLyKhachSan.Presentation
{
    public partial class FormNhanVien : Form
    {
        private readonly NhanVienDAL nhanVienDAL = new NhanVienDAL();
        private DataTable dtNhanVien;

        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            TaiDuLieu();
        }

        /// <summary>Tải (hoặc tải lại) toàn bộ danh sách nhân viên lên lưới.</summary>
        private void TaiDuLieu()
        {
            try
            {
                dtNhanVien = nhanVienDAL.LayDanhSachNhanVien();
                dgvNhanVien.DataSource = dtNhanVien;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string tuKhoa = txtTimKiem.Text.Trim();
                if (string.IsNullOrEmpty(tuKhoa))
                {
                    TaiDuLieu();
                    return;
                }

                // Lọc trực tiếp trên DataTable đã tải để tránh phụ thuộc thêm hàm DAL
                if (dtNhanVien == null) return;
                DataView dv = dtNhanVien.DefaultView;
                dv.RowFilter = $"HoTen LIKE '%{tuKhoa.Replace("'", "''")}%' OR MaNV LIKE '%{tuKhoa.Replace("'", "''")}%' OR ChucVu LIKE '%{tuKhoa.Replace("'", "''")}%' OR SoDienThoai LIKE '%{tuKhoa.Replace("'", "''")}%'";
                dgvNhanVien.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
            txtMaNV.Text = row.Cells["MaNV"].Value?.ToString() ?? string.Empty;
            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? string.Empty;
            txtChucVu.Text = row.Cells["ChucVu"].Value?.ToString() ?? string.Empty;
            txtSDT.Text = row.Cells["SoDienThoaiCol"].Value?.ToString() ?? string.Empty;
            txtDiaChi.Text = row.Cells["DiaChiCol"].Value?.ToString() ?? string.Empty;

            // Không cho phép đổi Mã NV khi đang sửa (khóa chính)
            txtMaNV.Enabled = false;
        }

        /// <summary>Kiểm tra dữ liệu nhập trước khi Thêm/Sửa. Trả về false nếu không hợp lệ.</summary>
        private bool KiemTraDauVao(out NhanVien nv)
        {
            nv = null;
            string maNV = txtMaNV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string chucVu = txtChucVu.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();

            if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập Mã NV và Họ tên!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!string.IsNullOrEmpty(sdt) && !System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^[0-9]{9,11}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ (chỉ gồm 9-11 chữ số)!", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            nv = new NhanVien(maNV, hoTen, chucVu, sdt, diaChi);
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDauVao(out NhanVien nv)) return;

            try
            {
                bool ok = nhanVienDAL.ThemNhanVien(nv);
                if (ok)
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoi();
                    TaiDuLieu();
                }
                else
                {
                    MessageBox.Show("Không thể thêm nhân viên. Vui lòng kiểm tra lại Mã NV (có thể đã tồn tại).",
                        "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null || dgvNhanVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa trong danh sách!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Khi sửa, tạm bật lại để KiemTraDauVao đọc được giá trị, nhưng vẫn dùng đúng MaNV đã chọn
            txtMaNV.Enabled = true;
            if (!KiemTraDauVao(out NhanVien nv)) return;

            try
            {
                bool ok = nhanVienDAL.SuaNhanVien(nv);
                if (ok)
                {
                    MessageBox.Show("Cập nhật nhân viên thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoi();
                    TaiDuLieu();
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật. Nhân viên có thể không tồn tại.", "Thất bại",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật nhân viên:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null || dgvNhanVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa trong danh sách!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNV = dgvNhanVien.SelectedRows[0].Cells["MaNV"].Value?.ToString();
            if (string.IsNullOrEmpty(maNV)) return;

            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên '{maNV}'?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            try
            {
                bool ok = nhanVienDAL.XoaNhanVien(maNV);
                if (ok)
                {
                    MessageBox.Show("Xóa nhân viên thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoi();
                    TaiDuLieu();
                }
                else
                {
                    MessageBox.Show("Không thể xóa nhân viên (có thể đang liên kết với tài khoản).", "Thất bại",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhân viên:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtChucVu.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtMaNV.Enabled = true;
            dgvNhanVien.ClearSelection();
        }
    }
}
