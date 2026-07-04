using System;
using System.Data;
using System.Data.SQLite;
using QuanLyKhachSan.Entity;

namespace QuanLyKhachSan.DAL
{
    public class PhieuThueDAL
    {
        // Gọi lớp kết nối cơ sở dữ liệu có sẵn của dự án
        KetNoiCSDL db = new KetNoiCSDL();

        /// <summary>Lấy toàn bộ danh sách phiếu thuê để hiển thị lên Form.</summary>
        public DataTable LayDanhSachPhieuThue()
        {
            string sql = "SELECT * FROM PhieuThue ORDER BY NgayCheckIn DESC";
            return db.LayDuLieu(sql);
        }

        /// <summary>Lấy danh sách phiếu thuê trong khoảng ngày check-in (dùng cho báo cáo).</summary>
        public DataTable LayPhieuThueTrongKhoang(DateTime tuNgay, DateTime denNgay)
        {
            string sql = "SELECT * FROM PhieuThue WHERE datetime(NgayCheckIn) >= datetime(@tuNgay) AND datetime(NgayCheckIn) <= datetime(@denNgay) ORDER BY NgayCheckIn";
            return db.LayDuLieu(sql,
                new SQLiteParameter("@tuNgay", tuNgay),
                new SQLiteParameter("@denNgay", denNgay.Date.AddDays(1).AddSeconds(-1)));
        }

        /// <summary>Doanh thu + số phiếu gộp theo từng phòng trong khoảng thời gian (dùng cho FormBaoCao).</summary>
        public DataTable LayDoanhThuTheoPhong(DateTime tuNgay, DateTime denNgay)
        {
            string sql = @"SELECT MaPhong, COUNT(*) AS SoPhieu, SUM(TongTien) AS DoanhThu
                           FROM PhieuThue
                           WHERE datetime(NgayCheckIn) >= datetime(@tuNgay) AND datetime(NgayCheckIn) <= datetime(@denNgay)
                           GROUP BY MaPhong
                           ORDER BY MaPhong";
            return db.LayDuLieu(sql,
                new SQLiteParameter("@tuNgay", tuNgay),
                new SQLiteParameter("@denNgay", denNgay.Date.AddDays(1).AddSeconds(-1)));
        }

        /// <summary>Doanh thu gộp theo từng ngày check-in trong khoảng thời gian (dùng để vẽ biểu đồ).</summary>
        public DataTable LayDoanhThuTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            string sql = @"SELECT date(NgayCheckIn) AS Ngay, SUM(TongTien) AS DoanhThu
                           FROM PhieuThue
                           WHERE datetime(NgayCheckIn) >= datetime(@tuNgay) AND datetime(NgayCheckIn) <= datetime(@denNgay)
                           GROUP BY date(NgayCheckIn)
                           ORDER BY date(NgayCheckIn)";
            return db.LayDuLieu(sql,
                new SQLiteParameter("@tuNgay", tuNgay),
                new SQLiteParameter("@denNgay", denNgay.Date.AddDays(1).AddSeconds(-1)));
        }

        /// <summary>Tổng doanh thu trong khoảng thời gian (dùng cho dashboard trang chủ).</summary>
        public decimal TinhTongDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            string sql = "SELECT IFNULL(SUM(TongTien), 0) FROM PhieuThue WHERE datetime(NgayCheckIn) >= datetime(@tuNgay) AND datetime(NgayCheckIn) <= datetime(@denNgay)";
            object ketQua = db.LayGiaTriDon(sql,
                new SQLiteParameter("@tuNgay", tuNgay),
                new SQLiteParameter("@denNgay", denNgay.Date.AddDays(1).AddSeconds(-1)));
            return (ketQua == null || ketQua == DBNull.Value) ? 0 : Convert.ToDecimal(ketQua);
        }

        /// <summary>Đếm số phiếu thuê được lập trong khoảng thời gian (dùng cho dashboard trang chủ).</summary>
        public int DemPhieuTrongKhoang(DateTime tuNgay, DateTime denNgay)
        {
            string sql = "SELECT COUNT(*) FROM PhieuThue WHERE datetime(NgayCheckIn) >= datetime(@tuNgay) AND datetime(NgayCheckIn) <= datetime(@denNgay)";
            object ketQua = db.LayGiaTriDon(sql,
                new SQLiteParameter("@tuNgay", tuNgay),
                new SQLiteParameter("@denNgay", denNgay.Date.AddDays(1).AddSeconds(-1)));
            return (ketQua == null || ketQua == DBNull.Value) ? 0 : Convert.ToInt32(ketQua);
        }

        /// <summary>Thêm một phiếu thuê mới (tham số hoá đầy đủ, chống SQL Injection).</summary>
        public bool ThemPhieuThue(PhieuThue pt)
        {
            string sql = "INSERT INTO PhieuThue (MaPhieu, MaPhong, MaKH, NgayCheckIn, NgayCheckOut, TongTien) " +
                         "VALUES (@MaPhieu, @MaPhong, @MaKH, @NgayCheckIn, @NgayCheckOut, @TongTien)";
            return db.ThucThiLenh(sql,
                new SQLiteParameter("@MaPhieu", pt.MaPhieu),
                new SQLiteParameter("@MaPhong", pt.MaPhong),
                new SQLiteParameter("@MaKH", pt.MaKH),
                new SQLiteParameter("@NgayCheckIn", pt.NgayCheckIn),
                new SQLiteParameter("@NgayCheckOut", pt.NgayCheckOut),
                new SQLiteParameter("@TongTien", pt.TongTien));
        }

        /// <summary>Cập nhật thông tin một phiếu thuê đã có.</summary>
        public bool SuaPhieuThue(PhieuThue pt)
        {
            string sql = "UPDATE PhieuThue SET MaPhong=@MaPhong, MaKH=@MaKH, NgayCheckIn=@NgayCheckIn, " +
                         "NgayCheckOut=@NgayCheckOut, TongTien=@TongTien WHERE MaPhieu=@MaPhieu";
            return db.ThucThiLenh(sql,
                new SQLiteParameter("@MaPhieu", pt.MaPhieu),
                new SQLiteParameter("@MaPhong", pt.MaPhong),
                new SQLiteParameter("@MaKH", pt.MaKH),
                new SQLiteParameter("@NgayCheckIn", pt.NgayCheckIn),
                new SQLiteParameter("@NgayCheckOut", pt.NgayCheckOut),
                new SQLiteParameter("@TongTien", pt.TongTien));
        }

        /// <summary>Xoá một phiếu thuê theo mã phiếu.</summary>
        public bool XoaPhieuThue(string maPhieu)
        {
            string sql = "DELETE FROM PhieuThue WHERE MaPhieu=@MaPhieu";
            return db.ThucThiLenh(sql, new SQLiteParameter("@MaPhieu", maPhieu));
        }
    }
}

