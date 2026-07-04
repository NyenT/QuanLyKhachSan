namespace QuanLyKhachSan.Presentation
{
    partial class FormNhanVien
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtChucVu = new System.Windows.Forms.TextBox();
            this.lblChucVu = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoDienThoaiCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChiCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.SuspendLayout();
            //
            // panel1
            //
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnLamMoi);
            this.panel1.Controls.Add(this.txtDiaChi);
            this.panel1.Controls.Add(this.lblDiaChi);
            this.panel1.Controls.Add(this.txtSDT);
            this.panel1.Controls.Add(this.lblSDT);
            this.panel1.Controls.Add(this.txtChucVu);
            this.panel1.Controls.Add(this.lblChucVu);
            this.panel1.Controls.Add(this.txtHoTen);
            this.panel1.Controls.Add(this.lblHoTen);
            this.panel1.Controls.Add(this.txtMaNV);
            this.panel1.Controls.Add(this.lblMaNV);
            this.panel1.Controls.Add(this.dgvNhanVien);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.txtTimKiem);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1050, 520);
            this.panel1.TabIndex = 0;
            //
            // btnLamMoi
            //
            this.btnLamMoi.Location = new System.Drawing.Point(950, 137);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(88, 23);
            this.btnLamMoi.TabIndex = 16;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            //
            // txtDiaChi
            //
            this.txtDiaChi.Location = new System.Drawing.Point(310, 137);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(420, 22);
            this.txtDiaChi.TabIndex = 15;
            //
            // lblDiaChi
            //
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(250, 140);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(54, 16);
            this.lblDiaChi.TabIndex = 14;
            this.lblDiaChi.Text = "Địa chỉ:";
            //
            // txtSDT
            //
            this.txtSDT.Location = new System.Drawing.Point(80, 137);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(150, 22);
            this.txtSDT.TabIndex = 13;
            //
            // lblSDT
            //
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(12, 140);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(54, 16);
            this.lblSDT.TabIndex = 12;
            this.lblSDT.Text = "SĐT:";
            //
            // txtChucVu
            //
            this.txtChucVu.Location = new System.Drawing.Point(600, 97);
            this.txtChucVu.Name = "txtChucVu";
            this.txtChucVu.Size = new System.Drawing.Size(150, 22);
            this.txtChucVu.TabIndex = 11;
            //
            // lblChucVu
            //
            this.lblChucVu.AutoSize = true;
            this.lblChucVu.Location = new System.Drawing.Point(540, 100);
            this.lblChucVu.Name = "lblChucVu";
            this.lblChucVu.Size = new System.Drawing.Size(55, 16);
            this.lblChucVu.TabIndex = 10;
            this.lblChucVu.Text = "Chức vụ:";
            //
            // txtHoTen
            //
            this.txtHoTen.Location = new System.Drawing.Point(300, 97);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(220, 22);
            this.txtHoTen.TabIndex = 9;
            //
            // lblHoTen
            //
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(240, 100);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(58, 16);
            this.lblHoTen.TabIndex = 8;
            this.lblHoTen.Text = "Họ tên:";
            //
            // txtMaNV
            //
            this.txtMaNV.Location = new System.Drawing.Point(90, 97);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(130, 22);
            this.txtMaNV.TabIndex = 7;
            //
            // lblMaNV
            //
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Location = new System.Drawing.Point(12, 100);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(58, 16);
            this.lblMaNV.TabIndex = 6;
            this.lblMaNV.Text = "Mã NV:";
            //
            // dgvNhanVien
            //
            this.dgvNhanVien.AllowUserToAddRows = false;
            this.dgvNhanVien.AutoGenerateColumns = false;
            this.dgvNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNV,
            this.HoTen,
            this.ChucVu,
            this.SoDienThoaiCol,
            this.DiaChiCol});
            this.dgvNhanVien.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvNhanVien.Location = new System.Drawing.Point(0, 237);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.ReadOnly = true;
            this.dgvNhanVien.RowHeadersWidth = 51;
            this.dgvNhanVien.RowTemplate.Height = 24;
            this.dgvNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanVien.Size = new System.Drawing.Size(1050, 283);
            this.dgvNhanVien.TabIndex = 5;
            this.dgvNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellClick);
            //
            // MaNV
            //
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.HeaderText = "Mã NV";
            this.MaNV.MinimumWidth = 6;
            this.MaNV.Name = "MaNV";
            this.MaNV.ReadOnly = true;
            //
            // HoTen
            //
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Họ Tên";
            this.HoTen.MinimumWidth = 6;
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            //
            // ChucVu
            //
            this.ChucVu.DataPropertyName = "ChucVu";
            this.ChucVu.HeaderText = "Chức vụ";
            this.ChucVu.MinimumWidth = 6;
            this.ChucVu.Name = "ChucVu";
            this.ChucVu.ReadOnly = true;
            //
            // SoDienThoaiCol
            //
            this.SoDienThoaiCol.DataPropertyName = "SoDienThoai";
            this.SoDienThoaiCol.HeaderText = "SĐT";
            this.SoDienThoaiCol.MinimumWidth = 6;
            this.SoDienThoaiCol.Name = "SoDienThoaiCol";
            this.SoDienThoaiCol.ReadOnly = true;
            //
            // DiaChiCol
            //
            this.DiaChiCol.DataPropertyName = "DiaChi";
            this.DiaChiCol.HeaderText = "Địa chỉ";
            this.DiaChiCol.MinimumWidth = 6;
            this.DiaChiCol.Name = "DiaChiCol";
            this.DiaChiCol.ReadOnly = true;
            //
            // btnXoa
            //
            this.btnXoa.Location = new System.Drawing.Point(887, 65);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            //
            // btnSua
            //
            this.btnSua.Location = new System.Drawing.Point(776, 65);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            //
            // btnThem
            //
            this.btnThem.Location = new System.Drawing.Point(665, 65);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            //
            // txtTimKiem
            //
            this.txtTimKiem.Location = new System.Drawing.Point(12, 65);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(600, 22);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            //
            // lblTitle
            //
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(1050, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý nhân viên";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // FormNhanVien
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 520);
            this.Controls.Add(this.panel1);
            this.Name = "FormNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Nhân Viên";
            this.Load += new System.EventHandler(this.FormNhanVien_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoDienThoaiCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChiCol;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblChucVu;
        private System.Windows.Forms.TextBox txtChucVu;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Button btnLamMoi;
    }
}
