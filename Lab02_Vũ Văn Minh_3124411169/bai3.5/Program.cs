using System;
using System.Collections.Generic;
namespace Bai3_5_TinhLuongDaHinh
{
    // Lớp cha 
    public abstract class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }

        public virtual void Nhap()
        {
            Console.Write("Nhập mã nhân viên: ");
            MaNV = Console.ReadLine();
            Console.Write("Nhập họ tên: ");
            HoTen = Console.ReadLine();
        }
        public virtual void Xuat()
        {
            Console.Write($"Mã NV: {MaNV,-6} | Họ tên: {HoTen,-15} | ");
        }
        public abstract double TinhLuong();
    }
    // Lớp con 1: Nhân viên kinh doanh
    public class NhanVienKinhDoanh : NhanVien
    {
        public double LuongCoBan { get; set; }
        public int SoHopDong { get; set; }
        public override void Nhap()
        {
            Console.WriteLine("--- Nhập thông tin Nhân viên Kinh doanh ---");
            base.Nhap();
            Console.Write("Nhập lương cơ bản: ");
            LuongCoBan = double.Parse(Console.ReadLine());
            Console.Write("Nhập số hợp đồng ký kết: ");
            SoHopDong = int.Parse(Console.ReadLine());
        }
        public override double TinhLuong()
        {
            return LuongCoBan + (SoHopDong * 500000);
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Loại: Kinh doanh | Lương: {TinhLuong():N0} VNĐ");
        }
    }
    // Lớp con 2: Nhân viên sản xuất
    public class NhanVienSanXuat : NhanVien
    {
        public int SoSanPham { get; set; }

        public override void Nhap()
        {
            Console.WriteLine("--- Nhập thông tin Nhân viên Sản xuất ---");
            base.Nhap();
            Console.Write("Nhập số lượng sản phẩm: ");
            SoSanPham = int.Parse(Console.ReadLine());
        }
        public override double TinhLuong()
        {
            double luong = SoSanPham * 1000;
            if (SoSanPham > 3000)
            {
                luong += luong * 0.05;
            }
            return luong;
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Loại: Sản xuất   | Lương: {TinhLuong():N0} VNĐ");
        }
    }
    // Lớp quản lý công ty
    public class CongTy
    {
        private List<NhanVien> danhSach = new List<NhanVien>();

        public void NhapDanhSach()
        {
            Console.Write("Nhập số lượng nhân viên cần quản lý: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nChọn loại nhân viên thứ {i + 1}:");
                Console.WriteLine("1. Nhân viên Kinh doanh");
                Console.WriteLine("2. Nhân viên Sản xuất");
                Console.Write("Lựa chọn (1-2): ");
                string loai = Console.ReadLine();

                NhanVien nv = null;
                if (loai == "1")
                {
                    nv = new NhanVienKinhDoanh();
                }
                else if (loai == "2")
                {
                    nv = new NhanVienSanXuat();
                }
                else
                {
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập lại nhân viên này.");
                    i--;
                    continue;
                }

                nv.Nhap();
                danhSach.Add(nv);
            }
        }
        public void XuatDanhSach()
        {
            Console.WriteLine("\n=== BẢNG LƯƠNG CÔNG TY ===");
            foreach (var nv in danhSach)
            {
                nv.Xuat(); 
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CongTy ctx = new CongTy();
            ctx.NhapDanhSach();
            ctx.XuatDanhSach();
            
            Console.ReadLine();
        }
    }
}