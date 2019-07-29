using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTiemBanhDAL;

namespace QuanLyTiemBanhBLL
{
   public class LoaiKhachBLL
    {
        QuanLyTiemBanhDataContext db = new QuanLyTiemBanhDataContext();
        // ham lay danh sach 
        public List<LoaiKhach> laydanhsach()
        {
            return db.LoaiKhaches.ToList();
        }
        // lay ma loai khach 
       public string laymaloaikhach()
        {
            return "LK" + db.LoaiKhaches.Count().ToString();
        }
        // them loai khach 
        public void insert(string ten)
        {
            LoaiKhach loaiKhach = new LoaiKhach();
            loaiKhach.MaLoaiKhach = laymaloaikhach();
            loaiKhach.TenLoaiKhach = ten;
            db.LoaiKhaches.InsertOnSubmit(loaiKhach);
            db.SubmitChanges();
        }
        public void update(string maloai, string ten)
        {
            LoaiKhach loaiKhach = db.LoaiKhaches.Single(p => p.MaLoaiKhach == maloai);
            loaiKhach.TenLoaiKhach = ten;
            db.SubmitChanges();
        }
        public void delete(string maloai)
        {
            LoaiKhach loaiKhach = db.LoaiKhaches.Single(p => p.MaLoaiKhach == maloai);
            db.LoaiKhaches.DeleteOnSubmit(loaiKhach);
            db.SubmitChanges();
        }
    }
}
