namespace QLBS
{
    partial class FormDangNhap
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
            this.matkhau = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.DangNhap = new System.Windows.Forms.Button();
            this.Thoat = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.taikhoan = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // matkhau
            // 
            this.matkhau.Location = new System.Drawing.Point(569, 301);
            this.matkhau.Name = "matkhau";
            this.matkhau.PasswordChar = '*';
            this.matkhau.Size = new System.Drawing.Size(430, 26);
            this.matkhau.TabIndex = 4;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(609, 395);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(159, 24);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Hiện thị mật khẩu";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // DangNhap
            // 
            this.DangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DangNhap.Location = new System.Drawing.Point(512, 436);
            this.DangNhap.Name = "DangNhap";
            this.DangNhap.Size = new System.Drawing.Size(167, 48);
            this.DangNhap.TabIndex = 6;
            this.DangNhap.Text = "Đăng nhập";
            this.DangNhap.UseVisualStyleBackColor = true;
            this.DangNhap.Click += new System.EventHandler(this.DangNhap_Click_1);
            // 
            // Thoat
            // 
            this.Thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Thoat.Location = new System.Drawing.Point(787, 436);
            this.Thoat.Name = "Thoat";
            this.Thoat.Size = new System.Drawing.Size(167, 48);
            this.Thoat.TabIndex = 7;
            this.Thoat.Text = "Thoát";
            this.Thoat.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(836, 395);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(118, 20);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Quên mật khẩu";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(722, 73);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(176, 39);
            this.guna2HtmlLabel1.TabIndex = 10;
            this.guna2HtmlLabel1.Text = "Đăng Nhập";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(512, 145);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(158, 39);
            this.guna2HtmlLabel2.TabIndex = 11;
            this.guna2HtmlLabel2.Text = "Tài Khoản";
            this.guna2HtmlLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // taikhoan
            // 
            this.taikhoan.BackColor = System.Drawing.Color.Transparent;
            this.taikhoan.BorderColor = System.Drawing.Color.Black;
            this.taikhoan.BorderRadius = 20;
            this.taikhoan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.taikhoan.DefaultText = "";
            this.taikhoan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.taikhoan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.taikhoan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.taikhoan.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.taikhoan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.taikhoan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.taikhoan.ForeColor = System.Drawing.Color.Transparent;
            this.taikhoan.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.taikhoan.Location = new System.Drawing.Point(512, 201);
            this.taikhoan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.taikhoan.Name = "taikhoan";
            this.taikhoan.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.taikhoan.PlaceholderText = "Nhập Tài Khoản";
            this.taikhoan.SelectedText = "";
            this.taikhoan.Size = new System.Drawing.Size(477, 60);
            this.taikhoan.TabIndex = 12;
            // 
            // FormDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 551);
            this.Controls.Add(this.taikhoan);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.Thoat);
            this.Controls.Add(this.DangNhap);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.matkhau);
            this.Name = "FormDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDangNhap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox matkhau;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button DangNhap;
        private System.Windows.Forms.Button Thoat;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2TextBox taikhoan;
    }
}