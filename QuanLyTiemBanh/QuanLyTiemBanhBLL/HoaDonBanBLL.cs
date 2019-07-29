using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTiemBanhBLL;
using QuanLyTiemBanhDAL;
namespace QuanLyTiemBanhBLL
{
   public class HoaDonBanBLL
    {
        QuanLyTiemBanhDataContext db = new QuanLyTiemBanhDataContext();
        // ham lay danh sach 
        public List<HoaDonBan> laydanhsach()
        {
            return db.HoaDonBans.ToList();
        }
        // lay ma hoa don 
        public string laymahoadon()
        {
            return "HDB" + db.HoaDonBans.Count().ToString();
        }
        // ham thêm hoa don 
        public void insert(DateTime thoigian, string manhanvien,string makhach)
        {
            HoaDonBan hoaDonBan = new HoaDonBan();
            hoaDonBan.MaHoaDon = laymahoadon();
            hoaDonBan.MaKhach = makhach;
            hoaDonBan.MaNhanVien = manhanvien;
            hoaDonBan.ThoiGian = thoigian;
            db.HoaDonBans.InsertOnSubmit(hoaDonBan);
            db.SubmitChanges();
        }
        // ham cap nhap
        public void update(string mahoadon, DateTime thoigian,string manhanvien,string makhach)
        {
            HoaDonBan hoaDonBan = db.HoaDonBans.Single(p => p.MaHoaDon==mahoadon);
            hoaDonBan.MaKhach = makhach;
            hoaDonBan.MaNhanVien = manhanvien;
            hoaDonBan.ThoiGian = thoigian;
            db.SubmitChanges();
        }
        // ham xoa hoa don 
        public void delete(string mahoadon)
        {
            HoaDonBan hoaDonBan = db.HoaDonBans.Single(p => p.MaHoaDon == mahoadon);
            db.HoaDonBans.DeleteOnSubmit(hoaDonBan);
            db.SubmitChanges();
        }

    }
}
