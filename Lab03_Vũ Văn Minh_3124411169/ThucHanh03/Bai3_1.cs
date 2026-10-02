using System;
using System.Linq;
namespace BaiThucHanhLINQ
{
    public class Bai3_1
    {
        public static void GiaiBai3_1()
        {
            Console.WriteLine("\n--- Bài 3.1 Thống kê mảng số ---");
            int[] mangSo = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };
            // --- Câu A ---
            // Sử dụng Method Syntax cho các hàm thống kê đếm nhanh
            int tongSoPhanTu = mangSo.Count();
            int soPhanTuChan = mangSo.Count(n => n % 2 == 0);
            int soPhanTuLe = mangSo.Count(n => n % 2 != 0);
            Console.WriteLine("Đáp án câu a: ");
            Console.WriteLine($"  - Tổng số phần tử: {tongSoPhanTu}");
            Console.WriteLine($"  - Số phần tử chẵn: {soPhanTuChan}");
            Console.WriteLine($"  - Số phần tử lẻ: {soPhanTuLe}");
            // --- Câu B ---
            int tongGiaTri = mangSo.Sum();
            int giaTriLonNhat = mangSo.Max();
            int giaTriNhoNhat = mangSo.Min();
            Console.WriteLine("Đáp án câu b: ");
            Console.WriteLine($"  - Tổng các giá trị: {tongGiaTri}");
            Console.WriteLine($"  - Giá trị lớn nhất: {giaTriLonNhat}");
            Console.WriteLine($"  - Giá trị nhỏ nhất: {giaTriNhoNhat}");
            // --- Câu C ---
            int soGiaTriKhacNhau = mangSo.Distinct().Count();
            Console.WriteLine("Đáp án câu c: ");
            Console.WriteLine($"  - Số lượng giá trị khác nhau: {soGiaTriKhacNhau}");
            // --- Câu D ---
            var cauD = from n in mangSo
                       group n by n % 5 into nhomSoDu
                       select nhomSoDu;
            Console.WriteLine("Đáp án câu d: ");
            foreach (var nhom in cauD)
            {
                Console.Write($"  - Nhóm có số dư {nhom.Key} khi chia cho 5: ");
                foreach (int n in nhom)
                {
                    Console.Write(n + " ");
                }
                Console.WriteLine();
            }
        }
    }
}