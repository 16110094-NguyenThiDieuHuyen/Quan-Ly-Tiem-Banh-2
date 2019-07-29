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
    public partial class ChiTietBanh : Form
    {
        BanhBLL dbbanh = new BanhBLL();
        NguyenLieuBLL dbnguyenlieu = new NguyenLieuBLL();
        ChiTietNguyenLieuBLL dbchitietbanh = new ChiTietNguyenLieuBLL();
        bool them;
        public ChiTietBanh()
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
        }
        void loadchitietbanh()
        {
            // chuyen du lieu len 
            (dgvChiTietHoaDon.Columns["MaBanh"] as DataGridViewComboBoxColumn).DataSource = dbbanh.laydanhsach();
            (dgvChiTietHoaDon.Columns["MaBanh"] as DataGridViewComboBoxColumn).DisplayMember = "TenBanh";
            (dgvChiTietHoaDon.Columns["MaBanh"] as DataGridViewComboBoxColumn).ValueMember = "MaBanh";
            (dgvChiTietHoaDon.Columns["MaNguyenLieu"] as DataGridViewComboBoxColumn).DataSource = dbnguyenlieu.laydanhsach();
            (dgvChiTietHoaDon.Columns["MaNguyenLieu"] as DataGridViewComboBoxColumn).DisplayMember = "TenNguyenLieu";
            (dgvChiTietHoaDon.Columns["MaNguyenLieu"] as DataGridViewComboBoxColumn).ValueMember = "MaNguyenLieu";
            dgvChiTietHoaDon.DataSource = dbchitietbanh.laydanhsach();
            dgvChiTietHoaDon_CellClick(null, null);
            monutchucnang();
        }
        private void dgvChiTietHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // chuyen du lieu len combobox tren pannel
            cmbBanh.DataSource = dbbanh.laydanhsach();
            cmbBanh.DisplayMember = "MaBanh";
            cmbBanh.ValueMember = "TenBanh";
            cmbNguyenLieu.DataSource = dbnguyenlieu.laydanhsach();
            cmbNguyenLieu.DisplayMember = "TenNguyenLieu";
            cmbNguyenLieu.ValueMember = "MaNguyenLieu";
            // lay dng hien hanh 
            int r = dgvChiTietHoaDon.CurrentCell.RowIndex;
            cmbBanh.SelectedValue = dgvChiTietHoaDon.Rows[r].Cells[0].Value.ToString();
            cmbNguyenLieu.SelectedValue = dgvChiTietHoaDon.Rows[r].Cells[1].Value.ToString();
            txtKhoiluong.Text = dgvChiTietHoaDon.Rows[r].Cells[2].Value.ToString();
        }

        private void ChiTietBanh_Load(object sender, EventArgs e)
        {
            loadchitietbanh();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            dongnutchucnang();
            cmbBanh.Enabled = true;
            cmbBanh.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
            dongnutchucnang();
            cmbBanh.Enabled = false;
            cmbBanh.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn muốn xóa?", "Trả Lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                try
                {
                    // lấy dòng hiện hành
                    int r = dgvChiTietHoaDon.CurrentCell.RowIndex;
                    string MaBanh = dgvChiTietHoaDon.Rows[r].Cells[0].Value.ToString();
                    string MaNguyenLieu = dgvChiTietHoaDon.Rows[r].Cells[1].Value.ToString();
                    // gọi hàm xóa bánh
                    dbchitietbanh.delete(MaBanh, MaNguyenLieu);
                    // cập nhập lại datagridview
                    loadchitietbanh();
                    dgvChiTietHoaDon_CellClick(null, null);
                    MessageBox.Show("Đã xóa xxong!!!", "Thông Báo", MessageBoxButtons.OK);
                }
                catch (Exception)
                {
                    MessageBox.Show("Không xóa được!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn muốn lưu?", "Trả Lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                if (txtKhoiluong.Text == null)
                    MessageBox.Show("Mời bạn điền đầy đủ thông tin");
                else
                {
                    float KhoiLuong;
                    float.TryParse(txtKhoiluong.Text, out KhoiLuong);
                    if (KhoiLuong <= 0)
                        MessageBox.Show("Đơn giá phải lớn hơn 0 và phải là chữ số!!!");
                    else {
                        if (them)
                        {
                            try
                            {
                                dbchitietbanh.insert(cmbBanh.SelectedValue.ToString(), cmbNguyenLieu.SelectedValue.ToString(), KhoiLuong);
                                loadchitietbanh();
                                MessageBox.Show("Lưu xong rùi!!!", "Thông Báo", MessageBoxButtons.OK);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Không lưu được!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            try
                            {
                                dbchitietbanh.update(cmbBanh.SelectedValue.ToString(), cmbNguyenLieu.SelectedValue.ToString(), KhoiLuong);
                                loadchitietbanh();
                                MessageBox.Show("Sửa xong rùi!!!", "Thông Báo", MessageBoxButtons.OK);
                            }
                            catch(Exception)
                            {
                                MessageBox.Show("Không sửa được!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn muốn hủy?", "Trả Lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                txtKhoiluong.ResetText();
                // cho  thao tac cac nut chuc nang 
                monutchucnang();
                dgvChiTietHoaDon_CellClick(null, null);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadchitietbanh();
        }

        private void btnXemchitiet_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes) this.Close();
        }
    }
}
