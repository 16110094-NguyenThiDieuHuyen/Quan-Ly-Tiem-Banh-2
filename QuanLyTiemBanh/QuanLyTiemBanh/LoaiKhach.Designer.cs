namespace QuanLyTiemBanh
{
    partial class LoaiKhach
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoaiKhach));
            this.grBThongTinh = new System.Windows.Forms.GroupBox();
            this.txtLoaiKhach = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaloai = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvLoaiKhach = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.maLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiBanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXemchitiet = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.grBThongTinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiKhach)).BeginInit();
            this.SuspendLayout();
            // 
            // grBThongTinh
            // 
            this.grBThongTinh.Controls.Add(this.txtLoaiKhach);
            this.grBThongTinh.Controls.Add(this.label2);
            this.grBThongTinh.Controls.Add(this.txtMaloai);
            this.grBThongTinh.Controls.Add(this.label3);
            this.grBThongTinh.Location = new System.Drawing.Point(8, 62);
            this.grBThongTinh.Name = "grBThongTinh";
            this.grBThongTinh.Size = new System.Drawing.Size(343, 97);
            this.grBThongTinh.TabIndex = 68;
            this.grBThongTinh.TabStop = false;
            this.grBThongTinh.Text = "Thông tin";
            // 
            // txtLoaiKhach
            // 
            this.txtLoaiKhach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoaiKhach.Location = new System.Drawing.Point(108, 61);
            this.txtLoaiKhach.Name = "txtLoaiKhach";
            this.txtLoaiKhach.Size = new System.Drawing.Size(184, 26);
            this.txtLoaiKhach.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Loại khách";
            // 
            // txtMaloai
            // 
            this.txtMaloai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaloai.Location = new System.Drawing.Point(108, 19);
            this.txtMaloai.Name = "txtMaloai";
            this.txtMaloai.Size = new System.Drawing.Size(184, 26);
            this.txtMaloai.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Mã loại";
            // 
            // dgvLoaiKhach
            // 
            this.dgvLoaiKhach.AllowUserToOrderColumns = true;
            this.dgvLoaiKhach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaiKhach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maLoai,
            this.LoaiBanh});
            this.dgvLoaiKhach.Location = new System.Drawing.Point(8, 177);
            this.dgvLoaiKhach.Name = "dgvLoaiKhach";
            this.dgvLoaiKhach.Size = new System.Drawing.Size(343, 227);
            this.dgvLoaiKhach.TabIndex = 67;
            this.dgvLoaiKhach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoaiKhach_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(56, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 50);
            this.label1.TabIndex = 66;
            this.label1.Text = "LOẠI KHÁCH";
            // 
            // maLoai
            // 
            this.maLoai.DataPropertyName = "MaLoaiKhach";
            this.maLoai.HeaderText = "Mã loại";
            this.maLoai.Name = "maLoai";
            this.maLoai.Width = 150;
            // 
            // LoaiBanh
            // 
            this.LoaiBanh.DataPropertyName = "TenLoaiKhach";
            this.LoaiBanh.HeaderText = "Loại khách";
            this.LoaiBanh.Name = "LoaiBanh";
            this.LoaiBanh.Width = 150;
            // 
            // btnXemchitiet
            // 
            this.btnXemchitiet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnXemchitiet.BackgroundImage")));
            this.btnXemchitiet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnXemchitiet.Location = new System.Drawing.Point(414, 70);
            this.btnXemchitiet.Name = "btnXemchitiet";
            this.btnXemchitiet.Size = new System.Drawing.Size(51, 51);
            this.btnXemchitiet.TabIndex = 76;
            this.btnXemchitiet.UseVisualStyleBackColor = true;
            this.btnXemchitiet.Click += new System.EventHandler(this.btnXemchitiet_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThem.BackgroundImage")));
            this.btnThem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThem.Location = new System.Drawing.Point(357, 70);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(51, 51);
            this.btnThem.TabIndex = 69;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSua.BackgroundImage")));
            this.btnSua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSua.Location = new System.Drawing.Point(357, 127);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(51, 51);
            this.btnSua.TabIndex = 75;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThoat.BackgroundImage")));
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThoat.Location = new System.Drawing.Point(414, 355);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(51, 51);
            this.btnThoat.TabIndex = 73;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHuy.BackgroundImage")));
            this.btnHuy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHuy.Location = new System.Drawing.Point(357, 298);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(51, 51);
            this.btnHuy.TabIndex = 74;
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnReload
            // 
            this.btnReload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReload.BackgroundImage")));
            this.btnReload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReload.Location = new System.Drawing.Point(357, 355);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(51, 51);
            this.btnReload.TabIndex = 72;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnXoa.BackgroundImage")));
            this.btnXoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnXoa.Location = new System.Drawing.Point(357, 184);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(51, 51);
            this.btnXoa.TabIndex = 71;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLuu.BackgroundImage")));
            this.btnLuu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLuu.Location = new System.Drawing.Point(357, 241);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(51, 51);
            this.btnLuu.TabIndex = 70;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // LoaiKhach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 450);
            this.Controls.Add(this.btnXemchitiet);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.grBThongTinh);
            this.Controls.Add(this.dgvLoaiKhach);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "LoaiKhach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Muc Loai Khach";
            this.Load += new System.EventHandler(this.LoaiKhach_Load);
            this.grBThongTinh.ResumeLayout(false);
            this.grBThongTinh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiKhach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grBThongTinh;
        private System.Windows.Forms.TextBox txtLoaiKhach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaloai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvLoaiKhach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn maLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiBanh;
        private System.Windows.Forms.Button btnXemchitiet;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
    }
}