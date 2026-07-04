using System;
using System.Windows.Forms;
using QuanLyKhachSan.DAL;
using QuanLyKhachSan.Entity;

namespace QuanLyKhachSan.Presentation
{
    public partial class FormDangNhap : Form
    {
        private readonly TaiKhoanDAL taiKhoanDAL = new TaiKhoanDAL();

        public FormDangNhap()
        {
            InitializeComponent();
            this.AcceptButton = btnDangNhap;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            string tk = txtUsername.Text.Trim();
            string mk = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(tk) || string.IsNullOrEmpty(mk))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnDangNhap.Enabled = false;
                TaiKhoan taiKhoan = taiKhoanDAL.DangNhap(tk, mk);

                if (taiKhoan != null)
                {
                    txtUsername.Clear();
                    txtPassword.Clear();
                    this.Hide();

                    using (FormTrangChu formTrangChu = new FormTrangChu(taiKhoan))
                    {
                        formTrangChu.ShowDialog();
                    }

                    // Sau khi đăng xuất khỏi Trang chủ, hiển thị lại màn hình đăng nhập
                    // để có thể đăng nhập tài khoản khác. Ứng dụng chỉ thực sự đóng khi
                    // người dùng đóng cửa sổ đăng nhập này.
                    this.Show();
                    txtUsername.Focus();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Đăng nhập thất bại",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi kết nối cơ sở dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnDangNhap.Enabled = true;
            }
        }
    }
}
