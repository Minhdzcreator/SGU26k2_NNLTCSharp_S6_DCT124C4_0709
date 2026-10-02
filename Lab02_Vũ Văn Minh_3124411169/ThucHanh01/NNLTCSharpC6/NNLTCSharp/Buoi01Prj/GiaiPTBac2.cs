using System;
using MyLib;

namespace Buoi01Prj;

public class GiaiPTBac2
{
    public static void Main(string[] args)
    {
        Console.Write("Nhap a: ");
        
        double a = double.Parse(Console.ReadLine()!); 

        Console.Write("Nhap b: ");
        double b = double.Parse(Console.ReadLine()!);

        Console.Write("Nhap c: ");
        double c = double.Parse(Console.ReadLine()!);

        double x1 = 0, x2 = 0;
        int sn = LibBaiTap.GiaiPTBac2(a, b, c, ref x1, ref x2);

        Console.WriteLine($"So nghiem: {sn}");
        Console.WriteLine($"x1 = {x1}");
        Console.WriteLine($"x2 = {x2}");
    }
}