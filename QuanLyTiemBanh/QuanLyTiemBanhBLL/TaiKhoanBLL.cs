using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTiemBanhDAL;

namespace QuanLyTiemBanhBLL
{
   public class TaiKhoanBLL
    {
        // chuoi ket noi 
        QuanLyTiemBanhDataContext db = new QuanLyTiemBanhDataContext();
        /// ham lay danh sach 
        public List<TaiKhoan> laydanhsach()
        {
            return db.TaiKhoans.ToList();
        }
        public List<TaiKhoan> laydanhsachnhanvien()
        {

            return db.TaiKhoans.Where(p => p.Quyen == (2.ToString())).ToList();
        }
        public List<TaiKhoan> laydanhsachkhachhang()
        {
            return db.TaiKhoans.Where(p => p.Quyen == 1.ToString()).ToList();
        }
        // ham them tai khoan 
        public void insert(string email, string quyen, string pass, decimal sodu)
        {
            TaiKhoan taiKhoan = new TaiKhoan();
            taiKhoan.Email = email;
            taiKhoan.Quyen = quyen;
            taiKhoan.Pass = pass;
            taiKhoan.SoDu = sodu;
            db.TaiKhoans.InsertOnSubmit(taiKhoan);
            db.SubmitChanges();
        }
        public void updatepass(string email,string pass)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Single(p => p.Email == email);
            taiKhoan.Pass = pass;
            db.SubmitChanges();
        }
        
        public void delete(string email)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Single(p => p.Email == email);
            db.TaiKhoans.DeleteOnSubmit(taiKhoan);
            db.SubmitChanges();
        }
    }
}
