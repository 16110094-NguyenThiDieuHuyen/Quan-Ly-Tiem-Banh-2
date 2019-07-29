using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTiemBanhDAL;

namespace QuanLyTiemBanhBLL
{
    public class BanhBLL
    {
        QuanLyTiemBanhDataContext db = new QuanLyTiemBanhDataContext();
        // ham lay danh sach cac banh 
        public List<Banh> laydanhsach()
        {
            return db.Banhs.OrderByDescending(p=>p.MaBanh).ToList();
        }
        // ham lay ma banh 
       public string laymabanh()
        {
            return "B" + db.Banhs.Count().ToString();
        }
        // ham them banh khong co anh 
        public void insertnotimage(string ten, decimal dongia, string mota, string maloai)
        {
            Banh banh = new Banh();
            banh.MaBanh = laymabanh();
            banh.TenBanh = ten;
            banh.MoTa = mota;
            banh.DonGia = dongia;
            banh.LoaiBanh = maloai;
            db.Banhs.InsertOnSubmit(banh);
            db.SubmitChanges();
        }
        // ,ham them banh co hinh anh
        public  void insertwithimage(string ten, decimal dongia, string mota, string maloai,byte[]Photo)
        {
            Banh banh = new Banh();
            banh.MaBanh = laymabanh();
            banh.TenBanh = ten;
            banh.MoTa = mota;
            banh.DonGia = dongia;
            banh.LoaiBanh = maloai;
            banh.PhoTo = Photo;
            db.Banhs.InsertOnSubmit(banh);
            db.SubmitChanges();
        }
        // ham sua banh khong hinh anh 
        public void updatenotimage(string mabanh,string ten, decimal dongia, string mota, string maloai)
        {
            Banh banh = db.Banhs.Single(p => p.MaBanh == mabanh);
            banh.MaBanh = laymabanh();
            banh.TenBanh = ten;
            banh.MoTa = mota;
            banh.DonGia = dongia;
            banh.LoaiBanh = maloai;
            db.Banhs.InsertOnSubmit(banh);
            db.SubmitChanges();
        }
        // ham sua banh co hinh anh 
        public void updatewithimage(string mabanh, string ten, decimal dongia, string mota, string maloai,byte[]PhoTo)
        {
            Banh banh = db.Banhs.Single(p => p.MaBanh == mabanh);
            banh.MaBanh = laymabanh();
            banh.TenBanh = ten;
            banh.MoTa = mota;
            banh.DonGia = dongia;
            banh.LoaiBanh = maloai;
            banh.PhoTo = PhoTo;
            db.Banhs.InsertOnSubmit(banh);
            db.SubmitChanges();
        }
        // ham xoa banh 
        public void deletebanh(string mabanh)
        {
            Banh banh = db.Banhs.Single(p => p.MaBanh == mabanh);
            db.Banhs.DeleteOnSubmit(banh);
            db.SubmitChanges();
        }
    }
}
