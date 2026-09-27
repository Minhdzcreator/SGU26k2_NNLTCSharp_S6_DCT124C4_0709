using System;
using System.Linq;
namespace Bai15
{
    class XuLyMang
    {
        public int[] NhapMang(int n)
        {
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhap phan tu thu {i + 1}: ");
                arr[i] = int.Parse(Console.ReadLine());
            }
            return arr;
        }
        public void InMang(int[] arr)
        {
            // string.Join giúp nối các phần tử mảng lại với nhau, cách nhau bởi dấu phẩy và khoảng trắng
            Console.WriteLine(string.Join(", ", arr));
        }
        public void TimMinMax(int[] arr, out int min, out int max)
        {
            min = arr.Min();
            max = arr.Max();
        }
        // Phương thức kiểm tra số nguyên tố
        private bool LaSoNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0) return false;
            return true;
        }
        // Phương thức trích xuất các số nguyên tố từ mảng ban đầu
        public int[] LayMangSoNguyenTo(int[] arr)
        {
            return arr.Where(LaSoNguyenTo).ToArray();
        }
    }
    class Program
    {
        static void Main()
        {
            Console.Write("Nhap so phan tu cua mang (n): ");
            int n = int.Parse(Console.ReadLine());
            XuLyMang xl = new XuLyMang();
            int[] mang = xl.NhapMang(n);
            Console.Write("\n-> Mang vua nhap: ");
            xl.InMang(mang);
            xl.TimMinMax(mang, out int min, out int max);
            // Gọi hàm tìm Min, Max với biến nội tuyến
            Console.WriteLine($"-> Phan tu nho nhat: {min} | Lon nhat: {max}");
            // Lấy mảng chỉ chứa các số nguyên tố và in ra
            int[] mangSNT = xl.LayMangSoNguyenTo(mang);
            Console.Write("-> Cac so nguyen to trong mang la: ");
            xl.InMang(mangSNT);
            Console.ReadLine();
        }
    }
}