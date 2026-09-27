using System;
namespace Bai14
{
    class NhanVien
    {
        public string HoTen;
        public double MucLuong;
        public int SoNgayVang;
        public void Nhap()
        {
            Console.Write("Nhap ho ten nhan vien: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhap muc luong co bản: ");
            MucLuong = double.Parse(Console.ReadLine());
            Console.Write("Nhap so ngay vang: ");
            SoNgayVang = int.Parse(Console.ReadLine());
        }
        public double TinhLuongThucLanh()
        {
            double luongThucLanh = MucLuong - (SoNgayVang * 100000);
            return luongThucLanh > 0 ? luongThucLanh : 0; 
        }
        public void Xuat()
        {
            Console.WriteLine("\n--- THONG TIN LUONG NHAN VIEN ---");
            Console.WriteLine($"Ho ten: {HoTen}");
            Console.WriteLine($"Muc luong goc: {MucLuong:N0} VNĐ");
            Console.WriteLine($"So ngay vang: {SoNgayVang}");
            Console.WriteLine($"Luong thuc lanh: {TinhLuongThucLanh():N0} VNĐ");
        }
    }
    class Program
    {
        static void Main()
        {
            NhanVien nv = new NhanVien();
            nv.Nhap();
            nv.Xuat();
        }
    }
}