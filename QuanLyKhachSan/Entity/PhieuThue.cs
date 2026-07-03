using System;

namespace QuanLyKhachSan.Entity
{
    public class PhieuThue
    {
        // Tính đóng gói (Encapsulation): Các thuộc tính mô tả thực thể Phiếu Thuê
        public string MaPhieu { get; set; }
        public string MaPhong { get; set; }
        public string MaKH { get; set; }
        public DateTime NgayCheckIn { get; set; }
        public DateTime NgayCheckOut { get; set; }
        public decimal TongTien { get; set; }

        // Constructor không tham số
        public PhieuThue() { }

        // Constructor đầy đủ tham số để khởi tạo nhanh đối tượng
        public PhieuThue(string maPhieu, string maPhong, string maKH, DateTime checkIn, DateTime checkOut, decimal tongTien)
        {
            MaPhieu = maPhieu;
            MaPhong = maPhong;
            MaKH = maKH;
            NgayCheckIn = checkIn;
            NgayCheckOut = checkOut;
            TongTien = tongTien;
        }
    }
}