using System.Data;
using Microsoft.Data.Sqlite;
using QuanLyKhachSan.Entity;

namespace QuanLyKhachSan.DAL
{
    public class KhachHangDAL
    {
        KetNoiCSDL db = new KetNoiCSDL();

        public DataTable LayDanhSachKhachHang()
        {
            string sql = "SELECT * FROM KhachHang";
            return db.LayDuLieu(sql);
        }

        public DataTable TimKiemKhachHang(string tuKhoa)
        {
            string sql = "SELECT * FROM KhachHang WHERE HoTen LIKE @tuKhoa OR CCCD LIKE @tuKhoa OR SoDienThoai LIKE @tuKhoa";
            return db.LayDuLieu(sql, new SqliteParameter("@tuKhoa", "%" + tuKhoa + "%"));
        }

        public bool ThemKhachHang(KhachHang kh)
        {
            string sql = "INSERT INTO KhachHang (MaKH, HoTen, CCCD, SoDienThoai, DiaChi) " +
                         "VALUES (@MaKH, @HoTen, @CCCD, @SoDienThoai, @DiaChi)";
            return db.ThucThiLenh(sql,
                new SqliteParameter("@MaKH", kh.MaKH),
                new SqliteParameter("@HoTen", kh.HoTen),
                new SqliteParameter("@CCCD", kh.CCCD),
                new SqliteParameter("@SoDienThoai", kh.SoDienThoai),
                new SqliteParameter("@DiaChi", kh.DiaChi));
        }

        public bool SuaKhachHang(KhachHang kh)
        {
            string sql = "UPDATE KhachHang SET HoTen=@HoTen, CCCD=@CCCD, SoDienThoai=@SoDienThoai, DiaChi=@DiaChi " +
                         "WHERE MaKH=@MaKH";
            return db.ThucThiLenh(sql,
                new SqliteParameter("@MaKH", kh.MaKH),
                new SqliteParameter("@HoTen", kh.HoTen),
                new SqliteParameter("@CCCD", kh.CCCD),
                new SqliteParameter("@SoDienThoai", kh.SoDienThoai),
                new SqliteParameter("@DiaChi", kh.DiaChi));
        }

        public bool XoaKhachHang(string maKH)
        {
            string sql = "DELETE FROM KhachHang WHERE MaKH=@MaKH";
            return db.ThucThiLenh(sql, new SqliteParameter("@MaKH", maKH));
        }
    }
}

