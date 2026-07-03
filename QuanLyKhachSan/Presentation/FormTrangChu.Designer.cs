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
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 40);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(180, 428);
            this.panelMenu.TabIndex = 1;
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
            this.panelPhongTrong.Location = new System.Drawing.Point(20, 20);
            this.panelPhongTrong.Name = "panelPhongTrong";
            this.panelPhongTrong.Size = new System.Drawing.Size(200, 80);
            this.panelPhongTrong.TabIndex = 0;
            // 
            // panelDaThue
            // 
            this.panelDaThue.BackColor = System.Drawing.Color.White;
            this.panelDaThue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDaThue.Location = new System.Drawing.Point(265, 20);
            this.panelDaThue.Name = "panelDaThue";
            this.panelDaThue.Size = new System.Drawing.Size(200, 80);
            this.panelDaThue.TabIndex = 1;
            // 
            // panelDoanhThu
            // 
            this.panelDoanhThu.BackColor = System.Drawing.Color.White;
            this.panelDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDoanhThu.Location = new System.Drawing.Point(510, 20);
            this.panelDoanhThu.Name = "panelDoanhThu";
            this.panelDoanhThu.Size = new System.Drawing.Size(200, 80);
            this.panelDoanhThu.TabIndex = 1;
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
    }
}