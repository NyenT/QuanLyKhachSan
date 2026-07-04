using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhachSan.Presentation;

namespace QuanLyKhachSan
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Microsoft.Data.Sqlite 7.0 tự động khởi tạo SQLitePCLRaw batteries
            // khi dùng SQLitePCLRaw.bundle_e_sqlite3, nên không cần gọi Init() thủ công.

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += (sender, e) =>
            {
                MessageBox.Show("Đã xảy ra lỗi không mong muốn:\n" + e.Exception.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            Application.Run(new FormDangNhap());
        }
    }
}
