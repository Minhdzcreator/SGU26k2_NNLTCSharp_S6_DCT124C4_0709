using System;
namespace bai1_5
{
    class DonThuc
    {
        // a là số thực, n là số nguyên không âm
        public double HeSo_a { get; set; }
        public int SoMu_n { get; set; }
        // Constructor
        public DonThuc(double heSo = 0, int soMu = 0)
        {
            HeSo_a = heSo;
            SoMu_n = soMu >= 0 ? soMu : 0; // Đảm bảo n không âm
        }
        // (a) Tính giá trị đơn thức P(x) = a.x^n
        public double TinhGiaTri(double x)
        {
            return HeSo_a * Math.Pow(x, SoMu_n);
        }
        // (b) Đạo hàm đơn thức Q(x) = P'(x) = a.n.x^(n-1)
        public DonThuc DaoHam()
        {
            if (SoMu_n == 0)
            {
                return new DonThuc(0, 0); // Đạo hàm của hằng số bằng 0
            }
            return new DonThuc(HeSo_a * SoMu_n, SoMu_n - 1);
        }
        public override string ToString()
        {
            if (HeSo_a == 0) return "0";
            if (SoMu_n == 0) return HeSo_a.ToString();
            if (SoMu_n == 1) return $"{HeSo_a}*x";
            return $"{HeSo_a}*x^{SoMu_n}";
        }
    }
    class Program
    {
        static void Main()
        {
            Console.Write("Nhap he so a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Nhap so mu n (n >= 0): ");
            int n = Convert.ToInt32(Console.ReadLine());
            DonThuc p = new DonThuc(a, n);
            Console.WriteLine($"Don thuc P(x) = {p}");
            Console.Write("Nhap gia tri x de tinh P(x): ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Gia tri P({x}) = {p.TinhGiaTri(x)}");
            DonThuc daoHam = p.DaoHam();
            Console.WriteLine($"Dao ham Q(x) = P'(x) = {daoHam}");
            Console.ReadLine();
        }
    }
}