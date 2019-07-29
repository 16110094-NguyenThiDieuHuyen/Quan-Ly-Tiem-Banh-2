using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTiemBanhDAL;

namespace QuanLyTiemBanhBLL
{
   public class NguyenLieuBLL
    {
        QuanLyTiemBanhDataContext db = new QuanLyTiemBanhDataContext();
        // lay danh sach cac nguyenlieu
        public List<NguyenLieu> laydanhsach()
        {
            return db.NguyenLieus.ToList();
        }
        // ham lay ma nguyen lieu
       public string laymanguyenlieu()
        {
            return "NL" + db.NguyenLieus.Count().ToString();
        }
        // ham them nguyen lieu
        public void insert(string ten, DateTime ngayhethan)
        {
            NguyenLieu nguyenLieu = new NguyenLieu();
            nguyenLieu.MaNguyenLieu = laymanguyenlieu();
            nguyenLieu.TenNguyenLieu = ten;
            nguyenLieu.NgayHetHan = ngayhethan;
            db.NguyenLieus.InsertOnSubmit(nguyenLieu);
            db.SubmitChanges();
        }
        public void update(string ma,string ten, DateTime ngayhethan)
        {
            NguyenLieu nguyenLieu = db.NguyenLieus.Single(p => p.MaNguyenLieu == ma);
            nguyenLieu.TenNguyenLieu = ten;
            nguyenLieu.NgayHetHan = ngayhethan;
            //db.NguyenLieus.InsertOnSubmit(nguyenLieu);
            db.SubmitChanges();
        }
        public void delete(string ma)
        {
            NguyenLieu nguyenLieu = db.NguyenLieus.Single(p => p.MaNguyenLieu == ma);
            db.NguyenLieus.DeleteOnSubmit(nguyenLieu);
        }
    }
}
