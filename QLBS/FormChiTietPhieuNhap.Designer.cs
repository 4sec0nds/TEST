namespace QLBS
{
    partial class FormChiTietPhieuNhap
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.numGiaNhapSach = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numSoLuongSach = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbSach = new System.Windows.Forms.ComboBox();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.dgPhieuNhap = new System.Windows.Forms.DataGridView();
            this.title = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.Label();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaNhapSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPhieuNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtTongTien);
            this.panel4.Controls.Add(this.numGiaNhapSach);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.numSoLuongSach);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.cbSach);
            this.panel4.Controls.Add(this.btnThem);
            this.panel4.Controls.Add(this.btnSua);
            this.panel4.Controls.Add(this.btnXoa);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(0, 457);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1170, 177);
            this.panel4.TabIndex = 22;
            // 
            // numGiaNhapSach
            // 
            this.numGiaNhapSach.Location = new System.Drawing.Point(427, 56);
            this.numGiaNhapSach.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numGiaNhapSach.Name = "numGiaNhapSach";
            this.numGiaNhapSach.Size = new System.Drawing.Size(120, 26);
            this.numGiaNhapSach.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(337, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "Giá Nhập";
            // 
            // numSoLuongSach
            // 
            this.numSoLuongSach.Location = new System.Drawing.Point(141, 58);
            this.numSoLuongSach.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numSoLuongSach.Name = "numSoLuongSach";
            this.numSoLuongSach.Size = new System.Drawing.Size(120, 26);
            this.numSoLuongSach.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "Số Lượng";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Tên Sách";
            // 
            // cbSach
            // 
            this.cbSach.FormattingEnabled = true;
            this.cbSach.Location = new System.Drawing.Point(141, 12);
            this.cbSach.Name = "cbSach";
            this.cbSach.Size = new System.Drawing.Size(406, 28);
            this.cbSach.TabIndex = 20;
            this.cbSach.SelectedIndexChanged += new System.EventHandler(this.cbSach_SelectedIndexChanged);
            // 
            // btnThem
            // 
            this.btnThem.BorderRadius = 15;
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(40, 107);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(133, 45);
            this.btnThem.TabIndex = 16;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BorderRadius = 15;
            this.btnSua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(209, 106);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(133, 45);
            this.btnSua.TabIndex = 15;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BorderRadius = 15;
            this.btnXoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(381, 107);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(133, 45);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // dgPhieuNhap
            // 
            this.dgPhieuNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPhieuNhap.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgPhieuNhap.Location = new System.Drawing.Point(0, 76);
            this.dgPhieuNhap.Name = "dgPhieuNhap";
            this.dgPhieuNhap.RowHeadersWidth = 62;
            this.dgPhieuNhap.RowTemplate.Height = 28;
            this.dgPhieuNhap.Size = new System.Drawing.Size(1170, 381);
            this.dgPhieuNhap.TabIndex = 23;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(410, 23);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(323, 37);
            this.title.TabIndex = 24;
            this.title.Text = "Chi Tiết Phiếu Nhập";
            this.title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtTongTien
            // 
            this.txtTongTien.AutoSize = true;
            this.txtTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(807, 15);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(278, 32);
            this.txtTongTien.TabIndex = 26;
            this.txtTongTien.Text = "Tổng Tiền : 100000";
            // 
            // btnBack
            // 
            this.btnBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(13, 13);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(180, 45);
            this.btnBack.TabIndex = 25;
            this.btnBack.Text = "guna2Button1";
            // 
            // FormChiTietPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 634);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.title);
            this.Controls.Add(this.dgPhieuNhap);
            this.Controls.Add(this.panel4);
            this.Name = "FormChiTietPhieuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormChiTietPhieuNhap";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaNhapSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPhieuNhap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private System.Windows.Forms.DataGridView dgPhieuNhap;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbSach;
        private System.Windows.Forms.NumericUpDown numSoLuongSach;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numGiaNhapSach;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txtTongTien;
        private Guna.UI2.WinForms.Guna2Button btnBack;
    }
}