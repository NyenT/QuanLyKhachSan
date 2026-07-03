using System.Data;
using QuanLyKhachSan.Entity;

namespace QuanLyKhachSan.DAL
{
    public class PhieuThueDAL
    {
        // Gọi lớp kết nối cơ sở dữ liệu có sẵn của dự án
        KetNoiCSDL db = new KetNoiCSDL();

        // Phương thức lấy danh sách phiếu thuê để hiển thị lên Form
        public DataTable LayDanhSachPhieuThue()
        {
            string sql = "SELECT * FROM PhieuThue";
            return db.LayDuLieu(sql);
        }

        // Phương thức lưu một đối tượng PhieuThue vào Database
        public bool ThemPhieuThue(PhieuThue pt)
        {
            string sql = $"INSERT INTO PhieuThue (MaPhieu, MaPhong, MaKH, NgayCheckIn, NgayCheckOut, TongTien) " +
                         $"VALUES ('{pt.MaPhieu}', '{pt.MaPhong}', '{pt.MaKH}', '{pt.NgayCheckIn:yyyy-MM-dd}', '{pt.NgayCheckOut:yyyy-MM-dd}', {pt.TongTien})";
            return db.ThucThiLenh(sql);
        }
    }
}