using System;

namespace QuanLyKhachSan.Entity
{
    public class Phong
    {
        public string MaPhong { get; set; }
        public string TenPhong { get; set; }
        public string LoaiPhong { get; set; }
        public decimal Gia { get; set; }
        public string TinhTrang { get; set; } // "Trống", "Đang thuê", "Đang dọn dẹp"...

        public Phong() { }

        public Phong(string maPhong, string tenPhong, string loaiPhong, decimal gia, string tinhTrang)
        {
            MaPhong = maPhong;
            TenPhong = tenPhong;
            LoaiPhong = loaiPhong;
            Gia = gia;
            TinhTrang = tinhTrang;
        }
    }
}