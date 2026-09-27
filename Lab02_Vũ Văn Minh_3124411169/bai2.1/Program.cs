using System;
using System.Collections.Generic;

namespace bai2_1
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point(double x = 0, double y = 0) { X = x; Y = y; }
        public override string ToString() => $"({X}, {Y})";
    }
    class ArrayPoint
    {
        private readonly List<Point> listPoint;
        public ArrayPoint()
        {
            listPoint = new List<Point>();
        }
        // Indexer cho phép truy cập Point thứ i
        public Point this[int index]
        {
            get { return listPoint[index]; }
            set { listPoint[index] = value; }
        }
        public void Add(Point p)
        {
            listPoint.Add(p);
        }
        public void Output()
        {
            for (int i = 0; i < listPoint.Count; i++)
            {
                Console.WriteLine($"Point {i}: {this[i]}");
            }
        }
    }
    class Program
    {
        static void Main()
        {
            ArrayPoint arr = new ArrayPoint();
            arr.Add(new Point(1, 2));
            arr.Add(new Point(3, 4));

            Console.WriteLine("Danh sach ArrayPoint:");
            arr.Output();
        }
    }
}