using System;
using System.Collections.Generic;
using System.Text;
using SchoolManager.QLTuyenSinh;

namespace SchoolManager.QLTuyenSinh
{
    public class managerHocSinh:HocSinh
    {
        public static List<HocSinh> lisths = new List<HocSinh>();
        public static HocSinh check(string Sbd)
        {
            foreach(HocSinh hs in lisths)
            {
                if(String.Compare(hs.MA, Sbd, true) == 0)
                    return hs;
            }
            return null;
        }
        public override void input()
        {
            HocSinh hs;
            do
            {
                Console.Write("Ma hoc sinh:");
                MA = Convert.ToString(Console.ReadLine());
                hs = check(MA);
                if(hs != null)
                {
                    Console.WriteLine("Ma hoc sinh da ton tai!");
                    Console.WriteLine("Vui long nhap lai!!!");
                }
            } while(hs!=null);
            base.input();
            Console.Write("Diem thi: ");
            Diemthi = Convert.ToDouble(Console.ReadLine());
            Console.Write("Khoi thi: ");
            Khoithi = Convert.ToString(Console.ReadLine());
            Console.Write("Nganh: ");
            Nganh = Convert.ToString(Console.ReadLine());
            Console.Write("Dien uu tien: ");
            DienUT = Convert.ToInt16(Console.ReadLine());
            Console.Write("So luong nguyen vong: ");
            SoluongNV = Convert.ToInt16(Console.ReadLine());
            Console.Write("Phuong thuc xet tuyen: ");
            Phuongthucxettuyen = Convert.ToString(Console.ReadLine());
            hs = new HocSinh(MA, TEN, NGSINH, GTINH, DIACHI, SDT, Diemthi, Khoithi, Nganh, DienUT, SoluongNV, Phuongthucxettuyen);
            lisths.Add(hs);

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Dang ki hoc sinh thanh cong!\n");
        }
        public override void print()
        {
            if (lisths.Count == 0)
            {
                Console.WriteLine("Khong co hoc sinh nao trong danh sach dang ki!");
            }
            else
            {
                Console.WriteLine("{0, -7} {1, -20} {2, -10} {3, -10} {4, -15} {5,-15} {6,-10} {7,-9} {8,-10} {9,-10} {10,-12} {11,-10}",
                             "MaHS", "TenHS", "Ngay Sinh", "Gioi Tinh", "Dia Chi", "SĐT", "Diem Thi", "Khoi thi", "Nganh","Dien UT","So luong NV","Phuong thuc xet tuyen");
                foreach (HocSinh hs in lisths)
                {
                   Console.WriteLine("{0, -7} {1, -20} {2, -10} {3, -10} {4, -15} {5,-15} {6,-10} {7,-9} {8,-10} {9,-10} {10,-12} {11,-10}",
                                  hs.MA, hs.TEN, hs.NGSINH, hs.GTINH, hs.DIACHI,hs.SDT,hs.Diemthi,hs.Khoithi,hs.Nganh,hs.DienUT,hs.SoluongNV,hs.Phuongthucxettuyen);
                }
            }
            
            Console.WriteLine();
        }
        public override void search()
        {
            if(lisths.Count==0)
            {
                Console.WriteLine("Khong co hoc sinh nao trong danh sach!");
            }
            else
            {
                Console.Write   ("Nhap ma hoc sinh: ");
                string MaHS = Console.ReadLine();
                
                foreach(HocSinh hs in lisths)
                {
                    if(String.Compare(hs.MA, MaHS, false)==0)
                    {
                        Console.WriteLine("Thong tin hoc sinh can tim:");
                        Console.WriteLine("{0, -7} {1, -20} {2, -10} {3, -10} {4, -15} {5,-15} {6,-10} {7,-9} {8,-10} {9,-10} {10,-12} {11,-10}",
                             "MaHS", "TenHS", "Ngay Sinh", "Gioi Tinh", "Dia Chi", "SĐT", "Diem Thi", "Khoi thi", "Nganh","Dien UT","So luong NV","Phuong thuc xet tuyen");
                        Console.WriteLine("{0, -7} {1, -20} {2, -10} {3, -10} {4, -15} {5,-15} {6,-10} {7,-9} {8,-10} {9,-10} {10,-12} {11,-10}",
                                  hs.MA, hs.TEN, hs.NGSINH, hs.GTINH, hs.DIACHI,hs.SDT,hs.Diemthi,hs.Khoithi,hs.Nganh,hs.DienUT,hs.SoluongNV,hs.Phuongthucxettuyen);
                    }
                }

            }
        }
        public void delete()
        {
            Console.Write("Nhap ma hoc sinh: ");
            string MaHS = Console.ReadLine();
            HocSinh hs1 = check (MaHS);
            if(hs1==null)
            {
                Console.WriteLine("Khong tim thay hoc sinh!");
            }
            else
            {
                lisths.Remove(hs1);
                Console.WriteLine("Da xoa hoc sinh thanh cong!");
            }
            Console.WriteLine("\n\n");
        }

        public delegate bool DelSort(HocSinh hs1, HocSinh hs2);
        public static bool CompareRise(HocSinh hs1, HocSinh hs2)
        {
            if(String.Compare(hs1.TEN,hs2.TEN,false)>0)
                return false;
            return true;
        }
        public override void sort()
        {
            DelSort d = new DelSort(CompareRise);
            if(lisths.Count==0)
            {
                Console.WriteLine("Danh sach rong! \n\n");
            }
            else
            {
                List<HocSinh> lisths1 = new List<HocSinh>(lisths);
                HocSinh hs1;
                for(int i = 0; i<lisths1.Count-1;i++)
                    for(int j = i+1;j<lisths1.Count;j++)
                    {
                        if(!d(lisths1[i],lisths1[j]))
                        {
                            hs1=lisths1[i];
                            lisths1[i]=lisths1[j];
                            lisths1[j]=hs1;
                        }
                    }
                Console.WriteLine("{0, -7} {1, -20} {2, -10} {3, -10} {4, -15} {5,-15} {6,-10} {7,-9} {8,-10} {9,-10} {10,-12} {11,-10}",
                             "MaHS", "TenHS", "Ngay Sinh", "Gioi Tinh", "Dia Chi", "SĐT", "Diem Thi", "Khoi thi", "Nganh","Dien UT","So luong NV","Phuong thuc xet tuyen");
                foreach (HocSinh hs in lisths1)
                {
                   Console.WriteLine("{0, -7} {1, -20} {2, -10} {3, -10} {4, -15} {5,-15} {6,-10} {7,-9} {8,-10} {9,-10} {10,-12} {11,-10}",
                                  hs.MA, hs.TEN, hs.NGSINH, hs.GTINH, hs.DIACHI,hs.SDT,hs.Diemthi,hs.Khoithi,hs.Nganh,hs.DienUT,hs.SoluongNV,hs.Phuongthucxettuyen);
                }
            }
        }

    }
}