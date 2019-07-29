using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTiemBanhDAL;

namespace QuanLyTiemBanhBLL
{
   public class NhanVienBLL
    {
        // chuoi ket noi
        QuanLyTiemBanhDataContext db = new QuanLyTiemBanhDataContext();
        // ham lay danh sach 
        public List<NhanVien> laydanhsach()
        {
            return db.NhanViens.ToList();
        }
        // ham lay ma nhan vien 
       public string layma()
        {
            return "NV" + db.NhanViens.Count().ToString();
        }
        //ham them han vien voi hinh anh 
        public void insertwithimage(string ten, string diachi, string sodienthoai, string email,DateTime ngay, decimal luong, byte[] photo)
        {
            NhanVien nhanVien = new NhanVien();
            nhanVien.MaNhanVien = layma();
            nhanVien.TenNhanVien = ten;
            nhanVien.DiaChi = diachi;
            nhanVien.SoDienThoai = sodienthoai;
            nhanVien.Email = email;
            nhanVien.NgayBatDauLam = ngay;
            nhanVien.Luong = luong;
            nhanVien.PhoTo = photo;
            db.NhanViens.InsertOnSubmit(nhanVien);
            db.SubmitChanges();
        }
        public void insernotimage(string ten, string diachi, string sodienthoai, string email, DateTime ngay, decimal luong)
        {
            NhanVien nhanVien = new NhanVien();
            nhanVien.MaNhanVien = layma();
            nhanVien.TenNhanVien = ten;
            nhanVien.DiaChi = diachi;
            nhanVien.SoDienThoai = sodienthoai;
            nhanVien.Email = email;
            nhanVien.NgayBatDauLam = ngay;
            nhanVien.Luong = luong;
            db.NhanViens.InsertOnSubmit(nhanVien);
            db.SubmitChanges();
        }
        // update
        public void updatewithimage(string ma,string ten, string diachi, string sodienthoai, string email, DateTime ngay, decimal luong, byte[] photo)
        {
            NhanVien nhanVien = db.NhanViens.Single(p => p.MaNhanVien == ma);
            nhanVien.TenNhanVien = ten;
            nhanVien.DiaChi = diachi;
            nhanVien.SoDienThoai = sodienthoai;
            nhanVien.Email = email;
            nhanVien.NgayBatDauLam = ngay;
            nhanVien.Luong = luong;
            nhanVien.PhoTo = photo;
            db.SubmitChanges();
        }
        public void updatenotimage(string ma, string ten, string diachi, string sodienthoai, string email, DateTime ngay, decimal luong)
        {
            NhanVien nhanVien = db.NhanViens.Single(p => p.MaNhanVien == ma);
            nhanVien.TenNhanVien = ten;
            nhanVien.DiaChi = diachi;
            nhanVien.SoDienThoai = sodienthoai;
            nhanVien.Email = email;
            nhanVien.NgayBatDauLam = ngay;
            nhanVien.Luong = luong;
            db.SubmitChanges();
        }
        // delete
        public void delete(string ma)
        {
            NhanVien nhanVien = db.NhanViens.Single(p => p.MaNhanVien == ma);
            db.NhanViens.DeleteOnSubmit(nhanVien);
            db.SubmitChanges();
        }
    }
}
