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
    
    public partial class FormMain : Form
    {
        private DataProvider dataProvider = new DataProvider();
        private int maSachLoaiSach;
        private int maSachSach;
        private int maLoaiSachLoaiSach;
        private int maHoaDonHoaDon;
        public FormMain()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            initSach();
            initLoaiSach();
            initHoaDon();
        }

        private void initSach()
        {
            loadDgSach();
            loadcbSachLoaiSach();
        }
        private void loadAll()
        {
            loadDgSach();
            loadcbSachLoaiSach();
            loadDgLoaiSach();
        }
        private void loadDgSach()
        {
            DataTable dt = new DataTable();

            StringBuilder query = new StringBuilder("SELECT ma_sach as [Mã Sách]");
            query.Append(", ten_sach as [Tên Sách]");
            query.Append(", ten_loai_sach as [Loại Sách]");
            query.Append(", tac_gia as [Tác Giả]");
            query.Append(", so_luong as [Số Lượng]");
            query.Append(", gia_ban as [Giá Bán]");
            query.Append(" FROM tbl_Sach, tbl_loai_sach");
            query.Append(" WHERE tbl_Sach.ma_loai_sach = tbl_loai_sach.ma_loai_sach;");
            dt = dataProvider.execQuery(query.ToString());

            dgSach.DataSource = dt;
        }


        private void loadcbSachLoaiSach()
        {
            DataTable dt = new DataTable();
            dt = dataProvider.execQuery("SELECT * FROM tbl_loai_sach");
            cbSachLoaiSach.DisplayMember = "ten_loai_sach";
            cbSachLoaiSach.ValueMember = "ma_loai_sach";

            cbSachLoaiSach.DataSource = dt;

        }

        private void dgSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = e.RowIndex;
            if (rowId < 0) return;
            if (rowId >= dgSach.Rows.Count - 1) rowId = rowId - 1;


            DataGridViewRow row = dgSach.Rows[rowId];

            maSachSach = Convert.ToInt32(row.Cells[0].Value);

            txtSachTenSach.Text = row.Cells[1].Value.ToString();
            cbSachLoaiSach.Text = row.Cells[2].Value.ToString();
            txtSachTacGia.Text = row.Cells[3].Value.ToString();
            numSachSoLuong.Value = Convert.ToInt32(row.Cells[4].Value);
            numSachGiaBan.Value = Convert.ToDecimal(row.Cells[5].Value);

            maSachLoaiSach = dataProvider.execScaler("SELECT ma_loai_sach FROM tbl_loai_sach WHERE ten_loai_sach = N'" + cbSachLoaiSach.Text + "'") is int ? (int)dataProvider.execScaler("SELECT ma_loai_sach FROM tbl_loai_sach WHERE ten_loai_sach = N'" + cbSachLoaiSach.Text + "'") : 0;
        }

        private void btnSachThem_Click(object sender, EventArgs e)
        {
            //StringBuilder query = new StringBuilder("INSERT INTO tbl_Sach(ten_sach, ma_loai_sach, tac_gia, so_luong, gia_ban)");
            StringBuilder query = new StringBuilder("EXEC sp_them_sach");
            query.AppendFormat(" @ten_sach = N'{0}'", txtSachTenSach.Text);
            query.AppendFormat(", @ma_loai_sach = N'{0}'", maSachLoaiSach);
            query.AppendFormat(", @tac_gia = N'{0}'", txtSachTacGia.Text);
            query.AppendFormat(", @so_luong = {0}", numSachSoLuong.Value);
            query.AppendFormat(", @gia_ban = {0}", numSachGiaBan.Value);

            int result = dataProvider.execNonQuery(query.ToString());

            if (result > 0)
            {
                loadDgSach();
                MessageBox.Show("Thêm sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDgSach();
            }
            else
            {
                MessageBox.Show("Thêm sách thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSachSua_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("EXEC sp_cap_nhat_sach");
            query.AppendFormat(" @ma_sach = {0}", maSachSach);
            query.AppendFormat(", @ten_sach = N'{0}'", txtSachTenSach.Text);
            query.AppendFormat(", @ma_loai_sach = N'{0}'", maSachLoaiSach);
            query.AppendFormat(", @tac_gia = N'{0}'", txtSachTacGia.Text);
            query.AppendFormat(", @so_luong = {0}", numSachSoLuong.Value);
            query.AppendFormat(", @gia_ban = {0}", numSachGiaBan.Value);

            int result = (int)dataProvider.execNonQuery(query.ToString());

            if (result > 0)
            {
                loadDgSach();
                MessageBox.Show("Cập nhật sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDgSach();
            }
            else
            {
                MessageBox.Show("Cập nhật sách thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSachXoa_Click(object sender, EventArgs e)
        {
            
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa sách " + txtSachTenSach.Text + " ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                string query = "EXEC sp_xoa_sach @ma_sach = " + maSachSach;
                int result = dataProvider.execNonQuery(query.ToString());
                loadDgSach();
                MessageBox.Show("Xóa sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDgSach();
            }
            else
            {
                MessageBox.Show("Xóa sách thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbSachLoaiSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            maSachLoaiSach = (int)comboBox.SelectedValue;
        }

        //form 2
        //

        private void initLoaiSach()
        {
            loadDgLoaiSach();
        }
        private void dgLoaiSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void loadDgLoaiSach()
        {
            
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("SELECT ma_loai_sach as [Mã Loại Sách]");
            query.Append(", ten_loai_sach as [Tên Loại Sách]");
            query.Append(" FROM tbl_loai_sach;");
            dt = dataProvider.execQuery(query.ToString());
            dgLoaiSach.DataSource = dt;
        }

        private void dgLoaiSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = e.RowIndex;
            if (rowId < 0) return;
            if (rowId >= dgLoaiSach.Rows.Count - 1) rowId = rowId - 1;
            DataGridViewRow row = dgLoaiSach.Rows[rowId];
            maLoaiSachLoaiSach = Convert.ToInt32(row.Cells[0].Value);
            txtLoaiSachTenLoaiSach.Text = row.Cells[1].Value.ToString();
        }

        private void btnLoaiSachThem_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("EXEC sp_them_loai_sach");
            query.AppendFormat(" @ten_loai_sach = N'{0}'", txtLoaiSachTenLoaiSach.Text);
            int result = dataProvider.execNonQuery(query.ToString());
            if (result > 0)
            {
                loadAll();
                MessageBox.Show("Thêm loại sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadAll();
            }
            else
            {
                MessageBox.Show("Thêm loại sách thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoaiSachSua_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("EXEC sp_cap_nhat_loai_sach");
            query.AppendFormat(" @ma_loai_sach = {0}", maLoaiSachLoaiSach);
            query.AppendFormat(", @ten_loai_sach = N'{0}'", txtLoaiSachTenLoaiSach.Text);
            int result = (int)dataProvider.execNonQuery(query.ToString());
            if (result > 0)
            {
                loadDgLoaiSach();
                MessageBox.Show("Cập nhật loại sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDgLoaiSach();
            }
            else
            {
                MessageBox.Show("Cập nhật loại sách thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoaiSachXoa_Click(object sender, EventArgs e)
        {
            dgLoaiSach.Refresh();
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa loại sách " + txtLoaiSachTenLoaiSach.Text + " ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                string query = "EXEC sp_xoa_loai_sach @ma_loai_sach = " + maLoaiSachLoaiSach;
                int result = dataProvider.execNonQuery(query.ToString());
                loadDgLoaiSach();
                MessageBox.Show("Xóa loại sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDgLoaiSach();
            }
            else
            {
                MessageBox.Show("Xóa loại sách thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       //form hoa don

        private void initHoaDon()
        {
            loadDgHoaDon();
        }
        private void loadDgHoaDon()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("SELECT ma_hoa_don as [Mã Hóa Đơn]");
            query.Append(", ngay_lap_hoa_don as [Ngày Lập Hóa Đơn]");

            query.Append(", ten_khach_hang as [Tên Khách Hàng]");
            query.Append(", sdt_khach_hang as [SĐT Khách Hàng]");
            query.Append(" FROM tbl_hoa_don;");
            dt = dataProvider.execQuery(query.ToString());
            dgHoaDon.DataSource = dt;
        }

        private void dgHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = e.RowIndex;
            if (rowId < 0) return;
            if (rowId >= dgHoaDon.Rows.Count - 1) rowId = rowId - 1;
            DataGridViewRow row = dgHoaDon.Rows[rowId];
            int maHoaDonHoaDon = Convert.ToInt32(row.Cells[0].Value);
            dateNgaylapHoaDon.Value = Convert.ToDateTime(row.Cells[1].Value);
            txtHoaDonTenKH.Text = row.Cells[2].Value.ToString();
            txtHoaDonSDTKH.Text = row.Cells[3].Value.ToString();

            DataTable dt = new DataTable();

        }

        private void btnHoaDonThem_Click(object sender, EventArgs e)
        {
            int result = 0;
            StringBuilder query = new StringBuilder("EXEC sp_them_hoa_don");
            query.AppendFormat(" @ngay_lap_hoa_don = '{0}'", dateNgaylapHoaDon.Value.ToString("dd-MM-yyyy"));
            query.AppendFormat(", @ten_khach_hang = N'{0}'", txtHoaDonTenKH.Text);
            query.AppendFormat(", @sdt_khach_hang = N'{0}'", txtHoaDonSDTKH.Text);
             result = dataProvider.execNonQuery(query.ToString());
            if (result > 0)
            {
                loadDgHoaDon();
                MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDgHoaDon();
            }
            else
            {
                MessageBox.Show("Thêm hóa đơn thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHoaDonSua_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("EXEC sp_cap_nhat_hoa_don");
            query.AppendFormat(" @ngay_lap_hoa_don = '{0}'", dateNgaylapHoaDon.Value.ToString("dd-MM-yyyy"));
            query.AppendFormat(", @ten_khach_hang = N'{0}'", txtHoaDonTenKH.Text);
            query.AppendFormat(", @sdt_khach_hang = N'{0}'", txtHoaDonSDTKH.Text);
            query.AppendFormat(", @ma_hoa_don = {0}", maHoaDonHoaDon);
            int result = dataProvider.execNonQuery(query.ToString());
            if (result > 0)
            {
                loadDgHoaDon();
                MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Thêm hóa đơn thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHoaDonXoa_Click(object sender, EventArgs e)
        {

        }
    }
}
