using System;
namespace Bai6
{
    class XuLyToanHoc
    {
        public int TimMax(int a, int b, int c) => Math.Max(a, Math.Max(b, c));
        // Sử dụng cú pháp rút gọn (=>) và hàm Math.Max để tìm số lớn nhất 
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap so 1: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Nhap so 2: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Nhap so 3: ");
            int c = int.Parse(Console.ReadLine());
            XuLyToanHoc toan = new XuLyToanHoc();
            Console.WriteLine($"Gia tri lon nhat: {toan.TimMax(a, b, c)}"); 
            // Gọi phương thức TimMax từ đối tượng vừa tạo và truyền 3 số a, b, c vào
            Console.ReadLine();
        }
    }
}