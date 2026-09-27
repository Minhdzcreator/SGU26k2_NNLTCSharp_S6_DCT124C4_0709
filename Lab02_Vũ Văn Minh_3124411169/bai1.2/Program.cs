using System;
namespace Bai1_2
{
    class Point
    {
        // 1. Fields
        private double x;
        private double y;
        // 2. Properties
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        // 3. Default Constructor
        public Point()
        {
            x = 0;
            y = 0;
        }
        // Parameter Constructor
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        // 4. Methods: Input và Output
        public void Input()
        {
            Console.Write("Nhap x: ");
            x = Convert.ToDouble(Console.ReadLine());
            Console.Write("Nhap y: ");
            y = Convert.ToDouble(Console.ReadLine());
        }
        public void Output()
        {
            Console.WriteLine(this.ToString());
        }
        // 5. Override hàm ToString() để xuất Point
        public override string ToString()
        {
            return $"({x}, {y})";
        }
        // 6. Phép toán: +, -, lấy âm (-)
        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.x + p2.x, p1.y + p2.y);
        }
        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.x - p2.x, p1.y - p2.y);
        }
        public static Point operator -(Point p)
        {
            return new Point(-p.x, -p.y);
        }
        // --- (a) Khoảng cách giữa 2 điểm ---
        // Cách 1: Phương thức thành viên
        public double KhoangCach(Point p)
        {
            return Math.Sqrt(Math.Pow(this.x - p.x, 2) + Math.Pow(this.y - p.y, 2));
        }
        // Cách 2: Phương thức tĩnh
        public static double KhoangCach(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.x - p2.x, 2) + Math.Pow(p1.y - p2.y, 2));
        }
        // --- (b) Trung điểm của 2 điểm ---
        // Cách 1: Phương thức thành viên
        public Point TrungDiem(Point p)
        {
            return new Point((this.x + p.x) / 2, (this.y + p.y) / 2);
        }
        // Cách 2: Phương thức tĩnh
        public static Point TrungDiem(Point p1, Point p2)
        {
            return new Point((p1.x + p2.x) / 2, (p1.y + p2.y) / 2);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point A = new Point();
            Point B = new Point();
            Console.WriteLine("--- NHAP TOA DO DIEM A ---");
            A.Input();
            Console.WriteLine("\n--- NHAP TOA DO DIEM B ---");
            B.Input();
            Console.WriteLine("\n--- THONG TIN DIEM ---");
            Console.Write("Diem A: "); A.Output();
            Console.Write("Diem B: "); B.Output();
            Console.WriteLine("\n--- TEST PHEP TOAN ---");
            Console.WriteLine($"A + B = {A + B}");
            Console.WriteLine($"A - B = {A - B}");
            Console.WriteLine($"-A (lay am diem A) = {-A}");
            Console.WriteLine("\n--- (a) TINH KHOANG CACH ---");
            Console.WriteLine($"Khoang cach AB (Phuong thuc thanh vien): {A.KhoangCach(B)}");
            Console.WriteLine($"Khoang cach AB (Phuong thuc tinh): {Point.KhoangCach(A, B)}");
            Console.WriteLine("\n--- (b) TIM TRUNG DIEM ---");
            Console.WriteLine($"Trung diem I (Phuong thuc thanh vien): {A.TrungDiem(B)}");
            Console.WriteLine($"Trung diem I (Phuong thuc tinh): {Point.TrungDiem(A, B)}");
            Console.ReadLine();
        }
    }
}