using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTiemBanhDAL;

namespace QuanLyTiemBanhBLL
{
   public class KhachBLL
    {
        QuanLyTiemBanhDataContext db = new QuanLyTiemBanhDataContext();
        // lay dah sach 
        public List<Khach> laydanhsach()
        {
            return db.Khaches.ToList();
        }
        // lay ma
       public string laymakhach()
        {
            return "K" + db.Khaches.Count().ToString();
        }
        public void insert(string ten,DateTime ngaysinh,string diachi,string sodienthoai,string email,string maloaikhach)
        {
            Khach khach = new Khach();
            khach.MaKhach = laymakhach();
            khach.Tenkhach = ten;
            khach.DiaChi = diachi;
            khach.SoDienThoai = sodienthoai;
            khach.NgaySinh = ngaysinh;
            khach.Email = email;
            khach.MaLoaiKhach = maloaikhach;
            db.Khaches.InsertOnSubmit(khach);
            db.SubmitChanges();
        }
        public void update(string ma, string ten, DateTime ngaysinh, string diachi, string sodienthoai, string email, string maloaikhach)
        {
            Khach khach = db.Khaches.Single(p => p.MaKhach == ma);
            khach.Tenkhach = ten;
            khach.DiaChi = diachi;
            khach.SoDienThoai = sodienthoai;
            khach.NgaySinh = ngaysinh;
            khach.Email = email;
            khach.MaLoaiKhach = maloaikhach;
            db.SubmitChanges();
        }
        // xoa 
        public void delete(string ma)
        {
            Khach khach = db.Khaches.Single(p => p.MaKhach == ma);
            db.Khaches.DeleteOnSubmit(khach);
            db.SubmitChanges();
        }
    }
}
