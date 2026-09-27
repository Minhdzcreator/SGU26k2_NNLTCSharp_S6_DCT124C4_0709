using System;
namespace bai2_4_Mang2Chieu
{
    public class MangHaiChieu
    {
        private int[,] arr;
        private int n; 
        private int m;
        // a. Các loại constructor
        // 1. Default constructor
        public MangHaiChieu()
        {
            n = 0;
            m = 0;
            arr = new int[0, 0];
        }
        // 2. Parameter constructor
        public MangHaiChieu(int rows, int cols)
        {
            n = rows;
            m = cols;
            arr = new int[n, m];
        }
        // 3. Copy constructor
        public MangHaiChieu(MangHaiChieu other)
        {
            this.n = other.n;
            this.m = other.m;
            this.arr = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    this.arr[i, j] = other.arr[i, j];
                }
            }
        }
        // b. Indexer để truy cập phần tử tại (i, j)
        public int this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= n || j < 0 || j >= m)
                    throw new IndexOutOfRangeException("Chi so vuot qua gioi han cua mang.");
                return arr[i, j];
            }
            set
            {
                if (i < 0 || i >= n || j < 0 || j >= m)
                    throw new IndexOutOfRangeException("Chi so vuot qua gioi han cua mang.");
                arr[i, j] = value;
            }
        }
        // c. Nhập / Xuất
        public void Nhap()
        {
            Console.Write("Nhap so dong n = ");
            n = int.Parse(Console.ReadLine());
            Console.Write("Nhap so cot m = ");
            m = int.Parse(Console.ReadLine());
            arr = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"Nhap phan tu arr[{i},{j}] = ");
                    arr[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }
        public void Xuat()
        {
            if (n == 0 || m == 0)
            {
                Console.WriteLine("Mang rong.");
                return;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    // In các phần tử trên cùng một dòng, cách nhau bởi khoảng trắng
                    Console.Write(arr[i, j] + "\t"); 
                }
                Console.WriteLine();
            }
        }
        // d. Tìm các số nguyên tố trong mảng
        private bool LaSoNguyenTo(int so)
        {
            if (so < 2) return false;
            for (int i = 2; i <= Math.Sqrt(so); i++)
            {
                if (so % i == 0) return false;
            }
            return true;
        }
        // Hàm chính thực hiện yêu cầu tìm số nguyên tố
        public void TimSoNguyenTo()
        {
            Console.Write("Cac so nguyen to trong mang la: ");
            bool coSoNguyenTo = false;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (LaSoNguyenTo(arr[i, j]))
                    {
                        Console.Write(arr[i, j] + " ");
                        coSoNguyenTo = true;
                    }
                }
            }
            if (!coSoNguyenTo)
            {
                Console.Write("Khong co so nguyen to nao.");
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MangHaiChieu m2c = new MangHaiChieu();
            Console.WriteLine("--- NHAP MANG 2 CHIEU ---");
            m2c.Nhap();
            Console.WriteLine("\n--- XUAT MANG 2 CHIEU ---");
            m2c.Xuat();
            Console.WriteLine("\n--- TIM SO NGUYEN TO ---");
            m2c.TimSoNguyenTo();
            Console.ReadLine();
        }
    }
}