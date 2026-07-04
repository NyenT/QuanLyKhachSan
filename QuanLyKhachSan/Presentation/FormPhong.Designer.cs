namespace QuanLyKhachSan.Presentation
{
    partial class FormPhong
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.cboTinhTrang = new System.Windows.Forms.ComboBox();
            this.lblTinhTrangInput = new System.Windows.Forms.Label();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.lblGia = new System.Windows.Forms.Label();
            this.cboLoaiPhong = new System.Windows.Forms.ComboBox();
            this.lblLoaiPhong = new System.Windows.Forms.Label();
            this.txtTenPhong = new System.Windows.Forms.TextBox();
            this.lblTenPhong = new System.Windows.Forms.Label();
            this.txtMaPhong = new System.Windows.Forms.TextBox();
            this.lblMaPhong = new System.Windows.Forms.Label();
            this.lblDonDepText = new System.Windows.Forms.Label();
            this.lblDaThueText = new System.Windows.Forms.Label();
            this.lblTrongText = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.Trong = new System.Windows.Forms.Label();
            this.DaThue = new System.Windows.Forms.Label();
            this.DonDep = new System.Windows.Forms.Label();
            this.flpPhong = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.btnLamMoi);
            this.panelMain.Controls.Add(this.cboTinhTrang);
            this.panelMain.Controls.Add(this.lblTinhTrangInput);
            this.panelMain.Controls.Add(this.txtGia);
            this.panelMain.Controls.Add(this.lblGia);
            this.panelMain.Controls.Add(this.cboLoaiPhong);
            this.panelMain.Controls.Add(this.lblLoaiPhong);
            this.panelMain.Controls.Add(this.txtTenPhong);
            this.panelMain.Controls.Add(this.lblTenPhong);
            this.panelMain.Controls.Add(this.txtMaPhong);
            this.panelMain.Controls.Add(this.lblMaPhong);
            this.panelMain.Controls.Add(this.lblDonDepText);
            this.panelMain.Controls.Add(this.lblDaThueText);
            this.panelMain.Controls.Add(this.lblTrongText);
            this.panelMain.Controls.Add(this.btnXoa);
            this.panelMain.Controls.Add(this.btnSua);
            this.panelMain.Controls.Add(this.btnThem);
            this.panelMain.Controls.Add(this.flpPhong);
            this.panelMain.Controls.Add(this.DonDep);
            this.panelMain.Controls.Add(this.DaThue);
            this.panelMain.Controls.Add(this.Trong);
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Location = new System.Drawing.Point(20, 20);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(900, 400);
            this.panelMain.TabIndex = 0;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(770, 322);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(90, 23);
            this.btnLamMoi.TabIndex = 12;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // cboTinhTrang
            // 
            this.cboTinhTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTinhTrang.FormattingEnabled = true;
            this.cboTinhTrang.Location = new System.Drawing.Point(100, 285);
            this.cboTinhTrang.Name = "cboTinhTrang";
            this.cboTinhTrang.Size = new System.Drawing.Size(150, 24);
            this.cboTinhTrang.TabIndex = 11;
            // 
            // lblTinhTrangInput
            // 
            this.lblTinhTrangInput.AutoSize = true;
            this.lblTinhTrangInput.Location = new System.Drawing.Point(30, 288);
            this.lblTinhTrangInput.Name = "lblTinhTrangInput";
            this.lblTinhTrangInput.Size = new System.Drawing.Size(75, 16);
            this.lblTinhTrangInput.TabIndex = 10;
            this.lblTinhTrangInput.Text = "Tình trạng:";
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(740, 250);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(120, 22);
            this.txtGia.TabIndex = 9;
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Location = new System.Drawing.Point(700, 253);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(38, 16);
            this.lblGia.TabIndex = 8;
            this.lblGia.Text = "Giá:";
            // 
            // cboLoaiPhong
            // 
            this.cboLoaiPhong.FormattingEnabled = true;
            this.cboLoaiPhong.Items.AddRange(new object[] {
            "Đơn",
            "Đôi",
            "VIP",
            "Suite"});
            this.cboLoaiPhong.Location = new System.Drawing.Point(540, 250);
            this.cboLoaiPhong.Name = "cboLoaiPhong";
            this.cboLoaiPhong.Size = new System.Drawing.Size(140, 24);
            this.cboLoaiPhong.TabIndex = 7;
            // 
            // lblLoaiPhong
            // 
            this.lblLoaiPhong.AutoSize = true;
            this.lblLoaiPhong.Location = new System.Drawing.Point(460, 253);
            this.lblLoaiPhong.Name = "lblLoaiPhong";
            this.lblLoaiPhong.Size = new System.Drawing.Size(74, 16);
            this.lblLoaiPhong.TabIndex = 6;
            this.lblLoaiPhong.Text = "Loại phòng:";
            // 
            // txtTenPhong
            // 
            this.txtTenPhong.Location = new System.Drawing.Point(290, 250);
            this.txtTenPhong.Name = "txtTenPhong";
            this.txtTenPhong.Size = new System.Drawing.Size(150, 22);
            this.txtTenPhong.TabIndex = 5;
            // 
            // lblTenPhong
            // 
            this.lblTenPhong.AutoSize = true;
            this.lblTenPhong.Location = new System.Drawing.Point(220, 253);
            this.lblTenPhong.Name = "lblTenPhong";
            this.lblTenPhong.Size = new System.Drawing.Size(77, 16);
            this.lblTenPhong.TabIndex = 4;
            this.lblTenPhong.Text = "Tên phòng:";
            // 
            // txtMaPhong
            // 
            this.txtMaPhong.Location = new System.Drawing.Point(100, 250);
            this.txtMaPhong.Name = "txtMaPhong";
            this.txtMaPhong.Size = new System.Drawing.Size(100, 22);
            this.txtMaPhong.TabIndex = 3;
            // 
            // lblMaPhong
            // 
            this.lblMaPhong.AutoSize = true;
            this.lblMaPhong.Location = new System.Drawing.Point(30, 253);
            this.lblMaPhong.Name = "lblMaPhong";
            this.lblMaPhong.Size = new System.Drawing.Size(70, 16);
            this.lblMaPhong.TabIndex = 2;
            this.lblMaPhong.Text = "Mã phòng:";
            // 
            // lblDonDepText
            // 
            this.lblDonDepText.AutoSize = true;
            this.lblDonDepText.Location = new System.Drawing.Point(248, 60);
            this.lblDonDepText.Name = "lblDonDepText";
            this.lblDonDepText.Size = new System.Drawing.Size(75, 16);
            this.lblDonDepText.TabIndex = 3;
            this.lblDonDepText.Text = "Đang dọn";
            // 
            // lblDaThueText
            // 
            this.lblDaThueText.AutoSize = true;
            this.lblDaThueText.Location = new System.Drawing.Point(148, 60);
            this.lblDaThueText.Name = "lblDaThueText";
            this.lblDaThueText.Size = new System.Drawing.Size(58, 16);
            this.lblDaThueText.TabIndex = 2;
            this.lblDaThueText.Text = "Đã thuê";
            // 
            // lblTrongText
            // 
            this.lblTrongText.AutoSize = true;
            this.lblTrongText.Location = new System.Drawing.Point(48, 60);
            this.lblTrongText.Name = "lblTrongText";
            this.lblTrongText.Size = new System.Drawing.Size(43, 16);
            this.lblTrongText.TabIndex = 1;
            this.lblTrongText.Text = "Trống";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(898, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý phòng";
            // 
            // Trong
            // 
            this.Trong.BackColor = System.Drawing.Color.White;
            this.Trong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Trong.Location = new System.Drawing.Point(30, 62);
            this.Trong.Name = "Trong";
            this.Trong.Size = new System.Drawing.Size(12, 12);
            this.Trong.TabIndex = 1;
            // 
            // DaThue
            // 
            this.DaThue.BackColor = System.Drawing.Color.Red;
            this.DaThue.Location = new System.Drawing.Point(130, 62);
            this.DaThue.Name = "DaThue";
            this.DaThue.Size = new System.Drawing.Size(12, 12);
            this.DaThue.TabIndex = 2;
            // 
            // DonDep
            // 
            this.DonDep.BackColor = System.Drawing.Color.Orange;
            this.DonDep.Location = new System.Drawing.Point(230, 62);
            this.DonDep.Name = "DonDep";
            this.DonDep.Size = new System.Drawing.Size(12, 12);
            this.DonDep.TabIndex = 3;
            // 
            // flpPhong
            // 
            this.flpPhong.AutoScroll = true;
            this.flpPhong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpPhong.Location = new System.Drawing.Point(30, 90);
            this.flpPhong.Name = "flpPhong";
            this.flpPhong.Size = new System.Drawing.Size(840, 150);
            this.flpPhong.TabIndex = 4;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(30, 322);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(133, 322);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(233, 322);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // FormPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 440);
            this.Controls.Add(this.panelMain);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "FormPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý phòng";
            this.Load += new System.EventHandler(this.FormPhong_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label DonDep;
        private System.Windows.Forms.Label DaThue;
        private System.Windows.Forms.Label Trong;
        private System.Windows.Forms.FlowLayoutPanel flpPhong;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label lblTrongText;
        private System.Windows.Forms.Label lblDaThueText;
        private System.Windows.Forms.Label lblDonDepText;
        private System.Windows.Forms.Label lblMaPhong;
        private System.Windows.Forms.TextBox txtMaPhong;
        private System.Windows.Forms.Label lblTenPhong;
        private System.Windows.Forms.TextBox txtTenPhong;
        private System.Windows.Forms.Label lblLoaiPhong;
        private System.Windows.Forms.ComboBox cboLoaiPhong;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.Label lblTinhTrangInput;
        private System.Windows.Forms.ComboBox cboTinhTrang;
        private System.Windows.Forms.Button btnLamMoi;
    }
}
