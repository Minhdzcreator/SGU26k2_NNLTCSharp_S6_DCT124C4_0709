using System;
namespace Bai3
{
       class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap so nguyen x: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Nhap so nguyen y: ");
            int y = int.Parse(Console.ReadLine());
            double ketQua = Math.Pow(x, y);
            Console.WriteLine("Ket qua " + x + " mu " + y + " la: " + ketQua);
            Console.ReadLine();
        }
    }
}