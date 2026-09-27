using System;
namespace TinhLuongNhanVienApp
{
    public class NhanVien
    {
        public string HoTen { get; set; }
        public double MucLuong { get; set; }
        public int SoNgayVang { get; set; }
        public void Nhap()
        {
            Console.Write("  - Nhap ho ten: ");
            HoTen = Console.ReadLine();
            Console.Write("  - Nhap muc luong: ");
            MucLuong = double.Parse(Console.ReadLine());
            Console.Write("  - Nhap so ngay vang: ");
            SoNgayVang = int.Parse(Console.ReadLine());
        }
        public void Xuat()
        {
            Console.WriteLine($"  - Ho ten: {HoTen}, Muc luong: {MucLuong:N0}, Ngay vang: {SoNgayVang}, Luong thuc nhan: {TinhLuongThucTe():N0}");
        }
        public double TinhLuongThucTe()
        {
            double luong = MucLuong - (SoNgayVang * 100000);
            return luong > 0 ? luong : 0; // Đảm bảo lương không bị âm
        }
    }
    // Lớp đại diện cho Phòng ban, chứa n nhân viên
    public class PhongBan
    {
        private NhanVien[] danhSach;
        private int n;
        public void Nhap()
        {
            Console.Write("Nhap so luong nhan vien n = ");
            if (int.TryParse(Console.ReadLine(), out n) && n > 0)
            {
                danhSach = new NhanVien[n];
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"\nNhap thong tin nhan vien thu {i + 1}:");
                    danhSach[i] = new NhanVien();
                    danhSach[i].Nhap();
                }
            }
            else
            {
                Console.WriteLine("So luong khong hop le.");
                n = 0;
                danhSach = new NhanVien[0];
            }
        }
        public void Xuat()
        {
            if (n == 0) return;
            for (int i = 0; i < n; i++)
            {
                danhSach[i].Xuat();
            }
        }
        // Tính tổng lương của cả phòng ban
        public double TinhTongLuong()
        {
            double tong = 0;
            for (int i = 0; i < n; i++)
            {
                tong += danhSach[i].TinhLuongThucTe();
            }
            return tong;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PhongBan pb = new PhongBan();
            Console.WriteLine("--- NHAP THONG TIN PHONG BAN ---");
            pb.Nhap();
            Console.WriteLine("\n--- DANH SACH NHAN VIEN ---");
            pb.Xuat();
            Console.WriteLine("\n--- TONG LUONG PHONG BAN ---");
            double tongLuong = pb.TinhTongLuong();
            Console.WriteLine($"Tong luong phai tra: {tongLuong:N0} VND");
            Console.ReadLine();
        }
    }
}