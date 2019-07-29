using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTiemBanhBLL;
using QuanLyTiemBanhDAL;

namespace QuanLyTiemBanh
{
    public partial class HoaDonCungCap : Form
    {
        public HoaDonCungCap()
        {
            InitializeComponent();
        }
        HoaDonCungCapBLL dbhoadon = new HoaDonCungCapBLL();
        NhaCungCapBLL dbnhacungcap = new NhaCungCapBLL();
        NhanVienBLL dbnhanvien = new NhanVienBLL();
        bool them;
        // mo cac nut chuc nang 
        void monutchucnang()
        {
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnReload.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnThoat.Enabled = true;
            btnXemchitiet.Enabled = true;
            btnXoa.Enabled = true;
            panel1.Enabled = false;
        }
        // dong cac nut chuc nang
        void dongnutchucnang()
        {
            btnXoa.Enabled = false;
            btnXemchitiet.Enabled = false;
            btnThoat.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnReload.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            panel1.Enabled = true;
           txtMaHD_CC.Enabled = false;
        }
        void loadhoadon()
        {
            (dgvHDCC.Columns["MaNhanVien"] as DataGridViewComboBoxColumn).DataSource = dbnhanvien.laydanhsach();
            (dgvHDCC.Columns["MaNhanVien"] as DataGridViewComboBoxColumn).DisplayMember = "TenNhanVien";
            (dgvHDCC.Columns["MaNhanVien"] as DataGridViewComboBoxColumn).ValueMember = "MaNhanVien";
            (dgvHDCC.Columns["MaNhaCungCap"] as DataGridViewComboBoxColumn).DataSource = dbnhacungcap.laydanhsach();
            (dgvHDCC.Columns["MaNhaCungCap"] as DataGridViewComboBoxColumn).DisplayMember = "TenNhaCungCap";
            (dgvHDCC.Columns["MaNhaCungCap"] as DataGridViewComboBoxColumn).ValueMember = "MaNhaCungCap";
            dgvHDCC.DataSource = dbhoadon.laydanhsach();
            dgvHDCC_CellClick(null, null);
            monutchucnang();
        }
        private void HoaDonCungCap_Load(object sender, EventArgs e)
        {
            loadhoadon();
        }

        private void dgvHDCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // chuyen du lieu len combobox tren pannel
            cmbNCC.DataSource = dbnhacungcap.laydanhsach();
            cmbNCC.DisplayMember = "TenNhaCungCap";
            cmbNCC.ValueMember = "MaNhaCungCap";
            cmbNV.DataSource = dbnhanvien.laydanhsach();
            cmbNV.DisplayMember = "TenNhanVien";
            cmbNV.ValueMember = "MaNhanVien";
            // lay dong hien hanh 
            int r = dgvHDCC.CurrentCell.RowIndex;
            // chuyen du lieu len pannel 
            txtMaHD_CC.Text = dgvHDCC.Rows[r].Cells[0].Value.ToString();
            dtNgayCC.Text = dgvHDCC.Rows[r].Cells[1].Value.ToString();
            cmbNV.SelectedValue = dgvHDCC.Rows[r].Cells[2].Value.ToString();
            cmbNCC.SelectedValue = dgvHDCC.Rows[r].Cells[3].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            dongnutchucnang();
            txtMaHD_CC.Text = dbhoadon.laymahoadon();
            dtNgayCC.Text = DateTime.Now.ToShortDateString();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
            dongnutchucnang();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn muốn xóa?", "Trả Lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                try
                {
                    // lay dong hien hanh
                    int r = dgvHDCC.CurrentCell.RowIndex;
                    string mahd = dgvHDCC.Rows[r].Cells[0].Value.ToString();
                    dbhoadon.delete(mahd);
                    loadhoadon();
                    MessageBox.Show("Đã xóa xong!!");
                }
                catch(Exception)
                {
                    MessageBox.Show("Không xóa được lỗi!!", "Lỗi", MessageBoxButtons.OK);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        { 
            DialogResult traloi = MessageBox.Show("Bạn muốn lưu?", "Trả Lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                if(them)
                {
                    try
                    {
                        dbhoadon.insert(dtNgayCC.Value, cmbNV.SelectedValue.ToString(), cmbNCC.SelectedValue.ToString());
                        loadhoadon();
                        MessageBox.Show("Thêm xong rồi!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch(Exception)
                    {
                        MessageBox.Show("Không thêm được!!! Lỗi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    try
                    {
                        dbhoadon.update(txtMaHD_CC.Text,dtNgayCC.Value, cmbNV.SelectedValue.ToString(), cmbNCC.SelectedValue.ToString());
                        loadhoadon();
                        MessageBox.Show("Sửa xong rồi!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Không Sửa được!!! Lỗi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn muốn hủy?", "Trả Lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                txtMaHD_CC.ResetText();
                loadhoadon();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadhoadon();
        }

        private void btnXemchitiet_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

            DialogResult traloi = MessageBox.Show("Bạn muốn thoát?", "Trả Lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
                this.Close();
        }
    }
}
