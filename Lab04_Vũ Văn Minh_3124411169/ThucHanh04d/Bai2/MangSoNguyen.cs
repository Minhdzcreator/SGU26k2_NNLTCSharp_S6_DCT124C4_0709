using System;
using System.Collections.Generic;
using System.Linq;
namespace WinFormsApp
{
    public class MangSoNguyen
    {
        private List<int> a;
        public MangSoNguyen()
        {
            a = new List<int>();
        }
        public MangSoNguyen(List<int> list)
        {
            a = new List<int>(list);
        }
        // Đọc chuỗi nhập dạng: "5 6 4 7 8 9 10 5 6 3 2 1"
        public static List<int> ParseString(string input)
        {
            List<int> list = new List<int>();
            if (string.IsNullOrWhiteSpace(input)) return list;
            string[] parts = input.Split(new[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var part in parts)
            {
                if (int.TryParse(part, out int num))
                {
                    list.Add(num);
                }
            }
            return list;
        }
        public string InMang()
        {
            return string.Join(" ", a);
        }
        // Sắp xếp
        public void SapXepTang() => a.Sort();
        public void SapXepGiam() => a.Sort((x, y) => y.CompareTo(x));
        // Tìm kiếm
        public int TimViTriDauTien(int giatri) => a.IndexOf(giatri);
        public int TimGiaTriTaiViTri(int index) => (index >= 0 && index < a.Count) ? a[index] : int.MinValue;
        // Xóa phần tử
        public bool XoaTheoGiaTri(int giatri) => a.Remove(giatri);
        public bool XoaTheoViTri(int index)
        {
            if (index >= 0 && index < a.Count)
            {
                a.RemoveAt(index);
                return true;
            }
            return false;
        }
        // Thêm phần tử
        public bool ThemTaiViTri(int giatri, int index)
        {
            if (index >= 0 && index <= a.Count)
            {
                a.Insert(index, giatri);
                return true;
            }
            return false;
        }
        // Tính tổng
        public int TongMang() => a.Sum();
        public int TongChan() => a.Where(x => x % 2 == 0).Sum();
        public int TongLe() => a.Where(x => x % 2 != 0).Sum();
        // Max - Min
        public int TimMax() => a.Count > 0 ? a.Max() : 0;
        public int TimMin() => a.Count > 0 ? a.Min() : 0;
        // Thay thế
        public bool ThayTheTheoGiaTri(int giaTriCu, int giaTriMoi)
        {
            int idx = a.IndexOf(giaTriCu);
            if (idx != -1)
            {
                a[idx] = giaTriMoi;
                return true;
            }
            return false;
        }
        public bool ThayTheTheoViTri(int index, int giaTriMoi)
        {
            if (index >= 0 && index < a.Count)
            {
                a[index] = giaTriMoi;
                return true;
            }
            return false;
        }
    }
}
