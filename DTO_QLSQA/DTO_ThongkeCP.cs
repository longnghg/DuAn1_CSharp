using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLSQA
{
    public class DTO_ThongkeCP
    {
        private int madonnhap;
        private string ngay;
        private string gio;
        private string tensp;
        private int soluong;
        private double dongia;
        private double tongtien;
        public DTO_ThongkeCP()
        {

        }
        public DTO_ThongkeCP(DataRow rows)
        {
            this.Madonnhap = (int)rows["MaDonNhap"];
            this.Tensp = rows["tensp"].ToString();
            this.Soluong = (int)rows["soluong"];
            this.Ngay = rows["ngay"].ToString();
            this.Gio = rows["gio"].ToString();
            this.Tongtien = double.Parse(rows["tongtiennhap"].ToString());
            this.Dongia = double.Parse(rows["dongianhap"].ToString());
        }
        public int Madonnhap { get => madonnhap; set => madonnhap = value; }
        public string Tensp { get => tensp; set => tensp = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public string Ngay { get => ngay; set => ngay = value; }
        public string Gio { get => gio; set => gio = value; }
        public double Tongtien { get => tongtien; set => tongtien = value; }
        public double Dongia { get => dongia; set => dongia = value; }
    }
}
