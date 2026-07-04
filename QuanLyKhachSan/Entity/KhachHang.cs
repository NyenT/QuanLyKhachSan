using System;

namespace QuanLyKhachSan.Entity
{
    public class KhachHang
    {
        // Tính đóng gói (Encapsulation): Các thuộc tính mô tả thực thể Khách Hàng
        public string MaKH { get; set; }
        public string HoTen { get; set; }
        public string CCCD { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }

        // Constructor không tham số
        public KhachHang() { }

        // Constructor đầy đủ tham số để khởi tạo nhanh đối tượng
        public KhachHang(string maKH, string hoTen, string cccd, string soDienThoai, string diaChi)
        {
            MaKH = maKH;
            HoTen = hoTen;
            CCCD = cccd;
            SoDienThoai = soDienThoai;
            DiaChi = diaChi;
        }
    }
}