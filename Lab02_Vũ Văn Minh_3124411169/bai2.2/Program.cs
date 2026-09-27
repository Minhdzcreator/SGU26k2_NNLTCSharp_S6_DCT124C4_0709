using System;
using System.Collections.Generic;
namespace Bai2_2
{
    // Lớp Person cơ bản 
    public class Person
    {
        public string Name { get; set; }
        public bool IsAlive { get; set; }
        // Default constructor
        public Person()
        {
            Name = "Unknown";
            IsAlive = true;
        }
        // Copy constructor cho Person
        public Person(Person other)
        {
            this.Name = other.Name;
            this.IsAlive = other.IsAlive;
        }
        public void Input()
        {
            Console.Write("Nhap ten: ");
            Name = Console.ReadLine();
            Console.Write("Nguoi nay con song khong? (true/false): ");
            IsAlive = bool.Parse(Console.ReadLine());
        }
        public void Output()
        {
            string status = IsAlive ? "Con song" : "Da mat";
            Console.WriteLine($"- Ten: {Name}, Trang thai: {status}");
        }
    }
    // Lớp PersonList theo yêu cầu Bài 2.2
    public class PersonList
    {
        private List<Person> danhSach;
        // 1. Default constructor
        public PersonList()
        {
            danhSach = new List<Person>();
        }

        // 2. Copy constructor
        public PersonList(PersonList other)
        {
            danhSach = new List<Person>();
            foreach (Person p in other.danhSach)
            {
                // Sử dụng copy constructor của Person để tạo bản sao độc lập (Deep copy)
                this.danhSach.Add(new Person(p)); 
            }
        }
        // 3. Input(): Nhập dữ liệu của PersonList
        public void Input()
        {
            Console.Write("Nhap so luong nguoi trong danh sach: ");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"\nNhap thong tin nguoi thu {i + 1}:");
                    Person p = new Person();
                    p.Input();
                    this.Add(p);
                }
            }
        }
        // 4. Output(): Xuất dữ liệu của PersonList
        public void Output()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sach rong.");
                return;
            }

            foreach (Person p in danhSach)
            {
                p.Output();
            }
        }

        // 5. Add(Person x): Thêm một Person vào trong PersonList
        public void Add(Person x)
        {
            danhSach.Add(x);
        }

        // 6. LivingPeople(): Trả về một PersonList những người còn sống
        public PersonList LivingPeople()
        {
            PersonList livingList = new PersonList();
            foreach (Person p in this.danhSach)
            {
                if (p.IsAlive)
                {
                    livingList.Add(p);
                }
            }
            return livingList;
        }
    }

    // Hàm Main để chạy thử nghiệm
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- NHAP DANH SACH NHAN KHAU ---");
            PersonList list = new PersonList();
            list.Input();

            Console.WriteLine("\n--- DANH SACH VUA NHAP ---");
            list.Output();

            Console.WriteLine("\n--- DANH SACH NHUNG NGUOI CON SONG ---");
            PersonList listLiving = list.LivingPeople();
            listLiving.Output();
            
            Console.ReadLine();
        }
    }
}