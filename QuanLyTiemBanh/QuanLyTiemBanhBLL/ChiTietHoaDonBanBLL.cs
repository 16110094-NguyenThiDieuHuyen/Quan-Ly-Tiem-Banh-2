using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTiemBanhDAL;

namespace QuanLyTiemBanhBLL
{
   public class ChiTietHoaDonBanBLL
    {
        QuanLyTiemBanhDataContext db = new QuanLyTiemBanhDataContext();
        // ham lay danh sach 
        public List<ChiTietHoaDonBan> laydanhsach()
        {
            return db.ChiTietHoaDonBans.ToList();
        }
        // ham thêm hoa don 
        public void insert(string mabanh,string mahoadon,int soluong)
        {
            ChiTietHoaDonBan chiTietHoaDonBan = new ChiTietHoaDonBan();
            chiTietHoaDonBan.MaBanh = mabanh;
            chiTietHoaDonBan.MaHoaDon = mahoadon;
            chiTietHoaDonBan.SoLuong = soluong;
            db.ChiTietHoaDonBans.InsertOnSubmit(chiTietHoaDonBan);
            db.SubmitChanges();
        }
        // ham cap nhap
        public void update(string mabanh, string mahoadon, int soluong)
        {
            ChiTietHoaDonBan chiTietHoaDonBan = db.ChiTietHoaDonBans.Single(p => p.MaBanh == mabanh && p.MaHoaDon == mahoadon);
            chiTietHoaDonBan.SoLuong = soluong;
            db.SubmitChanges();
        }
        // ham xoa hoa don 
        public void delete(string mabanh, string mahoadon)
        {
            ChiTietHoaDonBan chiTietHoaDonBan = db.ChiTietHoaDonBans.Single(p => p.MaBanh == mabanh && p.MaHoaDon == mahoadon);
            db.ChiTietHoaDonBans.DeleteOnSubmit(chiTietHoaDonBan);
            db.SubmitChanges();
        }
    }
}
