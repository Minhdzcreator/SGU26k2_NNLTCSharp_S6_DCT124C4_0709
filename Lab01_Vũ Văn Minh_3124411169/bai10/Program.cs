using System;
namespace Bai10
{
    class XuLyChuoi
    {
        public bool KiemTraDoiXung(string s)
        {
            int len = s.Length; // Lấy tổng chiều dài của chuỗi
            for (int i = 0; i < len / 2; i++)
            {
                // So sánh ký tự ở vị trí i với ký tự đối xứng ở cuối đếm ngược lại (len - 1 - i)
                // Nếu có bất kỳ cặp ký tự nào không giống nhau, lập tức kết luận sai và thoát hàm.
                if (s[i] != s[len - 1 - i]) return false;
            }
            return true;
        }
    }
    class Program
    {
        static void Main()
        {
            Console.Write("Nhap chuoi can kiem tra: ");
            string chuoi = Console.ReadLine();
            XuLyChuoi xl = new XuLyChuoi();
            if (xl.KiemTraDoiXung(chuoi))
                Console.WriteLine("-> Chuoi nay la chuoi doi xung.");
            else
                Console.WriteLine("-> Chuoi nay khong doi xung.");
            Console.ReadLine();
        }
    }
}