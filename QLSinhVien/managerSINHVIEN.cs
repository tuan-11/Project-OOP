using System;
using System.Collections.Generic;
using System.Text;
using SchoolManager.QLKhoa;
namespace SchoolManager.QLSinhVien
{
    public class managerSINHVIEN : SinhVien
    {
        public static List<SinhVien> listsv = new List<SinhVien>();
        public static SinhVien check(string MaSV)
        {
            foreach (SinhVien sv in listsv)
            {
                if (String.Compare(sv.MA, MaSV, false) == 0)
                return sv;
            }
            return null;
        }
        public void nhap(KHOA h)
        {
            SinhVien sv;
            do
            {
                Console.Write("Ma Sinh Vien: ");
                MA = Convert.ToString(Console.ReadLine());
                sv = check(MA);
                if(sv != null)
                {
                    Console.WriteLine("Ma Sinh Vien da ton tai !");
                    Console.WriteLine("Vui long nhap lai !");
                }
            }while (sv != null);
            base.input();
            listsv.Add(sv);
            Console.WriteLine("Them Sinh Vien thanh cong !");
        }
        public static void delete(KHOA h)
        {
            SinhVien k;
            Console.Write("Nhap Ma Sinh Vien: ");
            string MaSV = Console.ReadLine();
            k = check(MaSV);
            if(k == null)
            {
                Console.WriteLine("Khong tim thay sinh vien !");
            }
            else
            {
                listsv.Remove(k);
                h.Listsv1.Remove(k);
            }
            Console.WriteLine("Da xoa thanh cong !");
        }
        public static void print(KHOA k)
        {
            Console.WriteLine("Khoa {0}", k.TENKHOA);
            Console.WriteLine("{0, -7} {1, -20} {2, -15} {3, -15} {4, -15}",
                  "MaSV", "TenSV", "Ngay Sinh", "Gioi Tinh", "Dia Chi");
            foreach (SinhVien sv in k.Listsv1)
            {
                Console.WriteLine("{0, -7} {1, -20} {2, -15} {3, -15} {4, -15}",
                                  sv.MA, sv.TEN, sv.NGSINH, sv.GTINH, sv.DIACHI);
            }
            if(k.Listsv1.Count == 0)
            {
                Console.WriteLine("Khong co Sinh Vien nao trong Khoa!");
            }    
        }
        public override void input()
        {
            base.input();
            // NHAP NGANH HOC
            Console.Write("Nhap nganh hoc cua sinh vien: ");
            NGANH = Convert.ToString(Console.ReadLine());
            // NHAP KHOA HỌC
            Console.Write("Nhap khoa hoc cua sinh vien: ");
            KHOAHOC = Convert.ToString(Console.ReadLine()); 
        }
        public static void searchID(KHOA k)
        {
            if(k.Listsv1 == null)
                Console.WriteLine("Danh sach rong!");
            else               
            {
                Console.Write("Nhap Ma Sinh Vien: ");
                string MaSV = Console.ReadLine();
                Console.WriteLine("{0, -7} {1, -20} {2, -15} {3, -15} {4, -15}",
                  "MaSV", "TenSV", "Ngay Sinh", "Gioi Tinh", "Dia Chi");
                foreach (SinhVien sv in k.Listsv1)
                {
                    if (String.Compare(sv.MA, MaSV, false) == 0)
                    {
                        Console.WriteLine("{0, -7} {1, -20} {2, -15} {3, -15} {4, -15}",
                                      sv.MA, sv.TEN, sv.NGSINH, sv.GTINH, sv.DIACHI);
                    }
                }
                if (k.Listsv1.Count == 0)
                {
                    Console.WriteLine("Khong co Sinh Vien nao trong danh sach!");
                }
            }
        }
        public override void search()
        {
            if (listsv == null)
                Console.WriteLine("Danh sach rong!");
            else
            {
                Console.Write("Nhap Ma Sinh Vien: ");
                string MaSV = Console.ReadLine();
                Console.WriteLine("{0, -7} {1, -20} {2, -15} {3, -15} {4, -15} {5, -20}",
                  "MaGV", "TenGV", "Ngay Sinh", "Gioi Tinh", "Dia Chi", "So Dien Thoai");
                foreach (SinhVien sv in listsv)
                {
                    if (String.Compare(sv.MA, MaSV, false) == 0)
                    {
                        Console.WriteLine("{0, -7} {1, -20} {2, -15} {3, -15} {4, -15} {5, -20}",
                                      sv.MA, sv.TEN, sv.NGSINH, sv.GTINH, sv.DIACHI, sv.SDT);
                    }
                }
                if (listsv.Count == 0)
                {
                    Console.WriteLine("Khong co Sinh Vien nao trong danh sach!");
                }
            }
        }
        public delegate bool DelSort(SinhVien sv1, SinhVien sv2);
        public static bool compareRise(SinhVien sv1, SinhVien sv2)
        {
            if (String.Compare(sv1.TEN, sv2.TEN, false) > 0)
                return false;
            return true;
        }
        public static void sortID(KHOA k)
        {
            DelSort d = new DelSort(compareRise);
            if (k.Listsv1.Count == 0)   
            {
                Console.WriteLine("Danh sach rong!");
            }
            else
            {
            SinhVien sv;
            for(int i = 0; i < k.Listsv1.Count - 1; i++)
                for (int j = i + 1; j < k.Listsv1.Count; j++)
                    if (!d(k.Listsv1[i], k.Listsv1[j])) 
                    {
                        sv = k.Listsv1[i];
                        k.Listsv1[i] = k.Listsv1[j];
                        k.Listsv1[j] = sv;
                    }
            }
        }
        public override void sort()
        {
            if (listsv.Count == 0)
            {
                Console.WriteLine("Danh sach rong!");
            }
            else
            {
                listsv.Sort(delegate (SinhVien sv1, SinhVien sv2)
                {
                    return sv1.TEN.CompareTo(sv2.TEN);
                });
            }
        }
        public static int sl_khoa(KHOA k)
        {
            return k.Listsv1.Count;
        }
        public static int sl()
        {
            return listsv.Count;
        }
    }
}