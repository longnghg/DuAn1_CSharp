using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLSQA
{
    public class DTO_ChiTietDVC
    {
        private int madonnhap;
        private string tensp;
        private string manv;
        private string tensize;
        private string tenmau;
        private int soluong;
        private string ngay;
        private string gio;
        public DTO_ChiTietDVC()
        {

        }
        public DTO_ChiTietDVC(DataRow rows)
        {
            this.Madonnhap = (int)rows["MaDonNhap"];
            this.Tensp =  rows["tensp"].ToString();
            this.Manv =  rows["manv"].ToString();
            this.Tensize =  rows["tensize"].ToString();
            this.Tenmau =  rows["tenmau"].ToString();
            this.Soluong = (int)rows["soluong"];
            this.Ngay =  rows["ngay"].ToString();
            this.Gio =   rows["gio"].ToString();
        }
        public int Madonnhap { get => madonnhap; set => madonnhap = value; }
        public string Tensp { get => tensp; set => tensp = value; }
        public string Manv { get => manv; set => manv = value; }
        public string Tensize { get => tensize; set => tensize = value; }
        public string Tenmau { get => tenmau; set => tenmau = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public string Ngay { get => ngay; set => ngay = value; }
        public string Gio { get => gio; set => gio = value; }
    }
}
