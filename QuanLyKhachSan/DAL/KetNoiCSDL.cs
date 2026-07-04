using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace QuanLyKhachSan.DAL
{
    /// <summary>
    /// Lớp kết nối cơ sở dữ liệu SQLite.
    /// - Tự động tạo file QuanLyKhachSan.db và toàn bộ bảng khi chạy lần đầu.
    /// - Cung cấp các hàm tiện ích LayDuLieu / ThucThiLenh / LayGiaTriDon
    ///   dùng chung cho toàn bộ DAL.
    /// </summary>
    public class KetNoiCSDL
    {
        private readonly string connectionString;
        private readonly string dbFile;

        public KetNoiCSDL()
        {
            // Ưu tiên file DB nằm cùng thư mục với exe (bin\Debug hoặc bin\Release).
            // Nếu chưa có thì lùi về thư mục gốc của project để dùng chung trong lúc dev.
            string exeDir = AppDomain.CurrentDomain.BaseDirectory;
            dbFile = Path.Combine(exeDir, "QuanLyKhachSan.db");

            // Khi chạy trong bin\Debug hoặc bin\Release, lùi 2 cấp để ghi vào thư mục project
            // (giữ dữ liệu khi build lại). Nếu không thể ghi thì dùng tại chỗ exe.
            string projectDbFile = Path.GetFullPath(Path.Combine(exeDir, "..", "..", "QuanLyKhachSan.db"));
            if (!File.Exists(dbFile) && Directory.Exists(Path.GetDirectoryName(projectDbFile)))
            {
                dbFile = projectDbFile;
            }

            connectionString = $"Data Source={dbFile};Version=3;Cache=Shared;";

            // Đảm bảo file CSDL và bảng tồn tại trước khi dùng.
            KhoiTaoCSDLNeuChuaCo();
        }

        /// <summary>Trả về đường dẫn file SQLite đang dùng (debug / thông báo lỗi).</summary>
        public string DuongDanFile => dbFile;

        private SQLiteConnection MoKetNoi()
        {
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể kết nối cơ sở dữ liệu SQLite. Kiểm tra file .db và quyền truy cập.\n" + ex.Message);
            }
            return conn;
        }

        /// <summary>Tạo file SQLite và các bảng nếu chưa tồn tại, đồng thời chèn dữ liệu mẫu.</summary>
        private void KhoiTaoCSDLNeuChuaCo()
        {
            try
            {
                // Directory.CreateDirectory trả về nguyên đối tượng nếu đã tồn tại, không sinh lỗi.
                Directory.CreateDirectory(Path.GetDirectoryName(dbFile));

                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string schema = @"
CREATE TABLE IF NOT EXISTS Phong (
    MaPhong   TEXT PRIMARY KEY,
    TenPhong  TEXT NOT NULL,
    LoaiPhong TEXT,
    Gia       REAL NOT NULL,
    TinhTrang TEXT NOT NULL DEFAULT 'Trống'
);

CREATE TABLE IF NOT EXISTS KhachHang (
    MaKH         TEXT PRIMARY KEY,
    HoTen        TEXT NOT NULL,
    CCCD         TEXT,
    SoDienThoai  TEXT,
    DiaChi       TEXT
);

CREATE TABLE IF NOT EXISTS NhanVien (
    MaNV         TEXT PRIMARY KEY,
    HoTen        TEXT NOT NULL,
    ChucVu       TEXT,
    SoDienThoai  TEXT,
    DiaChi       TEXT
);

CREATE TABLE IF NOT EXISTS TaiKhoan (
    TenDangNhap TEXT PRIMARY KEY,
    MatKhau     TEXT NOT NULL,
    VaiTro      TEXT NOT NULL,
    MaNV        TEXT
);

CREATE TABLE IF NOT EXISTS PhieuThue (
    MaPhieu      TEXT PRIMARY KEY,
    MaPhong      TEXT NOT NULL,
    MaKH         TEXT NOT NULL,
    NgayCheckIn  TEXT NOT NULL,
    NgayCheckOut TEXT NOT NULL,
    TongTien     REAL NOT NULL
);
";
                    using (SQLiteCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = schema;
                        cmd.ExecuteNonQuery();
                    }

                    // Chèn dữ liệu mẫu (chỉ khi bảng Phong còn rỗng để tránh trùng khoá).
                    using (SQLiteCommand checkCmd = conn.CreateCommand())
                    {
                        checkCmd.CommandText = "SELECT COUNT(*) FROM Phong";
                        object ketQua = checkCmd.ExecuteScalar();
                        long soPhong = (ketQua == null || ketQua == DBNull.Value) ? 0 : Convert.ToInt64(ketQua);
                        if (soPhong == 0)
                        {
                            ChenDuLieuMau(conn);
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Bỏ qua lỗi khởi tạo khi dựng DAL tạm (VD: designer mode).
                // Khi chạy thực tế, lỗi sẽ được ném lại qua MoKetNoi.
            }
        }

        /// <summary>Chèn các dòng dữ liệu mẫu cho bảng Phong, NhanVien và TaiKhoan.</summary>
        private void ChenDuLieuMau(SQLiteConnection conn)
        {
            string seed = @"
INSERT INTO Phong (MaPhong, TenPhong, LoaiPhong, Gia, TinhTrang) VALUES ('P101', 'Phòng 101', 'Standard', 300000, 'Trống');
INSERT INTO Phong (MaPhong, TenPhong, LoaiPhong, Gia, TinhTrang) VALUES ('P102', 'Phòng 102', 'Standard', 300000, 'Trống');
INSERT INTO Phong (MaPhong, TenPhong, LoaiPhong, Gia, TinhTrang) VALUES ('P201', 'Phòng 201', 'Deluxe',   500000, 'Trống');
INSERT INTO Phong (MaPhong, TenPhong, LoaiPhong, Gia, TinhTrang) VALUES ('P202', 'Phòng 202', 'Deluxe',   500000, 'Trống');
INSERT INTO Phong (MaPhong, TenPhong, LoaiPhong, Gia, TinhTrang) VALUES ('P301', 'Phòng 301', 'Suite',    900000, 'Trống');

INSERT INTO NhanVien (MaNV, HoTen, ChucVu, SoDienThoai, DiaChi) VALUES ('NV01', 'Nguyễn Văn A', 'Quản lý',   '0901234567', 'Hà Nội');
INSERT INTO NhanVien (MaNV, HoTen, ChucVu, SoDienThoai, DiaChi) VALUES ('NV02', 'Trần Thị B',  'Lễ tân',    '0902345678', 'Hà Nội');

INSERT INTO TaiKhoan (TenDangNhap, MatKhau, VaiTro, MaNV) VALUES ('admin',    '123', 'Admin',     'NV01');
INSERT INTO TaiKhoan (TenDangNhap, MatKhau, VaiTro, MaNV) VALUES ('nhanvien', '123', 'NhanVien',  'NV02');
";
            using (SQLiteCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = seed;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>Kiểm tra nhanh xem có kết nối được CSDL hay không.</summary>
        public bool KiemTraKetNoi(out string thongBaoLoi)
        {
            thongBaoLoi = string.Empty;
            try
            {
                using (SQLiteConnection conn = MoKetNoi())
                {
                    return conn.State == ConnectionState.Open;
                }
            }
            catch (Exception ex)
            {
                thongBaoLoi = ex.Message;
                return false;
            }
        }

        /// <summary>Thực thi câu lệnh SELECT, trả về DataTable.</summary>
        public DataTable LayDuLieu(string sql)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = MoKetNoi())
            using (SQLiteCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }

        /// <summary>Thực thi SELECT có tham số (an toàn hơn, chống SQL Injection).</summary>
        public DataTable LayDuLieu(string sql, params SQLiteParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = MoKetNoi())
            using (SQLiteCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }

        /// <summary>Thực thi INSERT/UPDATE/DELETE, trả về true nếu có ít nhất 1 dòng bị ảnh hưởng.</summary>
        public bool ThucThiLenh(string sql)
        {
            using (SQLiteConnection conn = MoKetNoi())
            using (SQLiteCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>Thực thi INSERT/UPDATE/DELETE có tham số (an toàn hơn, khuyến khích dùng cho code mới).</summary>
        public bool ThucThiLenh(string sql, params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection conn = MoKetNoi())
            using (SQLiteCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>Trả về giá trị đơn (VD: COUNT(*), SUM...).</summary>
        public object LayGiaTriDon(string sql, params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection conn = MoKetNoi())
            using (SQLiteCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteScalar();
            }
        }
    }
}
