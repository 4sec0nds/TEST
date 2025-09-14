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
using ClosedXML.Excel;

namespace QLBS
{

    public partial class FormMain : Form
    {
        private DataProvider dataProvider = new DataProvider();
        private int maSachLoaiSach;
        private int maSachSach;
        private int maLoaiSachLoaiSach;
        private int maHoaDonHoaDon;
        private int maPhieuNhapPhieuNhap;
        public FormMain()
        {
            InitializeComponent();
            IsMdiContainer = true;
            init();
        }

        private void init()
        {
            initSach();
            initLoaiSach();
            initHoaDon();
            initPhieuNhap();
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

        private void searchSach(string keyword)
        {
            DataTable dt = new DataTable();

            StringBuilder query = new StringBuilder("SELECT ma_sach as [Mã Sách]");
            query.Append(", ten_sach as [Tên Sách]");
            query.Append(", ten_loai_sach as [Loại Sách]");
            query.Append(", tac_gia as [Tác Giả]");
            query.Append(", so_luong as [Số Lượng]");
            query.Append(", gia_ban as [Giá Bán]");
            query.Append(" FROM tbl_Sach, tbl_loai_sach");
            query.Append(" WHERE tbl_Sach.ma_loai_sach = tbl_loai_sach.ma_loai_sach");
            query.Append(" AND (ten_sach LIKE N'%" + keyword + "%' OR tac_gia LIKE N'%" + keyword + "%')");

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
            maHoaDonHoaDon = (int)row.Cells[0].Value;
            dateNgaylapHoaDon.Value = DateTime.Parse(row.Cells[1].Value.ToString());
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
            int result = 0;
            StringBuilder query = new StringBuilder("EXEC sp_cap_nhat_hoa_don");
            query.AppendFormat(" @ngay_lap_hoa_don = '{0}'", dateNgaylapHoaDon.Value.ToString("dd-MM-yyyy"));
            query.AppendFormat(", @ten_khach_hang = N'{0}'", txtHoaDonTenKH.Text);
            query.AppendFormat(", @sdt_khach_hang = N'{0}'", txtHoaDonSDTKH.Text);
            query.AppendFormat(", @ma_hoa_don = {0}", maHoaDonHoaDon);
            result = dataProvider.execNonQuery(query.ToString());
            if (result > 0)
            {
                loadDgHoaDon();
                MessageBox.Show("Cập nhật hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDgHoaDon();
            }
            else
            {
                MessageBox.Show("Cập nhật hóa đơn thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHoaDonXoa_Click(object sender, EventArgs e)
        {
            dgLoaiSach.Refresh();
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn " + maHoaDonHoaDon + " ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                string query = "EXEC sp_xoa_hoa_don @ma_hoa_don = " + maHoaDonHoaDon;
                int result = dataProvider.execNonQuery(query.ToString());
                loadDgHoaDon();
                MessageBox.Show("Xóa hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //loadDgLoaiSach();
            }
            else
            {
                MessageBox.Show("Xóa hóa đơn thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtHoaDonSDTKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true; // Ngăn chặn ký tự không hợp lệ
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true; // Ngăn chặn nhập thêm dấu chấm nếu đã có
            }
        }

        //form phieu nhap

        private void initPhieuNhap()
        {
            loadDgPhieuNhap();
        }



        private void loadDgPhieuNhap()
        {

            DataTable dt = new DataTable();

            StringBuilder query = new StringBuilder("SELECT ma_phieu_nhap as [Mã Phiếu Nhập]");
            query.Append(", ngay_lap_phieu_nhap as [Ngày Lập Phiếu Nhập]");
            query.Append(", ten_nha_cung_cap as [Tên Nhà Cung Cấp]");
            query.Append(" FROM tbl_phieu_nhap;");
            dt = dataProvider.execQuery(query.ToString());
            dgPhieuNhap.DataSource = dt;
        }

        private void dgPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = e.RowIndex;
            if (rowId < 0) return;
            if (rowId >= dgPhieuNhap.Rows.Count - 1) rowId = rowId - 1;
            DataGridViewRow row = dgPhieuNhap.Rows[rowId];
            maPhieuNhapPhieuNhap = (int)row.Cells[0].Value;
            dateNgayLapPhieuNhap.Value = DateTime.Parse(row.Cells[1].Value.ToString());
            txtPhieuNhapNhaCungCap.Text = row.Cells[2].Value.ToString();

            DataTable dt = new DataTable();
        }

        private void btnPhieuNhapThem_Click(object sender, EventArgs e)
        {
            int result = 0;
            StringBuilder query = new StringBuilder("EXEC sp_them_phieu_nhap");
            query.AppendFormat(" @ngay_lap_phieu_nhap = '{0}'", dateNgayLapPhieuNhap.Value.ToString("dd-MM-yyyy"));
            query.AppendFormat(", @ten_nha_cung_cap = N'{0}'", txtPhieuNhapNhaCungCap.Text);
            result = dataProvider.execNonQuery(query.ToString());
            if (result > 0)
            {
                loadDgPhieuNhap();
                MessageBox.Show("Thêm phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDgPhieuNhap();
            }
            else
            {
                MessageBox.Show("Thêm phiếu nhập thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPhieuNhapSua_Click(object sender, EventArgs e)
        {
            int result = 0;
            StringBuilder query = new StringBuilder("EXEC sp_cap_nhat_phieu_nhap");
            query.AppendFormat(" @ngay_lap_phieu_nhap = '{0}'", dateNgayLapPhieuNhap.Value.ToString("dd-MM-yyyy"));
            query.AppendFormat(", @ten_nha_cung_cap = N'{0}'", txtPhieuNhapNhaCungCap.Text);
            query.AppendFormat(", @ma_phieu_nhap = N'{0}'", maPhieuNhapPhieuNhap);

            result = dataProvider.execNonQuery(query.ToString());
            if (result > 0)
            {
                loadDgPhieuNhap();
                MessageBox.Show("Cập nhật phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDgPhieuNhap();
            }
            else
            {
                MessageBox.Show("Cập nhật phiếu nhập thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPhieuNhapXoa_Click(object sender, EventArgs e)
        {
            dgLoaiSach.Refresh();
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu nhập " + maPhieuNhapPhieuNhap + " ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                string query = "EXEC sp_xoa_phieu_nhap @ma_phieu_nhap = " + maPhieuNhapPhieuNhap;
                int result = dataProvider.execNonQuery(query.ToString());
                loadDgPhieuNhap();
                MessageBox.Show("Xóa phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //loadDgLoaiSach();
            }
            else
            {
                MessageBox.Show("Xóa Phiếu nhập thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void btnPhieuNhapChiTiet_Click(object sender, EventArgs e)
        //{
        //    // Tạo form chi tiết phiếu nhập
        //    FormChiTietPhieuNhap form = new FormChiTietPhieuNhap(maPhieuNhapPhieuNhap);
        //    form.TopLevel = false; // để form trở thành control
        //    form.FormBorderStyle = FormBorderStyle.None; // bỏ viền
        //    form.Dock = DockStyle.Fill; // chiếm toàn bộ tab

        //    // Lấy tab hiện tại
        //    TabPage currentTab = this.tabControl1.SelectedTab;
        //    if (currentTab != null)
        //    {
        //        currentTab.Controls.Clear(); // xóa control cũ
        //        currentTab.Controls.Add(form); // add form mới
        //        form.Show();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Không tìm thấy tab hiện tại!");
        //    }
        //}
        private void btnPhieuNhapChiTiet_Click(object sender, EventArgs e)
        {
            using (FormChiTietPhieuNhap form = new FormChiTietPhieuNhap(maPhieuNhapPhieuNhap))
            {
                form.ShowDialog();
            }
        }

        public void ShowPhieuNhapList()
        {
            TabPage tabPage = this.tabControl1.TabPages["tabPagePhieuNhap"];
            if (tabPage != null)
            {
                tabPage.Controls.Clear(); // xóa form chi tiết
                                          // Gọi lại phần hiển thị danh sách phiếu nhập
                DataGridView dgPhieuNhap = new DataGridView();
                dgPhieuNhap.Dock = DockStyle.Fill;
                tabPage.Controls.Add(dgPhieuNhap);

                // nạp dữ liệu từ DB
                DataTable dt = new DataTable();

                StringBuilder query = new StringBuilder("SELECT ma_phieu_nhap as [Mã Phiếu Nhập]");
                query.Append(", ngay_lap_phieu_nhap as [Ngày Lập Phiếu Nhập]");
                query.Append(", ten_nha_cung_cap as [Tên Nhà Cung Cấp]");
                query.Append(" FROM tbl_phieu_nhap;");
                dt = dataProvider.execQuery(query.ToString());

                dgPhieuNhap.DataSource = dt;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgSach.Rows.Count > 0)
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                var ws = wb.Worksheets.Add("Sach");

                                // Ghi header
                                for (int i = 0; i < dgSach.Columns.Count; i++)
                                {
                                    ws.Cell(1, i + 1).Value = dgSach.Columns[i].HeaderText;
                                }

                                // Ghi dữ liệu
                                for (int i = 0; i < dgSach.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dgSach.Columns.Count; j++)
                                    {
                                        ws.Cell(i + 2, j + 1).Value = dgSach.Rows[i].Cells[j].Value?.ToString();
                                    }
                                }

                                // Thêm border cho toàn bảng
                                var range = ws.Range(1, 1, dgSach.Rows.Count + 1, dgSach.Columns.Count);
                                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                                // Tự động co giãn cột
                                ws.Columns().AdjustToContents();

                                // Lưu file
                                wb.SaveAs(sfd.FileName);
                            }
                            MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex) 
                        {
                            MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    
                }
                


            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExcel1_Click(object sender, EventArgs e)
        {
            if (dgLoaiSach.Rows.Count > 0)
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                var ws = wb.Worksheets.Add("LoaiSach");

                                // Ghi header
                                for (int i = 0; i < dgLoaiSach.Columns.Count; i++)
                                {
                                    ws.Cell(1, i + 1).Value = dgLoaiSach.Columns[i].HeaderText;
                                }

                                // Ghi dữ liệu
                                for (int i = 0; i < dgLoaiSach.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dgLoaiSach.Columns.Count; j++)
                                    {
                                        ws.Cell(i + 2, j + 1).Value = dgLoaiSach.Rows[i].Cells[j].Value?.ToString();
                                    }
                                }

                                // Thêm border cho toàn bảng
                                var range = ws.Range(1, 1, dgLoaiSach.Rows.Count + 1, dgLoaiSach.Columns.Count);
                                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                                // Tự động co giãn cột
                                ws.Columns().AdjustToContents();

                                // Lưu file
                                wb.SaveAs(sfd.FileName);
                            }
                            MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }



            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            searchSach(keyword);
        }

        private void btnSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                // Nếu ô tìm kiếm trống -> load lại tất cả sách
                loadDgSach();
            }
            else
            {
                // Nếu có từ khóa -> tìm kiếm
                searchSach(keyword);
            }
        }
    }
    }

