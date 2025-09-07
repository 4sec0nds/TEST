using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace QLBS
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();


            DangNhap.Click += DangNhap_Click;   // Đăng nhập
            Thoat.Click += Thoat_Click;   // Thoát
            checkBox1.CheckedChanged += checkBox1_CheckedChanged; // checkbox hiện mật khẩu
        }

        //Đăng nhập
        private void DangNhap_Click(object sender, EventArgs e)
        {
            string tk = taikhoan.Text.Trim();
            string mk = matkhau.Text.Trim();

            if (string.IsNullOrEmpty(tk) || string.IsNullOrEmpty(mk))
            {
                MessageBox.Show("Tài khoản và mật khẩu không được để trống!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chuỗi kết nối (sửa lại theo tên server + database của bạn)
            string connectionString = @"Data Source=.;Initial Catalog=TEST;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE TaiKhoan=@tk AND MatKhau=@mk";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@tk", tk);
                    cmd.Parameters.AddWithValue("@mk", mk);

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Đăng nhập thành công!",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở FormMain
                        FormMain frm = new FormMain();
                        this.Hide();
                        frm.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu!",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }

        private void Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                matkhau.PasswordChar = '\0';
            else
                matkhau.PasswordChar = '*';
        }

        private void DangNhap_Click_1(object sender, EventArgs e)
        {

        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(60, 0, 0, 0);
        }
    }
}
