using System;
namespace DaThucApp
{
    public class DaThuc
    {
        // n là bậc lớn nhất của đa thức
        private int n; 
        // Mảng chứa n + 1 hệ số (từ a_0 đến a_n)
        private double[] heSo; 
        // a. Các loại constructor
        // 1. Default constructor
        public DaThuc()
        {
            n = 0;
            heSo = new double[1];
            heSo[0] = 0;
        }
        // 2. Parameter constructor
        public DaThuc(int bac)
        {
            n = bac;
            heSo = new double[n + 1]; 
        }
        // 3. Copy constructor 
        public DaThuc(DaThuc other)
        {
            this.n = other.n;
            this.heSo = new double[n + 1];
            // Sao chép từng hệ số 
            for (int i = 0; i <= n; i++)
            {
                this.heSo[i] = other.heSo[i];
            }
        }
        // b. Indexer để truy cập đơn thức thứ i
        public double this[int i]
        {
            get
            {
                if (i < 0 || i > n)
                    throw new IndexOutOfRangeException("Chi so vuot qua bac cua da thuc.");
                return heSo[i];
            }
            set
            {
                if (i < 0 || i > n)
                    throw new IndexOutOfRangeException("Chi so vuot qua bac cua da thuc.");
                heSo[i] = value;
            }
        }
        // c. Nhập / Xuất
        public void Nhap()
        {
            Console.Write("Nhap bac cua da thuc n = ");
            n = int.Parse(Console.ReadLine());
            // Cấp phát lại mảng dựa trên bậc mới
            heSo = new double[n + 1];
            Console.WriteLine("Nhap cac he so cua da thuc:");
            for (int i = 0; i <= n; i++)
            {
                Console.Write($"He so a_{i} (di voi x^{i}) = ");
                heSo[i] = double.Parse(Console.ReadLine());
            }
        }
        public void Xuat()
        {
            Console.Write("P(x) = ");
            for (int i = 0; i <= n; i++)
            {
                // In theo định dạng a_i * x^i như trong đề bài
                Console.Write($"{heSo[i]}.x^{i}");
                
                // Thêm dấu "+" giữa các đơn thức, trừ đơn thức cuối cùng
                if (i < n) 
                {
                    Console.Write(" + ");
                }
            }
            Console.WriteLine();
        }

        // d. Tính giá trị của đa thức với giá trị x được nhập từ bàn phím
        public double TinhGiaTri(double x)
        {
            double ketQua = 0;
            for (int i = 0; i <= n; i++)
            {
                ketQua += heSo[i] * Math.Pow(x, i);
            }
            return ketQua;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DaThuc dt = new DaThuc();
            Console.WriteLine("--- NHAP DA THUC ---");
            dt.Nhap();
            Console.WriteLine("\n--- XUAT DA THUC ---");
            dt.Xuat();
            Console.WriteLine("\n--- TINH GIA TRI P(x) ---");
            Console.Write("Nhap gia tri x = ");
            double x = double.Parse(Console.ReadLine());
            double ketQua = dt.TinhGiaTri(x);
            Console.WriteLine($"Gia tri cua P({x}) = {ketQua}");
            Console.ReadLine();
        }
    }
}