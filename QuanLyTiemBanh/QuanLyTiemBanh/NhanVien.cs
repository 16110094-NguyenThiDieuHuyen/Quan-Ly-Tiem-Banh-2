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
using System.IO;

namespace QuanLyTiemBanh
{
    public partial class NhanVien : Form
    {
        NhanVienBLL dbnhanhvien = new NhanVienBLL();
        bool them;
        MemoryStream ms;
        byte[] arrImage = null;
        public NhanVien()
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
            txtMaNV.Enabled = false;
        }
        void loadnhanvien()
        {
            dgvNV.DataSource = dbnhanhvien.laydanhsach();
            dgvNV_CellClick(null, null);
            monutchucnang();
        }
        private void NhanVien_Load(object sender, EventArgs e)
        {
            loadnhanvien();
        }

        private void dgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // lay dong hien hanah 
            int r = dgvNV.CurrentCell.RowIndex;
            txtMaNV.Text = dgvNV.Rows[r].Cells[0].Value.ToString();
            txtTenNV.Text = dgvNV.Rows[r].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvNV.Rows[r].Cells[2].Value.ToString();
            txtSDT.Text = dgvNV.Rows[r].Cells[3].Value.ToString();
            txtEmail.Text = dgvNV.Rows[r].Cells[4].Value.ToString();
            dtNgayVaoLam.Text = dgvNV.Rows[r].Cells[5].Value.ToString();
            txtLuong.Text = dgvNV.Rows[r].Cells[6].Value.ToString();
            picNV.Image = (System.Drawing.Image)dgvNV.Rows[r].Cells[7].FormattedValue;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            txtMaNV.Text = dbnhanhvien.layma();
            txtMaNV.Enabled = false;
            txtSDT.ResetText();
            txtTenNV.ResetText();
            txtLuong.ResetText();
            txtEmail.ResetText();
            txtDiaChi.ResetText();
            dtNgayVaoLam.Text = DateTime.Now.ToShortDateString();
            dongnutchucnang();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
            dongnutchucnang();
            txtMaNV.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn muốn xóa?", "Trả Lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                try
                {
                    // lấy dòng hiện hành
                    int r =dgvNV.CurrentCell.RowIndex;
                    string Ma = dgvNV.Rows[r].Cells[0].Value.ToString();
                    // gọi hàm xóa bánh
                    dbnhanhvien.delete(Ma);
                    // cập nhập lại datagridview
                    loadnhanvien();
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
                if (txtTenNV.Text == null && txtSDT.Text == null && txtLuong.Text == null && txtEmail.Text == null && txtDiaChi.Text == null)
                    MessageBox.Show("Mời bạn điền đầy đủ thông tin");
                else
                {
                    if (txtTenNV.Text == null || txtSDT.Text == null || txtLuong.Text == null || txtEmail.Text == null || txtDiaChi.Text == null)
                        MessageBox.Show("Mời bạn điền đầy đủ thông tin");
                    else
                    {
                        decimal luong;
                        decimal.TryParse(txtLuong.Text, out luong);
                        if (luong <= 0)
                            MessageBox.Show("Lương phải lớn hơn 0 và phải là số!!!");
                        else
                        {
                            if (them)
                            {
                                try
                                {
                                    // goi ham luu
                                    if (arrImage != null)
                                    {
                                        dbnhanhvien.insertwithimage(txtTenNV.Text,txtDiaChi.Text,txtSDT.Text,txtEmail.Text,dtNgayVaoLam.Value,luong, arrImage);
                                    }
                                    else dbnhanhvien.insernotimage(txtTenNV.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text, dtNgayVaoLam.Value, luong);
                                    loadnhanvien();
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
                                    // lay dong hien hnah 
                                    int r = dgvNV.CurrentCell.RowIndex;
                                    string ma = dgvNV.Rows[r].Cells[0].Value.ToString();
                                    // goi ham sua
                                    if (arrImage != null)
                                    {
                                        dbnhanhvien.updatewithimage(ma, txtTenNV.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text, dtNgayVaoLam.Value, luong,arrImage);
                                    }
                                    else dbnhanhvien.updatenotimage(ma, txtTenNV.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text, dtNgayVaoLam.Value, luong);
                                    loadnhanvien();
                                    MessageBox.Show("Sửa xong rùi!!!", "Thông Báo", MessageBoxButtons.OK);
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Không sửa được!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
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
                txtMaNV.ResetText();
                txtSDT.ResetText();
                txtTenNV.ResetText();
                txtLuong.ResetText();
                txtEmail.ResetText();
                txtDiaChi.ResetText();
                // cho  thao tac cac nut chuc nang 
                monutchucnang();
                dgvNV_CellClick(null, null);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadnhanvien();
        }

        private void btnXemchitiet_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes) this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.InitialDirectory = "C:\\";
            openfile.Title = "OpenFile";
            openfile.Filter = "Image files (*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp|All files (*.*)|*.*";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                picNV.Image = System.Drawing.Image.FromFile(openfile.FileName);
                //
                ms = new MemoryStream();
                picNV.Image.Save(ms, picNV.Image.RawFormat);
                arrImage = ms.GetBuffer();
                ms.Close();
            }
        }
    }
}
