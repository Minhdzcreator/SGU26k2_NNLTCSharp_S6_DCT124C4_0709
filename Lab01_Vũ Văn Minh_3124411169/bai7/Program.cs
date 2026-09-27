using System;
namespace Bai7
{
    class KiemTraSoNguyenTo
    {
        public bool LaSoNguyenTo(int n) //Hàm kiểm tra số nguyên tố
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap so nguyen n: ");
            int n = int.Parse(Console.ReadLine()); // Ép kiểu chuỗi nhập vào thành kiểu int
            KiemTraSoNguyenTo kt = new KiemTraSoNguyenTo(); // Khởi tạo đối tượng 'kt' từ lớp KiemTraSoNguyenTo
            if (kt.LaSoNguyenTo(n))
                Console.WriteLine($"{n} la so nguyen to.");
            else
                Console.WriteLine($"{n} khong phải la so nguyen to.");
            Console.ReadLine();
        }
    }
}