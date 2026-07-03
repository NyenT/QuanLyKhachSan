namespace QuanLyKhachSan.Presentation
{
<<<<<<< HEAD
    partial class FrmPhong
=======
    partial class FormPhong
>>>>>>> f8146d62df59577b243431f486856f5c2bc2bd49
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
<<<<<<< HEAD
            this.panelMain = new System.Windows.Forms.Panel();
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
            this.panelMain.Size = new System.Drawing.Size(900, 320);
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
            this.flpPhong.Location = new System.Drawing.Point(30, 100);
            this.flpPhong.Name = "flpPhong";
            this.flpPhong.Size = new System.Drawing.Size(820, 140);
            this.flpPhong.TabIndex = 4;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(30, 266);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(133, 266);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(233, 266);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // FrmPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 450);
            this.Controls.Add(this.panelMain);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "FrmPhong";
            this.Text = "Quản lý phòng";
            this.panelMain.ResumeLayout(false);
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
=======
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
        }

        #endregion
>>>>>>> f8146d62df59577b243431f486856f5c2bc2bd49
    }
}