using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal dongia;
            string dogia;
            Console.WriteLine("Nhap vao một số:");
            dogia = Console.ReadLine();
            decimal.TryParse(dogia, out dongia);
            Console.WriteLine("Đơn giá:" + dongia);
            
            
        }
    }
}
