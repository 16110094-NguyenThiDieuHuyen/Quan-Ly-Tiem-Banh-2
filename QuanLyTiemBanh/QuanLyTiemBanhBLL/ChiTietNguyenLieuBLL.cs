using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTiemBanhDAL;

namespace QuanLyTiemBanhBLL
{
    public class ChiTietNguyenLieuBLL
    {
        QuanLyTiemBanhDataContext db = new QuanLyTiemBanhDataContext();
        // ham lay danh sach 
        public List<ChiTietNguyenLieuBanh> laydanhsach()
        {
            return db.ChiTietNguyenLieuBanhs.ToList();
        }
        // ham thêm hoa don 
        public void insert(string mabanh, string manguyenlieu, float khoiluong)
        {
            ChiTietNguyenLieuBanh chiTietNguyenLieuBanh = new ChiTietNguyenLieuBanh();
            chiTietNguyenLieuBanh.MaBanh = mabanh;
            chiTietNguyenLieuBanh.MaNguyenLieu = manguyenlieu;
            chiTietNguyenLieuBanh.KhoiLuong = khoiluong;
            db.ChiTietNguyenLieuBanhs.InsertOnSubmit(chiTietNguyenLieuBanh);
            db.SubmitChanges();
        }
        // ham cap nhap
        public void update(string mabanh, string manguyenlieu, float khoiluong)
        {
            ChiTietNguyenLieuBanh chiTietNguyenLieuBanh = db.ChiTietNguyenLieuBanhs.Single(p => p.MaBanh == mabanh && p.MaNguyenLieu == manguyenlieu);
            chiTietNguyenLieuBanh.KhoiLuong = khoiluong;
            db.SubmitChanges();
        }
        // ham xoa hoa don 
        public void delete(string mabanh, string manguyenlieu)
        {
            ChiTietNguyenLieuBanh chiTietNguyenLieuBanh = db.ChiTietNguyenLieuBanhs.Single(p => p.MaBanh == mabanh && p.MaNguyenLieu == manguyenlieu);
            db.ChiTietNguyenLieuBanhs.DeleteOnSubmit(chiTietNguyenLieuBanh);
            db.SubmitChanges();
        }
    }
}
