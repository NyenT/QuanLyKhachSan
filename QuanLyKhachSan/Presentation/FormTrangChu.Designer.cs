namespace QuanLyKhachSan.Presentation
{
    partial class FormTrangChu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelNoiDung = new System.Windows.Forms.Panel();
            this.panelPhongTrong = new System.Windows.Forms.Panel();
            this.panelDaThue = new System.Windows.Forms.Panel();
            this.panelDoanhThu = new System.Windows.Forms.Panel();
            this.panelChart = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblSoPhongTrong = new System.Windows.Forms.Label();
            this.lblSoPhongDaThue = new System.Windows.Forms.Label();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.btnMenuKhachHang = new System.Windows.Forms.Button();
            this.btnMenuPhong = new System.Windows.Forms.Button();
            this.btnMenuPhieuThue = new System.Windows.Forms.Button();
            this.btnMenuNhanVien = new System.Windows.Forms.Button();
            this.btnMenuBaoCao = new System.Windows.Forms.Button();
            this.btnMenuDangXuat = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.panelNoiDung.SuspendLayout();
            this.panelChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.panelNoiDung);
            this.panelMain.Controls.Add(this.panelMenu);
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Location = new System.Drawing.Point(20, 20);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(920, 470);
            this.panelMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(918, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Trang Chủ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(83)))), ((int)(((byte)(105)))));
            this.panelMenu.Controls.Add(this.btnMenuDangXuat);
            this.panelMenu.Controls.Add(this.btnMenuBaoCao);
            this.panelMenu.Controls.Add(this.btnMenuNhanVien);
            this.panelMenu.Controls.Add(this.btnMenuPhieuThue);
            this.panelMenu.Controls.Add(this.btnMenuPhong);
            this.panelMenu.Controls.Add(this.btnMenuKhachHang);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 40);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(180, 428);
            this.panelMenu.TabIndex = 1;
            // 
            // btnMenuKhachHang
            // 
            this.btnMenuKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuKhachHang.FlatAppearance.BorderSize = 0;
            this.btnMenuKhachHang.ForeColor = System.Drawing.Color.White;
            this.btnMenuKhachHang.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnMenuKhachHang.Location = new System.Drawing.Point(0, 0);
            this.btnMenuKhachHang.Name = "btnMenuKhachHang";
            this.btnMenuKhachHang.Size = new System.Drawing.Size(180, 50);
            this.btnMenuKhachHang.TabIndex = 0;
            this.btnMenuKhachHang.Text = "Khách hàng";
            this.btnMenuKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuKhachHang.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMenuKhachHang.UseVisualStyleBackColor = false;
            this.btnMenuKhachHang.Click += new System.EventHandler(this.btnMenuKhachHang_Click);
            // 
            // btnMenuPhong
            // 
            this.btnMenuPhong.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuPhong.FlatAppearance.BorderSize = 0;
            this.btnMenuPhong.ForeColor = System.Drawing.Color.White;
            this.btnMenuPhong.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnMenuPhong.Location = new System.Drawing.Point(0, 50);
            this.btnMenuPhong.Name = "btnMenuPhong";
            this.btnMenuPhong.Size = new System.Drawing.Size(180, 50);
            this.btnMenuPhong.TabIndex = 1;
            this.btnMenuPhong.Text = "Phòng";
            this.btnMenuPhong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuPhong.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMenuPhong.UseVisualStyleBackColor = false;
            this.btnMenuPhong.Click += new System.EventHandler(this.btnMenuPhong_Click);
            // 
            // btnMenuPhieuThue
            // 
            this.btnMenuPhieuThue.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuPhieuThue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuPhieuThue.FlatAppearance.BorderSize = 0;
            this.btnMenuPhieuThue.ForeColor = System.Drawing.Color.White;
            this.btnMenuPhieuThue.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnMenuPhieuThue.Location = new System.Drawing.Point(0, 100);
            this.btnMenuPhieuThue.Name = "btnMenuPhieuThue";
            this.btnMenuPhieuThue.Size = new System.Drawing.Size(180, 50);
            this.btnMenuPhieuThue.TabIndex = 2;
            this.btnMenuPhieuThue.Text = "Lập phiếu thuê";
            this.btnMenuPhieuThue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuPhieuThue.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMenuPhieuThue.UseVisualStyleBackColor = false;
            this.btnMenuPhieuThue.Click += new System.EventHandler(this.btnMenuPhieuThue_Click);
            // 
            // btnMenuNhanVien
            // 
            this.btnMenuNhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuNhanVien.FlatAppearance.BorderSize = 0;
            this.btnMenuNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnMenuNhanVien.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnMenuNhanVien.Location = new System.Drawing.Point(0, 150);
            this.btnMenuNhanVien.Name = "btnMenuNhanVien";
            this.btnMenuNhanVien.Size = new System.Drawing.Size(180, 50);
            this.btnMenuNhanVien.TabIndex = 3;
            this.btnMenuNhanVien.Text = "Nhân viên";
            this.btnMenuNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuNhanVien.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMenuNhanVien.UseVisualStyleBackColor = false;
            this.btnMenuNhanVien.Click += new System.EventHandler(this.btnMenuNhanVien_Click);
            // 
            // btnMenuBaoCao
            // 
            this.btnMenuBaoCao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuBaoCao.FlatAppearance.BorderSize = 0;
            this.btnMenuBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnMenuBaoCao.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnMenuBaoCao.Location = new System.Drawing.Point(0, 200);
            this.btnMenuBaoCao.Name = "btnMenuBaoCao";
            this.btnMenuBaoCao.Size = new System.Drawing.Size(180, 50);
            this.btnMenuBaoCao.TabIndex = 4;
            this.btnMenuBaoCao.Text = "Báo cáo";
            this.btnMenuBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuBaoCao.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMenuBaoCao.UseVisualStyleBackColor = false;
            this.btnMenuBaoCao.Click += new System.EventHandler(this.btnMenuBaoCao_Click);
            // 
            // btnMenuDangXuat
            // 
            this.btnMenuDangXuat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnMenuDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuDangXuat.FlatAppearance.BorderSize = 0;
            this.btnMenuDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnMenuDangXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnMenuDangXuat.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnMenuDangXuat.Location = new System.Drawing.Point(0, 378);
            this.btnMenuDangXuat.Name = "btnMenuDangXuat";
            this.btnMenuDangXuat.Size = new System.Drawing.Size(180, 50);
            this.btnMenuDangXuat.TabIndex = 5;
            this.btnMenuDangXuat.Text = "Đăng xuất";
            this.btnMenuDangXuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuDangXuat.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMenuDangXuat.UseVisualStyleBackColor = false;
            this.btnMenuDangXuat.Click += new System.EventHandler(this.btnMenuDangXuat_Click);
            // 
            // panelNoiDung
            // 
            this.panelNoiDung.Controls.Add(this.panelChart);
            this.panelNoiDung.Controls.Add(this.panelDoanhThu);
            this.panelNoiDung.Controls.Add(this.panelDaThue);
            this.panelNoiDung.Controls.Add(this.panelPhongTrong);
            this.panelNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNoiDung.Location = new System.Drawing.Point(180, 40);
            this.panelNoiDung.Name = "panelNoiDung";
            this.panelNoiDung.Size = new System.Drawing.Size(738, 428);
            this.panelNoiDung.TabIndex = 2;
            // 
            // panelPhongTrong
            // 
            this.panelPhongTrong.BackColor = System.Drawing.Color.White;
            this.panelPhongTrong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPhongTrong.Controls.Add(this.lblSoPhongTrong);
            this.panelPhongTrong.Location = new System.Drawing.Point(20, 20);
            this.panelPhongTrong.Name = "panelPhongTrong";
            this.panelPhongTrong.Size = new System.Drawing.Size(200, 80);
            this.panelPhongTrong.TabIndex = 0;
            // 
            // lblSoPhongTrong
            // 
            this.lblSoPhongTrong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoPhongTrong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSoPhongTrong.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblSoPhongTrong.Name = "lblSoPhongTrong";
            this.lblSoPhongTrong.Text = "Phòng trống\n0";
            this.lblSoPhongTrong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelDaThue
            // 
            this.panelDaThue.BackColor = System.Drawing.Color.White;
            this.panelDaThue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDaThue.Controls.Add(this.lblSoPhongDaThue);
            this.panelDaThue.Location = new System.Drawing.Point(265, 20);
            this.panelDaThue.Name = "panelDaThue";
            this.panelDaThue.Size = new System.Drawing.Size(200, 80);
            this.panelDaThue.TabIndex = 1;
            // 
            // lblSoPhongDaThue
            // 
            this.lblSoPhongDaThue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoPhongDaThue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSoPhongDaThue.ForeColor = System.Drawing.Color.IndianRed;
            this.lblSoPhongDaThue.Name = "lblSoPhongDaThue";
            this.lblSoPhongDaThue.Text = "Đang thuê\n0";
            this.lblSoPhongDaThue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelDoanhThu
            // 
            this.panelDoanhThu.BackColor = System.Drawing.Color.White;
            this.panelDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDoanhThu.Controls.Add(this.lblTongDoanhThu);
            this.panelDoanhThu.Location = new System.Drawing.Point(510, 20);
            this.panelDoanhThu.Name = "panelDoanhThu";
            this.panelDoanhThu.Size = new System.Drawing.Size(200, 80);
            this.panelDoanhThu.TabIndex = 1;
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Text = "Doanh thu hôm nay\n0 đ";
            this.lblTongDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelChart
            // 
            this.panelChart.BackColor = System.Drawing.Color.White;
            this.panelChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelChart.Controls.Add(this.chart1);
            this.panelChart.Location = new System.Drawing.Point(20, 120);
            this.panelChart.Name = "panelChart";
            this.panelChart.Size = new System.Drawing.Size(690, 280);
            this.panelChart.TabIndex = 2;
            this.panelChart.Paint += new System.Windows.Forms.PaintEventHandler(this.panelChart_Paint);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(688, 278);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // FormTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.panelMain);
            this.Name = "FormTrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang Chủ";
            this.Load += new System.EventHandler(this.FormTrangChu_Load);
            this.panelMain.ResumeLayout(false);
            this.panelNoiDung.ResumeLayout(false);
            this.panelChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelNoiDung;
        private System.Windows.Forms.Panel panelDoanhThu;
        private System.Windows.Forms.Panel panelDaThue;
        private System.Windows.Forms.Panel panelPhongTrong;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblSoPhongTrong;
        private System.Windows.Forms.Label lblSoPhongDaThue;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.Button btnMenuKhachHang;
        private System.Windows.Forms.Button btnMenuPhong;
        private System.Windows.Forms.Button btnMenuPhieuThue;
        private System.Windows.Forms.Button btnMenuNhanVien;
        private System.Windows.Forms.Button btnMenuBaoCao;
        private System.Windows.Forms.Button btnMenuDangXuat;
    }
}