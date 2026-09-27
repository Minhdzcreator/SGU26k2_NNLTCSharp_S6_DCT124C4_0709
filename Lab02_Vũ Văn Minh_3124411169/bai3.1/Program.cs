using System;
namespace Bai3_1_ArraySort
{
    // Cài đặt interface IComparable<SinhVien> để Array.Sort biết cách so sánh
    public class SinhVien : IComparable<SinhVien>
    {
        public string HoTen { get; set; }
        public double Diem { get; set; }
        public SinhVien(string hoTen, double diem)
        {
            HoTen = hoTen;
            Diem = diem;
        }
        public void Xuat()
        {
            Console.WriteLine($"Tên: {HoTen} | Điểm: {Diem}");
        }
        // Định nghĩa phương thức CompareTo bắt buộc của giao diện IComparable
        public int CompareTo(SinhVien other)
        {
            if (other == null) return 1;
            // Ví dụ: Sắp xếp tăng dần theo Điểm
            // Trả về < 0 nếu đối tượng hiện tại nhỏ hơn
            // Trả về 0 nếu bằng nhau
            // Trả về > 0 nếu đối tượng hiện tại lớn hơn
            return this.Diem.CompareTo(other.Diem);
            // Lưu ý: Nếu muốn sắp xếp giảm dần, bạn chỉ cần đảo ngược lại:
            // return other.Diem.CompareTo(this.Diem);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Tạo một mảng các đối tượng SinhVien
            SinhVien[] danhSach = new SinhVien[]
            {
                new SinhVien("Nguyen Van A", 7.5),
                new SinhVien("Tran Thi B", 9.0),
                new SinhVien("Le Van C", 6.0),
                new SinhVien("Pham Thi D", 8.5)
            };
            Console.WriteLine("--- DANH SACH BAN DAU ---");
            foreach (var sv in danhSach)
            {
                sv.Xuat();
            }
            // 2. Dùng phương thức tĩnh Array.Sort(...) để sắp xếp các đối tượng
            Array.Sort(danhSach);
            Console.WriteLine("\n--- DANH SACH SAU KHI SAP XEP (Tang dan theo diem) ---");
            foreach (var sv in danhSach)
            {
                sv.Xuat();
            }
            Console.ReadLine();
        }
    }
}