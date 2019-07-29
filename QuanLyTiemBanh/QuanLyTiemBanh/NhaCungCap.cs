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
    public partial class NhaCungCap : Form
    {
        NhaCungCapBLL dbnhacungcap = new NhaCungCapBLL();
        bool them;
        public NhaCungCap()
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
            txtMaNCC.Enabled = false;
        }
        void loadnhacungcap()
        {
            dgvNCC.DataSource = dbnhacungcap.laydanhsach();
            dgvNCC_CellClick(null, null);
            monutchucnang();
        }
        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            loadnhacungcap();
        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // lay dong hien hnah 
            int r = dgvNCC.CurrentCell.RowIndex;
            txtMaNCC.Text = dgvNCC.Rows[r].Cells[0].Value.ToString();
            txtTen_NCC.Text = dgvNCC.Rows[r].Cells[1].Value.ToString();
            txtSDT_NCC.Text = dgvNCC.Rows[r].Cells[2].Value.ToString();
            txtDiaChi_NCC.Text = dgvNCC.Rows[r].Cells[3].Value.ToString();
            txtEmail_NCC.Text = dgvNCC.Rows[r].Cells[4].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            dongnutchucnang();
            txtMaNCC.Text = dbnhacungcap.laymanhacungcap();
            txtTen_NCC.ResetText();
            txtSDT_NCC.ResetText();
            txtEmail_NCC.ResetText();
            txtDiaChi_NCC.ResetText();
            txtTen_NCC.Focus();
            txtMaNCC.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
            dongnutchucnang();
            txtMaNCC.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn muốn xóa??", "Trả Lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                try
                {
                    // lay dong hien hnah 
                    int r = dgvNCC.CurrentCell.RowIndex;
                    // lay ma 
                    string ma = dgvNCC.Rows[r].Cells[0].Value.ToString();
                    dbnhacungcap.delete(ma);
                    loadnhacungcap();
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
                if (txtTen_NCC.Text == null && txtSDT_NCC.Text == null && txtEmail_NCC.Text == null && txtDiaChi_NCC.Text == null)
                    MessageBox.Show("Mời bạn điền đầy đủ  thông tin");
                else
                {
                    if (txtTen_NCC.Text == null || txtSDT_NCC.Text == null || txtEmail_NCC.Text == null || txtDiaChi_NCC.Text == null)
                        MessageBox.Show("Mời bạn điền đầy đủ thông tin");
                    else
                    {
                        if(them)
                        {
                            try
                            {
                                dbnhacungcap.insert(txtTen_NCC.Text, txtSDT_NCC.Text, txtDiaChi_NCC.Text, txtEmail_NCC.Text);
                                loadnhacungcap();
                                MessageBox.Show("Đã thêm xong rồi!!!");
                            }
                            catch(Exception)
                            {
                                MessageBox.Show("Không thêm được!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            try
                            {
                                int r = dgvNCC.CurrentCell.RowIndex;
                                string ma = dgvNCC.Rows[r].Cells[0].Value.ToString();
                                dbnhacungcap.update(ma,txtTen_NCC.Text,txtSDT_NCC.Text,txtDiaChi_NCC.Text,txtEmail_NCC.Text);
                                loadnhacungcap();
                                MessageBox.Show("Đã sửa xong!!!");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Không sửa được!!!Lỗi", "Lỗi", MessageBoxButtons.OK);
                            }

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
                txtMaNCC.ResetText();
                txtTen_NCC.ResetText();
                txtSDT_NCC.ResetText();
                txtEmail_NCC.ResetText();
                txtDiaChi_NCC.ResetText();
                dgvNCC_CellClick(null, null);
                monutchucnang();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadnhacungcap();
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
