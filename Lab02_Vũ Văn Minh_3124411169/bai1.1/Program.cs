    using System;
    namespace Bai1_1
    {
        class SinhVien
        {
            // 1. Fields
            private string _hoTen;
            private int _namSinh;
            // 2. Properties
            public string HoTen
            {
                get { return _hoTen; }
                set { _hoTen = value; }
            }
            public int NamSinh
            {
                get { return _namSinh; }
                set { _namSinh = value; }
            }
            // 3. Constructors
            // Default Constructor
            public SinhVien()
            {
                _hoTen = "Chua xac dinh";
                _namSinh = DateTime.Now.Year;
            }
            // Parameter Constructor
            public SinhVien(string hoTen, int namSinh)
            {
                _hoTen = hoTen;
                _namSinh = namSinh;
            }
            // 4. Methods 
            // Phương thức nhập thông tin
            public void Nhap()
            {
                Console.Write("Nhap ho ten sinh vien: ");
                _hoTen = Console.ReadLine();
                
                Console.Write("Nhap nam sinh: ");
                while (!int.TryParse(Console.ReadLine(), out _namSinh) || _namSinh > DateTime.Now.Year)
                {
                    Console.Write("Nam sinh khong hop le. Vui long nhap lai: ");
                }
            }
            // Phương thức tính tuổi
            public int TinhTuoi()
            {
                int namHienTai = DateTime.Now.Year;
                return namHienTai - _namSinh;
            }
            // Phương thức xuất thông tin
            public void Xuat()
            {
                Console.WriteLine($"\n--- THONG TIN SINH VIEN ---");
                Console.WriteLine($"Ho ten: {_hoTen}");
                Console.WriteLine($"Nam sinh: {_namSinh}");
                Console.WriteLine($"Tuoi: {TinhTuoi()}");
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                // Tạo đối tượng sinh viên bằng hàm tạo mặc định
                SinhVien sv = new SinhVien();
                // Gọi phương thức nhập dữ liệu
                sv.Nhap();
                // Gọi phương thức xuất dữ liệu và tuổi
                sv.Xuat();
                Console.ReadLine();
            }
        }
    }