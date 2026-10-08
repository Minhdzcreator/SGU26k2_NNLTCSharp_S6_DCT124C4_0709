using System;
namespace WinFormsApp
{
    public class PhuongTrinhBacHai
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public PhuongTrinhBacHai()
        {
            A = 0;
            B = 0;
            C = 0;
        }
        public PhuongTrinhBacHai(double a, double b, double c = 0)
        {
            A = a;
            B = b;
            C = c;
        }
        // Giải phương trình bậc 1: ax + b = 0
        public string GiaiBacNhat()
        {
            if (A == 0)
            {
                if (B == 0)
                    return "Phương trình có vô số nghiệm";
                else
                    return "Phương trình vô nghiệm";
            }
            double x = -B / A;
            return $"Phương trình có nghiệm x = {x:F2}";
        }
        // Giải phương trình bậc 2: ax^2 + bx + c = 0
        public string GiaiBacHai()
        {
            if (A == 0)
            {
                // Nếu a = 0 thì trở thành phương trình bậc nhất bx + c = 0
                PhuongTrinhBacHai pt1 = new PhuongTrinhBacHai(B, C);
                return pt1.GiaiBacNhat();
            }
            double delta = B * B - 4 * A * C;
            if (delta < 0)
            {
                return "Phương trình vô nghiệm";
            }
            else if (delta == 0)
            {
                double x = -B / (2 * A);
                return $"Phương trình có nghiệm kép x1 = x2 = {x:F2}";
            }
            else
            {
                double x1 = (-B + Math.Sqrt(delta)) / (2 * A);
                double x2 = (-B - Math.Sqrt(delta)) / (2 * A);
                return $"Phương trình có 2 nghiệm phân biệt:\nx1 = {x1:F2}, x2 = {x2:F2}";
            }
        }
    }
}
