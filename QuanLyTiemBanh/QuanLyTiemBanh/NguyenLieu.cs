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
    public partial class NguyenLieu : Form
    {
        NguyenLieuBLL dbnguyenlieu = new NguyenLieuBLL();
        bool them;
        public NguyenLieu()
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
            txtMaNguyenLieu.Enabled = false;
        }
        void loadnguyenlieu()
        {
            // chuyen du lieu len datagridview
            dgvNguyenLieu.DataSource = dbnguyenlieu.laydanhsach();
            dgvNguyenLieu_CellClick(null, null);
            monutchucnang();

        }
        private void NguyenLieu_Load(object sender, EventArgs e)
        {
            loadnguyenlieu();
        }

        private void dgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // lay dong hien hanh 
            int r = dgvNguyenLieu.CurrentCell.RowIndex;
            // chuyen du lieu len 
            txtMaNguyenLieu.Text = dgvNguyenLieu.Rows[r].Cells[0].Value.ToString();
            txtTenNguyenLieu.Text = dgvNguyenLieu.Rows[r].Cells[1].Value.ToString();
            dtHanSuDung.Text = dgvNguyenLieu.Rows[r].Cells[2].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            dongnutchucnang();
            txtMaNguyenLieu.Text = dbnguyenlieu.laymanguyenlieu();
            txtMaNguyenLieu.Enabled = false;
            txtTenNguyenLieu.ResetText();
            dtHanSuDung.Text = DateTime.Now.ToShortDateString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
            dongnutchucnang();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn muốn xóa??", "Trả Lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                try
                {
                    // lay dong hien hnah 
                    int r = dgvNguyenLieu.CurrentCell.RowIndex;
                    // lay ma 
                    string ma = dgvNguyenLieu.Rows[r].Cells[0].Value.ToString();
                    dbnguyenlieu.delete(ma);
                    loadnguyenlieu();
                    MessageBox.Show("Đã xóa xong rối!!!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Không xóa được!!! Lỗi");
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn muốn lưu??", "Trả Lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                if (txtTenNguyenLieu.Text == null)
                    MessageBox.Show("Bạn bạn nhập đầy đủ thông tin!!");
                else
                {
                    if (them)
                    {
                        try
                        {
                            dbnguyenlieu.insert(txtTenNguyenLieu.Text, dtHanSuDung.Value);
                            loadnguyenlieu();
                            MessageBox.Show("Đã thêm xong rồi!!!");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Không thêm được!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        try
                        {
                            int r = dgvNguyenLieu.CurrentCell.RowIndex;
                            string ma = dgvNguyenLieu.Rows[r].Cells[0].Value.ToString();
                            dbnguyenlieu.update(ma, txtTenNguyenLieu.Text, dtHanSuDung.Value);
                            loadnguyenlieu();
                            MessageBox.Show("Đã sửa xong!!!");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Không sửa được!!!Lỗi", "Lỗi",MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn muốn hủy??", "Trả Lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                txtMaNguyenLieu.ResetText();
                txtTenNguyenLieu.ResetText();
                dgvNguyenLieu_CellClick(null, null);
                monutchucnang();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadnguyenlieu();
        }

        private void btnXemchitiet_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn muốn thoát??", "Trả Lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
                this.Close();
        }
    }
}
