using System;
namespace Bai4
{
   class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap so nguyen x: ");
            string inputX = Console.ReadLine(); // Đọc dữ liệu nhập vào dưới dạng chuỗi
            // Kiểm tra và ép kiểu an toàn bằng int.TryParse
            // Nếu nhập sai (ví dụ: chữ cái), hàm trả về false, thực hiện khối lệnh if
            // Nếu nhập đúng, giá trị số nguyên được lưu vào biến x thông qua từ khóa 'out'
            if (!int.TryParse(inputX, out int x))
            {
                Console.WriteLine("Loi: x khong phai la so nguyen!"); // Thông báo lỗi
                Console.ReadLine();
                return; 
            }
            Console.Write("Nhap so nguyen y: ");
            string inputY = Console.ReadLine();
            if (!int.TryParse(inputY, out int y)) // Kiểm tra tính hợp lệ cho y tương tự như x
            {
                Console.WriteLine("Loi: y khong phai la so nguyen!");
                Console.ReadLine();
                return;
            }
            double ketQua = Math.Pow(x, y); // Tính toán lũy thừa
            Console.WriteLine("Ket qua " + x + " mu " + y + " la: " + ketQua);
            Console.ReadLine();
        }
    }
}