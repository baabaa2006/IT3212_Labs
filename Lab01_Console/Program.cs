using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        int chon;
        do
        {
            Console.WriteLine("\n===== LAB 01 =====");
            for (int i = 1; i <= 10; i++) Console.WriteLine("{0}. Bài {0}", i);
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn bài: ");
            int.TryParse(Console.ReadLine(), out chon);
            switch (chon)
            {
                case 1: Bai1(); break;
                case 2: Bai2(); break;
                case 3: Bai3(); break;
                case 4: Bai4(); break;
                case 5: Bai5(); break;
                case 6: Bai6(); break;
                case 7: Bai7(); break;
                case 8: Bai8(); break;
                case 9: Bai9(); break;
                case 10: Bai10(); break;
            }
        } while (chon != 0);
    }

    // Mỗi bài là một hàm static: static void Bai1() { ... }

    static void Bai1()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Họ và tên: ");
        string hoTen = Console.ReadLine();
        Console.Write("Năm sinh: ");
        int namSinh;
        if (!int.TryParse(Console.ReadLine(), out namSinh))
        {
            Console.WriteLine("Năm sinh không hợp lệ.");
            return;
        }
        int tuoi = DateTime.Now.Year - namSinh;
        Console.WriteLine("Xin chào {0}, tuổi gần đúng: {1}", hoTen, tuoi);
    }

    static void Bai2()
    {
        double r, h;
        Console.Write("Bán kính r = ");
        if (!double.TryParse(Console.ReadLine(), out r) || r <= 0) return;
        Console.Write("Chiều cao h = ");
        if (!double.TryParse(Console.ReadLine(), out h) || h <= 0) return;
        double dienTichXQ = 2 * Math.PI * r * h;
        double theTich = Math.PI * r * r * h;
        Console.WriteLine("Sxq = {0:N2}; V = {1:N2}", dienTichXQ, theTich);
    }

    static void Bai3()
    {
        double diem;
        if (!double.TryParse(Console.ReadLine(), out diem) || diem < 0 || diem > 10)
        {
            Console.WriteLine("Điểm phải thuộc [0, 10].");
        }
        else if (diem >= 9) Console.WriteLine("Xuất sắc");
        else if (diem >= 8) Console.WriteLine("Giỏi");
        else if (diem >= 6.5) Console.WriteLine("Khá");
        else if (diem >= 5) Console.WriteLine("Trung bình");
        else Console.WriteLine("Yếu");
    }

    static void Bai4()
    {
        int chon;
        do
        {
            Console.WriteLine("1. Tổng 1..n");
            Console.WriteLine("2. Bảng cửu chương");
            Console.WriteLine("0. Thoát");
            int.TryParse(Console.ReadLine(), out chon);
            switch (chon)
            {
                case 1:
                    Console.Write("n = ");
                    int n = int.Parse(Console.ReadLine());
                    int tong = 0;
                    for (int i = 1; i <= n; i++) tong += i;
                    Console.WriteLine("Tổng = " + tong);
                    break;
                case 2:
                    for (int i = 1; i <= 10; i++)
                        Console.WriteLine("7 x {0} = {1}", i, 7 * i);
                    break;
            }
        } while (chon != 0);
    }

    static void Bai5()
    {
        try
        {
            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("a / b = " + (a / b));
        }
        catch (FormatException)
        {
            Console.WriteLine("Dữ liệu phải là số nguyên.");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Không thể chia cho 0.");
        }
        finally
        {
            Console.WriteLine("Kết thúc phép tính.");
        }
    }

    static void Bai6()
    {
        double a, b, c;
        Console.Write("a = "); double.TryParse(Console.ReadLine(), out a);
        Console.Write("b = "); double.TryParse(Console.ReadLine(), out b);
        Console.Write("c = "); double.TryParse(Console.ReadLine(), out c);

        if (a == 0)
        {
            if (b == 0) Console.WriteLine(c == 0 ? "Vô số nghiệm" : "Vô nghiệm");
            else Console.WriteLine("Phương trình bậc nhất, x = {0:F2}", -c / b);
        }
        else
        {
            double delta = b * b - 4 * a * c;
            if (delta < 0) Console.WriteLine("Vô nghiệm thực");
            else if (delta == 0) Console.WriteLine("Nghiệm kép x = {0:F2}", -b / (2 * a));
            else
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine("x1 = {0:F2}, x2 = {1:F2}", x1, x2);
            }
        }
    }

    static void Bai7()
    {
        Console.Write("Nhập n (số lượng phần tử): ");
        int n;
        if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.WriteLine("n phải là số nguyên dương.");
            return;
        }

        long tong = 0;
        int max = int.MinValue, min = int.MaxValue, demChan = 0;

        for (int i = 1; i <= n; i++)
        {
            int x;
            Console.Write("Số thứ {0}: ", i);
            while (!int.TryParse(Console.ReadLine(), out x))
            {
                Console.Write("Không hợp lệ, nhập lại số thứ {0}: ", i);
            }

            tong += x;
            if (x > max) max = x;
            if (x < min) min = x;
            if (x % 2 == 0) demChan++;
        }

        double trungBinh = (double)tong / n;
        Console.WriteLine("Tổng            = {0}", tong);
        Console.WriteLine("Trung bình      = {0:F2}", trungBinh);
        Console.WriteLine("Số lớn nhất     = {0}", max);
        Console.WriteLine("Số nhỏ nhất     = {0}", min);
        Console.WriteLine("Số lượng số chẵn = {0}", demChan);
    }

    static bool LaNguyenTo(int n)
    {
        if (n < 2) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;
        for (int i = 3; i * i <= n; i += 2)   // chỉ kiểm tra đến căn bậc hai, bỏ qua số chẵn
        {
            if (n % i == 0) return false;
        }
        return true;
    }

    static void Bai8()
    {
        Console.Write("Nhập n: ");
        int n;
        if (!int.TryParse(Console.ReadLine(), out n) || n < 2)
        {
            Console.WriteLine("n phải là số nguyên >= 2.");
            return;
        }

        Console.WriteLine("Các số nguyên tố không vượt quá {0}:", n);
        int dem = 0;
        for (int i = 2; i <= n; i++)
        {
            if (LaNguyenTo(i))
            {
                Console.Write(i + " ");
                dem++;
            }
        }
        Console.WriteLine("\nTổng cộng: {0} số.", dem);
    }

    static string DocChuSo(int so)
    {
        switch (so)
        {
            case 0: return "không";
            case 1: return "một";
            case 2: return "hai";
            case 3: return "ba";
            case 4: return "bốn";
            case 5: return "năm";
            case 6: return "sáu";
            case 7: return "bảy";
            case 8: return "tám";
            case 9: return "chín";
            default: return "";
        }
    }


    static string DocDonVi(int dv, bool sauMuoi)
    {
        switch (dv)
        {
            case 0: return "";                                 
            case 1: return sauMuoi ? "mốt" : "một";            
            case 5: return "lăm";                               
            default: return DocChuSo(dv);
        }
    }

    static string DocSo(int n)
    {
        if (n < 10) return DocChuSo(n);

        int chuc = n / 10;
        int dv = n % 10;

        if (chuc == 1)
        {
            string s = "mười";
            string d = DocDonVi(dv, false);
            return d == "" ? s : s + " " + d;
        }
        else
        {
            string s = DocChuSo(chuc) + " mươi";
            string d = DocDonVi(dv, true);
            return d == "" ? s : s + " " + d;
        }
    }

    static void Bai9()
    {
        Console.Write("Nhập số nguyên từ 0 đến 99: ");
        int n;
        if (!int.TryParse(Console.ReadLine(), out n) || n < 0 || n > 99)
        {
            Console.WriteLine("Số phải thuộc đoạn [0, 99].");
            return;
        }

        string kq = DocSo(n);
        // Viết hoa chữ cái đầu cho đẹp
        kq = char.ToUpper(kq[0]) + kq.Substring(1);
        Console.WriteLine("{0} đọc là: {1}", n, kq);
    }

    static void VeTamGiacDac(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= i; j++) Console.Write("* ");
            Console.WriteLine();
        }
    }

    static void VeTamGiacRong(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                // In * ở cột đầu, cột cuối của hàng và toàn bộ hàng cuối
                if (j == 1 || j == i || i == n) Console.Write("* ");
                else Console.Write("  ");
            }
            Console.WriteLine();
        }
    }

    static void VeHinhVuongRong(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (i == 1 || i == n || j == 1 || j == n) Console.Write("* ");
                else Console.Write("  ");
            }
            Console.WriteLine();
        }
    }

    static void Bai10()
    {
        int chon;
        do
        {
            Console.WriteLine("\n--- VẼ HÌNH BẰNG KÝ TỰ ---");
            Console.WriteLine("1. Tam giác vuông đặc");
            Console.WriteLine("2. Tam giác vuông rỗng");
            Console.WriteLine("3. Hình vuông rỗng");
            Console.WriteLine("0. Quay lại");
            Console.Write("Chọn: ");
            int.TryParse(Console.ReadLine(), out chon);

            if (chon >= 1 && chon <= 3)
            {
                Console.Write("Nhập kích thước n: ");
                int n;
                if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                {
                    Console.WriteLine("n phải là số nguyên dương.");
                    continue;
                }

                switch (chon)
                {
                    case 1: VeTamGiacDac(n); break;
                    case 2: VeTamGiacRong(n); break;
                    case 3: VeHinhVuongRong(n); break;
                }
            }
            else if (chon != 0)
            {
                Console.WriteLine("Lựa chọn không hợp lệ.");
            }
        } while (chon != 0);
    }
}