using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBS
{
    public partial class FormChiTietPhieuNhap : Form
    {
        

        DataProvider dataProvider = new DataProvider();
        private int maSach;
        private int maPhieuNhap;
        public FormChiTietPhieuNhap(int maPhieuNhap)
        {
            InitializeComponent();
            

            MessageBox.Show("Mở form chi tiết phiếu nhập: " + maPhieuNhap);
            this.maPhieuNhap = maPhieuNhap;
            init();
            
        }


        private void init()
        {
            title.Text = "Chi Tiết Phiếu Nhập: " + maPhieuNhap;
            loadDgPhieuNhap();
            loadCbSach();          
            loadTongTien();
        }

        private void loadDgPhieuNhap()
        {
            DataTable dt = new DataTable();

            StringBuilder query = new StringBuilder("SELECT ten_sach as [Tên Sách]");
            query.Append(", tbl_chi_tiet_phieu_nhap.so_luong as [Số Lượng]");
            query.Append(", tbl_chi_tiet_phieu_nhap.gia_nhap as [Giá Nhâp]");
            
            query.Append(" FROM tbl_Sach, tbl_chi_tiet_phieu_nhap");
            query.Append(" WHERE tbl_Sach.ma_sach = tbl_chi_tiet_phieu_nhap.ma_sach;");
            dt = dataProvider.execQuery(query.ToString());

            dgPhieuNhap.DataSource = dt;
        }

        private void loadTongTien()
        {
            StringBuilder query = new StringBuilder("SELECT SUM(so_luong * gia_nhap) FROM tbl_chi_tiet_phieu_nhap");
            query.AppendFormat(" WHERE ma_phieu_nhap = N'{0}'", maPhieuNhap);
            object result = dataProvider.execScaler(query.ToString());
            if (result != DBNull.Value)
            {
                decimal tongTien = Convert.ToDecimal(result);
                txtTongTien.Text = "Tổng Tiền: " + tongTien.ToString("N0") + " VND";
            }
            else
            {
                txtTongTien.Text = "Tổng Tiền: 0 VND";
            }
        }

        private void loadCbSach()
        {
            DataTable dt = new DataTable();
            dt = dataProvider.execQuery("SELECT * FROM tbl_sach");
            cbSach.DisplayMember = "ten_sach";
            cbSach.ValueMember = "ma_sach";

            cbSach.DataSource = dt;
        }

        private void cbSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            maSach = (int)comboBox.SelectedValue;
            //
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            int dem = dataProvider.execScaler(
                string.Format("SELECT COUNT(*) FROM tbl_chi_tiet_phieu_nhap WHERE ma_phieu_nhap = N'{0}' AND ma_sach = N'{1}'", maPhieuNhap, maSach)
            ) is int count ? count : 0;
            StringBuilder query = new StringBuilder("EXEC sp_them_chi_tiet_phieu_nhap");
            query.AppendFormat(" @ma_phieu_nhap = N'{0}'", maPhieuNhap);
            query.AppendFormat(", @ma_sach = N'{0}'", maSach);
            query.AppendFormat(", @so_luong = N'{0}'", numSoLuongSach.Value);
            query.AppendFormat(", @gia_nhap = {0}", numGiaNhapSach.Value);


            int result = dataProvider.execNonQuery(query.ToString());
             
            if (result > 0)
            {
                loadDgPhieuNhap();
                MessageBox.Show("Thêm sách vào phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Thêm sách vào phiếu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           loadTongTien();
        }

        
        private void btnSua_Click(object sender, EventArgs e)
        {
            update(0);
            loadTongTien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Lấy TabPage cha chứa form này
            TabPage parentTab = this.Parent as TabPage;
            if (parentTab != null)
            {
                parentTab.Controls.Clear(); // Xóa form chi tiết

                // Tạo lại DataGridView hiển thị danh sách phiếu nhập
                DataGridView dgPhieuNhap = new DataGridView();
                dgPhieuNhap.Dock = DockStyle.Fill;
                parentTab.Controls.Add(dgPhieuNhap);

                // Nạp lại dữ liệu
                DataProvider dataProvider = new DataProvider();
                DataTable dt = dataProvider.execQuery(
                    "SELECT ma_phieu_nhap as [Mã Phiếu Nhập], ngay_lap_phieu_nhap as [Ngày Lập Phiếu Nhập], ten_nha_cung_cap as [Tên Nhà Cung Cấp] FROM tbl_phieu_nhap"
                );
                dgPhieuNhap.DataSource = dt;
            }
        }


        private void update(int soluong)
        {
            StringBuilder query = new StringBuilder("EXEC sp_cap_nhat_chi_tiet_phieu_nhap");
            query.AppendFormat(" @ma_phieu_nhap = N'{0}'", maPhieuNhap);
            query.AppendFormat(", @ma_sach = N'{0}'", maSach);
            query.AppendFormat(", @so_luong = N'{0}'", numSoLuongSach.Value + soluong);
            query.AppendFormat(", @gia_nhap = {0}", numGiaNhapSach.Value);


            int result = dataProvider.execNonQuery(query.ToString());

            if (result > 0)
            {
                loadDgPhieuNhap();
                MessageBox.Show("Thêm sách vào phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Thêm sách vào phiếu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loadTongTien();
        }
    }
}
