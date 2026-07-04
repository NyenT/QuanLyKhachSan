using System;

namespace QuanLyKhachSan.Entity
{
    public class TaiKhoan
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; } // "Admin", "NhanVien"...
        public string MaNV { get; set; }   // Liên kết tới NhanVien (nếu có)

        public TaiKhoan() { }

        public TaiKhoan(string tenDangNhap, string matKhau, string vaiTro, string maNV)
        {
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            VaiTro = vaiTro;
            MaNV = maNV;
        }
    }
}