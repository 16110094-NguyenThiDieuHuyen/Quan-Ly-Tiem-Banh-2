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
    public partial class LoaiKhach : Form
    {
        LoaiKhachBLL dbloaikhach = new LoaiKhachBLL();
        bool them;
        public LoaiKhach()
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
            grBThongTinh.Enabled = false;
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
            grBThongTinh.Enabled = true;
           txtMaloai.Enabled = false;
        }
        void loadloiakhach()
        {
            // dua 9du lieu len datagridview
            dgvLoaiKhach.DataSource = dbloaikhach.laydanhsach();
            monutchucnang();
            dgvLoaiKhach_CellClick(null, null);
        }

        private void LoaiKhach_Load(object sender, EventArgs e)
        {
            loadloiakhach();
        }

        private void dgvLoaiKhach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // lay dong hien hanh
            int r = dgvLoaiKhach.CurrentCell.RowIndex;
            txtMaloai.Text = dgvLoaiKhach.Rows[r].Cells[0].Value.ToString();
            txtLoaiKhach.Text = dgvLoaiKhach.Rows[r].Cells[1].Value.ToString();

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadloiakhach();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn muốn thoát?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            dongnutchucnang();
            txtMaloai.Text = dbloaikhach.laymaloaikhach();
            txtLoaiKhach.ResetText();
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
                    int r = dgvLoaiKhach.CurrentCell.RowIndex;
                    string ma = dgvLoaiKhach.Rows[r].Cells[0].Value.ToString();
                    dbloaikhach.delete(ma);
                    loadloiakhach();
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
                if (txtLoaiKhach.Text == null)
                    MessageBox.Show("Mời bạn điền đầy đủ thông tin!!!");
                else
                {
                    if (them)
                    {
                        try
                        {
                            dbloaikhach.insert(txtLoaiKhach.Text);
                            loadloiakhach();
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
                            dbloaikhach.update(txtMaloai.Text, txtLoaiKhach.Text);
                            loadloiakhach();
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
            if (traloi == DialogResult.Yes)
            {
                monutchucnang();
              txtLoaiKhach.ResetText();
                dgvLoaiKhach_CellClick(null, null);
            }
        }

        private void btnXemchitiet_Click(object sender, EventArgs e)
        {

        }
    }
}
