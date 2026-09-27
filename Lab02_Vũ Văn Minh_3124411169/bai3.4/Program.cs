using System;
namespace Bai3_4_ConsoleMenuEvent
{
    // 1. Định nghĩa Delegate làm khuôn mẫu cho sự kiện Menu
    public delegate void MenuChooseHandler(int choice);

    // 2. Lớp ConsoleMenu tổng quát xử lý giao diện hiển thị và phát sự kiện
    public class ConsoleMenu
    {
        // Khai báo sự kiện Choose dựa trên delegate
        public event MenuChooseHandler Choose;
        public virtual void PrintMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. Chức năng 1");
            Console.WriteLine("2. Chức năng 2");
            Console.WriteLine("0. Thoát chương trình");
        }
        // Vòng lặp chính quản lý tương tác người dùng
        public void Run()
        {
            int x = -1;
            while (x != 0)
            {
                Console.WriteLine("\n----------------------------------");
                PrintMenu();
                Console.Write("Thực hiện: ");
                
                if (int.TryParse(Console.ReadLine(), out x))
                {
                    Console.WriteLine($"\nBạn thực hiện chức năng {x}");
                    
                    if (x == 0)
                    {
                        Console.WriteLine("Đang thoát...");
                        break;
                    }
                    // Kích hoạt sự kiện (Phát tín hiệu báo rằng người dùng đã chọn 'x')
                    // Toán tử ?.Invoke() giúp kiểm tra nếu có ai lắng nghe sự kiện thì mới gọi
                    Choose?.Invoke(x); 
                }
                else
                {
                    Console.WriteLine("Vui lòng nhập một số hợp lệ.");
                }
            }
        }
    }
    // 3. Lớp PTBac2Console kế thừa từ ConsoleMenu
    public class PTBac2Console : ConsoleMenu
    {
        // Trạng thái lưu trữ của ứng dụng (các hệ số)
        private double a, b, c;
        // Ghi đè phương thức in menu để phù hợp bài toán cụ thể
        public override void PrintMenu()
        {
            Console.WriteLine("Menu Giải Phương Trình Bậc 2");
            Console.WriteLine("1. Nhập các hệ số a, b, c");
            Console.WriteLine("2. Tính và xuất nghiệm");
            Console.WriteLine("0. Thoát chương trình");
        }
        // Chức năng 1
        public void NhapHeSo()
        {
            Console.Write("Nhập hệ số a = "); a = double.Parse(Console.ReadLine());
            Console.Write("Nhập hệ số b = "); b = double.Parse(Console.ReadLine());
            Console.Write("Nhập hệ số c = "); c = double.Parse(Console.ReadLine());
        }
        // Chức năng 2
        public void GiaiPhuongTrinh()
        {
            if (a == 0)
            {
                if (b == 0)
                    Console.WriteLine(c == 0 ? "Phương trình vô số nghiệm." : "Phương trình vô nghiệm.");
                else
                    Console.WriteLine($"Phương trình có 1 nghiệm: x = {-c / b}");
                return;
            }
            double delta = b * b - 4 * a * c;
            if (delta < 0) 
            {
                Console.WriteLine("Phương trình vô nghiệm.");
            }
            else if (delta == 0) 
            {
                Console.WriteLine($"Phương trình có nghiệm kép: x1 = x2 = {-b / (2 * a)}");
            }
            else
            {
                Console.WriteLine($"x1 = {(-b + Math.Sqrt(delta)) / (2 * a)}");
                Console.WriteLine($"x2 = {(-b - Math.Sqrt(delta)) / (2 * a)}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PTBac2Console app = new PTBac2Console();
            app.Choose += (choice) =>
            {
                switch (choice)
                {
                    case 1:
                        app.NhapHeSo();
                        break;
                    case 2:
                        app.GiaiPhuongTrinh();
                        break;
                    default:
                        Console.WriteLine("Chức năng không hợp lệ! Vui lòng chọn lại.");
                        break;
                }
            };
            // Khởi động vòng lặp Menu
            app.Run();
        }
    }
}