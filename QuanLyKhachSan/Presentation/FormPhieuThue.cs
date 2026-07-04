using System;
using System.Data;
using System.Windows.Forms;
using QuanLyKhachSan.DAL;
using QuanLyKhachSan.Entity;

namespace QuanLyKhachSan.Presentation
{
    public partial class FormPhieuThue : Form
    {
        private readonly PhongDAL phongDAL = new PhongDAL();
        private readonly KhachHangDAL khachHangDAL = new KhachHangDAL();
        private readonly PhieuThueDAL phieuThueDAL = new PhieuThueDAL();

        // Lưu bảng phòng trống để tra cứu đơn giá khi tính tổng tiền
        private DataTable dtPhongTrong;

        public FormPhieuThue()
        {
            InitializeComponent();
        }

        private void FormPhieuThue_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now.AddDays(1);

            TaiDanhSachPhong();
            TaiDanhSachKhachHang();
            TinhTongTien();
        }

        private void TaiDanhSachPhong()
        {
            try
            {
                dtPhongTrong = phongDAL.LayDanhSachPhongTrong();
                comboBox1.Items.Clear();

                foreach (DataRow row in dtPhongTrong.Rows)
                {
                    string hienThi = $"{row["MaPhong"]} - {row["TenPhong"]} ({Convert.ToDecimal(row["Gia"]):N0} đ/đêm)";
                    comboBox1.Items.Add(hienThi);
                }

                if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedIndex = 0;
                else
                    comboBox1.Text = "Không còn phòng trống";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phòng trống:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaiDanhSachKhachHang()
        {
            try
            {
                DataTable dt = khachHangDAL.LayDanhSachKhachHang();
                comboBox2.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    string hienThi = $"{row["MaKH"]} - {row["HoTen"]}";
                    comboBox2.Items.Add(hienThi);
                }

                if (comboBox2.Items.Count > 0)
                    comboBox2.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Lấy Mã phòng từ chuỗi hiển thị dạng "MaPhong - TenPhong (...)".</summary>
        private string LayMaTuChuoi(string chuoiHienThi)
        {
            if (string.IsNullOrWhiteSpace(chuoiHienThi)) return null;
            int viTri = chuoiHienThi.IndexOf(" - ", StringComparison.Ordinal);
            return viTri > 0 ? chuoiHienThi.Substring(0, viTri).Trim() : chuoiHienThi.Trim();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void NgayThayDoi(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        /// <summary>Tính số đêm ở, đơn giá và thành tiền, đổ lên lưới và cập nhật label tổng tiền.</summary>
        private void TinhTongTien()
        {
            dataGridView1.Rows.Clear();

            string maPhong = LayMaTuChuoi(comboBox1.Text);
            if (string.IsNullOrEmpty(maPhong) || dtPhongTrong == null)
            {
                label6.Text = "Tổng tiền: 0 đ";
                return;
            }

            DataRow[] rows = dtPhongTrong.Select($"MaPhong = '{maPhong.Replace("'", "''")}'");
            if (rows.Length == 0)
            {
                label6.Text = "Tổng tiền: 0 đ";
                return;
            }

            decimal donGia = Convert.ToDecimal(rows[0]["Gia"]);
            int soDem = (int)Math.Ceiling((dateTimePicker2.Value - dateTimePicker1.Value).TotalDays);
            if (soDem < 1) soDem = 1;

            decimal thanhTien = donGia * soDem;

            dataGridView1.Rows.Add(maPhong, soDem, donGia.ToString("N0"), thanhTien.ToString("N0"));
            label6.Text = $"Tổng tiền: {thanhTien:N0} đ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string maPhong = LayMaTuChuoi(comboBox1.Text);
            string maKH = LayMaTuChuoi(comboBox2.Text);

            if (string.IsNullOrEmpty(maPhong))
            {
                MessageBox.Show("Vui lòng chọn phòng!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(maKH))
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dateTimePicker2.Value <= dateTimePicker1.Value)
            {
                MessageBox.Show("Ngày Check-out phải sau ngày Check-in!", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRow[] rows = dtPhongTrong.Select($"MaPhong = '{maPhong.Replace("'", "''")}'");
            if (rows.Length == 0)
            {
                MessageBox.Show("Phòng đã chọn không còn trống, vui lòng chọn lại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                TaiDanhSachPhong();
                return;
            }

            decimal donGia = Convert.ToDecimal(rows[0]["Gia"]);
            int soDem = (int)Math.Ceiling((dateTimePicker2.Value - dateTimePicker1.Value).TotalDays);
            if (soDem < 1) soDem = 1;
            decimal tongTien = donGia * soDem;

            string maPhieu = "PT" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            PhieuThue phieuThue = new PhieuThue(maPhieu, maPhong, maKH, dateTimePicker1.Value, dateTimePicker2.Value, tongTien);

            try
            {
                bool okThemPhieu = phieuThueDAL.ThemPhieuThue(phieuThue);
                if (!okThemPhieu)
                {
                    MessageBox.Show("Không thể lưu phiếu thuê!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Sau khi lập phiếu, cập nhật trạng thái phòng sang "Đang thuê"
                phongDAL.CapNhatTinhTrangPhong(maPhong, "Đang thuê");

                MessageBox.Show($"Lập phiếu thuê thành công!\nMã phiếu: {maPhieu}\nTổng tiền: {tongTien:N0} đ",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lập phiếu thuê:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
