7using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTiemBanhBLL;
using QuanLyTiemBanhDAL;

namespace QuanLyTiemBanh
{
    public partial class Banh : Form
    {
        // khai bao cac bien can su dung 
        BanhBLL dbbanh = new BanhBLL();
        LoaiBanhBLL dbLoaiBanh = new LoaiBanhBLL();
        bool them;
        MemoryStream ms;
        byte[] arrImage = null;// mang dung de doc du lieu hinh anh
        public Banh()
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
            btnBrowse.Enabled = false;
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
            btnBrowse.Enabled = true;
            panel1.Enabled = true;
            txtMaBanh.Enabled = false;
        }
        void load()
        {
            // chuyen du lieu len combobox tren dât grid view 
            (dgvBanh.Columns["LoaiBanh"] as DataGridViewComboBoxColumn).DataSource = dbLoaiBanh.laydanhsach();
            (dgvBanh.Columns["LoaiBanh"] as DataGridViewComboBoxColumn).DisplayMember = "TenLoaiBanh";
            (dgvBanh.Columns["LoaiBanh"] as DataGridViewComboBoxColumn).ValueMember = "MaLoaiBanh";
            // dua du lieu len datagridview
            dgvBanh.DataSource = dbbanh.laydanhsach();
            dgvBanh_CellClick(null, null);
            monutchucnang();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            dongnutchucnang();
            txtMaBanh.Text = dbbanh.laymabanh();
            txtMoTa.ResetText();
            txtTenBanh.ResetText();
            txtDonGia.ResetText();
            txtTenBanh.Focus();
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
                    int r = dgvBanh.CurrentCell.RowIndex;
                    string MaBanh = dgvBanh.Rows[r].Cells[0].Value.ToString();
                    // gọi hàm xóa bánh
                   dbbanh.deletebanh(MaBanh);
                    // cập nhập lại datagridview
                    load();
                    dgvBanh_CellClick(null, null);
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
                if (txtTenBanh.Text == null && txtDonGia.Text == null && txtMoTa.Text == null)
                    MessageBox.Show("Mời bạn điền đầy đủ thông tin");
                else
                {
                    if (txtTenBanh.Text == null || txtDonGia.Text == null || txtMoTa.Text == null)
                        MessageBox.Show("Mời bạn điền đầy đủ thông tin");
                    else
                    {
                        decimal dongia;
                        decimal.TryParse(txtDonGia.Text, out dongia);
                        if (dongia <= 0)
                            MessageBox.Show("Đơn giá phải lớn hơn 0 và phải là chữ số!!!");
                        else
                        {
                            if (them)
                            {
                                try
                                {
                                    // goi ham luu
                                    if (arrImage != null)
                                    {
                                        dbbanh.insertwithimage(txtTenBanh.Text, dongia, txtMoTa.Text, cmbLoaiBanh.SelectedValue.ToString(), arrImage);
                                    }
                                    else dbbanh.insertnotimage(txtTenBanh.Text, decimal.Parse(txtDonGia.Text), txtMoTa.Text, cmbLoaiBanh.SelectedValue.ToString());
                                    load();
                                    dgvBanh_CellClick(null, null);
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
                                    // goi ham sua
                                    if (arrImage != null)
                                    {
                                        dbbanh.updatewithimage(txtMaBanh.Text, txtTenBanh.Text, decimal.Parse(txtDonGia.Text), txtMoTa.Text, cmbLoaiBanh.SelectedValue.ToString(), arrImage);
                                    }
                                    else dbbanh.updatenotimage(txtMaBanh.Text, txtTenBanh.Text, decimal.Parse(txtDonGia.Text), txtMoTa.Text, cmbLoaiBanh.SelectedValue.ToString());
                                    load();
                                    dgvBanh_CellClick(null, null);
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
                txtTenBanh.ResetText();
                txtDonGia.ResetText();
                txtMoTa.ResetText();
                // cho  thao tac cac nut chuc nang 
                monutchucnang();
                dgvBanh_CellClick(null, null);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            load();
            dgvBanh_CellClick(null, null);
            monutchucnang();
        }

        private void btnXemchitiet_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes) this.Close();
        }

        private void Banh_Load(object sender, EventArgs e)
        {
            load();
            dgvBanh_CellClick(null, null);
        }

        private void dgvBanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // dua du lieu len combobox
            cmbLoaiBanh.DataSource = dbLoaiBanh.laydanhsach();
            cmbLoaiBanh.DisplayMember = "TenLoaiBanh";
            cmbLoaiBanh.ValueMember = "MaLoaiBanh";
            int r = dgvBanh.CurrentCell.RowIndex;
            // dua du lieu len pannel
            txtMaBanh.Text = dgvBanh.Rows[r].Cells[0].Value.ToString();
            txtTenBanh.Text = dgvBanh.Rows[r].Cells[1].Value.ToString();
            txtDonGia.Text = dgvBanh.Rows[r].Cells[2].Value.ToString();
            txtMoTa.Text = dgvBanh.Rows[r].Cells[3].Value.ToString();
            cmbLoaiBanh.SelectedValue = dgvBanh.Rows[r].Cells[4].Value.ToString();
            picHinh.Image = (System.Drawing.Image)dgvBanh.Rows[r].Cells[5].FormattedValue;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.InitialDirectory = "C:\\";
            openfile.Title = "OpenFile";
            openfile.Filter = "Image files (*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp|All files (*.*)|*.*";
            if(openfile.ShowDialog() == DialogResult.OK)
            {
                picHinh.Image = System.Drawing.Image.FromFile(openfile.FileName);
                //
                ms = new MemoryStream();
                picHinh.Image.Save(ms, picHinh.Image.RawFormat);
                arrImage = ms.GetBuffer();
                ms.Close();
            }
        }
    }
}
