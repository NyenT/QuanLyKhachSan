using System.Data;
using Microsoft.Data.Sqlite;
using QuanLyKhachSan.Entity;

namespace QuanLyKhachSan.DAL
{
    public class NhanVienDAL
    {
        KetNoiCSDL db = new KetNoiCSDL();

        public DataTable LayDanhSachNhanVien()
        {
            string sql = "SELECT * FROM NhanVien";
            return db.LayDuLieu(sql);
        }

        public bool ThemNhanVien(NhanVien nv)
        {
            string sql = "INSERT INTO NhanVien (MaNV, HoTen, ChucVu, SoDienThoai, DiaChi) " +
                         "VALUES (@MaNV, @HoTen, @ChucVu, @SoDienThoai, @DiaChi)";
            return db.ThucThiLenh(sql,
                new SqliteParameter("@MaNV", nv.MaNV),
                new SqliteParameter("@HoTen", nv.HoTen),
                new SqliteParameter("@ChucVu", nv.ChucVu),
                new SqliteParameter("@SoDienThoai", nv.SoDienThoai),
                new SqliteParameter("@DiaChi", nv.DiaChi));
        }

        public bool SuaNhanVien(NhanVien nv)
        {
            string sql = "UPDATE NhanVien SET HoTen=@HoTen, ChucVu=@ChucVu, SoDienThoai=@SoDienThoai, DiaChi=@DiaChi " +
                         "WHERE MaNV=@MaNV";
            return db.ThucThiLenh(sql,
                new SqliteParameter("@MaNV", nv.MaNV),
                new SqliteParameter("@HoTen", nv.HoTen),
                new SqliteParameter("@ChucVu", nv.ChucVu),
                new SqliteParameter("@SoDienThoai", nv.SoDienThoai),
                new SqliteParameter("@DiaChi", nv.DiaChi));
        }

        public bool XoaNhanVien(string maNV)
        {
            string sql = "DELETE FROM NhanVien WHERE MaNV=@MaNV";
            return db.ThucThiLenh(sql, new SqliteParameter("@MaNV", maNV));
        }
    }
}

