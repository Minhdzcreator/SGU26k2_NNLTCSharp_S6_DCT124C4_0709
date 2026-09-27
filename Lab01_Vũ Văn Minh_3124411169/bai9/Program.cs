using System;
namespace Bai9
{
    class TimKiem
    {
        // Sử dụng từ khóa 'out' cho phép phương thức trả về nhiều giá trị cùng lúc (cả min và max).
        public void TimMinMax(double a, double b, double c, out double min, out double max)
        {
            max = Math.Max(a, Math.Max(b, c));
            min = Math.Min(a, Math.Min(b, c));
        }
    }
    class Program
    {
        static void Main()
        {
            Console.Write("Nhap so 1: "); double a = double.Parse(Console.ReadLine());
            Console.Write("Nhap so 2: "); double b = double.Parse(Console.ReadLine());
            Console.Write("Nhap so 3: "); double c = double.Parse(Console.ReadLine());
            // Khởi tạo đối tượng ẩn danh và gọi phương thức TimMinMax.
            new TimKiem().TimMinMax(a, b, c, out double min, out double max);
            Console.WriteLine($"Gia tri lon nhat: {max}");
            Console.WriteLine($"Gia tri nho nhat: {min}");
            Console.ReadLine();
        }
    }
}