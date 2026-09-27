using System;
namespace Bai13
{
    class SinhVien
    {
        public string MaSV;
        public string HoTen;
        public string DiaChi;
        public int NamHoc;
        // Phương thức nhập thông tin
        public void NhapThongTin()
        {
            Console.Write("Nhap ma sinh vien: ");
            MaSV = Console.ReadLine();
            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhap dia chi: ");
            DiaChi = Console.ReadLine();
            Console.Write("Sinh vien nam thu may (nhap so): ");
            NamHoc = int.Parse(Console.ReadLine());
        }
        public void XuatThongTin()
        {
            Console.WriteLine("\n--- THONG TIN SINH VIEN ---");
            Console.WriteLine($"Ma SV: {MaSV}");
            Console.WriteLine($"Ho ten: {HoTen}");
            Console.WriteLine($"Dia chi: {DiaChi}");
            Console.WriteLine($"Nam hoc: Thu {NamHoc}");
        }
    }
    class Program
    {
        static void Main()
        {
            SinhVien sv = new SinhVien();
            sv.NhapThongTin();
            sv.XuatThongTin();
        }
    }
}