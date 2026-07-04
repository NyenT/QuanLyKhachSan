using System.Data;
using System.Data.SQLite;
using QuanLyKhachSan.Entity;

namespace QuanLyKhachSan.DAL
{
    public class PhongDAL
    {
        KetNoiCSDL db = new KetNoiCSDL();

        public DataTable LayDanhSachPhong()
        {
            string sql = "SELECT * FROM Phong";
            return db.LayDuLieu(sql);
        }

        public DataTable LayDanhSachPhongTrong()
        {
            string sql = "SELECT * FROM Phong WHERE TinhTrang = 'Trống'";
            return db.LayDuLieu(sql);
        }

        public bool ThemPhong(Phong p)
        {
            string sql = "INSERT INTO Phong (MaPhong, TenPhong, LoaiPhong, Gia, TinhTrang) " +
                         "VALUES (@MaPhong, @TenPhong, @LoaiPhong, @Gia, @TinhTrang)";
            return db.ThucThiLenh(sql,
                new SQLiteParameter("@MaPhong", p.MaPhong),
                new SQLiteParameter("@TenPhong", p.TenPhong),
                new SQLiteParameter("@LoaiPhong", p.LoaiPhong),
                new SQLiteParameter("@Gia", p.Gia),
                new SQLiteParameter("@TinhTrang", p.TinhTrang));
        }

        public bool SuaPhong(Phong p)
        {
            string sql = "UPDATE Phong SET TenPhong=@TenPhong, LoaiPhong=@LoaiPhong, Gia=@Gia, TinhTrang=@TinhTrang " +
                         "WHERE MaPhong=@MaPhong";
            return db.ThucThiLenh(sql,
                new SQLiteParameter("@MaPhong", p.MaPhong),
                new SQLiteParameter("@TenPhong", p.TenPhong),
                new SQLiteParameter("@LoaiPhong", p.LoaiPhong),
                new SQLiteParameter("@Gia", p.Gia),
                new SQLiteParameter("@TinhTrang", p.TinhTrang));
        }

        public bool CapNhatTinhTrangPhong(string maPhong, string tinhTrang)
        {
            string sql = "UPDATE Phong SET TinhTrang=@TinhTrang WHERE MaPhong=@MaPhong";
            return db.ThucThiLenh(sql,
                new SQLiteParameter("@TinhTrang", tinhTrang),
                new SQLiteParameter("@MaPhong", maPhong));
        }

        public bool XoaPhong(string maPhong)
        {
            string sql = "DELETE FROM Phong WHERE MaPhong=@MaPhong";
            return db.ThucThiLenh(sql, new SQLiteParameter("@MaPhong", maPhong));
        }
    }
}

