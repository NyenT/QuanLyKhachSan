using System.Data;
using Microsoft.Data.Sqlite;
using QuanLyKhachSan.Entity;

namespace QuanLyKhachSan.DAL
{
    public class TaiKhoanDAL
    {
        KetNoiCSDL db = new KetNoiCSDL();

        /// <summary>
        /// Kiểm tra đăng nhập. Trả về đối tượng TaiKhoan nếu đúng, null nếu sai tài khoản/mật khẩu.
        /// Dùng cho nút "Start"/"Đăng nhập" ở Form đăng nhập.
        /// </summary>
        public TaiKhoan DangNhap(string tenDangNhap, string matKhau)
        {
            string sql = "SELECT * FROM TaiKhoan WHERE TenDangNhap=@TenDangNhap AND MatKhau=@MatKhau";
            DataTable dt = db.LayDuLieu(sql,
                new SqliteParameter("@TenDangNhap", tenDangNhap),
                new SqliteParameter("@MatKhau", matKhau));

            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            return new TaiKhoan(
                row["TenDangNhap"].ToString(),
                row["MatKhau"].ToString(),
                row["VaiTro"].ToString(),
                row["MaNV"].ToString());
        }

        public DataTable LayDanhSachTaiKhoan()
        {
            string sql = "SELECT * FROM TaiKhoan";
            return db.LayDuLieu(sql);
        }

        public bool ThemTaiKhoan(TaiKhoan tk)
        {
            string sql = "INSERT INTO TaiKhoan (TenDangNhap, MatKhau, VaiTro, MaNV) " +
                         "VALUES (@TenDangNhap, @MatKhau, @VaiTro, @MaNV)";
            return db.ThucThiLenh(sql,
                new SqliteParameter("@TenDangNhap", tk.TenDangNhap),
                new SqliteParameter("@MatKhau", tk.MatKhau),
                new SqliteParameter("@VaiTro", tk.VaiTro),
                new SqliteParameter("@MaNV", tk.MaNV));
        }

        public bool DoiMatKhau(string tenDangNhap, string matKhauMoi)
        {
            string sql = "UPDATE TaiKhoan SET MatKhau=@MatKhau WHERE TenDangNhap=@TenDangNhap";
            return db.ThucThiLenh(sql,
                new SqliteParameter("@MatKhau", matKhauMoi),
                new SqliteParameter("@TenDangNhap", tenDangNhap));
        }

        public bool XoaTaiKhoan(string tenDangNhap)
        {
            string sql = "DELETE FROM TaiKhoan WHERE TenDangNhap=@TenDangNhap";
            return db.ThucThiLenh(sql, new SqliteParameter("@TenDangNhap", tenDangNhap));
        }
    }
}

