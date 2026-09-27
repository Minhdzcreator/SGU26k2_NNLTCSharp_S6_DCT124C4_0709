using System;
namespace MangMotChieu
{
    public class DaySo
    {
        private int[] arr;
        private int n;
        // a. Các loại Constructor
        // 1. Default Constructor
        public DaySo()
        {
            n = 0;
            arr = new int[0];
        }
        // 2. Parameter Constructor
        public DaySo(int size)
        {
            n = size;
            arr = new int[n];
        }
        // 3. Copy Constructor
        public DaySo(DaySo other)
        {
            this.n = other.n;
            this.arr = new int[this.n];
            for (int i = 0; i < this.n; i++)
            {
                this.arr[i] = other.arr[i];
            }
        }
        // b. Indexer để truy cập phần tử thứ i trong dãy
        public int this[int i]
        {
            get
            {
                if (i < 0 || i >= n)
                    throw new IndexOutOfRangeException("Chi so vuot qua gioi han cua mang.");
                return arr[i];
            }
            set
            {
                if (i < 0 || i >= n)
                    throw new IndexOutOfRangeException("Chi so vuot qua gioi han cua mang.");
                arr[i] = value;
            }
        }
        // c. Nhập / Xuất dãy số
        public void Nhap()
        {
            Console.Write("Nhap so luong phan tu n = ");
            if (int.TryParse(Console.ReadLine(), out n) && n > 0)
            {
                arr = new int[n];
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Nhap phan tu arr[{i}] = ");
                    arr[i] = int.Parse(Console.ReadLine());
                }
            }
            else
            {
                Console.WriteLine("So luong phan tu khong hop le.");
                n = 0;
                arr = new int[0];
            }
        }
        public void Xuat()
        {
            if (n == 0)
            {
                Console.WriteLine("Day so rong.");
                return;
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
        // d. Tìm các số chẵn
        public void TimSoChan()
        {
            Console.Write("Cac so chan trong day la: ");
            bool hasEven = false;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    Console.Write(arr[i] + " ");
                    hasEven = true;
                }
            }
            if (!hasEven)
            {
                Console.Write("Khong co so chan nao.");
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DaySo ds = new DaySo();
            Console.WriteLine("--- NHAP DAY SO ---");
            ds.Nhap();
            Console.WriteLine("\n--- XUAT DAY SO ---");
            ds.Xuat();
            Console.WriteLine("\n--- TIM SO CHAN ---");
            ds.TimSoChan();
            Console.ReadLine();
        }
    }
}