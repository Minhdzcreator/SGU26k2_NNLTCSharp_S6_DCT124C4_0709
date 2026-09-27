using System;
namespace Bai5
{
    class Program
    {

        static void Main(string[] args)
        {
            int luaChon;
            double x = 0, y = 0;
            bool daNhapDuLieu = false;
            do
            {
                // In menu ra màn hình
                Console.WriteLine("================================");
                Console.WriteLine("MENU");
                Console.WriteLine("1. Nhap hai gia tri so thuc cho x, y");
                Console.WriteLine("2. Tinh x^y");
                Console.WriteLine("3. Tinh can bac 2 cua x va y");
                Console.WriteLine("4. Thoat");
                Console.Write("Chon chuc nang: ");
                if (int.TryParse(Console.ReadLine(), out luaChon))
                {
                    switch (luaChon)
                    {
                        case 1:
                            Console.Write("Nhap so thuc x: ");
                            x = double.Parse(Console.ReadLine());
                            Console.Write("Nhap so thuc y: ");
                            y = double.Parse(Console.ReadLine());
                            daNhapDuLieu = true;
                            Console.WriteLine("-> Da nhap du lieu thanh cong!");
                            break;
                        case 2:
                            if (!daNhapDuLieu)
                                Console.WriteLine("-> Vui long chon chuc nang 1 de nhap x va y truoc!");
                            else
                                Console.WriteLine($"-> Ket qua {x}^{y} = {Math.Pow(x, y)}");
                            break;
                        case 3:
                            if (!daNhapDuLieu)
                                Console.WriteLine("-> Vui long chon chuc nang 1 de nhap x va y truoc!");
                            else
                            {
                                Console.WriteLine($"-> Can bac 2 cua {x} la: {Math.Sqrt(x)}");
                                Console.WriteLine($"-> Can bac 2 cua {y} la: {Math.Sqrt(y)}");
                            }
                            break;
                        case 4:
                            Console.WriteLine("-> Da thoat chuong trinh.");
                            break;
                        default:
                            Console.WriteLine("-> Lua chon khong hop le. Vui long chon tu 1 den 4.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("-> Loi: Vui long nhap mot so nguyen de chon menu.");
                    luaChon = 0;
                }
                Console.WriteLine();
            } while (luaChon != 4);

        }

    }

}