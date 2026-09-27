using System;
namespace Bai12
{
    class XuLyChuoi
    {
        public int DemSoTu(string s)
        {
            // Sử dụng hàm Split để cắt chuỗi thành một mảng các chuỗi con (các từ) dựa trên ký tự khoảng trắng ' '.
            // StringSplitOptions.RemoveEmptyEntries: giúp loại bỏ các phần tử rỗng
            string[] cacTu = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            // Trả về số lượng phần tử của mảng
            return cacTu.Length;
        }
    }
    class Program
    {
        static void Main()
        {
            Console.Write("Nhap chuoi: ");
            string chuoi = Console.ReadLine();
            Console.WriteLine($"-> Chuoi chu thuong: {chuoi.ToLower()}");
            Console.WriteLine($"-> Chuoi chu hoa: {chuoi.ToUpper()}");
            XuLyChuoi xl = new XuLyChuoi();
            Console.WriteLine($"-> So tu trong chuoi: {xl.DemSoTu(chuoi)}");
            Console.ReadLine();
        }
    }
}