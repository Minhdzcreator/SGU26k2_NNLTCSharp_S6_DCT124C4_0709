using System;
namespace Bai8
{
    class HoanVi
    {
        // Sử dụng từ khóa 'ref' để truyền tham chiếu, giúp hàm thay đổi trực tiếp biến gốc.
        // Cú pháp rút gọn (=>) kết hợp với Tuple (a, b) = (b, a) giúp hoán đổi giá trị.
        public void DoiCho(ref double a, ref double b) => (a, b) = (b, a);
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Nhap a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Nhap b: ");
            double b = double.Parse(Console.ReadLine());
            // Khởi tạo đối tượng ẩn danh từ lớp HoanVi và gọi ngay phương thức DoiCho.
            // Phải có từ khóa 'ref' ở tham số truyền vào để khớp với khai báo của phương thức.
            new HoanVi().DoiCho(ref a, ref b);
            Console.WriteLine($"Sau khi hoan vi: a = {a}, b = {b}");
        }
    }
}