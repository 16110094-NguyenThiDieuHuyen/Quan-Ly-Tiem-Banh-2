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
    public partial class TaiKhoan : Form
    {
        TaiKhoanBLL dbtaikhoan = new TaiKhoanBLL();
        NhanVienBLL dbnhanvien = new NhanVienBLL();
        bool them;
        public TaiKhoan()
        {
            InitializeComponent();
        }
        void monutchucnang()
        {
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnReload.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnThoat.Enabled = true;
            btnXoa.Enabled = true;
            panel1.Enabled = false;
        }
        // dong cac nut chuc nang
        void dongnutchucnang()
        {
            btnXoa.Enabled = false;
            btnThoat.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnReload.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            panel1.Enabled = true;
        }
        void loadTaiKhoan()
        {
            // dua du lieu len combobox
            (dgvTaiKhoan.Columns["MaNhanVien"] as DataGridViewComboBoxColumn).DataSource = dbnhanvien.laydanhsach();
            (dgvTaiKhoan.Columns["MaNhanVien"] as DataGridViewComboBoxColumn).DisplayMember = "TenNhanVien";
            (dgvTaiKhoan.Columns["MaNhanVien"] as DataGridViewComboBoxColumn).ValueMember = "MaNhanVien";
            dgvTaiKhoan.DataSource = dbtaikhoan.laydanhsachnhanvien();
            monutchucnang();
            dgvTaiKhoan_CellClick(null, null);
        }
        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            loadTaiKhoan();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            dongnutchucnang();
            txtEmail.ResetText();
            txtPassword.ResetText();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
            dongnutchucnang();
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

        }

        private void btnReload_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
