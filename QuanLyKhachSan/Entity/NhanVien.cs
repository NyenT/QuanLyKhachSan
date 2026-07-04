using System;

namespace QuanLyKhachSan.Entity
{
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string ChucVu { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }

        public NhanVien() { }

        public NhanVien(string maNV, string hoTen, string chucVu, string soDienThoai, string diaChi)
        {
            MaNV = maNV;
            HoTen = hoTen;
            ChucVu = chucVu;
            SoDienThoai = soDienThoai;
            DiaChi = diaChi;
        }
    }
}