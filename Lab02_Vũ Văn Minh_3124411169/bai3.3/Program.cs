using System;
namespace Bai3_3_DelegateSort
{
    public class SinhVien
    {
        public string HoTen { get; set; }
        public double Diem { get; set; }
        public SinhVien(string hoTen, double diem)
        {
            HoTen = hoTen;
            Diem = diem;
        }
        public void Xuat() => Console.WriteLine($"Tên: {HoTen} | Điểm: {Diem}");
    }
    public class MyArrayHelper
    {
        public static void CustomSort<T>(T[] arr, Comparison<T> soSanh)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (soSanh(arr[j], arr[j + 1]) > 0)
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
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
                new SinhVien("Le Van C", 6.0)
            };
            Console.WriteLine("--- SAP XEP THEO DIEM (TANG DAN) ---");
            MyArrayHelper.CustomSort(danhSach, (a, b) => a.Diem.CompareTo(b.Diem));
            foreach (var sv in danhSach) sv.Xuat();
            Console.WriteLine("\n--- SAP XEP THEO TEN (A -> Z) ---");
            MyArrayHelper.CustomSort(danhSach, (a, b) => a.HoTen.CompareTo(b.HoTen));
            foreach (var sv in danhSach) sv.Xuat();
            Console.ReadLine();
        }
    }
}