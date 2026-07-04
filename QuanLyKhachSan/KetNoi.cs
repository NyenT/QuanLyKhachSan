using System;
using System.Data;
using System.Data.OleDb;

namespace QuanLyKhachSan
{
    class KetNoi
    {
        // Thay đổi đường dẫn chỗ này cho đúng với file Access của bạn
        private static string strChuoiKetNoi = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\QuanLyKhachSan\QuanLyKhachSan.accdb";

        public static OleDbConnection GetConnection()
        {
            return new OleDbConnection(strChuoiKetNoi);
        }

        // Hàm lấy dữ liệu đổ vào DataGridView
        public static DataTable LayDuLieu(string query)
        {
            using (OleDbConnection conn = GetConnection())
            {
                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Hàm Thực thi lệnh Thêm, Sửa, Xóa
        public static int ThucThi(string query, OleDbParameter[] parameters = null)
        {
            using (OleDbConnection conn = GetConnection())
            {
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}