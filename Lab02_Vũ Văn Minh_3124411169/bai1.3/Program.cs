using System;
namespace Bai1_3
{
    class Person
    {
        // 1. Fields
        private string id;
        private string name;
        private int yob; // năm sinh
        private int yod; // năm mất
        // 2. Default Constructor
        public Person()
        {
            id = "Unknown";
            name = "Unknown";
            yob = 0;
            yod = 0;
        }
        // 3. Copy Constructor
        public Person(Person p)
        {
            this.id = p.id;
            this.name = p.name;
            this.yob = p.yob;
            this.yod = p.yod;
        }
        // 4. Input() - Nhập dữ liệu của Person
        public void Input()
        {
            Console.Write("Nhap ID: ");
            id = Console.ReadLine();
            Console.Write("Nhap ho va ten: ");
            name = Console.ReadLine();
            Console.Write("Nhap nam sinh (yob): ");
            while (!int.TryParse(Console.ReadLine(), out yob))
            {
                Console.Write("Gia tri khong hop le. Nhap lai nam sinh: ");
            }
            Console.Write("Nhap nam mat (yod) - [Nhap 0 neu con song]: ");
            while (!int.TryParse(Console.ReadLine(), out yod))
            {
                Console.Write("Gia tri khong hop le. Nhap lai nam mat: ");
            }
        }
        // 5. Output() - Xuất dữ liệu của Person
        public void Output()
        {
            Console.WriteLine($"[ID: {id}] - Ho ten: {name} - Nam sinh: {yob} - Nam mat: {(yod == 0 ? "Con song" : yod.ToString())}");
        }
        // 6. IsLiving() - Trả về false hay true tùy thuộc vào yod
        // yod bằng 0 => true (Còn sống) | yod khác 0 => false (Đã mất)
        public bool IsLiving()
        {
            if (yod == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- NHAP THONG TIN NGUOI THU 1 ---");
            // Sử dụng Default Constructor
            Person p1 = new Person(); 
            p1.Input();
            Console.WriteLine("\n--- THONG TIN NGUOI THU 1 ---");
            p1.Output();
            Console.WriteLine($"Tinh trang con song: {p1.IsLiving()}");
            Console.WriteLine("\n--- TAO NGUOI THU 2 (COPY TU NGUOI THU 1) ---");
            // Sử dụng Copy Constructor
            Person p2 = new Person(p1); 
            p2.Output();
            Console.ReadLine();
        }
    }
}