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
    public partial class LoaiBanh : Form
    {
        LoaiBanhBLL dbloaibanh = new LoaiBanhBLL();
        bool them;

        public LoaiBanh()
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
            txtMaLoaiBanh.Enabled = false;
        }
        void loadloaibanh()
        {
            // dua du lieu len datagrid
            dgvLoaiBanh.DataSource = dbloaibanh.laydanhsach();
            dgvLoaiBanh_CellClick(null, null);
            monutchucnang();
        }
        private void LoaiBanh_Load(object sender, EventArgs e)
        {
            loadloaibanh();
        }

        private void dgvLoaiBanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvLoaiBanh.CurrentCell.RowIndex;
            txtMaLoaiBanh.Text = dgvLoaiBanh.Rows[r].Cells[0].Value.ToString();
            txtTenLoaiBanh.Text = dgvLoaiBanh.Rows[r].Cells[1].Value.ToString();
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            loadloaibanh();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn muốn thoát?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(traloi == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            dongnutchucnang();
            txtMaLoaiBanh.Text = dbloaibanh.laymabanh();
            txtTenLoaiBanh.ResetText();
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
                    int r = dgvLoaiBanh.CurrentCell.RowIndex;
                    string ma = dgvLoaiBanh.Rows[r].Cells[0].Value.ToString();
                    dbloaibanh.delete(ma);
                    loadloaibanh();
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
                if (txtTenLoaiBanh.Text == null)
                    MessageBox.Show("Mời bạn điền đầy đủ thông tin!!!");
                else
                {
                    if (them)
                    {
                        try
                        {
                            dbloaibanh.insert(txtTenLoaiBanh.Text);
                            loadloaibanh();
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
                            dbloaibanh.update(txtMaLoaiBanh.Text, txtTenLoaiBanh.Text);
                            loadloaibanh();
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn muốn hủy?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(traloi == DialogResult.Yes)
            {
                monutchucnang();
                txtTenLoaiBanh.ResetText();
                dgvLoaiBanh_CellClick(null, null);
            }
        }

        private void btnXemchitiet_Click(object sender, EventArgs e)
        {

        }
    }
}
