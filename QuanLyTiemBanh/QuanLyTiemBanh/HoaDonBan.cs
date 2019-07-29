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
    public partial class HoaDonBan : Form
    {
        HoaDonBanBLL dbhoadonban = new HoaDonBanBLL();
        KhachBLL dbkhach = new KhachBLL();
        NhanVienBLL dbnhanvien = new NhanVienBLL();
        bool them;
        public HoaDonBan()
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
            groupBox1.Enabled = false;
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
            groupBox1.Enabled = true;
            txtMaHoaDon.Enabled = false;
        }
       void loadhoadon()
        {
            // chuyen du lieu len combobox trong datagridview
            // chuyen du lieu len combobox tren dât grid view 
            (dgvHoaDon.Columns["Khachid"] as DataGridViewComboBoxColumn).DataSource = dbkhach.laydanhsach();
            (dgvHoaDon.Columns["Khachid"] as DataGridViewComboBoxColumn).DisplayMember = "TenKhach";
            (dgvHoaDon.Columns["Khachid"] as DataGridViewComboBoxColumn).ValueMember = "MaKhach";
            (dgvHoaDon.Columns["NhanVienid"] as DataGridViewComboBoxColumn).DataSource =dbnhanvien.laydanhsach();
            (dgvHoaDon.Columns["NhanVienid"] as DataGridViewComboBoxColumn).DisplayMember = "TenNhanVien";
            (dgvHoaDon.Columns["NhanVienid"] as DataGridViewComboBoxColumn).ValueMember = "MaNhanVien";
            dgvHoaDon.DataSource = dbhoadonban.laydanhsach();
            dgvHoaDon_CellClick(null, null);
            monutchucnang();
        }
        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // dua du lieu len combobox
            cbbMaKhachHang.DataSource = dbkhach.laydanhsach();
            cbbMaKhachHang.DisplayMember = "TenKhach";
            cbbMaKhachHang.ValueMember = "MaKhach";
            CbbMaNV.DataSource = dbnhanvien.laydanhsach();
            CbbMaNV.DisplayMember = "TenNhanVien";
            CbbMaNV.ValueMember = "MaNhanVien";
            // lay dong hien hanh 
            int r = dgvHoaDon.CurrentCell.RowIndex;
            txtMaHoaDon.Text = dgvHoaDon.Rows[r].Cells[0].Value.ToString();
            dtThoigian.Text = dgvHoaDon.Rows[r].Cells[3].Value.ToString();
            cbbMaKhachHang.SelectedValue = dgvHoaDon.Rows[r].Cells[1].ToString();
            CbbMaNV.SelectedValue = dgvHoaDon.Rows[r].Cells[2].ToString();
        }

        private void HoaDonBan_Load(object sender, EventArgs e)
        {
            loadhoadon();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            dongnutchucnang();
            txtMaHoaDon.Text = dbhoadonban.laymahoadon();
            dtThoigian.Text = DateTime.Now.ToShortDateString();
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
                    // lấy dòng hiện hành
                    int r = dgvHoaDon.CurrentCell.RowIndex;
                    string Ma = dgvHoaDon.Rows[r].Cells[0].Value.ToString();
                    // gọi hàm xóa bánh
                    dbhoadonban.delete(Ma);
                    // cập nhập lại datagridview
                    loadhoadon();
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
                if(them)
                {
                    try
                    {
                        dbhoadonban.insert(dtThoigian.Value, CbbMaNV.SelectedValue.ToString(), cbbMaKhachHang.SelectedValue.ToString());
                        loadhoadon();
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
                        dbhoadonban.update(txtMaHoaDon.Text, dtThoigian.Value, CbbMaNV.SelectedValue.ToString(), cbbMaKhachHang.SelectedValue.ToString());
                        MessageBox.Show("Sửa xong rùi!!!", "Thông Báo", MessageBoxButtons.OK);
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("Không sửa được!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn muốn hủy?", "Trả Lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                txtMaHoaDon.ResetText();
                monutchucnang();
                dgvHoaDon_CellClick(null, null);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadhoadon();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes) this.Close();
        }

        private void btnXemchitiet_Click(object sender, EventArgs e)
        {

        }
    }
}
