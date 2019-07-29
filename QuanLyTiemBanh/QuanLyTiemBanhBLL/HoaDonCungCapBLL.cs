using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTiemBanhDAL;

namespace QuanLyTiemBanhBLL
{
   public class HoaDonCungCapBLL
    {
        QuanLyTiemBanhDataContext db = new QuanLyTiemBanhDataContext();
        // ham lay danh sach 
        public List<HoaDonCungCap> laydanhsach()
        {
            return db.HoaDonCungCaps.ToList();
        }
        // lay ma hoa don 
       public string laymahoadon()
        {
            return "HDCC" + db.HoaDonCungCaps.Count().ToString();
        }
        // ham thêm hoa don 
        public void insert(DateTime thoigian, string manhanvien, string manhacungcap)
        {
            HoaDonCungCap hoaDonCungCap = new HoaDonCungCap();
            hoaDonCungCap.MaHoaDonCungCap = laymahoadon();
            hoaDonCungCap.MaNhaCungCap = manhacungcap;
            hoaDonCungCap.MaNhanVien = manhanvien;
            hoaDonCungCap.ThoiGian = thoigian;
            db.HoaDonCungCaps.InsertOnSubmit(hoaDonCungCap);
            db.SubmitChanges();
        }
        // ham cap nhap
        public void update(string mahoadon, DateTime thoigian, string manhanvien, string manhacungcap)
        {
            HoaDonCungCap hoaDonCungCap = db.HoaDonCungCaps.Single(p => p.MaHoaDonCungCap == mahoadon);
            hoaDonCungCap.MaNhaCungCap = manhacungcap;
            hoaDonCungCap.MaNhanVien = manhanvien;
            hoaDonCungCap.ThoiGian = thoigian;
            db.SubmitChanges();
        }
        // ham xoa hoa don 
        public void delete(string mahoadon)
        {
            HoaDonCungCap hoaDonCungCap = db.HoaDonCungCaps.Single(p => p.MaHoaDonCungCap == mahoadon);
            db.HoaDonCungCaps.DeleteOnSubmit(hoaDonCungCap);
            db.SubmitChanges();
        }
    }
}
