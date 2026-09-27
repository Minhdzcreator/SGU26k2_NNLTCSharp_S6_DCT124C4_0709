using System;
using System.Collections.Generic;
namespace Bai17
{
    class XuLyMang2D
    {
        public int[,] SinhMangNgauNhien(int n, int m)
        {
            int[,] a = new int[n, m]; // Khởi tạo mảng 2 chiều
            Random rand = new Random(); // Khởi tạo đối tượng sinh số ngẫu nhiên
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    // Sinh số ngẫu nhiên từ 10 đến 100
                    a[i, j] = rand.Next(10, 101);
                }
            }
            return a;
        }
        // Phương thức in mảng 2 chiều ra màn hình
        public void InMang(int[,] a)
        {
            int n = a.GetLength(0); // Lấy số lượng dòng
            int m = a.GetLength(1); // Lấy số lượng cột
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{a[i, j], 4}");
                }
                Console.WriteLine();
            }
        }
        public void TachChanLe(int[,] a, out int[] mangChan, out int[] mangLe)
        {
            List<int> chan = new List<int>();
            List<int> le = new List<int>();
            foreach (int x in a) 
            {
                if (x % 2 == 0) chan.Add(x);
                else le.Add(x);
            }
            // Chuyển đổi từ danh sách động (List) về lại mảng tĩnh (Array) để gán cho biến out
            mangChan = chan.ToArray();
            mangLe = le.ToArray();
        }
    }
    class Program
    {
        static void Main()
        {
            Console.Write("Nhap so dong (n): ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Nhap so cot (m): ");
            int m = int.Parse(Console.ReadLine());
            XuLyMang2D xl = new XuLyMang2D();
            // Sinh mảng ngẫu nhiên 
            int[,] mang = xl.SinhMangNgauNhien(n, m);
            Console.WriteLine("\n--- MANG 2 CHIEU VUA SINH ---");
            xl.InMang(mang);
            // Tách mảng chẵn lẻ
            xl.TachChanLe(mang, out int[] chan, out int[] le);
            // Sử dụng string.Join để in mảng 1 chiều
            Console.WriteLine("\n-> Mang cac so chan: " + string.Join(", ", chan));
            Console.WriteLine("-> Mang cac so le: " + string.Join(", ", le));
        }
    }
}