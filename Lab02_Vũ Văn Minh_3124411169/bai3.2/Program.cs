using System;
namespace Bai3_2_MoPhongArraySort
{
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
        public int CompareTo(SinhVien other)
        {
            if (other == null) return 1;
            return this.Diem.CompareTo(other.Diem); // Tăng dần theo điểm
        }
    }
    // 2. Lớp chứa phương thức tự viết để mô phỏng Array.Sort
    public class MyArrayHelper
    {
        // Viết phương thức sắp xếp mảng tổng quát T[]
        // Ràng buộc (where T : IComparable<T>) bắt buộc T phải có khả năng tự so sánh
        public static void CustomSort<T>(T[] arr) where T : IComparable<T>
        {
            int n = arr.Length;
            // Sử dụng thuật toán Bubble Sort
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Sử dụng hàm CompareTo() từ interface để quyết định vị trí
                    // Nếu arr[j] lớn hơn arr[j+1] (CompareTo trả về > 0), thì hoán vị
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        T temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
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
            // GỌI PHƯƠNG THỨC MÔ PHỎNG THAY VÌ Array.Sort
            MyArrayHelper.CustomSort(danhSach);
            Console.WriteLine("\n--- SAU KHI SAP XEP BANG CUSTOM SORT (Tang dan theo diem) ---");
            foreach (var sv in danhSach)
            {
                sv.Xuat();
            }
            Console.ReadLine();
        }
    }
}