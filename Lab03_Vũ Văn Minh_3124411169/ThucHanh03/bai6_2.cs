namespace BaiThucHanhLINQ
{
    public class Bai6_2
    {
        public static void GiaiBai6_2()
        {
            Console.WriteLine("\n--- Bài 6.2 Join và các toán tử tập hợp ---");
            // Lấy nguồn dữ liệu từ Bài 4.1 và 6.1
            List<MonHoc> dsMon = DuLieu.DS_Mon();
            List<He> dsHe = DuLieuHe.DS_He();
            // a. Dùng join để liệt kê: Tên hệ, Mã môn, Tên môn (Inner Join)
            var cauA = from m in dsMon
                       join h in dsHe on m.He equals h.MaHe
                       select new { h.TenHe, m.MaMon, m.TenMon };
            Console.WriteLine("\na. Danh sách môn học có hệ tương ứng (Inner Join):");
            foreach (var item in cauA)
            {
                Console.WriteLine($"  - Hệ: {item.TenHe,-20} | Mã: {item.MaMon,-5} | Tên: {item.TenMon}");
            }
            // b. Liệt kê cả hệ chưa có môn học (Left Outer Join)
            var cauB = from h in dsHe
                       join m in dsMon on h.MaHe equals m.He into nhomMon
                       from m in nhomMon.DefaultIfEmpty() // Khớp nếu không có môn
                       select new 
                       { 
                           TenHe = h.TenHe, 
                           MaMon = m?.MaMon ?? "N/A", 
                           TenMon = m?.TenMon ?? "Không có môn học" 
                       };
            Console.WriteLine("\nb. Danh sách tất cả các hệ (kể cả hệ chưa có môn):");
            foreach (var item in cauB)
            {
                Console.WriteLine($"  - Hệ: {item.TenHe,-20} | Mã: {item.MaMon,-5} | Tên: {item.TenMon}");
            }
            // c. Liệt kê cả hệ chưa có môn và môn chưa khai báo hệ (Full Outer Join)
            var heChuaMonVaHeCoMon = cauB; // Lấy kết quả Left Join ở câu b
            
            var monChuaHe = from m in dsMon
                            where !dsHe.Any(h => h.MaHe == m.He)
                            select new 
                            { 
                                TenHe = "Hệ chưa khai báo", 
                                MaMon = m.MaMon, 
                                TenMon = m.TenMon 
                            };
            var cauC = heChuaMonVaHeCoMon.Union(monChuaHe);
            Console.WriteLine("\nc. Tất cả hệ và tất cả môn (Full Outer Join):");
            foreach (var item in cauC)
            {
                Console.WriteLine($"  - Hệ: {item.TenHe,-20} | Mã: {item.MaMon,-5} | Tên: {item.TenMon}");
            }
            // d. Chỉ liệt kê những hệ chưa có môn và những môn chưa khai báo hệ
            var heChuaMon = from h in dsHe
                            where !dsMon.Any(m => m.He == h.MaHe)
                            select new { TenHe = h.TenHe, MaMon = "N/A", TenMon = "N/A" };
            var cauD = heChuaMon.Union(monChuaHe);
            Console.WriteLine("\nd. Những hệ chưa có môn HOẶC môn chưa có hệ:");
            foreach (var item in cauD)
            {
                Console.WriteLine($"  - Hệ: {item.TenHe,-20} | Mã: {item.MaMon,-5} | Tên: {item.TenMon}");
            }
            // e. Lấy 5 môn học đầu tiên có số tiết giảm dần; hiển thị Tên hệ, Mã, Tên, Số tiết
            var top5Mon = (from m in dsMon
                           orderby m.SoTiet descending
                           select m).Take(5);
            var cauE = from m in top5Mon
                       join h in dsHe on m.He equals h.MaHe into hm
                       from h in hm.DefaultIfEmpty()
                       select new 
                       { 
                           TenHe = h?.TenHe ?? "Chưa rõ hệ", 
                           m.MaMon, 
                           m.TenMon, 
                           m.SoTiet 
                       };
            Console.WriteLine("\ne. Top 5 môn có số tiết cao nhất:");
            foreach (var item in cauE)
            {
                Console.WriteLine($"  - Hệ: {item.TenHe,-20} | Mã: {item.MaMon,-5} | Số tiết: {item.SoTiet,-3} | Tên: {item.TenMon}");
            }
            // f. Tổng số môn học của mỗi hệ: Mã hệ, Tên hệ, Tổng số môn
            var cauF = from h in dsHe
                       join m in dsMon on h.MaHe equals m.He into hm
                       select new { h.MaHe, h.TenHe, TongSoMon = hm.Count() };
            Console.WriteLine("\nf. Tổng số môn học của mỗi hệ:");
            foreach (var item in cauF)
            {
                Console.WriteLine($"  - [{item.MaHe}] {item.TenHe,-20} | Tổng số môn: {item.TongSoMon}");
            }
            // g. Có bao nhiêu loại Số tiết khác nhau
            int loaiSoTiet = dsMon.Select(m => m.SoTiet).Distinct().Count();
            Console.WriteLine($"\ng. Số lượng loại số tiết khác nhau: {loaiSoTiet}");
            // h. Tìm môn học đầu tiên có tên bắt đầu bằng "Lập trình"
            var monLapTrinh = dsMon.FirstOrDefault(m => m.TenMon.StartsWith("Lập trình"));
            Console.WriteLine("\nh. Môn đầu tiên bắt đầu bằng 'Lập trình':");
            if (monLapTrinh != null)
                Console.WriteLine($"  - [{monLapTrinh.MaMon}] {monLapTrinh.TenMon} ({monLapTrinh.SoTiet} tiết)");
            else
                Console.WriteLine("  - Không tìm thấy môn học nào.");
            // i. Liệt kê các môn theo từng hệ, đánh số thứ tự trong mỗi nhóm
            Console.WriteLine("\ni. Liệt kê môn theo hệ, đánh số thứ tự:");
            var cauI = from m in dsMon
                       group m by m.He into nhomHe
                       select nhomHe;
            foreach (var nhom in cauI)
            {
                // Tìm tên hệ dựa vào mã hệ (nếu mã trống hoặc không có, gán mặc định)
                string tenHe = dsHe.FirstOrDefault(h => h.MaHe == nhom.Key)?.TenHe ?? "Hệ chưa khai báo/Khác";
                Console.WriteLine($"  + Nhóm: {tenHe} (Mã: {nhom.Key})");
                int stt = 1;
                foreach (var m in nhom)
                {
                    Console.WriteLine($"      {stt++}. [{m.MaMon}] {m.TenMon}");
                }
            }
        }
    }
}