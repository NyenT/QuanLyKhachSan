using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKhachSan.DAL
{
    internal class KetNoiCSDL
    {
        // TODO: Sửa lại chuỗi kết nối cho đúng với SQL Server trên máy bạn
        // - Nếu dùng SQL Server Express: Data Source=.\SQLEXPRESS
        // - Nếu dùng SQL Server Authentication thay vì Windows Authentication:
        //   "Data Source=.;Initial Catalog=QuanLyKhachSan;User ID=sa;Password=your_password"
        private readonly string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True;TrustServerCertificate=True";

        private SqlConnection MoKetNoi()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể kết nối cơ sở dữ liệu. Kiểm tra lại SQL Server và chuỗi kết nối.\n" + ex.Message);
            }
            return conn;
        }

        /// <summary>Kiểm tra nhanh xem có kết nối được CSDL hay không (dùng khi nhấn Start).</summary>
        public bool KiemTraKetNoi(out string thongBaoLoi)
        {
            thongBaoLoi = string.Empty;
            try
            {
                using (SqlConnection conn = MoKetNoi())
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
            using (SqlConnection conn = MoKetNoi())
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
            }
            return dt;
        }

        /// <summary>Thực thi SELECT có tham số (an toàn hơn, chống SQL Injection).</summary>
        public DataTable LayDuLieu(string sql, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = MoKetNoi())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        /// <summary>Thực thi INSERT/UPDATE/DELETE, trả về true nếu có ít nhất 1 dòng bị ảnh hưởng.</summary>
        public bool ThucThiLenh(string sql)
        {
            using (SqlConnection conn = MoKetNoi())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>Thực thi INSERT/UPDATE/DELETE có tham số (an toàn hơn, khuyến khích dùng cho code mới).</summary>
        public bool ThucThiLenh(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = MoKetNoi())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>Trả về giá trị đơn (VD: COUNT(*), SUM...).</summary>
        public object LayGiaTriDon(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = MoKetNoi())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
        }
    }
}