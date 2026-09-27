using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiThucHanhLINQ
{
    public class Bai5_1
    {
        public static void GiaiBai5_1()
        {
            Console.WriteLine("\n--- Bài 5.1 Truy vấn cơ bản ---");
            
            // Lấy nguồn dữ liệu từ lớp DuLieu (Bài 4.1)
            List<MonHoc> dsMon = DuLieu.DS_Mon();

            // --- Câu A ---
            // Liệt kê tên các môn học bắt đầu bằng "Lập trình"
            var cauA = from m in dsMon
                       where m.TenMon.StartsWith("Lập trình")
                       select m.TenMon;

            Console.WriteLine("Đáp án câu a (Môn bắt đầu bằng 'Lập trình'):");
            foreach (var ten in cauA)
            {
                Console.WriteLine($"  - {ten}");
            }

            // --- Câu B ---
            // Liệt kê các môn thuộc hệ "CD", sắp xếp số tiết giảm dần rồi mã môn tăng dần
            var cauB = from m in dsMon
                       where m.He == "CD"
                       orderby m.SoTiet descending, m.MaMon ascending
                       select m;

            Console.WriteLine("\nĐáp án câu b (Hệ 'CD', Số tiết giảm, Mã môn tăng):");
            foreach (var m in cauB)
            {
                Console.WriteLine($"  - Mã: {m.MaMon,-5} | Số tiết: {m.SoTiet,-3} | Tên: {m.TenMon}");
            }

            // --- Câu C ---
            // Liệt kê các môn có tên chứa từ "web", chỉ lấy Tên môn và Hệ
            // Dùng ToLower() để tìm kiếm không phân biệt chữ hoa/chữ thường
            var cauC = from m in dsMon
                       where m.TenMon.ToLower().Contains("web")
                       select new { m.TenMon, m.He };

            Console.WriteLine("\nĐáp án câu c (Tên chứa 'web', chỉ lấy Tên và Hệ):");
            foreach (var item in cauC)
            {
                Console.WriteLine($"  - Tên môn: {item.TenMon} | Hệ: {item.He}");
            }

            // --- Câu D ---
            // Liệt kê các môn thuộc hệ "KTV", sắp xếp tăng dần theo Mã môn
            var cauD = from m in dsMon
                       where m.He == "KTV"
                       orderby m.MaMon ascending
                       select m;

            Console.WriteLine("\nĐáp án câu d (Hệ 'KTV', Mã môn tăng dần):");
            foreach (var m in cauD)
            {
                Console.WriteLine($"  - Mã: {m.MaMon,-5} | Hệ: {m.He,-3} | Tên: {m.TenMon}");
            }
        }
    }
}