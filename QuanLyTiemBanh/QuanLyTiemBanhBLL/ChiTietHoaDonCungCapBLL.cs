using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTiemBanhDAL;

namespace QuanLyTiemBanhBLL
{
   public class ChiTietHoaDonCungCapBLL
    {
        QuanLyTiemBanhDataContext db = new QuanLyTiemBanhDataContext();
        // ham lay danh sach 
        public List<ChiTietHoaDonCungCap> laydanhsach()
        {
            return db.ChiTietHoaDonCungCaps.ToList();
        }
        // ham thêm hoa don 
        public void insert(string manguyenlieu, string mahoadon, int soluong,decimal dongia)
        {
            ChiTietHoaDonCungCap chiTietHoaDonCungCap = new ChiTietHoaDonCungCap();
            chiTietHoaDonCungCap.MaNguyenLieu = manguyenlieu;
            chiTietHoaDonCungCap.MaHoaDon = mahoadon;
            chiTietHoaDonCungCap.SoLuong = soluong;
            chiTietHoaDonCungCap.DonGia = dongia;
            db.ChiTietHoaDonCungCaps.InsertOnSubmit(chiTietHoaDonCungCap);
            db.SubmitChanges();
        }
        // ham cap nhap
        public void update(string manguyenlieu, string mahoadon, int soluong, decimal dongia)
        {
            ChiTietHoaDonCungCap chiTietHoaDonCungCap = db.ChiTietHoaDonCungCaps.Single(p => p.MaNguyenLieu == manguyenlieu && p.MaHoaDon == mahoadon);
            chiTietHoaDonCungCap.SoLuong = soluong;
            chiTietHoaDonCungCap.DonGia = dongia;
            db.SubmitChanges();
        }
        // ham xoa hoa don 
        public void delete(string manguyenlieu, string mahoadon)
        {
            ChiTietHoaDonCungCap chiTietHoaDonCungCap = db.ChiTietHoaDonCungCaps.Single(p => p.MaNguyenLieu == manguyenlieu && p.MaHoaDon == mahoadon);
            db.ChiTietHoaDonCungCaps.DeleteOnSubmit(chiTietHoaDonCungCap);
            db.SubmitChanges();
        }
    }
}
