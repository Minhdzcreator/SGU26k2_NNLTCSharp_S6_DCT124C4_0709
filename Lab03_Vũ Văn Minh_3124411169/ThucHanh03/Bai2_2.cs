using System;
using System.Linq;

namespace BaiThucHanhLINQ
{
    public class Bai2_2()
    {
        public static void GiaiBai2_2()
{
    // Khởi tạo mảng chuỗi theo đề bài
    string[] mangChuoi = { "đầu", "lòng", "hai", "ả", "tố", "nga", 
                           "Thúy", "Kiều", "là", "chị", "em", "là", "Thúy", "Vân" };

    Console.WriteLine("--- Bài 2.2. Truy vấn mảng chuỗi ---");

    // a. Liệt kê các phần tử có 4 ký tự và sắp xếp tăng dần theo ký tự đầu tiên
    var cauA = from s in mangChuoi
               where s.Length == 4
               orderby s[0] ascending
               select s;

    Console.Write("\na. Các phần tử có 4 ký tự (đã sắp xếp): ");
    foreach (var s in cauA)
    {
        Console.Write(s + " ");
    }
    Console.WriteLine();

    // b. Biến đổi mỗi phần tử thành dạng: <chữ thường> - <CHỮ HOA>
    var cauB = from s in mangChuoi
               select $"{s.ToLower()} - {s.ToUpper()}";

    Console.WriteLine("\nb. Dạng <chữ thường> - <CHỮ HOA>:");
    foreach (var s in cauB)
    {
        Console.WriteLine(s);
    }

    // c. Liệt kê các phần tử có chứa ký tự “u”
    var cauC = from s in mangChuoi
               where s.Contains("u")
               select s;

    Console.Write("\nc. Các phần tử chứa ký tự 'u': ");
    foreach (var s in cauC)
    {
        Console.Write(s + " ");
    }
    Console.WriteLine();

    // d. Liệt kê các từ bắt đầu bằng chữ in hoa
    var cauD = from s in mangChuoi
               where !string.IsNullOrEmpty(s) && char.IsUpper(s[0])
               select s;

    Console.Write("\nd. Các từ bắt đầu bằng chữ in hoa: ");
    foreach (var s in cauD)
    {
        Console.Write(s + " ");
    }
    Console.WriteLine();
}
        }
    }
