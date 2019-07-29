using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTiemBanhDAL;

namespace QuanLyTiemBanhBLL
{
   public class NhaCungCapBLL
    {
        QuanLyTiemBanhDataContext db = new QuanLyTiemBanhDataContext();
        // lay danh sach 
        public List<NhaCungCap> laydanhsach()
        {
            return db.NhaCungCaps.ToList();
        }
        // lay ma nha cung cap
       public string laymanhacungcap()
        {
            return "NCC" + db.NhaCungCaps.Count().ToString();
        }
        // them nha cung cap 
        public void insert(string ten,string dienthoai, string diachi, string email)
        {
            NhaCungCap nhaCungCap = new NhaCungCap();
            nhaCungCap.MaNhaCungCap = laymanhacungcap();
            nhaCungCap.TenNhaCungCap = ten;
            nhaCungCap.DienThoai = dienthoai;
            nhaCungCap.DiaChi = diachi;
            nhaCungCap.Email = email;
            db.NhaCungCaps.InsertOnSubmit(nhaCungCap);
            db.SubmitChanges();
        }
        // ham cap nhap
        public void update(string ma, string ten, string dienthoai, string diachi, string email)
        {
            NhaCungCap nhaCungCap = db.NhaCungCaps.Single(p => p.MaNhaCungCap == ma);
            nhaCungCap.TenNhaCungCap = ten;
            nhaCungCap.DienThoai = dienthoai;
            nhaCungCap.DiaChi = diachi;
            nhaCungCap.Email = email;
            db.SubmitChanges();
        }
        // ham sua
        public void delete(string ma)
        {
            NhaCungCap nhaCungCap = db.NhaCungCaps.Single(p => p.MaNhaCungCap == ma);
            db.NhaCungCaps.DeleteOnSubmit(nhaCungCap);
            db.SubmitChanges();
        }
    }
}
