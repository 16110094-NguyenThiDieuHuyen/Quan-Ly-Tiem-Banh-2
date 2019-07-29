using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTiemBanhDAL;

namespace QuanLyTiemBanhBLL
{
    public class LoaiBanhBLL
    {
        QuanLyTiemBanhDataContext db = new QuanLyTiemBanhDataContext();
        // lay danh sach cac loai banh 
        public List<LoaiBanh> laydanhsach()
        {
            return db.LoaiBanhs.ToList();
        }
        // ham lay ma loai banh
       public string laymabanh()
        {
           return "LB"+db.LoaiBanhs.Count().ToString();
        }
        // ham them loai banh
        public void insert(string tenloai)
        {
            LoaiBanh loaiBanh = new LoaiBanh();
            loaiBanh.MaLoaiBanh = laymabanh();
            loaiBanh.TenLoaiBanh = tenloai;
            db.LoaiBanhs.InsertOnSubmit(loaiBanh);
            db.SubmitChanges();
        }
        // ham update
       public void update(string maloai, string tenloai)
        {
            LoaiBanh loaiBanh = db.LoaiBanhs.Single(p=>p.MaLoaiBanh == maloai);
            loaiBanh.TenLoaiBanh = tenloai;
            db.SubmitChanges();
        }
        // ham xoa loai banh 
        public void delete(string maloai)
        {
            LoaiBanh loaiBanh = db.LoaiBanhs.Single(p => p.MaLoaiBanh == maloai);
            db.LoaiBanhs.DeleteOnSubmit(loaiBanh);
            db.SubmitChanges();
        }
    }
}
