using System;
using System.Collections.Generic;
namespace Bai3_6_TinhDiemThiSinh
{
    // Lớp cha
    public abstract class ThiSinh
    {
        public string SBD { get; set; }
        public string HoTen { get; set; }
        public double Bai1 { get; set; }
        public double Bai2 { get; set; }
        public double Bai3 { get; set; }
        public double TongDiem { get; protected set; } 
        public virtual void Nhap()
        {
            Console.Write("  - Nhập SBD: "); SBD = Console.ReadLine();
            Console.Write("  - Nhập Họ tên: "); HoTen = Console.ReadLine();
            Console.Write("  - Nhập điểm Bài 1: "); Bai1 = double.Parse(Console.ReadLine());
            Console.Write("  - Nhập điểm Bài 2: "); Bai2 = double.Parse(Console.ReadLine());
            Console.Write("  - Nhập điểm Bài 3: "); Bai3 = double.Parse(Console.ReadLine());
        }
        // Phương thức thuần ảo yêu cầu các lớp con tự định nghĩa cách tính điểm
        public abstract void TinhTongDiem();
        public virtual void Xuat()
        {
            Console.Write($"SBD: {SBD,-5} | Họ tên: {HoTen,-15} | B1: {Bai1} | B2: {Bai2} | B3: {Bai3} | ");
        }
    }
    // Lớp thí sinh Chuyên 
    public class ThiSinhChuyen : ThiSinh
    {
        public double TiengAnh { get; set; }
        public override void Nhap()
        {
            Console.WriteLine("--- Thông tin Thí sinh Chuyên ---");
            base.Nhap();
            Console.Write("  - Nhập điểm Tiếng Anh: "); 
            TiengAnh = double.Parse(Console.ReadLine());
        }
        // Tính điểm: Tổng 3 bài + Điểm thưởng Tiếng Anh
        public override void TinhTongDiem()
        {
            double diemThuong = 0;
            if (TiengAnh >= 7 && TiengAnh <= 8) 
                diemThuong = 1;
            else if (TiengAnh >= 9 && TiengAnh <= 10) 
                diemThuong = 2;

            TongDiem = Bai1 + Bai2 + Bai3 + diemThuong;
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"T.Anh: {TiengAnh} | TỔNG ĐIỂM: {TongDiem}");
        }
    }
    // Lớp thí sinh Siêu cúp (dành cho thí sinh đã đoạt giải)
    public class ThiSinhSieuCup : ThiSinh
    {
        public double CSDL { get; set; }
        public override void Nhap()
        {
            Console.WriteLine("--- Thông tin Thí sinh Siêu Cúp ---");
            base.Nhap();
            Console.Write("  - Nhập điểm CSDL: "); 
            CSDL = double.Parse(Console.ReadLine());
        }
        // Tính điểm: Tổng 4 bài (3 bài lập trình + CSDL)
        public override void TinhTongDiem()
        {
            TongDiem = Bai1 + Bai2 + Bai3 + CSDL;
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"CSDL: {CSDL}  | TỔNG ĐIỂM: {TongDiem}");
        }
    }
    // Lớp quản lý Cuộc thi chứa danh sách các thí sinh
    public class CuocThi
    {
        private List<ThiSinh> danhSach = new List<ThiSinh>();

        public void NhapDanhSach()
        {
            Console.Write("Nhập số lượng thí sinh tham gia: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0) return;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nChọn đối tượng cho thí sinh thứ {i + 1}:");
                Console.WriteLine("1. Chuyên (chưa có giải trước đây)");
                Console.WriteLine("2. Siêu cúp (đã đoạt giải trước đây)");
                Console.Write("Lựa chọn (1-2): ");
                string loai = Console.ReadLine();

                ThiSinh ts = null;
                if (loai == "1")
                {
                    ts = new ThiSinhChuyen();
                }
                else if (loai == "2")
                {
                    ts = new ThiSinhSieuCup();
                }
                else
                {
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập lại.");
                    i--; // Quay lại vòng lặp hiện tại
                    continue;
                }
                ts.Nhap();
                ts.TinhTongDiem(); // Tính tổng điểm ngay sau khi nhập xong dữ liệu
                danhSach.Add(ts);
            }
        }
        public void XuatKetQua()
        {
            Console.WriteLine("\n================ KẾT QUẢ CUỘC THI ================");
            foreach (var ts in danhSach)
            {
                ts.Xuat(); 
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Hỗ trợ hiển thị tiếng Việt trên Console
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
            CuocThi cuocThiTinHoc = new CuocThi();
            cuocThiTinHoc.NhapDanhSach();
            cuocThiTinHoc.XuatKetQua();
            Console.ReadLine();
        }
    }
}