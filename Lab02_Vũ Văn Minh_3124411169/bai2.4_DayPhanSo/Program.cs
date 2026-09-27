using System;
namespace bai2_4_DayPhanSo
{
    public class PhanSo
    {
        public int TuSo { get; set; }
        public int MauSo { get; set; }
        public PhanSo()
        {
            TuSo = 0;
            MauSo = 1;
        }
        public PhanSo(int tu, int mau)
        {
            TuSo = tu;
            MauSo = mau == 0 ? 1 : mau;
        }
        public void Nhap()
        {
            Console.Write("  - Nhap tu so: ");
            TuSo = int.Parse(Console.ReadLine());     
            do
            {
                Console.Write("  - Nhap mau so (khac 0): ");
                MauSo = int.Parse(Console.ReadLine());
            } while (MauSo == 0);
        }
        public void Xuat()
        {
            Console.Write($"{TuSo}/{MauSo}");
        }
        private int UCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (a * b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }
            return a + b;
        }
        public PhanSo RutGon()
        {
            if (TuSo == 0) return this;
            int ucln = UCLN(TuSo, MauSo);
            TuSo /= ucln;
            MauSo /= ucln;
            if (MauSo < 0)
            {
                TuSo = -TuSo;
                MauSo = -MauSo;
            }
            return this;
        }
        public PhanSo Cong(PhanSo khac)
        {
            int tuMoi = this.TuSo * khac.MauSo + khac.TuSo * this.MauSo;
            int mauMoi = this.MauSo * khac.MauSo;
            PhanSo ketQua = new PhanSo(tuMoi, mauMoi);
            return ketQua.RutGon();
        }
    }
    public class DayPhanSo
    {
        private PhanSo[] danhSach;
        private int n;
        public void Nhap()
        {
            Console.Write("Nhap so luong phan so n = ");
            if (int.TryParse(Console.ReadLine(), out n) && n > 0)
            {
                danhSach = new PhanSo[n];
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"Nhap phan so thu {i + 1}:");
                    danhSach[i] = new PhanSo();
                    danhSach[i].Nhap();
                }
            }
            else
            {
                Console.WriteLine("So luong khong hop le.");
                n = 0;
                danhSach = new PhanSo[0];
            }
        }
        public void Xuat()
        {
            if (n == 0) return;
            for (int i = 0; i < n; i++)
            {
                danhSach[i].Xuat();
                if (i < n - 1) Console.Write(" ; ");
            }
            Console.WriteLine();
        }
        // Tính tổng của n phân số
        public PhanSo TinhTong()
        {
            PhanSo tong = new PhanSo(0, 1); // Khởi tạo tổng = 0
            if (n == 0) return tong;

            for (int i = 0; i < n; i++)
            {
                tong = tong.Cong(danhSach[i]);
            }
            return tong;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DayPhanSo dayPS = new DayPhanSo();
            Console.WriteLine("--- NHAP DAY PHAN SO ---");
            dayPS.Nhap();
            Console.WriteLine("\n--- DAY PHAN SO VUA NHAP ---");
            dayPS.Xuat();
            Console.WriteLine("\n--- TONG DAY PHAN SO ---");
            PhanSo tong = dayPS.TinhTong();
            Console.Write("Tong = ");
            tong.Xuat();
            Console.ReadLine();
        }
    }
}