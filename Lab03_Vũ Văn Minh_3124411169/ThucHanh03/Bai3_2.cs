using System;
using System.Linq;
namespace BaiThucHanhLINQ
{
    public class Bai3_2
    {
        public static void GiaiBai3_2()
        {
            Console.WriteLine("\n--- Bài 3.2 Thống kê mảng chuỗi ---");
            string[] monAn = { "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì",
                               "Nước Cà phê", "Mì quảng", "Cơm tấm", "Nước Chanh dây", "Mì xào",
                               "Bún riêu", "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang" };
            // --- Câu A ---
            // Tìm chiều dài ngắn nhất và dài nhất
            int minLength = monAn.Min(s => s.Length);
            int maxLength = monAn.Max(s => s.Length);

            var nganNhat = from s in monAn
                           where s.Length == minLength
                           select s;

            var daiNhat = from s in monAn
                          where s.Length == maxLength
                          select s;
            Console.WriteLine("Đáp án câu a:");
            Console.WriteLine($"  - Phần tử ngắn nhất (độ dài {minLength}): {string.Join(", ", nganNhat)}");
            Console.WriteLine($"  - Phần tử dài nhất (độ dài {maxLength}): {string.Join(", ", daiNhat)}");
            // --- Câu B ---
            // Phân nhóm theo từ đầu tiên (tách chuỗi bằng khoảng trắng và lấy phần tử đầu)
            var cauB = from s in monAn
                       group s by s.Split(' ')[0] into nhomTuDau
                       select nhomTuDau;

            Console.WriteLine("Đáp án câu b (Phân nhóm theo từ đầu tiên):");
            foreach (var nhom in cauB)
            {
                Console.WriteLine($"  + Nhóm '{nhom.Key}':");
                foreach (var mon in nhom)
                {
                    Console.WriteLine($"      - {mon}");
                }
            }
            // --- Câu C ---
            // Đếm số phần tử có từ đầu tiên là "Bánh"
            int demBanh = monAn.Count(s => s.StartsWith("Bánh"));
            Console.WriteLine("Đáp án câu c:");
            Console.WriteLine($"  - Số phần tử có từ đầu tiên là \"Bánh\": {demBanh}");
        }
    }
}