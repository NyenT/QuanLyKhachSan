using System;
using System.Data;
using System.IO;
using Microsoft.Data.Sqlite;

namespace QuanLyKhachSan.DAL
{
    internal class KetNoiCSDL
    {
        private readonly string connectionString;

        public KetNoiCSDL()
        {
            string dbFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "QuanLyKhachSan.db");
            if (!File.Exists(dbFile))
            {
                dbFile = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "QuanLyKhachSan.db"));
            }
            connectionString = $"Data Source={dbFile};Cache=Shared";
        }

        private SqliteConnection MoKetNoi()
        {
            SqliteConnection conn = new SqliteConnection(connectionString);
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

        /// <summary>Kiểm tra nhanh xem có kết nối được CSDL hay không.</summary>
        public bool KiemTraKetNoi(out string thongBaoLoi)
        {
            thongBaoLoi = string.Empty;
            try
            {
                using (SqliteConnection conn = MoKetNoi())
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
            using (SqliteConnection conn = MoKetNoi())
            using (SqliteCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                using (SqliteDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }

        /// <summary>Thực thi SELECT có tham số (an toàn hơn, chống SQL Injection).</summary>
        public DataTable LayDuLieu(string sql, params SqliteParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqliteConnection conn = MoKetNoi())
            using (SqliteCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                using (SqliteDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }

        /// <summary>Thực thi INSERT/UPDATE/DELETE, trả về true nếu có ít nhất 1 dòng bị ảnh hưởng.</summary>
        public bool ThucThiLenh(string sql)
        {
            using (SqliteConnection conn = MoKetNoi())
            using (SqliteCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>Thực thi INSERT/UPDATE/DELETE có tham số (an toàn hơn, khuyến khích dùng cho code mới).</summary>
        public bool ThucThiLenh(string sql, params SqliteParameter[] parameters)
        {
            using (SqliteConnection conn = MoKetNoi())
            using (SqliteCommand cmd = conn.CreateCommand())
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
        public object LayGiaTriDon(string sql, params SqliteParameter[] parameters)
        {
            using (SqliteConnection conn = MoKetNoi())
            using (SqliteCommand cmd = conn.CreateCommand())
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
