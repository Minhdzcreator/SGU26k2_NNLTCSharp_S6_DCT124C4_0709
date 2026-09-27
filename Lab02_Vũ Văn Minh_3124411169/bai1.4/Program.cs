using System;
namespace bai1_4
{
    class PhanSo
    {
        public int TuSo { get; set; }
        public int MauSo { get; set; }
        // 1. Constructors
        public PhanSo()
        {
            TuSo = 0;
            MauSo = 1;
        }
        // Parameter Constructor
        public PhanSo(int tu, int mau)
        {
            TuSo = tu;
            MauSo = mau != 0 ? mau : 1; // Tránh lỗi chia cho 0
            ChuanHoa();
        }
        // Copy Constructor
        public PhanSo(PhanSo p)
        {
            TuSo = p.TuSo;
            MauSo = p.MauSo;
        }
        // Hàm tối giản phân số
        private void ChuanHoa()
        {
            if (MauSo < 0)
            {
                TuSo = -TuSo;
                MauSo = -MauSo;
            }
            int ucln = UCLN(Math.Abs(TuSo), Math.Abs(MauSo));
            if (ucln > 0)
            {
                TuSo /= ucln;
                MauSo /= ucln;
            }
        }
        private int UCLN(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        // 2. Override ToString()
        public override string ToString()
        {
            if (TuSo == 0) return "0";
            if (MauSo == 1) return TuSo.ToString();
            return $"{TuSo}/{MauSo}";
        }
        // 3. Overload toán tử
        // Một ngôi: +, -
        public static PhanSo operator +(PhanSo a) => new PhanSo(a.TuSo, a.MauSo);
        public static PhanSo operator -(PhanSo a) => new PhanSo(-a.TuSo, a.MauSo);
        // Hai ngôi: +, -, *, /
        public static PhanSo operator +(PhanSo a, PhanSo b) => 
            new PhanSo(a.TuSo * b.MauSo + b.TuSo * a.MauSo, a.MauSo * b.MauSo);
        public static PhanSo operator -(PhanSo a, PhanSo b) => 
            new PhanSo(a.TuSo * b.MauSo - b.TuSo * a.MauSo, a.MauSo * b.MauSo);
        public static PhanSo operator *(PhanSo a, PhanSo b) => 
            new PhanSo(a.TuSo * b.TuSo, a.MauSo * b.MauSo);
        public static PhanSo operator /(PhanSo a, PhanSo b) => 
            new PhanSo(a.TuSo * b.MauSo, a.MauSo * b.TuSo);
        // So sánh: >, <, >=, <=, ==, !=
        public static bool operator >(PhanSo a, PhanSo b) => (double)a.TuSo / a.MauSo > (double)b.TuSo / b.MauSo;
        public static bool operator <(PhanSo a, PhanSo b) => (double)a.TuSo / a.MauSo < (double)b.TuSo / b.MauSo;
        public static bool operator >=(PhanSo a, PhanSo b) => (double)a.TuSo / a.MauSo >= (double)b.TuSo / b.MauSo;
        public static bool operator <=(PhanSo a, PhanSo b) => (double)a.TuSo / a.MauSo <= (double)b.TuSo / b.MauSo;
        public static bool operator ==(PhanSo a, PhanSo b) 
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return ReferenceEquals(a, b);
            return a.TuSo * b.MauSo == b.TuSo * a.MauSo;
        }
        public static bool operator !=(PhanSo a, PhanSo b) => !(a == b);
        // Bắt buộc khi override == và !=
        public override bool Equals(object obj)
        {
            if (obj is PhanSo p) return this == p;
            return false;
        }
        public override int GetHashCode() => HashCode.Combine(TuSo, MauSo);
    }
    class Program
    {
        static void Main()
        {
            PhanSo p1 = new PhanSo(1, 2);
            PhanSo p2 = new PhanSo(3, 4);
            Console.WriteLine($"p1 = {p1}, p2 = {p2}");
            Console.WriteLine($"p1 + p2 = {p1 + p2}");
            Console.WriteLine($"p1 - p2 = {p1 - p2}");
            Console.WriteLine($"p1 * p2 = {p1 * p2}");
            Console.WriteLine($"p1 / p2 = {p1 / p2}");
            Console.WriteLine($"p1 > p2 : {p1 > p2}");
            Console.WriteLine($"p1 == p2 : {p1 == p2}");
        }
    }
}