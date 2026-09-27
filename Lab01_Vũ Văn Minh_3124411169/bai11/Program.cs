using System;
namespace Bai11
{
    class XuLyChuoi
    {
        public string DaoNguocChuoi(string s)
        {
            // Bước 1: Chuyển đổi chuỗi thành một mảng các ký tự (char array).
            char[] arr = s.ToCharArray();
            // Bước 2: Sử dụng phương thức có sẵn của lớp Array để đảo ngược vị trí các phần tử trong mảng.
            Array.Reverse(arr);
            // Bước 3: Khởi tạo một chuỗi mới từ mảng ký tự đã bị đảo ngược và trả về kết quả.
            return new string(arr);
        }
    }
    class Program
    {
        static void Main()
        {
            Console.Write("Nhap chuoi can dao nguoc: ");
            string chuoi = Console.ReadLine();
            XuLyChuoi xl = new XuLyChuoi();
            Console.WriteLine($"-> Chuoi dao nguoc la: {xl.DaoNguocChuoi(chuoi)}");
            Console.ReadLine();
        }
    }
}