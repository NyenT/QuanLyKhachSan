using System.Data;
using System.Data.SqlClient;
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
                new SqlParameter("@MaNV", nv.MaNV),
                new SqlParameter("@HoTen", nv.HoTen),
                new SqlParameter("@ChucVu", nv.ChucVu),
                new SqlParameter("@SoDienThoai", nv.SoDienThoai),
                new SqlParameter("@DiaChi", nv.DiaChi));
        }

        public bool SuaNhanVien(NhanVien nv)
        {
            string sql = "UPDATE NhanVien SET HoTen=@HoTen, ChucVu=@ChucVu, SoDienThoai=@SoDienThoai, DiaChi=@DiaChi " +
                         "WHERE MaNV=@MaNV";
            return db.ThucThiLenh(sql,
                new SqlParameter("@MaNV", nv.MaNV),
                new SqlParameter("@HoTen", nv.HoTen),
                new SqlParameter("@ChucVu", nv.ChucVu),
                new SqlParameter("@SoDienThoai", nv.SoDienThoai),
                new SqlParameter("@DiaChi", nv.DiaChi));
        }

        public bool XoaNhanVien(string maNV)
        {
            string sql = "DELETE FROM NhanVien WHERE MaNV=@MaNV";
            return db.ThucThiLenh(sql, new SqlParameter("@MaNV", maNV));
        }
    }
}