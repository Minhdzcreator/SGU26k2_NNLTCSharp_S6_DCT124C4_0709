<Query Kind="Program" />

// LINQPad 9 - C# Program mode

void Main()
{
    Console.OutputEncoding = System.Text.Encoding.UTF8;

    Bai21();
    Bai22();
    Bai31();
    Bai32();
    Bai41();
    Bai51();
    Bai52();
    Bai61();
    Bai62();

    "KẾT THÚC CHƯƠNG TRÌNH".Dump();
}

// Bài 2.1
void Bai21()
{
    "================ BÀI 2.1 ================".Dump();

    int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };
	// câu a
    var aQuery = from x in mangSo
                 where x % 4 == 0 && x % 3 == 0
                 select x;

    var aMethod = mangSo.Where(x => x % 4 == 0 && x % 3 == 0);

    aQuery.Dump("Câu a - Query");
    aMethod.Dump("Câu a - Method");
	// câu b
    var bQuery = from x in mangSo where x <= 3 select x;
    var bMethod = mangSo.Where(x => x <= 3);

    bQuery.Dump("Câu b - Query");
    bMethod.Dump("Câu b - Method");
	// câu c
    var cQuery = from x in mangSo select x % 2 == 0 ? x / 2 : x;
    var cMethod = mangSo.Select(x => x % 2 == 0 ? x / 2 : x);

    cQuery.Dump("Câu c - Query");
    cMethod.Dump("Câu c - Method");
}

// Bài 2.2
void Bai22()
{
    "================ BÀI 2.2 ================".Dump();

    string[] mangChuoi =
    {
        "đầu", "lòng", "hai", "ả", "tố", "nga",
        "Thúy", "Kiều", "là", "chị", "em",
        "là", "Thúy", "Vân"
    };

    var aQuery = from x in mangChuoi
                 where x.Length == 4
                 orderby x[0]
                 select x;

    var aMethod = mangChuoi.Where(x => x.Length == 4).OrderBy(x => x[0]);

    aQuery.Dump("Câu a - Query");
    aMethod.Dump("Câu a - Method");

    (from x in mangChuoi select $"{x.ToLower()} - {x.ToUpper()}")
        .Dump("Câu b");

    (from x in mangChuoi where x.Contains("u") select x)
        .Dump("Câu c");

    (from x in mangChuoi where x.Length > 0 && char.IsUpper(x[0]) select x)
        .Dump("Câu d");
}

// Bài 3.1
void Bai31()
{
    "================ BÀI 3.1 ================".Dump();

    int[] mangSo = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };

    new
    {
        TongSoPhanTu = mangSo.Count(),
        SoChan = mangSo.Count(x => x % 2 == 0),
        SoLe = mangSo.Count(x => x % 2 != 0)
    }.Dump("Câu a");

    new
    {
        Tong = mangSo.Sum(),
        LonNhat = mangSo.Max(),
        NhoNhat = mangSo.Min()
    }.Dump("Câu b");

    mangSo.Distinct().Count().Dump("Câu c - Số giá trị khác nhau");

    mangSo.GroupBy(x => x % 5)
          .OrderBy(g => g.Key)
          .Select(g => new { SoDu = g.Key, CacSo = g })
          .Dump("Câu d - Nhóm theo số dư");
}

// Bài 3.2
void Bai32()
{
    "================ BÀI 3.2 ================".Dump();

    string[] monAn =
    {
        "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì",
        "Nước Cà phê", "Mì quảng", "Cơm tấm", "Nước Chanh dây",
        "Mì xào", "Bún riêu", "Bánh cuốn", "Mì gói",
        "Bún chả", "Hủ tiếu Nam vang"
    };

    int minLen = monAn.Min(x => x.Length);
    int maxLen = monAn.Max(x => x.Length);

    monAn.Where(x => x.Length == minLen).Dump("Câu a - Món ngắn nhất");
    monAn.Where(x => x.Length == maxLen).Dump("Câu a - Món dài nhất");

    monAn.GroupBy(x => x.Split(' ')[0])
         .OrderBy(g => g.Key)
         .Dump("Câu b - Nhóm theo từ đầu");

    monAn.Count(x => x.StartsWith("Bánh")).Dump("Câu c - Số món bắt đầu bằng Bánh");
}

// Bài 4.1
void Bai41()
{
    "================ BÀI 4.1 ================".Dump();
    DuLieu.DS_Mon().Dump("Danh sách MonHoc");
}

// Bài 5.1
void Bai51()
{
    "================ BÀI 5.1 ================".Dump();

    var dsMon = DuLieu.DS_Mon();

    (from mon in dsMon
     where mon.TenMon.StartsWith("Lập trình")
     select mon.TenMon).Dump("Câu a");

    (from mon in dsMon
     where mon.He == "CD"
     orderby mon.SoTiet descending, mon.MaMon
     select mon).Dump("Câu b");

    (from mon in dsMon
     where mon.TenMon.ToLower().Contains("web")
     select new { mon.TenMon, mon.He }).Dump("Câu c");

    (from mon in dsMon
     where mon.He == "KTV"
     orderby mon.MaMon
     select mon).Dump("Câu d");
}

// Bài 5.2
void Bai52()
{
    "================ BÀI 5.2 ================".Dump();

    var dsMon = DuLieu.DS_Mon();

    dsMon.Count.Dump("Câu a - Tổng số môn");

    dsMon.Count(x => x.TenMon.StartsWith("Lập trình"))
         .Dump("Câu b - Số môn Lập trình");

    dsMon.Where(x => x.He == "KTV").Sum(x => x.SoTiet)
         .Dump("Câu c - Tổng tiết KTV");

    dsMon.GroupBy(x => x.He)
         .OrderBy(g => g.Key)
         .Select(g => new { He = g.Key, SoMon = g.Count() })
         .Dump("Câu d");

    dsMon.GroupBy(x => x.SoTiet)
         .OrderByDescending(g => g.Key)
         .Select(g => new { SoTiet = g.Key, SoMon = g.Count() })
         .Dump("Câu e");

    dsMon.OrderByDescending(x => x.SoTiet).First()
         .Dump("Câu f - Môn số tiết cao nhất");

    dsMon.GroupBy(x => x.He)
         .OrderBy(g => g.Key)
         .Select(g => new
         {
             He = g.Key,
             TongMon = g.Count(),
             TongTiet = g.Sum(x => x.SoTiet),
             MaxTiet = g.Max(x => x.SoTiet),
             MinTiet = g.Min(x => x.SoTiet)
         }).Dump("Câu g");

    dsMon.GroupBy(x => x.He).OrderBy(g => g.Key).Dump("Câu h");

    dsMon.GroupBy(x => x.SoTiet).OrderBy(g => g.Key).Dump("Câu i");

    dsMon.Where(x => x.He == "KTV" &&
                     (x.MaMon.StartsWith("HP2") || x.MaMon.StartsWith("HP3") ||
                      x.MaMon.StartsWith("HP4") || x.MaMon.StartsWith("HP5")))
         .GroupBy(x => x.MaMon.Substring(0, 3))
         .OrderBy(g => g.Key)
         .Dump("Câu j");

    dsMon.Where(x => x.SoTiet > 40)
         .GroupBy(x => x.He)
         .OrderBy(g => g.Key)
         .Dump("Câu k");
}

// Bài 6.1
void Bai61()
{
    "================ BÀI 6.1 ================".Dump();
    DuLieu.DS_He().Dump("Danh sách Hệ");
}

// Bài 6.2
void Bai62()
{
    "================ BÀI 6.2 ================".Dump();

    var dsMon = DuLieu.DS_Mon();
    var dsHe = DuLieu.DS_He();

    (from he in dsHe
     join mon in dsMon on he.MaHe equals mon.He
     select new { he.TenHe, mon.MaMon, mon.TenMon })
    .Dump("Câu a - INNER JOIN");

    dsHe.GroupJoin(dsMon, he => he.MaHe, mon => mon.He, (he, mons) => new { he, mons })
        .SelectMany(x => x.mons.DefaultIfEmpty(), (x, mon) => new { x.he, mon })
        .Select(x => x.mon == null
            ? $"{x.he.TenHe} - KHÔNG CÓ MÔN HỌC"
            : $"{x.he.TenHe} - {x.mon.MaMon} - {x.mon.TenMon}")
        .Dump("Câu b - LEFT OUTER JOIN");

    var heKhongCoMon = dsHe
        .GroupJoin(dsMon, he => he.MaHe, mon => mon.He, (he, mons) => new { he, mons })
        .Where(x => !x.mons.Any())
        .Select(x => new { Loai = "Hệ chưa có môn", ThongTin = x.he.TenHe });

    var monChuaKhaiBaoHe = dsMon
        .Where(mon => string.IsNullOrWhiteSpace(mon.He) || !dsHe.Any(he => he.MaHe == mon.He))
        .Select(mon => new { Loai = "Môn chưa khai báo hệ", ThongTin = $"{mon.MaMon} - {mon.TenMon}" });

    heKhongCoMon.Concat(monChuaKhaiBaoHe).Dump("Câu c");

    dsHe.Where(h => !dsMon.Any(m => m.He == h.MaHe)).Dump("Câu d - Hệ chưa có môn");
    dsMon.Where(m => string.IsNullOrWhiteSpace(m.He) || !dsHe.Any(h => h.MaHe == m.He))
         .Dump("Câu d - Môn chưa khai báo hệ");

    (from mon in dsMon
     join he in dsHe on mon.He equals he.MaHe
     orderby mon.SoTiet descending
     select new { he.TenHe, mon.MaMon, mon.TenMon, mon.SoTiet })
    .Take(5)
    .Dump("Câu e");

    dsHe.GroupJoin(dsMon, he => he.MaHe, mon => mon.He,
                   (he, mons) => new { he.MaHe, he.TenHe, TongSoMon = mons.Count() })
        .Dump("Câu f");

    dsMon.Select(x => x.SoTiet).Distinct().Count()
         .Dump("Câu g - Số loại SốTiet");

    dsMon.FirstOrDefault(x => x.TenMon.StartsWith("Lập trình"))
         .Dump("Câu h");

    dsMon.GroupBy(x => x.He)
         .OrderBy(g => g.Key)
         .Select(g => new
         {
             He = g.Key,
             DanhSach = g.OrderBy(x => x.MaMon)
                         .Select((mon, i) => new { STT = i + 1, mon.MaMon, mon.TenMon })
         })
         .Dump("Câu i");
}

// Classes
public class MonHoc
{
    public string MaMon { get; set; } = "";
    public string TenMon { get; set; } = "";
    public string He { get; set; } = "";
    public byte SoTiet { get; set; }
}

public class He
{
    public string MaHe { get; set; } = "";
    public string TenHe { get; set; } = "";
}

public static class DuLieu
{
    public static List<MonHoc> DS_Mon() => new()
    {
        new() { MaMon = "HP2_1", TenMon = "Nền tảng C#", He = "KTV", SoTiet = 64 },
        new() { MaMon = "HP2_2", TenMon = "Công nghệ ADO.NET", He = "KTV", SoTiet = 64 },
        new() { MaMon = "HP3_1", TenMon = "Lập trình Windows Forms", He = "KTV", SoTiet = 64 },
        new() { MaMon = "HP3_2", TenMon = "Xây dựng ứng dụng Windows Forms", He = "KTV", SoTiet = 64 },
        new() { MaMon = "HP4_1", TenMon = "Lập trình Web với HTML, CSS và JavaScript", He = "KTV", SoTiet = 64 },
        new() { MaMon = "HP4_2", TenMon = "Xây dựng ứng dụng Web với ASP.NET", He = "KTV", SoTiet = 64 },
        new() { MaMon = "HP5_1", TenMon = "Lập trình CSDL SQL Server căn bản", He = "KTV", SoTiet = 64 },
        new() { MaMon = "HP5_2", TenMon = "Lập trình CSDL SQL Server nâng cao", He = "KTV", SoTiet = 64 },
        new() { MaMon = "JLCB", TenMon = "Joomla cơ bản", He = "CD", SoTiet = 72 },
        new() { MaMon = "LINQ", TenMon = "Language-Integrated Query", He = "CD", SoTiet = 64 },
        new() { MaMon = "DAWEB", TenMon = "Đồ án thực tế Web với ASP.NET", He = "CD", SoTiet = 40 },
        new() { MaMon = "DAWIN", TenMon = "Đồ án thực tế Windows Forms", He = "CD", SoTiet = 40 },
        new() { MaMon = "CC++", TenMon = "Lập trình hướng đối tượng với C/C++", He = "CD", SoTiet = 128 },
        new() { MaMon = "JQUE", TenMon = "JQuery", He = "CD", SoTiet = 22 },
        new() { MaMon = "XML", TenMon = "Công nghệ XML", He = "CD", SoTiet = 32 },
        new() { MaMon = "CRYS", TenMon = "Crystal Report trong Visual Studio", He = "CD", SoTiet = 32 },
        new() { MaMon = "BWEB", TenMon = "HTML, CSS và JavaScript", He = "CD", SoTiet = 32 },
        new() { MaMon = "XYZ", TenMon = "Chưa đặt tên môn", He = "", SoTiet = 0 }
    };

    public static List<He> DS_He() => new()
    {
        new() { MaHe = "KTV", TenHe = "Kỹ thuật viên" },
        new() { MaHe = "CD", TenHe = "Chuyên đề" },
        new() { MaHe = "QT", TenHe = "Chứng chỉ quốc tế" }
    };
}