using System;
using System.Collections.Generic;
using System.Linq;
namespace BaiThucHanhLINQ
{
    public class Bai5_2
    {
        public static void GiaiBai5_2()
        {
            Console.WriteLine("\n--- Bài 5.2 Thống kê trên List<MonHoc> ---");
            // Lấy nguồn dữ liệu từ lớp DuLieu
            List<MonHoc> dsMon = DuLieu.DS_Mon();
            // a. Cho biết tổng số môn hiện có.
            int tongSoMon = dsMon.Count;
            Console.WriteLine($"a. Tổng số môn hiện có: {tongSoMon}");
            // b. Đếm số môn có tên bắt đầu bằng “Lập trình”.
            int demLapTrinh = dsMon.Count(m => m.TenMon.StartsWith("Lập trình"));
            Console.WriteLine($"b. Số môn bắt đầu bằng 'Lập trình': {demLapTrinh}");
            // c. Tính tổng số tiết của hệ Kỹ thuật viên (KTV).
            int tongTietKTV = dsMon.Where(m => m.He == "KTV").Sum(m => m.SoTiet);
            Console.WriteLine($"c. Tổng số tiết của hệ KTV: {tongTietKTV}");
            // d. Cho biết tổng số môn của mỗi hệ: Hệ, Tổng số môn.
            var cauD = from m in dsMon
                       group m by m.He into g
                       select new { He = g.Key, TongSoMon = g.Count() };
            Console.WriteLine("\nd. Tổng số môn của mỗi hệ:");
            foreach (var item in cauD)
            {
                string tenHe = string.IsNullOrEmpty(item.He) ? "Chưa rõ hệ" : item.He;
                Console.WriteLine($"  - Hệ: {tenHe,-10} | Tổng số môn: {item.TongSoMon}");
            }

            // e. Nhóm theo Số tiết; in Số tiết và Tổng số môn, sắp xếp giảm dần theo Số tiết.
            var cauE = from m in dsMon
                       group m by m.SoTiet into g
                       orderby g.Key descending
                       select new { SoTiet = g.Key, TongSoMon = g.Count() };

            Console.WriteLine("\ne. Nhóm theo số tiết (giảm dần):");
            foreach (var item in cauE)
            {
                Console.WriteLine($"  - Số tiết: {item.SoTiet,-3} | Tổng số môn: {item.TongSoMon}");
            }
            // f. Cho biết thông tin môn học có số tiết cao nhất.
            int maxSoTiet = dsMon.Max(m => m.SoTiet);
            var cauF = dsMon.Where(m => m.SoTiet == maxSoTiet);
            
            Console.WriteLine($"\nf. Các môn học có số tiết cao nhất ({maxSoTiet} tiết):");
            foreach (var m in cauF)
            {
                Console.WriteLine($"  - [{m.MaMon}] {m.TenMon}");
            }
            // g. Thống kê theo Hệ: tổng số môn, tổng số tiết, số tiết cao nhất, số tiết thấp nhất.
            var cauG = from m in dsMon
                       group m by m.He into g
                       select new 
                       { 
                           He = string.IsNullOrEmpty(g.Key) ? "Chưa rõ hệ" : g.Key,
                           TongMon = g.Count(),
                           TongTiet = g.Sum(x => x.SoTiet),
                           MaxTiet = g.Max(x => x.SoTiet),
                           MinTiet = g.Min(x => x.SoTiet)
                       };
            Console.WriteLine("\ng. Thống kê chi tiết theo Hệ:");
            foreach (var item in cauG)
            {
                Console.WriteLine($"  - Hệ {item.He}: Tổng môn: {item.TongMon}, Tổng tiết: {item.TongTiet}, Max: {item.MaxTiet}, Min: {item.MinTiet}");
            }
            // h. Liệt kê các môn học được phân nhóm theo Hệ.
            var cauH = from m in dsMon
                       group m by m.He into g
                       select g;
            Console.WriteLine("\nh. Danh sách môn học phân nhóm theo Hệ:");
            foreach (var nhom in cauH)
            {
                string tenHe = string.IsNullOrEmpty(nhom.Key) ? "Chưa rõ hệ" : nhom.Key;
                Console.WriteLine($"  + Hệ: {tenHe}");
                foreach (var m in nhom)
                    Console.WriteLine($"      - {m.TenMon}");
            }
            // i. Liệt kê các môn học được phân nhóm theo Số tiết và tăng dần theo Số tiết.
            var cauI = from m in dsMon
                       group m by m.SoTiet into g
                       orderby g.Key ascending
                       select g;
            Console.WriteLine("\ni. Danh sách môn học phân nhóm theo Số tiết (tăng dần):");
            foreach (var nhom in cauI)
            {
                Console.WriteLine($"  + Số tiết: {nhom.Key}");
                foreach (var m in nhom)
                    Console.WriteLine($"      - {m.TenMon}");
            }
            // j. Với hệ KTV, phân nhóm theo học phần HP2, HP3, HP4, HP5; sắp xếp theo Mã môn.
            var cauJ = from m in dsMon
                       where m.He == "KTV"
                       orderby m.MaMon ascending // Sắp xếp theo mã môn trước khi nhóm hoặc trong từng nhóm
                       group m by m.MaMon.Substring(0, 3) into g // Cắt 3 ký tự đầu (HP2, HP3...) để làm nhóm
                       select g;

            Console.WriteLine("\nj. Hệ KTV, phân nhóm theo HP2, HP3, HP4, HP5:");
            foreach (var nhom in cauJ)
            {
                Console.WriteLine($"  + Nhóm {nhom.Key}:");
                foreach (var m in nhom)
                    Console.WriteLine($"      - [{m.MaMon}] {m.TenMon}");
            }
            // k. Phân nhóm theo Hệ, chỉ lấy các môn có Số tiết > 40; trong mỗi nhóm sắp xếp theo Mã môn.
            var cauK = from m in dsMon
                       where m.SoTiet > 40
                       orderby m.MaMon ascending
                       group m by m.He into g
                       select g;

            Console.WriteLine("\nk. Phân nhóm theo Hệ (Số tiết > 40, sắp xếp theo Mã môn):");
            foreach (var nhom in cauK)
            {
                string tenHe = string.IsNullOrEmpty(nhom.Key) ? "Chưa rõ hệ" : nhom.Key;
                Console.WriteLine($"  + Hệ: {tenHe}");
                foreach (var m in nhom)
                    Console.WriteLine($"      - [{m.MaMon}] {m.TenMon} ({m.SoTiet} tiết)");
            }
        }
    }
}