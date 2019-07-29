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
    public partial class Khach : Form
    {
        LoaiKhachBLL dbloaikhach = new LoaiKhachBLL();
        KhachBLL dbkhach = new KhachBLL();
        bool them;
        public Khach()
        {
            InitializeComponent();
        }
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
            txtMaKH.Enabled = false;
        }
        void loadkhach()
        {
            // dua du lieu len combobox trong datagridview
            // chuyen du lieu len combobox tren dât grid view 
            (dgvKhachHang.Columns["LoaiKhach"] as DataGridViewComboBoxColumn).DataSource = dbloaikhach.laydanhsach();
            (dgvKhachHang.Columns["LoaiKhach"] as DataGridViewComboBoxColumn).DisplayMember = "TenLoaiKhach";
            (dgvKhachHang.Columns["LoaiKhach"] as DataGridViewComboBoxColumn).ValueMember = "MaLoaiKhach";
            // dua du lieu len datagridview
            dgvKhachHang.DataSource = dbkhach.laydanhsach();
            monutchucnang();
            dgvKhachHang_CellClick(null, null);
        }
        private void Khach_Load(object sender, EventArgs e)
        {
            loadkhach();
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // dua du lieu len combobox
            cmbLoaiKH.DataSource = dbloaikhach.laydanhsach();
            cmbLoaiKH.DisplayMember = "TenLoaiKhach";
            cmbLoaiKH.ValueMember = "MaLoaiKhach";
            // lay dong hien hanh
            int r = dgvKhachHang.CurrentCell.RowIndex;
            // chuyen len 
            txtMaKH.Text = dgvKhachHang.Rows[r].Cells[0].Value.ToString();
            txtTenKH.Text = dgvKhachHang.Rows[r].Cells[1].Value.ToString();
            dtNgaySinh.Text = dgvKhachHang.Rows[r].Cells[2].Value.ToString();
            txtDiaChi.Text = dgvKhachHang.Rows[r].Cells[3].Value.ToString();
            txtSDT.Text = dgvKhachHang.Rows[r].Cells[4].Value.ToString();
            txtEmail.Text = dgvKhachHang.Rows[r].Cells[5].Value.ToString();
            cmbLoaiKH.SelectedValue = dgvKhachHang.Rows[r].Cells[6].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            dongnutchucnang();
            txtMaKH.Text = dbloaikhach.laymaloaikhach();
            txtTenKH.ResetText();
            txtSDT.ResetText();
            txtEmail.ResetText();
            txtDiaChi.ResetText();
            dtNgaySinh.Text = DateTime.Now.ToShortDateString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
            dongnutchucnang();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn muốn xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                try
                {
                    int r = dgvKhachHang.CurrentCell.RowIndex;
                    string ma = dgvKhachHang.Rows[r].Cells[0].Value.ToString();
                    dbkhach.delete(ma);
                    loadkhach();
                    MessageBox.Show("Đã xóa xong!!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Không xóa được!! Lỗi!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn muốn lưu?", "Thong Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                if (txtTenKH.Text == null && txtSDT.Text == null && txtEmail.Text == null && txtDiaChi.Text == null)
                    MessageBox.Show("Mời bạn điền đầy đủ thông tin vào!!!");
                else
                { if (txtTenKH.Text == null || txtSDT.Text == null || txtEmail.Text == null || txtDiaChi.Text == null)
                    MessageBox.Show("Mời bạn điền đầy đủ thông tin vào!!!");
                    else
                    {
                        if (them)
                        {
                            try
                            {
                                dbkhach.insert(txtTenKH.Text, dtNgaySinh.Value, txtDiaChi.Text, txtSDT.Text, txtEmail.Text, cmbLoaiKH.SelectedValue.ToString());
                                loadkhach();
                                MessageBox.Show("Thêm xong Rồi!!!");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Không Thêm Được!!! Lỗi Rồi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            try
                            {
                                dbkhach.update(txtMaKH.Text, txtTenKH.Text, dtNgaySinh.Value, txtDiaChi.Text, txtSDT.Text, txtEmail.Text, cmbLoaiKH.SelectedValue.ToString());
                                loadkhach();
                                MessageBox.Show("Sửa xong Rồi!!!");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Không sửa được!!! Lỗi Rồi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn muốn hủy?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                monutchucnang();
                txtDiaChi.ResetText();
                txtEmail.ResetText();
                txtSDT.ResetText();
                txtTenKH.ResetText();
                dgvKhachHang_CellClick(null, null);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadkhach();
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
