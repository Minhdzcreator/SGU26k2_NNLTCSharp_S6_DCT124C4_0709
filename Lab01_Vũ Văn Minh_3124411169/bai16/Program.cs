using System;
namespace Bai16
{
    class Program
    {
        static void Main()
        {
            Console.Write("Nhap so luong nguoi (n): ");
            int n = int.Parse(Console.ReadLine());
            string[] danhSachTen = new string[n];
            // Nhập dữ liệu cho mảng
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhap ho ten nguoi thu {i + 1}: ");
                danhSachTen[i] = Console.ReadLine();
            }
            Array.Sort(danhSachTen);
            Console.WriteLine("\n--- DANH SACH SAU KHI SAP XEP TANG DAN ---");
            // Sử dụng vòng lặp foreach để duyệt qua mảng.
            foreach (string ten in danhSachTen)
            {
                Console.WriteLine(ten);
            }
            Console.ReadLine();
        }
    }
}