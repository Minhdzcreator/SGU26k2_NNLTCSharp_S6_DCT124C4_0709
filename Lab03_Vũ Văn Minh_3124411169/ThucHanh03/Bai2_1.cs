using System;
using System.Linq;

namespace BaiThucHanhLINQ
{
    public class Bai2_1()
    {
        public static void GiaiBai2_1()
        {
            Console.WriteLine("--- Bài 2.1 Truy vấn mảng số nguyên ---");
            int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };

            // --- Câu A ---
            var cauA = from n in mangSo
                       where n % 3 == 0 && n % 4 == 0
                       select n;

            Console.Write("Đáp án câu a: ");
            foreach (int n in cauA)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();

            // --- Câu B ---
            var cauB = from n in mangSo
                       where n <= 3
                       select n;

            Console.Write("Đáp án câu b: ");
            foreach (int n in cauB)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();

            // --- Câu C ---
            var cauC = from n in mangSo
                       select (n % 2 == 0) ? (n / 2) : n;

            Console.Write("Đáp án câu c: ");
            foreach (int n in cauC)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
        }
    }
}